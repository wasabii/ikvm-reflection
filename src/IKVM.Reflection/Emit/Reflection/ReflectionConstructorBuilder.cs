namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionConstructorBuilder : ConstructorBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.ConstructorBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionConstructorBuilder(ReflectionEmitContext context, System.Reflection.Emit.ConstructorBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.ConstructorBuilder Wrapped => wrapped;

        protected override ConstructorInfo AsConstructorInfo() => Wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
