namespace IKVM.Reflection
{

    /// <summary>
    /// Represents an argument value in a custom attribute construction.
    /// </summary>
    public abstract class CustomAttributeArgument
    {

        /// <summary>
        /// Gets or sets the type of the argument value.
        /// </summary>
        public abstract TypeRef ArgumentType { get; }

    }

}