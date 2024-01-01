namespace IKVM.Reflection.Emit
{

    public abstract class EnumBuilder
    {

        public static bool operator ==(EnumBuilder? left, Type? right) => Equals(left?.AsType(), right);

        public static bool operator !=(EnumBuilder? left, Type? right) => Equals(left?.AsType(), right) == false;

        /// <summary>
        /// Returns a <see cref="Type"/> instance that represents the constructor being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator Type(EnumBuilder builder) => builder.AsType();

        public abstract FieldBuilder DefineLiteral(string literalName, object? literalValue);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        /// <summary>
        /// Obtains a representation of the <see cref="EnumBuilder"/> which behaves like a <see cref="Type"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Type AsType();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();


    }

}
