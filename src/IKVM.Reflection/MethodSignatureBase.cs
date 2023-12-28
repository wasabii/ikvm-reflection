using System;
using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides a base for method and property signatures.
    /// </summary>
    public abstract class MethodSignatureBase : MemberSignature
    {

        readonly TypeSignature[] parameterTypes;

        /// <summary>
        /// Initializes the base of a method signature.
        /// </summary>
        /// <param name="attributes">The attributes associated to the signature.</param>
        /// <param name="returnType">The return type of the member.</param>
        /// <param name="parameterTypes">The types of all (non-sentinel) parameters.</param>
        protected MethodSignatureBase(CallingConventionAttributes attributes, TypeSignature returnType, params TypeSignature[] parameterTypes) :
            base(attributes, returnType)
        {
            Array.Copy(parameterTypes, this.parameterTypes = new TypeSignature[parameterTypes.Length], parameterTypes.Length);
        }

        /// <summary>
        /// Gets an ordered list of types indicating the types of the parameters that this member defines.
        /// </summary>
        public IReadOnlyList<TypeSignature> ParameterTypes => parameterTypes;

        /// <summary>
        /// Gets the return type of the method descriptor.
        /// </summary>
        public TypeSignature ReturnType => MemberType;

    }

}
