using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a field either being written or loaded from the workspace.
    /// </summary>
    public interface IField
    {

        /// <summary>
        /// Gets the module from which this reference was loaded from.
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Gets the type that contains the field.
        /// </summary>
        IType? ParentType { get; }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the attributes of the field.
        /// </summary>
        FieldAttributes Attributes { get; }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        TypeSignature FieldType { get; }

    }

}
