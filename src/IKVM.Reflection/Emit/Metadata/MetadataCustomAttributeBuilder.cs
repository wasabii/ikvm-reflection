namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataCustomAttributeBuilder : CustomAttributeBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataCustomAttributeBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

    }

}
