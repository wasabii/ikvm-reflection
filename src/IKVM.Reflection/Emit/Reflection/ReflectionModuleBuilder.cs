using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionModuleBuilder : ModuleBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.ModuleBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        public ReflectionModuleBuilder(ReflectionEmitContext context, System.Reflection.Emit.ModuleBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.ModuleBuilder Wrapped => wrapped;

        /// <inheritdoc />
        public override FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes)
        {
            return context.Adopt(wrapped.DefineInitializedData(name, data, attributes));
        }

        /// <inheritdoc />
        public override EnumBuilder DefineEnum(string name, TypeAttributes visibility, Type underlyingType)
        {
            return context.Adopt(wrapped.DefineEnum(name, visibility, underlyingType));
        }

        /// <inheritdoc />
        public override MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineGlobalMethod(name, attributes, returnType, parameterTypes));
        }

        /// <inheritdoc />
        public override MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes)
        {
            return context.Adopt(wrapped.DefineGlobalMethod(name, attributes, callingConvention, returnType, parameterTypes));
        }

        /// <inheritdoc />
        public override MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? requiredReturnTypeCustomModifiers, Type[]? optionalReturnTypeCustomModifiers, Type[]? parameterTypes, Type[][]? requiredParameterTypeCustomModifiers, Type[][]? optionalParameterTypeCustomModifiers)
        {
            return context.Adopt(wrapped.DefineGlobalMethod(name, attributes, callingConvention, returnType, requiredReturnTypeCustomModifiers, optionalReturnTypeCustomModifiers, parameterTypes, requiredParameterTypeCustomModifiers, optionalParameterTypeCustomModifiers));
        }

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
        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packingSize, int typesize)
        {
            return context.Adopt(wrapped.DefineType(name, attr, parent, packingSize, typesize));
        }

        /// <inheritdoc />
        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces)
        {
            return context.Adopt(wrapped.DefineType(name, attr, parent, interfaces));
        }

        /// <inheritdoc />
        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packsize)
        {
            return context.Adopt(wrapped.DefineType(name, attr, parent, packsize));
        }

        /// <inheritdoc />
        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent)
        {
            return context.Adopt(wrapped.DefineType(name, attr, parent));
        }

        /// <inheritdoc />
        public override TypeBuilder DefineType(string name, TypeAttributes attr)
        {
            return context.Adopt(wrapped.DefineType(name, attr));
        }

        /// <inheritdoc />
        public override TypeBuilder DefineType(string name)
        {
            return context.Adopt(wrapped.DefineType(name));
        }

        /// <inheritdoc />
        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, int typesize)
        {
            return context.Adopt(wrapped.DefineType(name, attr, parent, typesize));
        }

        /// <inheritdoc />
        protected override Module AsModule() => Wrapped;

        /// <inheritdoc />
        public override string ToString() => Wrapped.ToString();

    }

}
