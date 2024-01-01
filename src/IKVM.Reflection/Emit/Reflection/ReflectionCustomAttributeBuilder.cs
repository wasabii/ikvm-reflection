namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionCustomAttributeBuilder : CustomAttributeBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.CustomAttributeBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ReflectionCustomAttributeBuilder(ReflectionEmitContext context, System.Reflection.Emit.CustomAttributeBuilder wrapped)
        {
            this.context = context;
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.CustomAttributeBuilder Wrapped => wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
