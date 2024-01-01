namespace IKVM.Reflection.Emit
{

    public abstract class ConstructorBuilder
    {

        public static implicit operator ConstructorInfo(ConstructorBuilder builder) => builder.AsConstructorInfo();

        /// <summary>
        /// Obtains a representation of the <see cref="ConstructorBuilder"/> which behaves like an <see cref="ConstructorInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract ConstructorInfo AsConstructorInfo();

    }

}
