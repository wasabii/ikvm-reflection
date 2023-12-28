namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a sentinel type signature to be used in a method signature, indicating the start of any vararg
    /// argument types.
    /// </summary>
    /// <remarks>
    /// This type signature should not be used directly.
    /// </remarks>
    public class SentinelTypeSignature : TypeSignature
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public SentinelTypeSignature()
        {

        }

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitSentinelType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitSentinelType(this, state);

    }

}
