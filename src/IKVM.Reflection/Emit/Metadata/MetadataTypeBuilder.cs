using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataTypeBuilder : TypeBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataTypeBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override void AddInterfaceImplementation(Type interfaceType)
        {
            throw new NotImplementedException();
        }

        public override ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        public override ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype)
        {
            throw new NotImplementedException();
        }

        public override FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override FieldBuilder DefineField(string fieldName, Type type, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers, FieldAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
        {
            throw new NotImplementedException();
        }

        public override FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, PackingSize packSize, int typeSize)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, PackingSize packSize)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, int typeSize)
        {
            throw new NotImplementedException();
        }

#if NET5_0_OR_GREATER

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            throw new NotImplementedException();
        }

#endif

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            throw new NotImplementedException();
        }

        public override ConstructorBuilder DefineTypeInitializer()
        {
            throw new NotImplementedException();
        }

        public override FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes)
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

        public override void SetParent(Type? parent)
        {
            throw new NotImplementedException();
        }

        protected override Type AsType()
        {
            throw new NotImplementedException();
        }
    }

}
