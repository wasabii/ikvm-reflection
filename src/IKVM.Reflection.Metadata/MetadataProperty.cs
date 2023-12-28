using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    [DebuggerDisplay(nameof(DisplayName))]
    internal class MetadataProperty : IProperty
    {

        readonly MetadataModule module;
        readonly MetadataType parentType;
        readonly PropertyDefinitionHandle handle;
        readonly PropertyDefinition def;

        MethodSignature? signature;
        Lazy<MetadataMethod?>? getMethod;
        Lazy<MetadataMethod?>? setMethod;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="declaringType"></param>
        /// <param name="handle"></param>
        public MetadataProperty(MetadataModule module, MetadataType declaringType, PropertyDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.parentType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            this.handle = handle;
            this.def = module.Reader.GetPropertyDefinition(handle);
        }

        /// <summary>
        /// Gets the parent module of this property.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets the parent module of this property.
        /// </summary>
        IModule IProperty.Module => Module;

        /// <summary>
        /// Gets the parent type of this property.
        /// </summary>
        public MetadataType ParentType => parentType;

        /// <summary>
        /// Gets the parent type of this property.
        /// </summary>
        IType IProperty.ParentType => ParentType;

        /// <summary>
        /// Gets the name of this property.
        /// </summary>
        public string Name => module.Reader.GetString(def.Name);

        /// <summary>
        /// Gets the display name of the property.
        /// </summary>
        public string DisplayName => MemberNameUtil.GetPropertyDisplayName(this);

        /// <summary>
        /// Gets the attributes of this property.
        /// </summary>
        public PropertyAttributes Attributes => def.Attributes;

        /// <summary>
        /// Gets the method signature of the property.
        /// </summary>
        public MethodSignature Signature => LazyUtil.Get(ref signature, () => module.DecodePropertySignature(handle, new MetadataGenericContext(ParentType, null)));

        /// <summary>
        /// Gets the type signature of this property.
        /// </summary>
        public TypeSignature PropertyType => Signature.ReturnType;

        /// <summary>
        /// Gets the parameter types of the property.
        /// </summary>
        public IReadOnlyList<TypeSignature> ParameterTypes => Signature.ParameterTypes;

        /// <summary>
        /// Gets the get method.
        /// </summary>
        public MetadataMethod? GetMethod => LazyUtil.Get(ref getMethod, () => new Lazy<MetadataMethod?>(() => module.GetOrCreateMethod(def.GetAccessors().Getter))).Value;

        /// <summary>
        /// Gets the get method.
        /// </summary>
        IMethod? IProperty.GetMethod => GetMethod;

        /// <summary>
        /// Gets the set method.
        /// </summary>
        public MetadataMethod? SetMethod => LazyUtil.Get(ref setMethod, () => new Lazy<MetadataMethod?>(() => module.GetOrCreateMethod(def.GetAccessors().Setter))).Value;

        /// <summary>
        /// Gets the set method.
        /// </summary>
        IMethod? IProperty.SetMethod => SetMethod;

        /// <inheritdoc />
        public override string ToString()
        {
            return DisplayName;
        }

    }

}