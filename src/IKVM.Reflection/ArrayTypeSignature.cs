using System;
using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a single (complex) array type signature, which encodes a variable amount of array dimensions,
    /// as well as their sizes and lower bounds.
    /// </summary>
    /// <remarks>
    /// For simple single-dimension arrays, use <see cref="SzArrayTypeSignature"/> instead.
    /// </remarks>
    public class ArrayTypeSignature : ArrayBaseTypeSignature
    {

        readonly ArrayDimension[] dimensions = Array.Empty<ArrayDimension>();

        /// <summary>
        /// Creates a new array type signature.
        /// </summary>
        /// <param name="baseType">The element type.</param>
        public ArrayTypeSignature(TypeSignature baseType) :
            base(baseType)
        {

        }

        /// <summary>
        /// Creates a new array type signature with the provided dimensions count.
        /// </summary>
        /// <param name="baseType">The element type.</param>
        /// <param name="dimensionCount">The number of dimensions.</param>
        public ArrayTypeSignature(TypeSignature baseType, int dimensionCount) :
            base(baseType)
        {
            if (dimensionCount < 0)
                throw new ArgumentException("Number of dimensions cannot be negative.");

            dimensions = new ArrayDimension[dimensionCount];
            for (int i = 0; i < dimensionCount; i++)
                dimensions[i] = new ArrayDimension();
        }

        /// <summary>
        /// Creates a new array type signature with the provided dimensions count.
        /// </summary>
        /// <param name="baseType">The element type.</param>
        /// <param name="dimensions">The dimensions.</param>
        public ArrayTypeSignature(TypeSignature baseType, params ArrayDimension[] dimensions) :
            base(baseType)
        {
            if (dimensions.Length > 0)
            {
                this.dimensions = new ArrayDimension[dimensions.Length];
                Array.Copy(dimensions, this.dimensions, dimensions.Length);
            }
        }

        /// <inheritdoc />
        public override int Rank => dimensions.Length;

        /// <inheritdoc />
        public override IReadOnlyList<ArrayDimension> Dimensions => dimensions;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitArrayType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitArrayType(this, state);

    }

}
