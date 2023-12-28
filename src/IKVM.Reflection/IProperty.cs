using System.Collections.Generic;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a property either being written or loaded from the workspace.
    /// </summary>
    public interface IProperty
    {

        /// <summary>
        /// Gets the module from which this property was loaded from.
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Gets the type that contains the property.
        /// </summary>
        IType? ParentType { get; }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the display name of the property.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the attributes of the property.
        /// </summary>
        PropertyAttributes Attributes { get; }

        /// <summary>
        /// Gets the signature of the property.
        /// </summary>
        MethodSignature Signature { get; }

        /// <summary>
        /// Gets the type of the property.
        /// </summary>
        TypeSignature PropertyType { get; }

        /// <summary>
        /// Gets the parameters of the property.
        /// </summary>
        IReadOnlyList<TypeSignature> ParameterTypes { get; }

        /// <summary>
        /// Gets the getter method implementation.
        /// </summary>
        IMethod? GetMethod { get; }

        /// <summary>
        /// Gets the setter method implementation.
        /// </summary>
        IMethod? SetMethod { get; }

    }

}
