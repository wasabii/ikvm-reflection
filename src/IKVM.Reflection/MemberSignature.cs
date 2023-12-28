using System;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides a base for all member signatures.
    /// </summary>
    public abstract class MemberSignature : CallingConventionSignature
    {

        readonly TypeSignature memberType;

        /// <summary>
        /// Initializes a new member signature.
        /// </summary>
        /// <param name="attributes">The attributes of the signature.</param>
        /// <param name="memberType">The type of the object this member returns or contains.</param>
        protected MemberSignature(CallingConventionAttributes attributes, TypeSignature memberType) :
            base(attributes)
        {
            this.memberType = memberType ?? throw new ArgumentNullException(nameof(memberType));
        }

        /// <summary>
        /// Gets the type of the object this member returns or contains.
        /// </summary>
        protected TypeSignature MemberType => memberType;

    }

}
