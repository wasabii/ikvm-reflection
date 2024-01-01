namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataEventBuilder : EventBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataEventBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override void AddOtherMethod(MethodBuilder mdBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetAddOnMethod(MethodBuilder mdBuilder)
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

        public override void SetRaiseMethod(MethodBuilder mdBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetRemoveOnMethod(MethodBuilder mdBuilder)
        {
            throw new NotImplementedException();
        }

    }

}
