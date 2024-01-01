using System.Globalization;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionPropertyBuilder : PropertyBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.PropertyBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionPropertyBuilder(ReflectionEmitContext context, System.Reflection.Emit.PropertyBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.PropertyBuilder Wrapped => wrapped;

        public override void AddOtherMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.AddOtherMethod(b.Wrapped);

            throw new ArgumentException("AddOtherMethod requires a MethodBuilder derived from the Reflection provider.");
        }

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
            throw new NotImplementedException();
        }

        public override void SetGetMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.SetGetMethod(b.Wrapped);

            throw new ArgumentException("SetGetMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        public override void SetSetMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.SetSetMethod(b.Wrapped);

            throw new ArgumentException("SetSetMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        public override void SetValue(object? obj, object? value, object?[]? index)
        {
            wrapped.SetValue(obj, value, index);
        }

        public override void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
        {
            wrapped.SetValue(obj, value, invokeAttr, binder, index, culture);
        }

        protected override PropertyInfo AsPropertyInfo() => wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
