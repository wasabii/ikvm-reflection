using System;
using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a module either being written or loaded from the context.
    /// </summary>
    public interface IModule
    {

        /// <summary>
        /// Gets the reference to the assembly.
        /// </summary>
        IAssembly Assembly { get; }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the MVID of the module.
        /// </summary>
        Guid Mvid { get; }

        /// <summary>
        /// Gets the types of this module.
        /// </summary>
        IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Attempts to find a type from this module.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryFindType(string namespaceName, string name, out IType? type);

        /// <summary>
        /// Gets the methods of this module.
        /// </summary>
        IReadOnlyList<IMethod> Methods { get; }

        /// <summary>
        /// Attempts to find a method from this module.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        bool TryFindMethod(string name, out IMethod? method);

        /// <summary>
        /// Gets the fields of this module.
        /// </summary>
        IReadOnlyList<IField> Fields { get; }

        /// <summary>
        /// Attempts to find a field from this module.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryFindField(string name, out IField? type);

    }

}
