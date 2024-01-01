using System.Reflection.Emit;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionMethodBuilder : MethodBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.MethodBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionMethodBuilder(ReflectionEmitContext context, System.Reflection.Emit.MethodBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        internal System.Reflection.Emit.MethodBuilder Wrapped => wrapped;

        public override GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
        {
            var r = wrapped.DefineGenericParameters(names);
            var l = new GenericTypeParameterBuilder[r.Length];
            for (int i = 0; i < l.Length; i++)
                l[i] = context.Adopt(r[i]);
            return l;
        }

        public override ParameterBuilder DefineParameter(int position, ParameterAttributes attributes, string? strParamName)
        {
            return context.Adopt(wrapped.DefineParameter(position, attributes, strParamName));
        }

        public override ILGenerator GetILGenerator()
        {
            return context.Adopt(wrapped.GetILGenerator());
        }

        public override ILGenerator GetILGenerator(int size)
        {
            return context.Adopt(wrapped.GetILGenerator(size));
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a CustomAttributeBuilder derived from the Reflection provider.");
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            wrapped.SetCustomAttribute(con, binaryAttribute);
        }

        public override void SetImplementationFlags(MethodImplAttributes attributes)
        {
            wrapped.SetImplementationFlags(attributes);
        }

        public override void SetParameters(params Type[] parameterTypes)
        {
            wrapped.SetParameters(parameterTypes);
        }

        public override void SetReturnType(Type? returnType)
        {
            wrapped.SetReturnType(returnType);
        }

        public override void SetSignature(Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            wrapped.SetSignature(returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
        }

        protected override MethodInfo AsMethodInfo() => Wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
