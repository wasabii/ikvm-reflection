namespace IKVM.Reflection.Emit
{

    public abstract class GenericTypeParameterBuilder
    {

        public static bool operator ==(GenericTypeParameterBuilder? left, Type? right) => Equals(left?.AsType(), right);

        public static bool operator !=(GenericTypeParameterBuilder? left, Type? right) => Equals(left?.AsType(), right) == false;

        /// <summary>
        /// Returns a <see cref="Type"/> instance that represents the generic type parameter being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator Type(GenericTypeParameterBuilder builder) => builder.AsType();

        /// <summary>
        /// Obtains a representation of the <see cref="GenericTypeParameterBuilder"/> which behaves like an <see cref="Type"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Type AsType();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();

    }

}
