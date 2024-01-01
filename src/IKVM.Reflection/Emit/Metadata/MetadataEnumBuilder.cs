
namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataEnumBuilder : EnumBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataEnumBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override FieldBuilder DefineLiteral(string literalName, object? literalValue)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            throw new NotImplementedException();
        }

        protected override Type AsType()
        {
            throw new NotImplementedException();
        }

    }

}
