using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type signature describing a single dimension array with 0 as a lower bound.
    /// </summary>
    public class SzArrayTypeSignature : ArrayBaseTypeSignature
    {

        static readonly ArrayDimension[] SzDimensions = { new() };

        /// <summary>
        /// Creates a new single-dimension array signature with 0 as a lower bound.
        /// </summary>
        /// <param name="baseType">The type of the elements to store in the array.</param>
        public SzArrayTypeSignature(TypeSignature baseType)
            : base(baseType)
        {

        }

        /// <inheritdoc />
        public override int Rank => 1;

        /// <inheritdoc />
        public override IReadOnlyList<ArrayDimension> Dimensions => SzDimensions;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitSzArrayType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitSzArrayType(this, state);

    }

}
