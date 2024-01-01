namespace IKVM.Reflection.Emit
{

    public abstract class MethodBuilder
    {

        public static implicit operator MethodInfo(MethodBuilder builder) => builder.AsMethodInfo();

        public abstract GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names);

        public abstract ParameterBuilder DefineParameter(int position, ParameterAttributes attributes, string? strParamName);

        public abstract ILGenerator GetILGenerator();

        public abstract ILGenerator GetILGenerator(int size);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetImplementationFlags(MethodImplAttributes attributes);

        public abstract void SetParameters(params Type[] parameterTypes);

        public abstract void SetReturnType(Type? returnType);

        public abstract void SetSignature(Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        /// <summary>
        /// Obtains a representation of the <see cref="MethodBuilder"/> which behaves like an <see cref="MethodInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract MethodInfo AsMethodInfo();

    }

}
