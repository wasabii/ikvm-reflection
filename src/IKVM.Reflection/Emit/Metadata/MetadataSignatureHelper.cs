namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataSignatureHelper : SignatureHelper
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataSignatureHelper(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override void AddArgument(Type clsArgument)
        {
            throw new NotImplementedException();
        }

        public override void AddArgument(Type argument, bool pinned)
        {
            throw new NotImplementedException();
        }

        public override void AddArgument(Type argument, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        public override void AddArguments(Type[]? arguments, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        public override void AddSentinel()
        {
            throw new NotImplementedException();
        }

        public override byte[] GetSignature()
        {
            throw new NotImplementedException();
        }
    }

}
