namespace IKVM.Reflection.Emit
{

    public abstract class GenericTypeParameterBuilder
    {

        public static implicit operator Type(GenericTypeParameterBuilder builder) => builder.AsType();

        /// <summary>
        /// Obtains a representation of the <see cref="GenericTypeParameterBuilder"/> which behaves like an <see cref="Type"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Type AsType();

    }

}
