namespace IKVM.Reflection.Emit
{

    public abstract class MemberBuilder
    {

        /// <summary>
        /// Gets a collection that contains this member's custom attributes.
        /// </summary>
        public abstract IEnumerable<CustomAttributeData> CustomAttributes { get; }

        /// <summary>
        /// Returns the type that declared this type.
        /// </summary>
        public abstract Type? DeclaringType { get; }

        /// <summary>
        /// When overridden in a derived class, gets a MemberTypes value indicating the type of the member - method, constructor, event, and so on.
        /// </summary>
        public abstract MemberTypes MemberType { get; }

        /// <summary>
        /// Gets a value that identifies a metadata element.
        /// </summary>
        public abstract int MetadataToken { get; }

        /// <summary>
        /// Gets the module in which the type that declares the member represented by the current MemberInfo is defined.
        /// </summary>
        public abstract Module? Module { get; }

        /// <summary>
        /// Gets the name of the current member.
        /// </summary>
        public abstract string Name { get; }

    }

}
