using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    [DebuggerDisplay(nameof(FullName))]
    internal class MetadataType : IType
    {

        readonly MetadataModule module;
        readonly MetadataType? declaringType;
        readonly TypeDefinitionHandle handle;
        readonly TypeDefinition def;

        TypeSignature? baseType;
        MetadataTypeGenericParameter[]? genericParameters;
        MetadataField[]? fields;
        MetadataMethod[]? methods;
        MetadataType[]? nestedTypes;
        MetadataProperty[]? properties;
        MetadataEvent[]? events;

        readonly ConcurrentDictionary<string, MetadataField?> fieldByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataMethod?> methodByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataType?> nestedTypeByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataProperty?> propertyByNameMap = new();
        readonly ConcurrentDictionary<string, MetadataEvent?> eventByNameMap = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="declaringType"></param>
        /// <param name="handle"></param>
        public MetadataType(MetadataModule module, MetadataType? declaringType, TypeDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.declaringType = declaringType;
            this.handle = handle;
            this.def = module.Reader.GetTypeDefinition(handle);
        }

        /// <summary>
        /// Gets the assembly of this  type.
        /// </summary>
        public MetadataAssembly Assembly => module.Assembly;

        /// <summary>
        /// Gets the assembly of this  type.
        /// </summary>
        IAssembly IType.Assembly => Assembly;

        /// <summary>
        /// Gets the module of this  type.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets the module of this type.
        /// </summary>
        IModule IType.Module => Module;

        /// <summary>
        /// Gets the parent type of this type.
        /// </summary>
        public MetadataType? DeclaringType => declaringType;

        /// <summary>
        /// Gets the parent type of this type.
        /// </summary>
        IType? IType.ParentType => DeclaringType;

        /// <summary>
        /// Gets the namespace of this type.
        /// </summary>
        public string Namespace => module.Reader.GetString(def.Namespace);

        /// <summary>
        /// Gets the name of this type.
        /// </summary>
        public string Name => module.Reader.GetString(def.Name);

        /// <summary>
        /// Gets the display name of this type.
        /// </summary>
        public string FullName => TypeNameUtil.GetTypeFullName(this);

        /// <summary>
        /// Gets the attributes of this type.
        /// </summary>
        public TypeAttributes Attributes => def.Attributes;

        /// <summary>
        /// Gets the generic type parameters of this type.
        /// </summary>
        public IReadOnlyList<IGenericParameter> GenericParameters => LazyUtil.Get(ref genericParameters, LoadGenericParameters);

        /// <summary>
        /// Loads the generic type parameters of this type.
        /// </summary>
        /// <returns></returns>
        MetadataTypeGenericParameter[] LoadGenericParameters()
        {
            var p = def.GetGenericParameters();
            if (p.Count == 0)
                return Array.Empty<MetadataTypeGenericParameter>();

            var l = new MetadataTypeGenericParameter[p.Count];
            int i = 0;
            foreach (var h in p)
                l[i++] = new MetadataTypeGenericParameter(module, this, h);

            return l;
        }

        /// <summary>
        /// Gets the signature of the base type.
        /// </summary>
        public TypeSignature? BaseType => def.BaseType.IsNil == false ? LazyUtil.Get(ref baseType, () => module.DecodeTypeSignature(def.BaseType, new MetadataGenericContext(this, null))) : null;

        /// <summary>
        /// Gets the fields of the type.
        /// </summary>
        public IReadOnlyList<MetadataField> Fields => LazyUtil.Get(ref fields, LoadFields);

        /// <summary>
        /// Gets the fields of this type.
        /// </summary>
        IReadOnlyList<IField> IType.Fields => Fields;

        /// <summary>
        /// Loads the fields of this  type.
        /// </summary>
        /// <returns></returns>
        MetadataField[] LoadFields()
        {
            var f = def.GetFields();
            if (f.Count == 0)
                return Array.Empty<MetadataField>();

            var l = new MetadataField[f.Count];
            int i = 0;
            foreach (var h in f)
                l[i++] = module.GetOrCreateField(h, this);

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
            return (field = fieldByNameMap.GetOrAdd(name, _ => Fields.FirstOrDefault(i => i.Name == _))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified method by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        bool IType.TryFindField(string name, out IField? field)
        {
            var r = TryFindField(name, out var f);
            field = f;
            return r;
        }

        /// <summary>
        /// Gets the methods of the type.
        /// </summary>
        public IReadOnlyList<MetadataMethod> Methods => LazyUtil.Get(ref methods, LoadMethods);

        IReadOnlyList<IMethod> IType.Methods => Methods;

        /// <summary>
        /// Loads the methods of the type.
        /// </summary>
        /// <returns></returns>
        MetadataMethod[] LoadMethods()
        {
            var m = def.GetMethods();
            if (m.Count == 0)
                return Array.Empty<MetadataMethod>();

            var l = new MetadataMethod[m.Count];
            int i = 0;
            foreach (var h in m)
                l[i++] = module.GetOrCreateMethod(h, this);

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
            return (method = methodByNameMap.GetOrAdd(name, _ => Methods.FirstOrDefault(i => i.Name == _))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified method by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        bool IType.TryFindMethod(string name, out IMethod? method)
        {
            var r = TryFindMethod(name, out var m);
            method = m;
            return r;
        }

        /// <summary>
        /// Gets the nested types of this type.
        /// </summary>
        public IReadOnlyList<MetadataType> NestedTypes => LazyUtil.Get(ref nestedTypes, LoadNestedTypes);

        /// <summary>
        /// Gets the nested types of this type.
        /// </summary>
        IReadOnlyList<IType> IType.NestedTypes => NestedTypes;

        /// <summary>
        /// Loads the nested types of this type.
        /// </summary>
        /// <returns></returns>
        MetadataType[] LoadNestedTypes()
        {
            var t = def.GetNestedTypes();
            if (t.Length == 0)
                return Array.Empty<MetadataType>();

            var l = new MetadataType[t.Length];
            int i = 0;
            foreach (var h in t)
                l[i++] = module.GetOrCreateType(h, this);

            return l;
        }

        /// <summary>
        /// Attempts to resolve the specified type by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal bool TryFindNestedType(string name, out MetadataType? type)
        {
            return (type = nestedTypeByNameMap.GetOrAdd(name, _ => NestedTypes.FirstOrDefault(i => i.Name == _))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified type by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IType.TryFindNestedType(string name, out IType? type)
        {
            var r = TryFindNestedType(name, out var t);
            type = t;
            return r;
        }

        /// <summary>
        /// Gets the properties of this type.
        /// </summary>
        public IReadOnlyList<MetadataProperty> Properties => LazyUtil.Get(ref properties, LoadProperties);

        /// <summary>
        /// Gets the properties of this type.
        /// </summary>
        IReadOnlyList<IProperty> IType.Properties => Properties;

        /// <summary>
        /// Loads the properties of this type.
        /// </summary>
        /// <returns></returns>
        MetadataProperty[] LoadProperties()
        {
            var p = def.GetProperties();
            if (p.Count == 0)
                return Array.Empty<MetadataProperty>();

            var l = new MetadataProperty[p.Count];
            int i = 0;
            foreach (var h in p)
                l[i++] = new MetadataProperty(module, this, h);

            return l;
        }

        /// <summary>
        /// Attempts to resolve the specified property by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal bool TryFindProperty(string name, out MetadataProperty? type)
        {
            return (type = propertyByNameMap.GetOrAdd(name, _ => Properties.FirstOrDefault(i => i.Name == _))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified property by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IType.TryFindProperty(string name, out IProperty? type)
        {
            var r = TryFindProperty(name, out var t);
            type = t;
            return r;
        }

        /// <summary>
        /// Gets the events of this type.
        /// </summary>
        public IReadOnlyList<MetadataEvent> Events => LazyUtil.Get(ref events, LoadEvents);

        /// <summary>
        /// Gets the events of this type.
        /// </summary>
        IReadOnlyList<IEvent> IType.Events => Events;

        /// <summary>
        /// Loads the events of this type.
        /// </summary>
        /// <returns></returns>
        MetadataEvent[] LoadEvents()
        {
            var p = def.GetEvents();
            if (p.Count == 0)
                return Array.Empty<MetadataEvent>();

            var l = new MetadataEvent[p.Count];
            int i = 0;
            foreach (var h in p)
                l[i++] = new MetadataEvent(module, this, h);

            return l;
        }

        /// <summary>
        /// Attempts to resolve the specified event by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal bool TryFindEvent(string name, out MetadataEvent? type)
        {
            return (type = eventByNameMap.GetOrAdd(name, _ => Events.FirstOrDefault(i => i.Name == _))) != null;
        }

        /// <summary>
        /// Attempts to resolve the specified event by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IType.TryFindEvent(string name, out IEvent? type)
        {
            var r = TryFindEvent(name, out var t);
            type = t;
            return r;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return FullName;
        }

    }

}