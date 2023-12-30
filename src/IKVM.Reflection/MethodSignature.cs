using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents the signature of a method.
    /// </summary>
    public abstract class MethodSignature
    {

        /// <summary>
        /// Gets the return type of the method descriptor.
        /// </summary>
        public abstract ITypeDefOrRef ReturnType { get; }

        /// <summary>
        /// Gets the number of generic parameters this method defines.
        /// </summary>
        public abstract int GenericParameterCount { get; }

        /// <summary>
        /// Gets an ordered list of types indicating the types of the parameters that this member defines.
        /// </summary>
        public abstract IReadOnlyList<ITypeDefOrRef> ParameterTypes { get; }

    }

}
