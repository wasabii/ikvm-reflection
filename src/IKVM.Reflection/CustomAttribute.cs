namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a generic parameter.
    /// </summary>
    public abstract class CustomAttribute
    {

        /// <summary>
        /// Gets the member that this custom attribute is assigned to.
        /// </summary>
        public abstract IHasCustomAttributes Parent { get; }

        /// <summary>
        /// Gets a reference to the constructor that is invoked to initialize the attribute.
        /// </summary>
        public abstract MethodRef Constructor { get; }

        /// <summary>
        /// Gets the signature containing the arguments passed onto the attribute's constructor.
        /// </summary>
        public abstract CustomAttributeSignature Signature { get; }

        /// <inheritdoc />
        public override string ToString() => Constructor?.Name ?? "<<<NULL CONSTRUCTOR>>>";

    }

}
