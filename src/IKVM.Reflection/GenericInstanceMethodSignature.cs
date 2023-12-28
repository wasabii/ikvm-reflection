using System;
using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents an instantiation of a generic method.
    /// </summary>
    public class GenericInstanceMethodSignature : CallingConventionSignature, IGenericArgumentsProvider
    {

        readonly TypeSignature[] typeArguments;

        /// <summary>
        /// Creates a new instantiation signature for a generic method.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        public GenericInstanceMethodSignature(CallingConventionAttributes attributes) :
            this(attributes, Array.Empty<TypeSignature>())
        {

        }

        /// <summary>
        /// Creates a new instantiation signature for a generic method with the provided type arguments.
        /// </summary>
        /// <param name="typeArguments">The type arguments to use for the instantiation.</param>
        public GenericInstanceMethodSignature(params TypeSignature[] typeArguments) :
            this(CallingConventionAttributes.GenericInstance, typeArguments)
        {

        }

        /// <summary>
        /// Creates a new instantiation signature for a generic method with the provided type arguments.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="typeArguments">The type arguments to use for the instantiation.</param>
        public GenericInstanceMethodSignature(CallingConventionAttributes attributes, TypeSignature[] typeArguments) :
            base(attributes | CallingConventionAttributes.GenericInstance)
        {
            Array.Copy(typeArguments, this.typeArguments = new TypeSignature[typeArguments.Length], typeArguments.Length);
        }

        /// <summary>
        /// Gets a collection of type arguments that are used to instantiate the method.
        /// </summary>
        public IReadOnlyList<TypeSignature> TypeArguments => typeArguments;

    }

}
