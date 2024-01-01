using System.Globalization;

namespace IKVM.Reflection.Emit
{

    public abstract class FieldBuilder
    {

        public static implicit operator FieldInfo(FieldBuilder builder) => builder.AsFieldInfo();

        public abstract void SetConstant(object? defaultValue);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetOffset(int iOffset);

        public abstract void SetValue(object? obj, object? val, BindingFlags invokeAttr, Binder? binder, CultureInfo? culture);

        /// <summary>
        /// Obtains a representation of the <see cref="FieldBuilder"/> which behaves like an <see cref="FieldInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract FieldInfo AsFieldInfo();

    }

}
