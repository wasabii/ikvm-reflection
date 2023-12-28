using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Represents a module definition loaded from metadata.
    /// </summary>
    internal class MetadataModule : IModule, IDisposable
    {

        readonly MetadataAssembly assembly;
        readonly PEReader pe;
        readonly MetadataReader reader;
        readonly string location;
        readonly ModuleDefinition def;

        readonly MetadataGlobalType globalType;

        readonly MetadataPrimitiveTypeRef _VoidTypeRef;
        readonly MetadataPrimitiveTypeRef _BooleanTypeRef;
        readonly MetadataPrimitiveTypeRef _CharTypeRef;
        readonly MetadataPrimitiveTypeRef _SByteTypeRef;
        readonly MetadataPrimitiveTypeRef _ByteTypeRef;
        readonly MetadataPrimitiveTypeRef _Int16TypeRef;
        readonly MetadataPrimitiveTypeRef _UInt16TypeRef;
        readonly MetadataPrimitiveTypeRef _Int32TypeRef;
        readonly MetadataPrimitiveTypeRef _UInt32TypeRef;
        readonly MetadataPrimitiveTypeRef _Int64TypeRef;
        readonly MetadataPrimitiveTypeRef _UInt64TypeRef;
        readonly MetadataPrimitiveTypeRef _SingleTypeRef;
        readonly MetadataPrimitiveTypeRef _DoubleTypeRef;
        readonly MetadataPrimitiveTypeRef _StringTypeRef;
        readonly MetadataPrimitiveTypeRef _TypedReferenceTypeRef;
        readonly MetadataPrimitiveTypeRef _IntPtrTypeRef;
        readonly MetadataPrimitiveTypeRef _UIntPtrTypeRef;
        readonly MetadataPrimitiveTypeRef _ObjectTypeRef;

        MetadataType[]? types;
        MetadataField[]? fields;
        MetadataMethod[]? methods;

        readonly ConcurrentDictionary<AssemblyReferenceHandle, MetadataAssemblyRef> assemblyRefByHandleMap = new();
        readonly ConcurrentDictionary<ModuleReferenceHandle, MetadataModuleRef> moduleRefByHandleMap = new();
        readonly ConcurrentDictionary<TypeReferenceHandle, MetadataTypeRef> typeRefByHandleMap = new();
        readonly ConcurrentDictionary<MemberReferenceHandle, MetadataFieldRef> fieldRefByHandleMap = new();
        readonly ConcurrentDictionary<MemberReferenceHandle, MetadataMethodRef> methodRefByHandleMap = new();

        readonly ConcurrentDictionary<TypeDefinitionHandle, MetadataType> typeByHandleMap = new();
        readonly ConcurrentDictionary<FieldDefinitionHandle, MetadataField> fieldByHandleMap = new();
        readonly ConcurrentDictionary<MethodDefinitionHandle, MetadataMethod> methodByHandleMap = new();

        readonly ConcurrentDictionary<(string, string), MetadataType?> typeByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataField?> fieldByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataMethod?> methodByNameMap = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="pe"></param>
        /// <param name="reader"></param>
        /// <param name="location"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataModule(MetadataAssembly assembly, PEReader pe, MetadataReader reader, string location)
        {
            this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            this.pe = pe ?? throw new ArgumentNullException(nameof(pe));
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
            this.location = location ?? throw new ArgumentNullException(nameof(location));

            // initialize module
            def = reader.GetModuleDefinition();
            globalType = new MetadataGlobalType(this);

            // cache primitive types
            _VoidTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Void);
            _BooleanTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Boolean);
            _CharTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Char);
            _SByteTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.SByte);
            _ByteTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Byte);
            _Int16TypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Int16);
            _UInt16TypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.UInt16);
            _Int32TypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Int32);
            _UInt32TypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.UInt32);
            _Int64TypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Int64);
            _UInt64TypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.UInt64);
            _SingleTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Single);
            _DoubleTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Double);
            _StringTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.String);
            _TypedReferenceTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.TypedReference);
            _IntPtrTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.IntPtr);
            _UIntPtrTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.UIntPtr);
            _ObjectTypeRef = new MetadataPrimitiveTypeRef(this, PrimitiveTypeCode.Object);
        }

        /// <inheritdoc />
        public MetadataAssembly Assembly => assembly;

        /// <summary>
        /// Gets the assembly of the module.
        /// </summary>
        IAssembly IModule.Assembly => Assembly;

        /// <summary>
        /// Gets the metadata reader responsible for this module.
        /// </summary>
        public MetadataReader Reader => reader;

        /// <summary>
        /// Gets the location of this module.
        /// </summary>
        public string Location => location;

        /// <inheritdoc />
        public string Name => reader.GetString(def.Name);

        /// <inheritdoc />
        public Guid Mvid => reader.GetGuid(def.Mvid);

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        internal MetadataType[] Types => LazyUtil.Get(ref types, LoadTypes);

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        IReadOnlyList<IType> IModule.Types => Types;

        /// <summary>
        /// Loads the types of the assembly.
        /// </summary>
        /// <returns></returns>
        MetadataType[] LoadTypes()
        {
            var l = new MetadataType[reader.TypeDefinitions.Count];

            int i = 0;
            foreach (var h in reader.TypeDefinitions)
                l[i++] = GetOrCreateType(h);

            return l;
        }

        /// <summary>
        /// Attempts to resolve the specified type by name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal bool TryFindType(string namespaceName, string name, out MetadataType? type) => (type = typeByNameMap.GetOrAdd((namespaceName, name), _ => Types.FirstOrDefault(i => _.Item1 == namespaceName && i.Name == _.Item2))) != null;

        /// <summary>
        /// Attempts to resolve the specified type by name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IModule.TryFindType(string namespaceName, string name, out IType? type)
        {
            var r = TryFindType(namespaceName, name, out var t);
            type = t;
            return r;
        }

        /// <summary>
        /// Gets the methods of the module.
        /// </summary>
        internal MetadataMethod[] Methods => LazyUtil.Get(ref methods, LoadMethods);

        /// <summary>
        /// Gets the methods of the module.
        /// </summary>
        IReadOnlyList<IMethod> IModule.Methods => Methods;

        /// <summary>
        /// Loads the methods of the module.
        /// </summary>
        /// <returns></returns>
        MetadataMethod[] LoadMethods()
        {
            var l = new MetadataMethod[reader.MethodDefinitions.Count];

            int i = 0;
            foreach (var h in reader.MethodDefinitions)
                l[i++] = GetOrCreateMethod(h);

            return l;
        }

        /// <summary>
        /// Attempts to resolve the specified method by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        internal bool TryFindMethod(string name, out MetadataMethod? method)
        {
            return (method = methodByNameMap.GetOrAdd((name), _ => Methods.FirstOrDefault(i => _ == i.Name))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified method by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        bool IModule.TryFindMethod(string name, out IMethod? method)
        {
            var r = TryFindMethod(name, out var t);
            method = t;
            return r;
        }

        /// <summary>
        /// Gets the fields of the module.
        /// </summary>
        internal MetadataField[] Fields => LazyUtil.Get(ref fields, LoadFields);

        /// <summary>
        /// Gets the fields of the module.
        /// </summary>
        IReadOnlyList<IField> IModule.Fields => Fields;

        /// <summary>
        /// Loads the fields of the module.
        /// </summary>
        /// <returns></returns>
        MetadataField[] LoadFields()
        {
            var l = new MetadataField[reader.FieldDefinitions.Count];

            int i = 0;
            foreach (var h in reader.FieldDefinitions)
                l[i++] = GetOrCreateField(h);

            return l;
        }

        /// <summary>
        /// Attempts to resolve the specified field by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        internal bool TryFindField(string name, out MetadataField? field)
        {
            return (field = fieldByNameMap.GetOrAdd(name, _ => Fields.FirstOrDefault(i => _ == i.Name))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified field by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        bool IModule.TryFindField(string name, out IField? field)
        {
            var r = TryFindField(name, out var t);
            field = t;
            return r;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            pe.Dispose();
        }

        /// <summary>
        /// Creates a new assembly reference instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataAssemblyRef GetOrCreateAssemblyRef(AssemblyReferenceHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            return assemblyRefByHandleMap.GetOrAdd(handle, _ => new MetadataAssemblyRef(this, _));
        }

        /// <summary>
        /// Creates a new module reference instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataModuleRef GetOrCreateModuleRef(ModuleReferenceHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            return moduleRefByHandleMap.GetOrAdd(handle, _ => new MetadataModuleRef(this, _));
        }

        /// <summary>
        /// Creates a new type reference instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataTypeRef GetOrCreateTypeRef(TypeReferenceHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            return typeRefByHandleMap.GetOrAdd(handle, _ => new MetadataTypeRef(this, _));
        }

        /// <summary>
        /// Gets the primitive type reference associated with this module for the given type code.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        internal ITypeRef GetOrCreatePrimitiveTypeRef(System.Reflection.Metadata.PrimitiveTypeCode typeCode) => typeCode switch
        {
            System.Reflection.Metadata.PrimitiveTypeCode.Void => _VoidTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Boolean => _BooleanTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Char => _CharTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.SByte => _SByteTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Byte => _ByteTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Int16 => _Int16TypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.UInt16 => _UInt16TypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Int32 => _Int32TypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.UInt32 => _UInt32TypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Int64 => _Int64TypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.UInt64 => _UInt64TypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Single => _SingleTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Double => _DoubleTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.String => _StringTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.TypedReference => _TypedReferenceTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.IntPtr => _IntPtrTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.UIntPtr => _UIntPtrTypeRef,
            System.Reflection.Metadata.PrimitiveTypeCode.Object => _ObjectTypeRef,
            _ => throw new InvalidOperationException(),
        };

        /// <summary>
        /// Creates a new field reference instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataFieldRef GetOrCreateFieldRef(MemberReferenceHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            return fieldRefByHandleMap.GetOrAdd(handle, _ => new MetadataFieldRef(this, _));
        }

        /// <summary>
        /// Creates a new method ref instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataMethodRef GetOrCreateMethodRef(MemberReferenceHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            return methodRefByHandleMap.GetOrAdd(handle, _ => new MetadataMethodRef(this, _));
        }

        /// <summary>
        /// Creates a new type instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="declaringType"></param>
        /// <returns></returns>
        internal MetadataType GetOrCreateType(TypeDefinitionHandle handle, MetadataType? declaringType)
        {
            Debug.Assert(handle.IsNil == false);

            return typeByHandleMap.GetOrAdd(handle, _ => new MetadataType(this, declaringType, _));
        }

        /// <summary>
        /// Creates a new type instance that resides in this module, detecting the declaring type.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataType GetOrCreateType(TypeDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            var d = reader.GetTypeDefinition(handle);
            var p = d.GetDeclaringType();
            return GetOrCreateType(handle, p.IsNil ? null : GetOrCreateType(p));
        }

        /// <summary>
        /// Creates a new field instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="declaringType"></param>
        /// <returns></returns>
        internal MetadataField GetOrCreateField(FieldDefinitionHandle handle, MetadataType declaringType)
        {
            Debug.Assert(handle.IsNil == false);

            return fieldByHandleMap.GetOrAdd(handle, _ => new MetadataField(this, declaringType, _));
        }

        /// <summary>
        /// Creates a new field instance that resides in this module, detecting the declaring type.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataField GetOrCreateField(FieldDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            var d = reader.GetFieldDefinition(handle);
            var p = d.GetDeclaringType();
            return GetOrCreateField(handle, p.IsNil ? throw new BadImageFormatException("Missing DeclaringType on FieldDef.") : GetOrCreateType(p));
        }

        /// <summary>
        /// Creates a new method instance that resides in this module.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="parentType"></param>
        /// <returns></returns>
        internal MetadataMethod GetOrCreateMethod(MethodDefinitionHandle handle, MetadataType? parentType)
        {
            Debug.Assert(handle.IsNil == false);

            return methodByHandleMap.GetOrAdd(handle, _ => new MetadataMethod(this, parentType, _));
        }

        /// <summary>
        /// Creates a new method instance that resides in this module, detecting the declaring type.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataMethod GetOrCreateMethod(MethodDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            var d = reader.GetMethodDefinition(handle);
            var t = d.GetDeclaringType();
            return GetOrCreateMethod(handle, t.IsNil ? null : GetOrCreateType(t));
        }

        /// <summary>
        /// Decodes a handle into a <see cref="TypeSignature"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        internal TypeSignature DecodeTypeSignature(EntityHandle handle, MetadataGenericContext context)
        {
            Debug.Assert(handle.IsNil == false);

            return handle.Kind switch
            {
                HandleKind.TypeDefinition => new TypeDefTypeSignature(GetOrCreateType((TypeDefinitionHandle)handle)),
                HandleKind.TypeReference => new TypeRefTypeSignature(GetOrCreateTypeRef((TypeReferenceHandle)handle)),
                HandleKind.TypeSpecification => Reader.GetTypeSpecification((TypeSpecificationHandle)handle).DecodeSignature(new MetadataSignatureTypeProvider(this), context),
                _ => throw new BadImageFormatException("Entity must be a TypeDef, TypeRef or TypeSpec."),
            };
        }

        /// <summary>
        /// Decodes a handle into a <see cref="TypeSignature"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        internal MethodSignature DecodeMethodSignature(MethodDefinitionHandle handle, MetadataGenericContext context)
        {
            Debug.Assert(handle.IsNil == false);

            var d = reader.GetMethodDefinition(handle);
            var s = d.DecodeSignature(new MetadataSignatureTypeProvider(this), context);
            var m = GetMethodSignature(s);
            return m;
        }

        /// <summary>
        /// Decodes a handle into a <see cref="TypeSignature"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        internal MethodSignature DecodePropertySignature(PropertyDefinitionHandle handle, MetadataGenericContext context)
        {
            Debug.Assert(handle.IsNil == false);

            var d = reader.GetPropertyDefinition(handle);
            var s = d.DecodeSignature(new MetadataSignatureTypeProvider(this), context);
            var m = GetMethodSignature(s);
            return m;
        }

        /// <summary>
        /// Gets a <see cref="MethodSignature"/> for a <see cref="MethodSignature{TypeSignature}"/>.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        internal MethodSignature GetMethodSignature(MethodSignature<TypeSignature> signature)
        {
            return new MethodSignature(GetCallingConventionAttributes(signature.Header.CallingConvention), signature.GenericParameterCount, signature.ReturnType, signature.ParameterTypes.ToArray());
        }

        /// <summary>
        /// Converts a metadata <see cref="SignatureCallingConvention"/> value to a <see cref="CallingConventionAttributes"/> value.
        /// </summary>
        /// <param name="callingConvention"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        CallingConventionAttributes GetCallingConventionAttributes(SignatureCallingConvention callingConvention) => callingConvention switch
        {
            SignatureCallingConvention.Default => CallingConventionAttributes.Default,
            SignatureCallingConvention.CDecl => CallingConventionAttributes.CDecl,
            SignatureCallingConvention.StdCall => CallingConventionAttributes.StdCall,
            SignatureCallingConvention.ThisCall => CallingConventionAttributes.ThisCall,
            SignatureCallingConvention.FastCall => CallingConventionAttributes.FastCall,
            SignatureCallingConvention.VarArgs => CallingConventionAttributes.VarArgs,
            SignatureCallingConvention.Unmanaged => CallingConventionAttributes.Unmanaged,
            _ => throw new NotImplementedException(),
        };

    }

}
