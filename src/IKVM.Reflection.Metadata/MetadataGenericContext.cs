namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Provides a context within a generic instantiation, including the type arguments of the enclosing type and method.
    /// </summary>
    readonly struct MetadataGenericContext
    {

        readonly MetadataTypeDef? type;
        readonly MetadataMethod? method;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="method"></param>
        public MetadataGenericContext(MetadataTypeDef? type, MetadataMethod? method)
        {
            this.type = type;
            this.method = method;
        }

        /// <summary>
        /// Gets the object responsible for providing type arguments defined by the current generic type instantiation.
        /// </summary>
        public MetadataTypeDef? Type => type;

        /// <summary>
        /// Gets the object responsible for providing type arguments defined by the current generic method instantiation.
        /// </summary>
        public MetadataMethod? Method => method;

        /// <summary>
        /// Returns true if both Type and Method providers are null
        /// </summary>
        public bool IsEmpty => Type is null && Method is null;

    }

}