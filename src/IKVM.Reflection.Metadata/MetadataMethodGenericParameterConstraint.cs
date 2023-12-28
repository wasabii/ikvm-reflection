using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Describes a constraint on a generic parameter.
    /// </summary>
    internal class MetadataMethodGenericParameterConstraint : IGenericParameterConstraint
    {

        readonly MetadataModule module;
        readonly MetadataMethod method;
        readonly GenericParameterConstraint def;

        TypeSignature? constraint;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="method"></param>
        /// <param name="handle"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public MetadataMethodGenericParameterConstraint(MetadataModule module, MetadataMethod method, GenericParameterConstraintHandle handle)
        {
            this.module = module ?? throw new System.ArgumentNullException(nameof(module));
            this.method = method ?? throw new System.ArgumentNullException(nameof(method));
            this.def = module.Reader.GetGenericParameterConstraint(handle);
        }

        /// <summary>
        /// Gets the type to which this parameter is constrained.
        /// </summary>
        public TypeSignature Constraint => LazyUtil.Get(ref constraint, () => module.DecodeTypeSignature(def.Type, new MetadataGenericContext(method.ParentType, method)));

    }

}