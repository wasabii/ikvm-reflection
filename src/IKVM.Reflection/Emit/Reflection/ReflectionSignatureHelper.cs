namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionSignatureHelper : SignatureHelper
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.SignatureHelper wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionSignatureHelper(ReflectionEmitContext context, System.Reflection.Emit.SignatureHelper wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.SignatureHelper Wrapped => wrapped;

        public override void AddArgument(Type clsArgument)
        {
            wrapped.AddArgument(clsArgument);
        }

        public override void AddArgument(Type argument, bool pinned)
        {
            wrapped.AddArgument(argument, pinned);
        }

        public override void AddArgument(Type argument, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers)
        {
            wrapped.AddArgument(argument, requiredCustomModifiers, optionalCustomModifiers);
        }

        public override void AddArguments(Type[]? arguments, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers)
        {
            wrapped.AddArguments(arguments, requiredCustomModifiers, optionalCustomModifiers);
        }

        public override void AddSentinel()
        {
            wrapped.AddSentinel();
        }

        public override byte[] GetSignature()
        {
            return wrapped.GetSignature();
        }

        public override string ToString() => Wrapped.ToString();

    }

}
