using System.Globalization;

namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataFieldBuilder : FieldBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataFieldBuilder(MetadataEmitContext context)
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

        public override void SetOffset(int iOffset)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object? obj, object? val, BindingFlags invokeAttr, Binder? binder, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }

        protected override FieldInfo AsFieldInfo()
        {
            throw new NotImplementedException();
        }

    }

}
