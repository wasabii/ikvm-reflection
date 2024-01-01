using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataModuleBuilder : ModuleBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataModuleBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override EnumBuilder DefineEnum(string name, TypeAttributes visibility, Type underlyingType)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? requiredReturnTypeCustomModifiers, Type[]? optionalReturnTypeCustomModifiers, Type[]? parameterTypes, Type[][]? requiredParameterTypeCustomModifiers, Type[][]? optionalParameterTypeCustomModifiers)
        {
            throw new NotImplementedException();
        }

#if NET6_0_OR_GREATER

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            throw new NotImplementedException();
        }

        public override MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
        {
            throw new NotImplementedException();
        }

#endif

        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packingSize, int typesize)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packsize)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineType(string name, TypeAttributes attr)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineType(string name)
        {
            throw new NotImplementedException();
        }

        public override TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, int typesize)
        {
            throw new NotImplementedException();
        }

    }

}
