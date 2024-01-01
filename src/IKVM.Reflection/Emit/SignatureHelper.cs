namespace IKVM.Reflection.Emit
{

    public abstract class SignatureHelper
    {

        public abstract void AddArgument(Type clsArgument);

        public abstract void AddArgument(Type argument, bool pinned);

        public abstract void AddArgument(Type argument, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers);

        public abstract void AddArguments(Type[]? arguments, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers);

        public abstract void AddSentinel();

        public abstract byte[] GetSignature();

    }

}
