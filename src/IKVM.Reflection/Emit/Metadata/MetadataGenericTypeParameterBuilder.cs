namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataGenericTypeParameterBuilder : GenericTypeParameterBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataGenericTypeParameterBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override Type AsType()
        {
            throw new NotImplementedException();
        }

    }

}
