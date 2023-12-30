namespace IKVM.Reflection
{

    /// <summary>
    /// Represents an argument value in a custom attribute construction that is assigned to a field or property in the
    /// attribute class.
    /// </summary>
    public abstract class CustomAttributeNamedArgument
    {

        /// <summary>
        /// Gets a value indicating whether the referenced member is a field or a property.
        /// </summary>
        public abstract CustomAttributeArgumentMemberType MemberType { get; }

        /// <summary>
        /// Gets the name of the referenced member.
        /// </summary>
        public abstract string? MemberName { get; }

        /// <summary>
        /// Gets the type of the argument to store.
        /// </summary>
        public abstract TypeRef ArgumentType { get; }

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        public abstract CustomAttributeArgument Argument { get; }

        /// <inheritdoc />
        public override string ToString() => $"{MemberName} = {Argument}";

    }

}
