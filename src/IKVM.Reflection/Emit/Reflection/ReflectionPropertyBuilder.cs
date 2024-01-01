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

        /// <inheritdoc />
        public override IEnumerable<CustomAttributeData> CustomAttributes => wrapped.CustomAttributes;

        /// <inheritdoc />
        public override Type? DeclaringType => wrapped.DeclaringType;

        /// <inheritdoc />
        public override MemberTypes MemberType => wrapped.MemberType;

        /// <inheritdoc />
        public override int MetadataToken => wrapped.MetadataToken;

        /// <inheritdoc />
        public override Module? Module => wrapped.Module;

        /// <inheritdoc />
        public override string Name => wrapped.Name;

        /// <inheritdoc />
        public override void AddOtherMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.AddOtherMethod(b.Wrapped);

            throw new ArgumentException("AddOtherMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void SetConstant(object? defaultValue)
        {
            wrapped.SetConstant(defaultValue);
        }

        /// <inheritdoc />
        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a CustomAttributeBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void SetGetMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.SetGetMethod(b.Wrapped);

            throw new ArgumentException("SetGetMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void SetSetMethod(MethodBuilder mdBuilder)
        {
            if (mdBuilder is ReflectionMethodBuilder b)
                wrapped.SetSetMethod(b.Wrapped);

            throw new ArgumentException("SetSetMethod requires a MethodBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void SetValue(object? obj, object? value, object?[]? index)
        {
            wrapped.SetValue(obj, value, index);
        }

        /// <inheritdoc />
        public override void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
        {
            wrapped.SetValue(obj, value, invokeAttr, binder, index, culture);
        }

        /// <inheritdoc />
        protected override PropertyInfo AsPropertyInfo() => wrapped;

        /// <inheritdoc />
        public override string ToString() => Wrapped.ToString();

    }

}
