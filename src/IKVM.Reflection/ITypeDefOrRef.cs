namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type definition or reference that can be referenced by a TypeDefOrRef coded index.
    /// </summary>
    public interface ITypeDefOrRef
    {

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// Gets the namespace the type resides in.
        /// </summary>
        string? Namespace { get; }

        /// <summary>
        /// When this type is nested, gets the enclosing type.
        /// </summary>
        ITypeDefOrRef? DeclaringType { get; }

        /// <summary>
        /// Attempts to resolve the type definition.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryResolve(out TypeDef type);

        /// <summary>
        /// Accepts a visitation from a visitor.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TState"></typeparam>
        /// <param name="visitor"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        abstract TResult AcceptVisitor<TResult, TState>(ITypeDefVisitor<TResult, TState> visitor, TState state);

    }

}