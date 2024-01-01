using System.Reflection.Emit;

namespace IKVM.Reflection.Emit
{

    public abstract class EnumBuilder
    {

        public static implicit operator Type(EnumBuilder builder) => builder.AsType();

        public abstract FieldBuilder DefineLiteral(string literalName, object? literalValue);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        /// <summary>
        /// Obtains a representation of the <see cref="EnumBuilder"/> which behaves like a <see cref="Type"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Type AsType();


    }

}
