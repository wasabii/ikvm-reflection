namespace IKVM.Reflection
{
    /// <summary>
    /// Represents the signature of a method defined or referenced by a .NET executable file.
    /// </summary>
    public class MethodSignature : MethodSignatureBase
    {

        readonly int genericParameterCount;

        /// <summary>
        /// Creates a new method signature with the provided return and parameter types.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="returnType">The return type of the method.</param>
        /// <param name="parameterTypes">The types of the parameter the method defines.</param>
        public MethodSignature(CallingConventionAttributes attributes, int genericParameterCount, TypeSignature returnType, params TypeSignature[] parameterTypes) :
            base(attributes, returnType, parameterTypes)
        {
            this.genericParameterCount = genericParameterCount;
        }

        /// <summary>
        /// Gets the number of generic parameters this method defines.
        /// </summary>
        public int GenericParameterCount => genericParameterCount;

    }

}
