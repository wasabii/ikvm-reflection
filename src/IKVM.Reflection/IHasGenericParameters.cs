using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a member that can be referenced by a TypeOrMethod coded index, and exposes generic parameters.
    /// </summary>
    public interface IHasGenericParameters : IMetadataMember, IMemberDescriptor
    {

        /// <summary>
        /// Gets a collection of generic parameters this member defines.
        /// </summary>
        IReadOnlyList<GenericParameter> GenericParameters { get; }

    }

}