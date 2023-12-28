using System;

namespace IKVM.Reflection
{

    public class TypeDefTypeSignature : TypeSignature
    {

        readonly IType type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public TypeDefTypeSignature(IType handle)
        {
            this.type = handle ?? throw new ArgumentNullException(nameof(handle));
        }

        /// <summary>
        /// Gets the underlying type reference.
        /// </summary>
        public IType Type => type;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitTypeDefType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitTypeDefType(this, state);

    }

}
