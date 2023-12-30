using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a method resolved within .NET metadata.
    /// </summary>
    public abstract class PropertyDef
    {

        /// <summary>
        /// Gets the custom attributes applied to the method.
        /// </summary>
        public abstract IReadOnlyList<CustomAttribute> CustomAttributes { get; }

        /// <summary>
        /// Gets the reference to the type that holds the method.
        /// </summary>
        public abstract TypeDef DeclaringType { get; }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the signature of the property.
        /// </summary>
        public abstract MethodSignature Signature { get; }
    }

}
