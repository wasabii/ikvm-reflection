using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit
{

    public abstract class ModuleBuilder
    {

        public abstract EnumBuilder DefineEnum(string name, TypeAttributes visibility, Type underlyingType);

        public abstract MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes);

        public abstract MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes);

        public abstract MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? requiredReturnTypeCustomModifiers, Type[]? optionalReturnTypeCustomModifiers, Type[]? parameterTypes, Type[][]? requiredParameterTypeCustomModifiers, Type[][]? optionalParameterTypeCustomModifiers);

#if NET6_0_OR_GREATER

        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet);

        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet);

#endif

        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packingSize, int typesize);

        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces);

        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packsize);

        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent);

        public abstract TypeBuilder DefineType(string name, TypeAttributes attr);

        public abstract TypeBuilder DefineType(string name);

        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, int typesize);


    }

}
