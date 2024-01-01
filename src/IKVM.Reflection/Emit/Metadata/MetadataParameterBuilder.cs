namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataParameterBuilder : ParameterBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataParameterBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override void SetConstant(object? defaultValue)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            throw new NotImplementedException();
        }

    }

}
