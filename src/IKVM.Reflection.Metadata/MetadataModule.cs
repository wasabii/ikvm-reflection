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
    internal sealed class MetadataModule : ModuleDef, IDisposable
    {

        readonly MetadataAssembly assembly;
        readonly PEReader pe;
        readonly MetadataReader reader;
        readonly string location;
        readonly System.Reflection.Metadata.ModuleDefinition def;

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

        MetadataTypeDef[]? types;

        readonly ConcurrentDictionary<AssemblyReferenceHandle, MetadataAssemblyRef> assemblyRefByHandleMap = new();
        readonly ConcurrentDictionary<TypeReferenceHandle, MetadataTypeRef> typeRefByHandleMap = new();
        readonly ConcurrentDictionary<MemberReferenceHandle, MetadataFieldRef> fieldRefByHandleMap = new();
        readonly ConcurrentDictionary<MemberReferenceHandle, MetadataMethodRef> methodRefByHandleMap = new();

        readonly ConcurrentDictionary<TypeDefinitionHandle, MetadataTypeDef> typeByHandleMap = new();
        readonly ConcurrentDictionary<FieldDefinitionHandle, MetadataFieldDef> fieldByHandleMap = new();
        readonly ConcurrentDictionary<MethodDefinitionHandle, MetadataMethod> methodByHandleMap = new();

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
            def = reader.GetModuleDefinition();

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
        public override MetadataAssembly Assembly => assembly;

        /// <summary>
        /// Gets the metadata reader responsible for this module.
        /// </summary>
        public MetadataReader Reader => reader;

        /// <summary>
        /// Gets the location of this module.
        /// </summary>
        public override string Location => location;

        /// <inheritdoc />
        public override string Name => reader.GetString(def.Name);

        /// <inheritdoc />
        public override Guid Mvid => reader.GetGuid(def.Mvid);

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        public override IReadOnlyList<MetadataTypeDef> Types => LazyUtil.Get(ref types, LoadTypes);

        /// <summary>
        /// Loads the types of the assembly.
        /// </summary>
        /// <returns></returns>
        MetadataTypeDef[] LoadTypes()
        {
            var l = new MetadataTypeDef[reader.TypeDefinitions.Count];

            int i = 0;
            foreach (var h in reader.TypeDefinitions)
                l[i++] = GetOrCreateType(h);

            return l;
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
        internal MetadataTypeDef GetOrCreateType(TypeDefinitionHandle handle, MetadataTypeDef? declaringType)
        {
            Debug.Assert(handle.IsNil == false);

            return typeByHandleMap.GetOrAdd(handle, _ => new MetadataTypeDef(this, declaringType, _));
        }

        /// <summary>
        /// Creates a new type instance that resides in this module, detecting the declaring type.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataTypeDef GetOrCreateType(TypeDefinitionHandle handle)
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
        internal MetadataFieldDef GetOrCreateField(FieldDefinitionHandle handle, MetadataTypeDef declaringType)
        {
            Debug.Assert(handle.IsNil == false);

            return fieldByHandleMap.GetOrAdd(handle, _ => new MetadataFieldDef(this, declaringType, _));
        }

        /// <summary>
        /// Creates a new field instance that resides in this module, detecting the declaring type.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        internal MetadataFieldDef GetOrCreateField(FieldDefinitionHandle handle)
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
        /// <param name="declaringType"></param>
        /// <returns></returns>
        internal MetadataMethod GetOrCreateMethod(MethodDefinitionHandle handle, MetadataTypeDef declaringType)
        {
            Debug.Assert(handle.IsNil == false);

            return methodByHandleMap.GetOrAdd(handle, _ => new MetadataMethod(this, declaringType, _));
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
            return GetOrCreateMethod(handle, GetOrCreateType(t));
        }

        /// <summary>
        /// Decodes a handle into a <see cref="TypeSig"/>.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        internal TypeSig DecodeTypeSignature(EntityHandle handle, MetadataGenericContext context)
        {
            Debug.Assert(handle.IsNil == false);

            return handle.Kind switch
            {
                HandleKind.TypeDefinition => new TypeDefTypeSignature(GetOrCreateType((TypeDefinitionHandle)handle)),
                HandleKind.TypeReference => new TypeDefOrRefSignature(GetOrCreateTypeRef((TypeReferenceHandle)handle)),
                HandleKind.TypeSpecification => Reader.GetTypeSpecification((TypeSpecificationHandle)handle).DecodeSignature(new MetadataSignatureTypeProvider(this), context),
                _ => throw new BadImageFormatException("Entity must be a TypeDef, TypeRef or TypeSpec."),
            };
        }

        /// <summary>
        /// Decodes a handle into a <see cref="TypeSig"/>.
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
        /// Decodes a handle into a <see cref="TypeSig"/>.
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
        internal MethodSignature GetMethodSignature(MethodSignature<TypeSig> signature)
        {
            return new MethodSig(GetCallingConventionAttributes(signature.Header.CallingConvention), signature.GenericParameterCount, signature.ReturnType, signature.ParameterTypes.ToArray());
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
