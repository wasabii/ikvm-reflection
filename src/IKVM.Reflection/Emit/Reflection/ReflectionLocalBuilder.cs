
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

        /// <inheritdoc />
        public override bool IsPinned => wrapped.IsPinned;

        /// <inheritdoc />
        public override int LocalIndex => wrapped.LocalIndex;

        /// <inheritdoc />
        public override Type LocalType => wrapped.LocalType;

        /// <inheritdoc />
        protected override LocalVariableInfo AsLocalVariableInfo() => throw new NotImplementedException();

        /// <inheritdoc />
        public override string ToString() => Wrapped.ToString();

    }

}
