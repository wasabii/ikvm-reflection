using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Defines and represents a module in an assembly.
    /// </summary>
    public abstract class ModuleBuilder
    {

        public static bool operator ==(ModuleBuilder? left, Module? right) => Equals(left?.AsModule(), right);

        public static bool operator !=(ModuleBuilder? left, Module? right) => Equals(left?.AsModule(), right) == false;

        /// <summary>
        /// Returns a <see cref="Module"/> instance that represents the module being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator Module(ModuleBuilder builder) => builder.AsModule();

        /// <summary>
        /// Defines an initialized data field in the .sdata section of the portable executable (PE) file.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes);

        /// <summary>
        /// Defines an enumeration type that is a value type with a single non-static field called value__ of the specified type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="visibility"></param>
        /// <param name="underlyingType"></param>
        /// <returns></returns>
        public abstract EnumBuilder DefineEnum(string name, TypeAttributes visibility, Type underlyingType);

        /// <summary>
        /// Defines a global method with the specified name, attributes, return type, and parameter types.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes);

        /// <summary>
        /// Defines a global method with the specified name, attributes, calling convention, return type, and parameter types.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes);

        /// <summary>
        /// Defines a global method with the specified name, attributes, calling convention, return type, custom modifiers for the return type, parameter types, and custom modifiers for the parameter types.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="requiredReturnTypeCustomModifiers"></param>
        /// <param name="optionalReturnTypeCustomModifiers"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="requiredParameterTypeCustomModifiers"></param>
        /// <param name="optionalParameterTypeCustomModifiers"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineGlobalMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? requiredReturnTypeCustomModifiers, Type[]? optionalReturnTypeCustomModifiers, Type[]? parameterTypes, Type[][]? requiredParameterTypeCustomModifiers, Type[][]? optionalParameterTypeCustomModifiers);

        /// <summary>
        /// Defines a PInvoke method with the specified name, the name of the DLL in which the method is defined, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the PInvoke flags.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dllName"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="nativeCallConv"></param>
        /// <param name="nativeCharSet"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet);

        /// <summary>
        /// Defines a PInvoke method with the specified name, the name of the DLL in which the method is defined, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the PInvoke flags.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dllName"></param>
        /// <param name="entryName"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="nativeCallConv"></param>
        /// <param name="nativeCharSet"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet);

        /// <summary>
        /// Constructs a TypeBuilder given the type name, attributes, the type that the defined type extends, the packing size of the defined type, and the total size of the defined type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="packingSize"></param>
        /// <param name="typesize"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packingSize, int typesize);

        /// <summary>
        /// Constructs a TypeBuilder given the type name, attributes, the type that the defined type extends, and the interfaces that the defined type implements.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces);

        /// <summary>
        /// Constructs a TypeBuilder given the type name, the attributes, the type that the defined type extends, and the packing size of the type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="packsize"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, PackingSize packsize);

        /// <summary>
        /// Constructs a TypeBuilder given type name, its attributes, and the type that the defined type extends.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent);

        /// <summary>
        /// Constructs a TypeBuilder given the type name and the type attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name, TypeAttributes attr);

        /// <summary>
        /// Constructs a TypeBuilder for a private type with the specified name in this module.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name);

        /// <summary>
        /// Constructs a TypeBuilder given the type name, the attributes, the type that the defined type extends, and the total size of the type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="typesize"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineType(string name, TypeAttributes attr, Type? parent, int typesize);

        /// <summary>
        /// Obtains a representation of the <see cref="ModuleBuilder"/> which behaves like an <see cref="Module"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Module AsModule();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();


    }

}
