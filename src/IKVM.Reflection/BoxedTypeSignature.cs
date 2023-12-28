namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type modifier indicating a boxing of a value type.
    /// </summary>
    public class BoxedTypeSignature : TypeSpecificationSignature
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseType"></param>
        public BoxedTypeSignature(TypeSignature baseType) :
            base(baseType)
        {

        }

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitBoxedType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitBoxedType(this, state);

    }

}
