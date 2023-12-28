using System.Collections.Generic;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a generic parameter.
    /// </summary>
    public interface IGenericParameter
    {

        /// <summary>
        /// Gets the name of this parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the attributes of this parameter.
        /// </summary>
        GenericParameterAttributes Attributes { get; }

        /// <summary>
        /// Gets the constraints of this generic parameter.
        /// </summary>
        IReadOnlyList<IGenericParameterConstraint> Constraints { get; }

    }

}
