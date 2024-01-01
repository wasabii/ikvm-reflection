namespace IKVM.Reflection.Emit
{

    public abstract class ConstructorBuilder
    {

        public static bool operator ==(ConstructorBuilder? left, ConstructorInfo? right) => Equals(left?.AsConstructorInfo(), right);

        public static bool operator !=(ConstructorBuilder? left, ConstructorInfo? right) => Equals(left?.AsConstructorInfo(), right) == false;

        /// <summary>
        /// Returns a <see cref="ConstructorInfo"/> instance that represents the constructor being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator ConstructorInfo(ConstructorBuilder builder) => builder.AsConstructorInfo();

        /// <summary>
        /// Obtains a representation of the <see cref="ConstructorBuilder"/> which behaves like an <see cref="ConstructorInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract ConstructorInfo AsConstructorInfo();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();

    }

}
