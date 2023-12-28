namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a field either being written or loaded from the context.
    /// </summary>
    public interface IFieldRef
    {

        /// <summary>
        /// Gets a reference to the type that holds the field.
        /// </summary>
        TypeSignature? ParentType { get; }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Attempts to resolve the reference into a definition.
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        bool TryResolve(out IField? def);

    }

}
