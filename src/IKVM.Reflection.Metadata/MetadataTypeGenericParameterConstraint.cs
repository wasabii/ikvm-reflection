using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Describes a constraint on a generic parameter.
    /// </summary>
    internal class MetadataTypeGenericParameterConstraint : GenericParameterConstraint
    {

        readonly MetadataModule module;
        readonly MetadataTypeDef type;
        readonly System.Reflection.Metadata.GenericParameterConstraint def;

        TypeSig? constraint;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="type"></param>
        /// <param name="handle"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public MetadataTypeGenericParameterConstraint(MetadataModule module, MetadataTypeDef type, GenericParameterConstraintHandle handle)
        {
            this.module = module ?? throw new System.ArgumentNullException(nameof(module));
            this.type = type ?? throw new System.ArgumentNullException(nameof(type));
            this.def = module.Reader.GetGenericParameterConstraint(handle);
        }

        /// <summary>
        /// Gets the type to which this parameter is constrained.
        /// </summary>
        public TypeSig Constraint => LazyUtil.Get(ref constraint, () => module.DecodeTypeSignature(def.Type, new MetadataGenericContext(type, null)));

    }

}