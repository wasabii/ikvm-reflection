namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type signature that describes a type that is passed on by reference.
    /// </summary>
    public class ByRefTypeSignature : TypeSpecificationSignature
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseType"></param>
        public ByRefTypeSignature(TypeSignature baseType)
            : base(baseType)
        {

        }

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitByRefType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitByReferenceType(this, state);

    }

}
