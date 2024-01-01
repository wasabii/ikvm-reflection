namespace IKVM.Reflection.Emit
{

    public abstract class ParameterBuilder
    {

        public abstract void SetConstant(object? defaultValue);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

    }

}
