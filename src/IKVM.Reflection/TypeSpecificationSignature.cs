using System;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides a base for type signatures that are based on another type signature.
    /// </summary>
    public abstract class TypeSpecificationSignature : TypeSignature
    {

        readonly TypeSignature baseType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="baseType"></param>
        public TypeSpecificationSignature(TypeSignature baseType)
        {
            this.baseType = baseType ?? throw new ArgumentNullException(nameof(baseType));
        }

        /// <summary>
        /// Gets the type this specification is based on.
        /// </summary>
        public TypeSignature BaseType => baseType;

    }

}