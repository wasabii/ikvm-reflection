namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a member that is either a method definition or a method reference, and can be referenced by a
    /// MethodDefOrRef coded index.
    /// </summary>
    public interface IMethodDefOrRef : IHasCustomAttributes, INameProvider
    {

        /// <summary>
        /// When this member is defined in a type, gets the enclosing type.
        /// </summary>
        ITypeDefOrRef? DeclaringType { get; }

        /// <summary>
        /// Gets the signature of the method.
        /// </summary>
        MethodSignature Signature { get; }

    }

}
