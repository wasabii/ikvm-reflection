namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type modifier indicating the value is pinned into memory, and the garbage collector cannot
    /// change the location of a value at runtime.
    /// </summary>
    public class PinnedTypeSignature : TypeSpecificationSignature
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseType"></param>
        public PinnedTypeSignature(TypeSignature baseType) :
            base(baseType)
        {

        }

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitPinnedType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitPinnedType(this, state);

    }

}
