using System.Globalization;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionFieldBuilder : FieldBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.FieldBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionFieldBuilder(ReflectionEmitContext context, System.Reflection.Emit.FieldBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.FieldBuilder Wrapped => wrapped;

        public override void SetConstant(object? defaultValue)
        {
            wrapped.SetConstant(defaultValue);
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a CustomAttributeBuilder derived from the Reflection provider.");
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            wrapped.SetCustomAttribute(con, binaryAttribute);
        }

        public override void SetOffset(int iOffset)
        {
            wrapped.SetOffset(iOffset);
        }

        public override void SetValue(object? obj, object? val, BindingFlags invokeAttr, Binder? binder, CultureInfo? culture)
        {
            wrapped.SetValue(obj, val, invokeAttr, binder, culture);
        }

        protected override FieldInfo AsFieldInfo() => Wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
