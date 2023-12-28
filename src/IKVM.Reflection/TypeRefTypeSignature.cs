using System;

namespace IKVM.Reflection
{

    public class TypeRefTypeSignature : TypeSignature
    {

        readonly ITypeRef type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public TypeRefTypeSignature(ITypeRef handle)
        {
            this.type = handle ?? throw new ArgumentNullException(nameof(handle));
        }

        /// <summary>
        /// Gets the underlying type reference.
        /// </summary>
        public ITypeRef Type => type;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitTypeRefType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitTypeRefType(this, state);

    }

}
