namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionLocalBuilder : LocalBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.LocalBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ReflectionLocalBuilder(ReflectionEmitContext context, System.Reflection.Emit.LocalBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.LocalBuilder Wrapped => wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
