
namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataMethodBuilder : MethodBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataMethodBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override IEnumerable<CustomAttributeData> CustomAttributes => throw new NotImplementedException();

        public override Type? DeclaringType => throw new NotImplementedException();

        public override MemberTypes MemberType => throw new NotImplementedException();

        public override int MetadataToken => throw new NotImplementedException();

        public override Module? Module => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
        {
            throw new NotImplementedException();
        }

        public override ParameterBuilder DefineParameter(int position, ParameterAttributes attributes, string? strParamName)
        {
            throw new NotImplementedException();
        }

        public override ILGenerator GetILGenerator()
        {
            throw new NotImplementedException();
        }

        public override ILGenerator GetILGenerator(int size)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            throw new NotImplementedException();
        }

        public override void SetImplementationFlags(MethodImplAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override void SetParameters(params Type[] parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override void SetReturnType(Type? returnType)
        {
            throw new NotImplementedException();
        }

        public override void SetSignature(Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        protected override MethodInfo AsMethodInfo()
        {
            throw new NotImplementedException();
        }

    }

}
