using System.Globalization;

namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataPropertyBuilder : PropertyBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataPropertyBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override void AddOtherMethod(MethodBuilder mdBuilder)
        {
            throw new NotImplementedException();
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

        public override void SetGetMethod(MethodBuilder mdBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetSetMethod(MethodBuilder mdBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object? obj, object? value, object?[]? index)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
        {
            throw new NotImplementedException();
        }

        protected override PropertyInfo AsPropertyInfo()
        {
            throw new NotImplementedException();
        }
    }

}
