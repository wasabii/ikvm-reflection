using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionTypeBuilder : TypeBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.TypeBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionTypeBuilder(ReflectionEmitContext context, System.Reflection.Emit.TypeBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.TypeBuilder Wrapped => wrapped;

        public override void AddInterfaceImplementation(Type interfaceType)
        {
            wrapped.AddInterfaceImplementation(interfaceType);
        }

        public override ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineConstructor(attributes, callingConvention, parameterTypes));
        }

        public override ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers)
        {
            return context.Adopt(wrapped.DefineConstructor(attributes, callingConvention, parameterTypes));
        }

        public override ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes)
        {
            return context.Adopt(wrapped.DefineDefaultConstructor(attributes));
        }

        public override EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype)
        {
            return context.Adopt(wrapped.DefineEvent(name, attributes, eventtype));
        }

        public override FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes)
        {
            return context.Adopt(wrapped.DefineField(fieldName, type, attributes));
        }

        public override FieldBuilder DefineField(string fieldName, Type type, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers, FieldAttributes attributes)
        {
            return context.Adopt(wrapped.DefineField(fieldName, type, requiredCustomModifiers, optionalCustomModifiers, attributes));
        }

        public override GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
        {
            var r = wrapped.DefineGenericParameters(names);
            var l = new GenericTypeParameterBuilder[r.Length];
            for (int i = 0; i < l.Length; i++)
                l[i] = context.Adopt(r[i]);
            return l;
        }

        public override FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes)
        {
            return context.Adopt(wrapped.DefineInitializedData(name, data, attributes));
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            return context.Adopt(wrapped.DefineMethod(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers));
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineMethod(name, attributes, callingConvention, returnType, parameterTypes));
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention)
        {
            return context.Adopt(wrapped.DefineMethod(name, attributes, callingConvention));
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes)
        {
            return context.Adopt(wrapped.DefineMethod(name, attributes));
        }

        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineMethod(name, attributes, returnType, parameterTypes));
        }

        public override void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
        {
            wrapped.DefineMethodOverride(methodInfoBody, methodInfoDeclaration);
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces)
        {
            return context.Adopt(wrapped.DefineNestedType(name, attr, parent, interfaces));
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, System.Reflection.Emit.PackingSize packSize, int typeSize)
        {
            return context.Adopt(wrapped.DefineNestedType(name, attr, parent, packSize, typeSize));
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, System.Reflection.Emit.PackingSize packSize)
        {
            return context.Adopt(wrapped.DefineNestedType(name, attr, parent, packSize));
        }

        public override TypeBuilder DefineNestedType(string name)
        {
            return context.Adopt(wrapped.DefineNestedType(name));
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent)
        {
            return context.Adopt(wrapped.DefineNestedType(name, attr, parent));
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr)
        {
            return context.Adopt(wrapped.DefineNestedType(name, attr));
        }

        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, int typeSize)
        {
            return context.Adopt(wrapped.DefineNestedType(name, attr, parent, typeSize));
        }

#if NET6_0_OR_GREATER

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            return context.Adopt(wrapped.DefinePInvokeMethod(name, dllName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet));
        }

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            return context.Adopt(wrapped.DefinePInvokeMethod(name, dllName, entryName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet));
        }

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            return context.Adopt(wrapped.DefinePInvokeMethod(name, dllName, entryName, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, nativeCallConv, nativeCharSet));
        }

#endif

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineProperty(name, attributes, returnType, parameterTypes));
        }

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineProperty(name, attributes, callingConvention, returnType, parameterTypes));
        }

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            return context.Adopt(wrapped.DefineProperty(name, attributes, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers));
        }

        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers)
        {
            return context.Adopt(wrapped.DefineProperty(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers));
        }

        public override ConstructorBuilder DefineTypeInitializer()
        {
            return context.Adopt(wrapped.DefineTypeInitializer());
        }

        public override FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes)
        {
            return context.Adopt(wrapped.DefineUninitializedData(name, size, attributes));
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a ICustomAttributeBuilder derived from the Reflection provider.");
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            wrapped.SetCustomAttribute(con, binaryAttribute);
        }

        public override void SetParent(Type? parent)
        {
            wrapped.SetParent(parent);
        }

        protected override Type AsType() => wrapped;

        public override string ToString() => Wrapped.ToString();

    }

}
