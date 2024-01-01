using System.Globalization;

namespace IKVM.Reflection.Emit
{

    public abstract class PropertyBuilder
    {

        public static implicit operator PropertyInfo(PropertyBuilder builder) => builder.AsPropertyInfo();

        public abstract void SetConstant(object? defaultValue);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetGetMethod(MethodBuilder mdBuilder);

        public abstract void SetSetMethod(MethodBuilder mdBuilder);

        public abstract void AddOtherMethod(MethodBuilder mdBuilder);

        public abstract void SetValue(object? obj, object? value, object?[]? index);

        public abstract void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture);

        /// <summary>
        /// Obtains a representation of the <see cref="PropertyBuilder"/> which behaves like an <see cref="PropertyInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract PropertyInfo AsPropertyInfo();

    }

}
