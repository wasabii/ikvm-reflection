namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type signature that describes an unmanaged pointer that addresses a chunk of data in memory.
    /// </summary>
    public class PointerTypeSignature : TypeSpecificationSignature
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseType"></param>
        public PointerTypeSignature(TypeSignature baseType) :
            base(baseType)
        {

        }

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitPointerType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitPointerType(this, state);

    }

}
