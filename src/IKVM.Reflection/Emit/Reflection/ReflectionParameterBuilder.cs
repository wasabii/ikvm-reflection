namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionParameterBuilder : ParameterBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.ParameterBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="wrapped"></param>
        public ReflectionParameterBuilder(ReflectionEmitContext context, System.Reflection.Emit.ParameterBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.ParameterBuilder Wrapped => wrapped;

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

        public override string ToString() => Wrapped.ToString();

    }

}
