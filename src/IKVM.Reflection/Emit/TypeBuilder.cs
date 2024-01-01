using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit
{

    public abstract class TypeBuilder
    {

        public static implicit operator Type(TypeBuilder builder) => builder.AsType();

        public abstract void AddInterfaceImplementation(Type interfaceType);

        public abstract ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes);

        public abstract ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers);

        public abstract ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes);

        public abstract EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype);

        public abstract FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes);

        public abstract FieldBuilder DefineField(string fieldName, Type type, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers, FieldAttributes attributes);

        public abstract GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names);

        public abstract FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes);

        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes);

        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention);

        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes);

        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes);

        public abstract void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration);

        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces);

        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, PackingSize packSize, int typeSize);

        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, PackingSize packSize);

        public abstract TypeBuilder DefineNestedType(string name);

        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent);

        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr);

        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, int typeSize);

#if NET5_0_OR_GREATER

        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet);

        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet);

        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet);

#endif

        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? parameterTypes);

        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? parameterTypes);

        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        public abstract ConstructorBuilder DefineTypeInitializer();

        public abstract FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes);

        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        public abstract void SetParent(Type? parent);

        /// <summary>
        /// Obtains a representation of the <see cref="TypeBuilder"/> which behaves like an <see cref="Type"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Type AsType();

    }

}
