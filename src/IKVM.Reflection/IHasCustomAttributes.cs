using System.Collections.Generic;
namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a member that can be referenced by a HasCustomAttribute coded index,
    /// </summary>
    public interface IHasCustomAttributes
    {

        /// <summary>
        /// Gets a collection of custom attributes assigned to this member.
        /// </summary>
        IReadOnlyList<CustomAttribute> CustomAttributes { get; }

    }

}
