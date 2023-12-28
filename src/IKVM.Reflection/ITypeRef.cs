namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a type either being written or loaded from the context.
    /// </summary>
    public interface ITypeRef
    {

        /// <summary>
        /// Gets a reference to the assembly that declares this type.
        /// </summary>
        IAssemblyRef Assembly { get; }

        /// <summary>
        /// Gets the parent type of this type.
        /// </summary>
        ITypeRef? ParentType { get; }

        /// <summary>
        /// Gets the namespace of the type.
        /// </summary>
        string? Namespace { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the display name of the type.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Attempts to resolve the reference into a definition.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryResolve(out IType? type);

    }

}
