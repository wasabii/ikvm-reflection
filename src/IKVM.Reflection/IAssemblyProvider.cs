namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a member definition or reference that resides in a .NET assembly.
    /// </summary>
    public interface IAssemblyProvider
    {

        /// <summary>
        /// Gets the assembly that defines the member definition or reference.
        /// </summary>
        /// <remarks>
        /// For member references, this does not obtain the assembly definition that the member is defined in. 
        /// Rather, it obtains the assembly definition that references this reference.
        /// </remarks>
        AssemblyDef Assembly { get; }

    }

}