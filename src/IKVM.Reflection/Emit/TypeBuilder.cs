using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Defines and creates new instances of classes.
    /// </summary>
    public abstract class TypeBuilder : MemberBuilder
    {

        public static bool operator ==(TypeBuilder? left, Type? right) => Equals(left?.AsType(), right);

        public static bool operator !=(TypeBuilder? left, Type? right) => Equals(left?.AsType(), right) == false;

        /// <summary>
        /// Returns a <see cref="Type"/> instance that represents the type being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator Type(TypeBuilder builder) => builder.AsType();

        /// <summary>
        /// Retrieves the assembly that contains this type definition.
        /// </summary>
        public abstract Assembly Assembly { get; }

        /// <summary>
        /// Returns the full name of this type qualified by the display name of the assembly.
        /// </summary>
        public abstract string? AssemblyQualifiedName { get; }

        /// <summary>
        /// Retrieves the base type of this type.
        /// </summary>
        public abstract Type? BaseType { get; }

        /// <summary>
        /// Gets the method that declared the current generic type parameter.
        /// </summary>
        public abstract MethodBuilder? DeclaringMethod { get; }

        /// <summary>
        /// Retrieves the full path of this type.
        /// </summary>
        public abstract string? FullName { get; }

        /// <summary>
        /// Adds an interface that this type implements.
        /// </summary>
        /// <param name="interfaceType"></param>
        public abstract void AddInterfaceImplementation(Type interfaceType);

        /// <summary>
        /// Adds a new constructor to the type, with the given attributes and signature.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes);

        /// <summary>
        /// Adds a new constructor to the type, with the given attributes, signature, and custom modifiers.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="requiredCustomModifiers"></param>
        /// <param name="optionalCustomModifiers"></param>
        /// <returns></returns>
        public abstract ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[]? parameterTypes, Type[][]? requiredCustomModifiers, Type[][]? optionalCustomModifiers);

        /// <summary>
        /// Defines the parameterless constructor. The constructor defined here will simply call the parameterless constructor of the parent.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes);

        /// <summary>
        /// Adds a new event to the type, with the given name, attributes and event type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="eventtype"></param>
        /// <returns></returns>
        public abstract EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype);

        /// <summary>
        /// Adds a new field to the type, with the given name, attributes, and field type.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="type"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes);

        /// <summary>
        /// Adds a new field to the type, with the given name, attributes, field type, and custom modifiers.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="type"></param>
        /// <param name="requiredCustomModifiers"></param>
        /// <param name="optionalCustomModifiers"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract FieldBuilder DefineField(string fieldName, Type type, Type[]? requiredCustomModifiers, Type[]? optionalCustomModifiers, FieldAttributes attributes);

        /// <summary>
        /// Defines the generic type parameters for the current type, specifying their number and their names, and returns an array of <see cref="GenericTypeParameterBuilder"/> objects that can be used to set their constraints.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public abstract GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names);

        /// <summary>
        /// Defines initialized data field in the .sdata section of the portable executable (PE) file.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes);

        /// <summary>
        /// Adds a new method to the type, with the specified name, method attributes, calling convention, method signature, and custom modifiers.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="returnTypeRequiredCustomModifiers"></param>
        /// <param name="returnTypeOptionalCustomModifiers"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterTypeRequiredCustomModifiers"></param>
        /// <param name="parameterTypeOptionalCustomModifiers"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        /// <summary>
        /// Adds a new method to the type, with the specified name, method attributes, calling convention, and method signature.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? parameterTypes);

        /// <summary>
        /// Adds a new method to the type, with the specified name, method attributes, and calling convention.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention);

        /// <summary>
        /// Adds a new method to the type, with the specified name and method attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes);

        /// <summary>
        /// Adds a new method to the type, with the specified name, method attributes, and method signature.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type? returnType, Type[]? parameterTypes);

        /// <summary>
        /// Specifies a given method body that implements a given method declaration, potentially with a different name.
        /// </summary>
        /// <param name="methodInfoBody"></param>
        /// <param name="methodInfoDeclaration"></param>
        public abstract void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration);

        /// <summary>
        /// Defines a nested type, given its name, attributes, the type that it extends, and the interfaces that it implements.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, Type[]? interfaces);

        /// <summary>
        /// Defines a nested type, given its name, attributes, size, and the type that it extends.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="packSize"></param>
        /// <param name="typeSize"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, PackingSize packSize, int typeSize);

        /// <summary>
        /// Defines a nested type, given its name, attributes, the type that it extends, and the packing size.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="packSize"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, PackingSize packSize);

        /// <summary>
        /// Defines a nested type, given its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name);

        /// <summary>
        /// Defines a nested type, given its name, attributes, and the type that it extends.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent);

        /// <summary>
        /// Defines a nested type, given its name and attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr);

        /// <summary>
        /// Defines a nested type, given its name, attributes, the total size of the type, and the type that it extends.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attr"></param>
        /// <param name="parent"></param>
        /// <param name="typeSize"></param>
        /// <returns></returns>
        public abstract TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type? parent, int typeSize);

        /// <summary>
        /// Defines a PInvoke method given its name, the name of the DLL in which the method is defined, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the PInvoke flags.
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
        /// Defines a PInvoke method given its name, the name of the DLL in which the method is defined, the name of the entry point, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the PInvoke flags.
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
        /// Defines a PInvoke method given its name, the name of the DLL in which the method is defined, the name of the entry point, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, the PInvoke flags, and custom modifiers for the parameters and return type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dllName"></param>
        /// <param name="entryName"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="returnTypeRequiredCustomModifiers"></param>
        /// <param name="returnTypeOptionalCustomModifiers"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterTypeRequiredCustomModifiers"></param>
        /// <param name="parameterTypeOptionalCustomModifiers"></param>
        /// <param name="nativeCallConv"></param>
        /// <param name="nativeCharSet"></param>
        /// <returns></returns>
        public abstract MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type? returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet);

        /// <summary>
        /// Adds a new property to the type, with the given name and property signature.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? parameterTypes);

        /// <summary>
        /// Adds a new property to the type, with the given name, attributes, calling convention, and property signature.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? parameterTypes);

        /// <summary>
        /// Adds a new property to the type, with the given name, property signature, and custom modifiers.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="returnType"></param>
        /// <param name="returnTypeRequiredCustomModifiers"></param>
        /// <param name="returnTypeOptionalCustomModifiers"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterTypeRequiredCustomModifiers"></param>
        /// <param name="parameterTypeOptionalCustomModifiers"></param>
        /// <returns></returns>
        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        /// <summary>
        /// dds a new property to the type, with the given name, calling convention, property signature, and custom modifiers.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="callingConvention"></param>
        /// <param name="returnType"></param>
        /// <param name="returnTypeRequiredCustomModifiers"></param>
        /// <param name="returnTypeOptionalCustomModifiers"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterTypeRequiredCustomModifiers"></param>
        /// <param name="parameterTypeOptionalCustomModifiers"></param>
        /// <returns></returns>
        public abstract PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[]? returnTypeRequiredCustomModifiers, Type[]? returnTypeOptionalCustomModifiers, Type[]? parameterTypes, Type[][]? parameterTypeRequiredCustomModifiers, Type[][]? parameterTypeOptionalCustomModifiers);

        /// <summary>
        /// Defines the initializer for this type.
        /// </summary>
        /// <returns></returns>
        public abstract ConstructorBuilder DefineTypeInitializer();

        /// <summary>
        /// Defines an uninitialized data field in the .sdata section of the portable executable (PE) file.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public abstract FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes);

        /// <summary>
        /// Set a custom attribute using a custom attribute builder.
        /// </summary>
        /// <param name="customBuilder"></param>
        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        /// <summary>
        /// Sets a custom attribute using a specified custom attribute blob.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="binaryAttribute"></param>
        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        /// <summary>
        /// Sets the base type of the type currently under construction.
        /// </summary>
        /// <param name="parent"></param>
        public abstract void SetParent(Type? parent);

        /// <summary>
        /// Obtains a representation of the <see cref="TypeBuilder"/> which behaves like an <see cref="Type"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Type AsType();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();

    }

}
