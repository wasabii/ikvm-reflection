namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a method either being written or loaded from the workspace.
    /// </summary>
    public abstract class MethodRef
    {

        /// <summary>
        /// Gets the reference to the type that holds the method.
        /// </summary>
        public abstract ITypeDefOrRef? DeclaringType { get; }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Attempts to resolve the reference into a definition.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public abstract bool TryResolve(out MethodDef? method);

    }

}
