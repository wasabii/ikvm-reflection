namespace IKVM.Reflection.Emit
{

    public abstract class MethodBuilder : MemberBuilder
    {

        public static bool operator ==(MethodBuilder? left, MethodBase? right) => Equals(left?.AsMethodInfo(), right);

        public static bool operator !=(MethodBuilder? left, MethodBase? right) => Equals(left?.AsMethodInfo(), right) == false;

        /// <summary>
        /// Returns a <see cref="MethodInfo"/> instance that represents the method being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator MethodInfo(MethodBuilder builder) => builder.AsMethodInfo();

        /// <summary>
        /// Sets the number of generic type parameters for the current method, specifies their names, and returns an array of GenericTypeParameterBuilder objects that can be used to define their constraints.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public abstract GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names);

        /// <summary>
        /// Sets the parameter attributes and the name of a parameter of this method, or of the return value of this method. Returns a ParameterBuilder that can be used to apply custom attributes.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="attributes"></param>
        /// <param name="strParamName"></param>
        /// <returns></returns>
        public abstract ParameterBuilder DefineParameter(int position, ParameterAttributes attributes, string? strParamName);

        /// <summary>
        /// Returns an ILGenerator for this method with a default Microsoft intermediate language (MSIL) stream size of 64 bytes.
        /// </summary>
        /// <returns></returns>
        public abstract ILGenerator GetILGenerator();

        /// <summary>
        /// Returns an ILGenerator for this method with the specified Microsoft intermediate language (MSIL) stream size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public abstract ILGenerator GetILGenerator(int size);

        /// <summary>
        /// Sets a custom attribute using a custom attribute builder.
        /// </summary>
        /// <param name="customBuilder"></param>
        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        /// <summary>
        /// Sets a custom attribute using a specified custom attribute blob.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="binaryAttribute"></param>
        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        /// <summary>
        /// Sets the implementation flags for this method.
        /// </summary>
        /// <param name="attributes"></param>
        public abstract void SetImplementationFlags(MethodImplAttributes attributes);

        /// <summary>
        /// Sets the number and types of parameters for a method.
        /// </summary>
        /// <param name="parameterTypes"></param>
        public abstract void SetParameters(params Type[] parameterTypes);

        /// <summary>
        /// Sets the return type of the method.
        /// </summary>
        /// <param name="returnType"></param>
        public abstract void SetReturnType(Type? returnType);

        /// <summary>
        /// Sets the method signature, including the return type, the parameter types, and the required and optional custom modifiers of the return type and parameter types.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="returnTypeRequiredCustomModifiers"></param>
        /// <param name="returnTypeOptionalCustomModifiers"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterTypeRequiredCustomModifiers"></param>
        /// <param name="parameterTypeOptionalCustomModifiers"></param>
        public abstract void SetSignature(Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        /// <summary>
        /// Obtains a representation of the <see cref="MethodBuilder"/> which behaves like an <see cref="MethodInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract MethodInfo AsMethodInfo();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();

    }

}
