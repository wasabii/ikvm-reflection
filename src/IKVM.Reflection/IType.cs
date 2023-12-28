using System.Collections.Generic;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a type either being written or loaded from the workspace.
    /// </summary>
    public interface IType
    {

        /// <summary>
        /// Gets the module that contains the type.
        /// </summary>
        IAssembly Assembly { get; }

        /// <summary>
        /// Gets the module that contains the type.
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Gets the parent type of this type.
        /// </summary>
        IType? ParentType { get; }

        /// <summary>
        /// Gets the namespace of the type.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the full name of the type.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets the attributes of the type.
        /// </summary>
        TypeAttributes Attributes { get; }

        /// <summary>
        /// Gets the generic parameters of the type.
        /// </summary>
        IReadOnlyList<IGenericParameter> GenericParameters { get; }

        /// <summary>
        /// Gets the signature of the base type.
        /// </summary>
        TypeSignature? BaseType { get; }

        /// <summary>
        /// Gets the set of fields on the type.
        /// </summary>
        IReadOnlyList<IField> Fields { get; }

        /// <summary>
        /// Attempts to find the field with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        bool TryFindField(string name, out IField? field);

        /// <summary>
        /// Gets the set of methods on the type.
        /// </summary>
        IReadOnlyList<IMethod> Methods { get; }

        /// <summary>
        /// Attempts to find the method with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        bool TryFindMethod(string name, out IMethod? method);

        /// <summary>
        /// Gets the set of nested types on this type.
        /// </summary>
        IReadOnlyList<IType> NestedTypes { get; }

        /// <summary>
        /// Attempts to find the nested type with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryFindNestedType(string name, out IType? type);

        /// <summary>
        /// Gets the set of properties on this type.
        /// </summary>
        IReadOnlyList<IProperty> Properties { get; }

        /// <summary>
        /// Attempts to find the property with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        bool TryFindProperty(string name, out IProperty? property);

        /// <summary>
        /// Gets the set of events on this type.
        /// </summary>
        IReadOnlyList<IEvent> Events { get; }

        /// <summary>
        /// Attempts to find the event with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        bool TryFindEvent(string name, out IEvent? evt);

    }

}
