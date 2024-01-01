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

        /// <inheritdoc />
        public override Assembly Assembly => wrapped.Assembly;

        /// <inheritdoc />
        public override string? AssemblyQualifiedName => wrapped.AssemblyQualifiedName;

        /// <inheritdoc />
        public override Type? BaseType => wrapped.BaseType;

        /// <inheritdoc />
        public override MethodBuilder? DeclaringMethod => wrapped.DeclaringMethod is System.Reflection.Emit.MethodBuilder b ? context.Adopt(b) : null;

        /// <inheritdoc />
        public override string? FullName => wrapped.FullName;

        /// <inheritdoc />
        public override IEnumerable<CustomAttributeData> CustomAttributes => wrapped.CustomAttributes;

        /// <inheritdoc />
        public override Type? DeclaringType => wrapped.DeclaringType;

        /// <inheritdoc />
        public override MemberTypes MemberType => wrapped.MemberType;

        /// <inheritdoc />
        public override int MetadataToken => wrapped.MetadataToken;

        /// <inheritdoc />
        public override Module Module => wrapped.Module;

        /// <inheritdoc />
        public override string Name => wrapped.Name;

        /// <inheritdoc />
        public override void AddInterfaceImplementation(Type interfaceType) => wrapped.AddInterfaceImplementation(interfaceType);

        /// <inheritdoc />
        public override ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes) => context.Adopt(wrapped.DefineConstructor(attributes, callingConvention, parameterTypes));

        /// <inheritdoc />
        public override ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers) => context.Adopt(wrapped.DefineConstructor(attributes, callingConvention, parameterTypes));

        /// <inheritdoc />
        public override ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes) => context.Adopt(wrapped.DefineDefaultConstructor(attributes));

        /// <inheritdoc />
        public override EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype) => context.Adopt(wrapped.DefineEvent(name, attributes, eventtype));

        /// <inheritdoc />
        public override FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes) => context.Adopt(wrapped.DefineField(fieldName, type, attributes));

        /// <inheritdoc />
        public override FieldBuilder DefineField(string fieldName, Type type, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers, FieldAttributes attributes) => context.Adopt(wrapped.DefineField(fieldName, type, requiredCustomModifiers, optionalCustomModifiers, attributes));

        /// <inheritdoc />
        public override GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
        {
            var r = wrapped.DefineGenericParameters(names);
            var l = new GenericTypeParameterBuilder[r.Length];
            for (int i = 0; i < l.Length; i++)
                l[i] = context.Adopt(r[i]);
            return l;
        }

        /// <inheritdoc />
        public override FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes) => context.Adopt(wrapped.DefineInitializedData(name, data, attributes));

        /// <inheritdoc />
        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers) => context.Adopt(wrapped.DefineMethod(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers));

        /// <inheritdoc />
        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes) => context.Adopt(wrapped.DefineMethod(name, attributes, callingConvention, returnType, parameterTypes));

        /// <inheritdoc />
        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention) => context.Adopt(wrapped.DefineMethod(name, attributes, callingConvention));

        /// <inheritdoc />
        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes) => context.Adopt(wrapped.DefineMethod(name, attributes));

        /// <inheritdoc />
        public override MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes) => context.Adopt(wrapped.DefineMethod(name, attributes, returnType, parameterTypes));

        /// <inheritdoc />
        public override void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration) => wrapped.DefineMethodOverride(methodInfoBody, methodInfoDeclaration);

        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces) => context.Adopt(wrapped.DefineNestedType(name, attr, parent, interfaces));

        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, System.Reflection.Emit.PackingSize packSize, int typeSize) => context.Adopt(wrapped.DefineNestedType(name, attr, parent, packSize, typeSize));

        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, System.Reflection.Emit.PackingSize packSize) => context.Adopt(wrapped.DefineNestedType(name, attr, parent, packSize));

        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name) => context.Adopt(wrapped.DefineNestedType(name));

        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent) => context.Adopt(wrapped.DefineNestedType(name, attr, parent));

        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr) => context.Adopt(wrapped.DefineNestedType(name, attr));
        /// <inheritdoc />
        public override TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, int typeSize) => context.Adopt(wrapped.DefineNestedType(name, attr, parent, typeSize));

        /// <inheritdoc />
        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
#if NET6_0_OR_GREATER
            return context.Adopt(wrapped.DefinePInvokeMethod(name, dllName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet));
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
#if NET6_0_OR_GREATER
            return context.Adopt(wrapped.DefinePInvokeMethod(name, dllName, entryName, attributes, callingConvention, returnType, parameterTypes, nativeCallConv, nativeCharSet));
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
#if NET6_0_OR_GREATER
            return context.Adopt(wrapped.DefinePInvokeMethod(name, dllName, entryName, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, nativeCallConv, nativeCharSet));
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? parameterTypes) => context.Adopt(wrapped.DefineProperty(name, attributes, returnType, parameterTypes));

        /// <inheritdoc />
        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? parameterTypes) => context.Adopt(wrapped.DefineProperty(name, attributes, callingConvention, returnType, parameterTypes));

        /// <inheritdoc />
        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers) => context.Adopt(wrapped.DefineProperty(name, attributes, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers));

        /// <inheritdoc />
        public override PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers) => context.Adopt(wrapped.DefineProperty(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers));

        /// <inheritdoc />
        public override ConstructorBuilder DefineTypeInitializer() => context.Adopt(wrapped.DefineTypeInitializer());

        /// <inheritdoc />
        public override FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes) => context.Adopt(wrapped.DefineUninitializedData(name, size, attributes));

        /// <inheritdoc />
        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a ICustomAttributeBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute) => wrapped.SetCustomAttribute(con, binaryAttribute);

        /// <inheritdoc />
        public override void SetParent(Type? parent) => wrapped.SetParent(parent);

        /// <inheritdoc />
        protected override Type AsType() => wrapped;

        /// <inheritdoc />
        public override string ToString() => Wrapped.ToString();

    }

}
