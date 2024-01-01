namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionEnumBuilder : EnumBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.EnumBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionEnumBuilder(ReflectionEmitContext context, System.Reflection.Emit.EnumBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.EnumBuilder Wrapped => wrapped;

        public override FieldBuilder DefineLiteral(string literalName, object? literalValue)
        {
            return context.Adopt(wrapped.DefineLiteral(literalName, literalValue));
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            wrapped.SetCustomAttribute(con, binaryAttribute);
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a CustomAttributeBuilder derived from the Reflection provider.");
        }

        protected override Type AsType() => wrapped;

        public override string ToString() => Wrapped.ToString();
    }

}
