using System.Globalization;

namespace IKVM.Reflection.Emit
{

    public abstract class PropertyBuilder : MemberBuilder
    {

        public static bool operator ==(PropertyBuilder? left, PropertyInfo? right) => Equals(left?.AsPropertyInfo(), right);

        public static bool operator !=(PropertyBuilder? left, PropertyInfo? right) => Equals(left?.AsPropertyInfo(), right) == false;

        /// <summary>
        /// Returns a <see cref="PropertyInfo"/> instance that represents the property being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator PropertyInfo(PropertyBuilder builder) => builder.AsPropertyInfo();

        /// <summary>
        /// Sets the default value of this property.
        /// </summary>
        /// <param name="defaultValue"></param>
        public abstract void SetConstant(object? defaultValue);

        /// <summary>
        /// Set a custom attribute using a custom attribute builder.
        /// </summary>
        /// <param name="customBuilder"></param>
        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        /// <summary>
        /// Set a custom attribute using a specified custom attribute blob.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="binaryAttribute"></param>
        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        /// <summary>
        /// Sets the method that gets the property value.
        /// </summary>
        /// <param name="mdBuilder"></param>
        public abstract void SetGetMethod(MethodBuilder mdBuilder);

        /// <summary>
        /// Sets the method that sets the property value.
        /// </summary>
        /// <param name="mdBuilder"></param>
        public abstract void SetSetMethod(MethodBuilder mdBuilder);

        /// <summary>
        /// Adds one of the other methods associated with this property.
        /// </summary>
        /// <param name="mdBuilder"></param>
        public abstract void AddOtherMethod(MethodBuilder mdBuilder);

        /// <summary>
        /// Sets the value of the property with optional index values for index properties.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public abstract void SetValue(object? obj, object? value, object?[]? index);

        /// <summary>
        /// Sets the property value for the given object to the given value.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <param name="invokeAttr"></param>
        /// <param name="binder"></param>
        /// <param name="index"></param>
        /// <param name="culture"></param>
        public abstract void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture);

        /// <summary>
        /// Obtains a representation of the <see cref="PropertyBuilder"/> which behaves like an <see cref="PropertyInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract PropertyInfo AsPropertyInfo();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();

    }

}
