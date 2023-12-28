namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a method either being written or loaded from the workspace.
    /// </summary>
    public interface IMethodRef
    {

        /// <summary>
        /// Gets the reference to the assembly that holds the method.
        /// </summary>
        IAssemblyRef Assembly { get; }

        /// <summary>
        /// Gets the reference to the type that holds the method.
        /// </summary>
        ITypeRef? ParentType { get; }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Attempts to resolve the reference into a definition.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        bool TryResolve(out IMethod? method);

    }

}
