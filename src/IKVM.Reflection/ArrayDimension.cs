﻿namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a single dimension in an array specification.
    /// </summary>
    public readonly record struct ArrayDimension
    {


        /// <summary>
        /// Creates a new array dimension.
        /// </summary>
        /// <param name="size">The number of elements in this dimension.</param>
        public ArrayDimension(int size) :
            this(size, null)
        {


        }

        /// <summary>
        /// Creates a new array dimension.
        /// </summary>
        /// <param name="size">The number of elements in this dimension.</param>
        /// <param name="lowerBound">the lower bound for each index in the dimension (if specified)</param>
        public ArrayDimension(int? size, int? lowerBound)
        {
            Size = size;
            LowerBound = lowerBound;
        }

        /// <summary>
        /// Gets or sets the number of elements in the dimension (if specified).
        /// </summary>
        /// <remarks>
        /// When this value is not specified (<c>null</c>), no upper bound on the number of elements is assumed by the CLR.
        /// </remarks>
        public int? Size { get; init; }

        /// <summary>
        /// Gets or sets the lower bound for each index in the dimension (if specified).
        /// </summary>
        /// <remarks>
        /// When this value is not specified (<c>null</c>), a lower bound of 0 is assumed by the CLR.
        /// </remarks>
        public int? LowerBound { get; init; }

    }

}
