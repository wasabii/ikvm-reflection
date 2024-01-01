namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionGenericTypeParameterBuilder : GenericTypeParameterBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.GenericTypeParameterBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="builder"></param>
        public ReflectionGenericTypeParameterBuilder(ReflectionEmitContext context, System.Reflection.Emit.GenericTypeParameterBuilder builder)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public System.Reflection.Emit.GenericTypeParameterBuilder Wrapped => wrapped;

        protected override Type AsType() => Wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
