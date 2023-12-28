using System.Collections.Generic;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a method either being written or loaded from the workspace.
    /// </summary>
    public interface IMethod
    {

        /// <summary>
        /// Gets the parent type of the method.
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Gets the parent type of the method.
        /// </summary>
        IType? ParentType { get; }

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the display name of this method.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the attributes of the method.
        /// </summary>
        MethodAttributes Attributes { get; }

        /// <summary>
        /// Gets the implementation attributes of the method.
        /// </summary>
        MethodImplAttributes ImplAttributes { get; }

        /// <summary>
        /// Gets the signature for the method.
        /// </summary>
        MethodSignature Signature { get; }

        /// <summary>
        /// Gets the generic parameters of the method.
        /// </summary>
        IReadOnlyList<IGenericParameter> GenericParameters { get; }

        /// <summary>
        /// Gets the return type of the method.
        /// </summary>
        TypeSignature ReturnType { get; }

        /// <summary>
        /// Gets the parameters of the method.
        /// </summary>
        IReadOnlyList<IParameter> Parameters { get; }

    }

}
