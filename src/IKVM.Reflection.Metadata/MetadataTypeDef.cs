using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    internal sealed class MetadataTypeDef : MetadataTypeDefBase
    {

        readonly MetadataTypeDef? declaringType;
        readonly TypeDefinitionHandle handle;
        readonly System.Reflection.Metadata.TypeDefinition def;

        TypeSig? baseType;
        MetadataTypeGenericParameter[]? genericParameters;
        MetadataFieldDef[]? fields;
        MetadataMethod[]? methods;
        MetadataTypeDef[]? nestedTypes;
        MetadataProperty[]? properties;
        MetadataEvent[]? events;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="declaringType"></param>
        /// <param name="handle"></param>
        public MetadataTypeDef(MetadataModule module, MetadataTypeDef? declaringType, TypeDefinitionHandle handle) :
            base(module)
        {
            Debug.Assert(handle.IsNil == false);
            this.declaringType = declaringType;
            this.handle = handle;
            this.def = module.Reader.GetTypeDefinition(handle);
        }

        /// <inheritdoc />
        public override MetadataTypeDef? DeclaringType => declaringType;

        /// <inheritdoc />
        public override string Namespace => Module.Reader.GetString(def.Namespace);

        /// <inheritdoc />
        public override string Name => Module.Reader.GetString(def.Name);

        /// <inheritdoc />
        public override TypeAttributes Attributes => def.Attributes;

        /// <inheritdoc />
        public override IReadOnlyList<MetadataTypeGenericParameter> GenericParameters => LazyUtil.Get(ref genericParameters, LoadGenericParameters);

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
                l[i++] = new MetadataTypeGenericParameter(Module, this, h);

            return l;
        }

        /// <inheritdoc />
        public override TypeSig? BaseType => def.BaseType.IsNil == false ? LazyUtil.Get(ref baseType, () => Module.DecodeTypeSignature(def.BaseType, new MetadataGenericContext(this, null))) : null;

        /// <inheritdoc />
        public override IReadOnlyList<MetadataFieldDef> Fields => LazyUtil.Get(ref fields, LoadFields);

        /// <summary>
        /// Loads the fields of this type.
        /// </summary>
        /// <returns></returns>
        MetadataFieldDef[] LoadFields()
        {
            var f = def.GetFields();
            if (f.Count == 0)
                return Array.Empty<MetadataFieldDef>();

            var l = new MetadataFieldDef[f.Count];
            int i = 0;
            foreach (var h in f)
                l[i++] = Module.GetOrCreateField(h, this);

            return l;
        }

        /// <inheritdoc />
        public override IReadOnlyList<MetadataMethod> Methods => LazyUtil.Get(ref methods, LoadMethods);

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
                l[i++] = Module.GetOrCreateMethod(h, this);

            return l;
        }

        /// <inheritdoc />
        public override IReadOnlyList<MetadataProperty> Properties => LazyUtil.Get(ref properties, LoadProperties);

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
                l[i++] = new MetadataProperty(Module, this, h);

            return l;
        }

        /// <inheritdoc />
        public override IReadOnlyList<MetadataEvent> Events => LazyUtil.Get(ref events, LoadEvents);

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
                l[i++] = new MetadataEvent(Module, this, h);

            return l;
        }

        /// <inheritdoc />
        public override IReadOnlyList<MetadataTypeDef> NestedTypes => LazyUtil.Get(ref nestedTypes, LoadNestedTypes);

        /// <summary>
        /// Loads the nested types of this type.
        /// </summary>
        /// <returns></returns>
        MetadataTypeDef[] LoadNestedTypes()
        {
            var t = def.GetNestedTypes();
            if (t.Length == 0)
                return Array.Empty<MetadataTypeDef>();

            var l = new MetadataTypeDef[t.Length];
            int i = 0;
            foreach (var h in t)
                l[i++] = Module.GetOrCreateType(h, this);

            return l;
        }

    }

}