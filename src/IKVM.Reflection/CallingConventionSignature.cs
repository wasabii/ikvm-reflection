namespace IKVM.Reflection
{

    /// <summary>
    /// Provides a base for all signature that deal with a calling convention. This includes most member signatures,
    /// such as method and field signatures.
    /// </summary>
    public abstract class CallingConventionSignature
    {

        const CallingConventionAttributes SignatureTypeMask = (CallingConventionAttributes)0xF;

        readonly CallingConventionAttributes attributes;

        /// <summary>
        /// Creates a new calling convention signature.
        /// </summary>
        /// <param name="attributes">The attributes associated to the signature.</param>
        protected CallingConventionSignature(CallingConventionAttributes attributes)
        {
            this.attributes = attributes;
        }

        /// <summary>
        /// Gets or sets the attributes of the signature.
        /// </summary>
        public CallingConventionAttributes Attributes => attributes;

        /// <summary>
        /// When this signature references a method signature, gets or sets the calling convention that is used.
        /// </summary>
        public CallingConventionAttributes CallingConvention => attributes & SignatureTypeMask;

        /// <summary>
        /// Gets a value indicating whether the signature describes a method.
        /// </summary>
        public bool IsMethod => (int)(attributes & SignatureTypeMask) <= 0x5;

        /// <summary>
        /// Gets a value indicating whether the signature describes a field
        /// </summary>
        public bool IsField => (attributes & SignatureTypeMask) == CallingConventionAttributes.Field;

        /// <summary>
        /// Gets a value indicating whether the signature describes a local variable.
        /// </summary>
        public bool IsLocal => (attributes & SignatureTypeMask) == CallingConventionAttributes.Local;

        /// <summary>
        /// Gets a value indicating whether the signature describes a generic instance of a method.
        /// </summary>
        public bool IsGenericInstance => (attributes & SignatureTypeMask) == CallingConventionAttributes.GenericInstance;

        /// <summary>
        /// Gets a value indicating whether the member using this signature is a generic member and defines
        /// generic parameters.
        /// </summary>
        public bool IsGeneric => (attributes & CallingConventionAttributes.Generic) != 0;

        /// <summary>
        /// Gets a value indicating whether the member is an instance member and an additional argument is
        /// required to use this member.
        /// </summary>
        public bool HasThis => (attributes & CallingConventionAttributes.HasThis) != 0;

        /// <summary>
        /// Gets a value indicating whether the this parameter is explicitly specified in the parameter list.
        /// That is, determines whether the first parameter is used for the current instance object.
        /// </summary>
        public bool ExplicitThis => (Attributes & CallingConventionAttributes.ExplicitThis) != 0;

    }

}
