using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type signature representing an array.
    /// </summary>
    public abstract class ArrayBaseTypeSignature : TypeSpecificationSignature
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseType"></param>
        protected ArrayBaseTypeSignature(TypeSignature baseType) :
            base(baseType)
        {

        }

        /// <summary>
        /// Gets the number of dimenstions this array defines.
        /// </summary>
        public abstract int Rank { get; }

        /// <summary>
        /// Obtains the dimensions this array defines.
        /// </summary>
        /// <returns>The dimensions.</returns>
        public abstract IReadOnlyList<ArrayDimension> Dimensions { get; }

    }

}
