using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Metadata type representing the implicit '<Module>' type.
    /// </summary>
    internal class MetadataGlobalType : IType
    {

        readonly MetadataModule module;

        readonly ConcurrentDictionary<string, MetadataField?> fieldByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataMethod?> methodByNameMap = new();

        MetadataField[]? fields;
        MetadataMethod[]? methods;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataGlobalType(MetadataModule module)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
        }

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        public IAssembly Assembly => module.Assembly;

        /// <summary>
        /// Gets the module.
        /// </summary>
        public IModule Module => module;

        /// <summary>
        /// Gets the parent type.
        /// </summary>
        public IType? ParentType => null;

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        public string Namespace => "";

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name => "<Module>";

        /// <summary>
        /// Gets the full name.
        /// </summary>
        public string FullName => "<Module>";

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        public TypeAttributes Attributes => TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.NotPublic | TypeAttributes.SpecialName | TypeAttributes.RTSpecialName;

        /// <summary>
        /// Gets the generic parameters.
        /// </summary>
        public IReadOnlyList<IGenericParameter> GenericParameters => Array.Empty<IGenericParameter>();

        /// <summary>
        /// Gets the base type.
        /// </summary>
        public TypeSignature? BaseType => new TypeRefTypeSignature(module.GetOrCreatePrimitiveTypeRef(System.Reflection.Metadata.PrimitiveTypeCode.Object));

        /// <summary>
        /// Gets the global fields of the module.
        /// </summary>
        public IReadOnlyList<MetadataField> Fields => LazyUtil.Get(ref fields, LoadFields);

        /// <summary>
        /// Gets the global fields of the module.
        /// </summary>
        IReadOnlyList<IField> IType.Fields => Fields;

        /// <summary>
        /// Loads the global fields of the module.
        /// </summary>
        /// <returns></returns>
        MetadataField[] LoadFields() => module.Reader.FieldDefinitions.Where(i => module.Reader.GetFieldDefinition(i).GetDeclaringType().IsNil).Select(module.GetOrCreateField).ToArray();

        /// <summary>
        /// Attempts to locate a global field of the module.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool TryFindField(string name, out IField? field) => (field = fieldByNameMap.GetOrAdd(name, _ => Fields.FirstOrDefault(i => i.Name == _))) != null;

        /// <summary>
        /// Gets the global methods of the module.
        /// </summary>
        public IReadOnlyList<MetadataMethod> Methods => LazyUtil.Get(ref methods, LoadMethods);

        /// <summary>
        /// Gets the global methods of the module.
        /// </summary>
        IReadOnlyList<IMethod> IType.Methods => Methods;

        /// <summary>
        /// Loads the global methods of the module.
        /// </summary>
        /// <returns></returns>
        MetadataMethod[] LoadMethods() => module.Reader.MethodDefinitions.Where(i => module.Reader.GetMethodDefinition(i).GetDeclaringType().IsNil).Select(module.GetOrCreateMethod).ToArray();

        /// <summary>
        /// Attempts to locate a global method of the module.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public bool TryFindMethod(string name, out IMethod? method) => (method = methodByNameMap.GetOrAdd(name, _ => Methods.FirstOrDefault(i => i.Name == _))) != null;

        public IReadOnlyList<IType> NestedTypes => Array.Empty<IType>();

        public bool TryFindNestedType(string name, out IType? type)
        {
            type = null;
            return false;
        }

        public IReadOnlyList<IProperty> Properties => Array.Empty<IProperty>();

        public bool TryFindProperty(string name, out IProperty? property)
        {
            property = null;
            return false;
        }

        public IReadOnlyList<IEvent> Events => Array.Empty<IEvent>();

        public bool TryFindEvent(string name, out IEvent? evt)
        {
            evt = null;
            return false;
        }

    }

}
