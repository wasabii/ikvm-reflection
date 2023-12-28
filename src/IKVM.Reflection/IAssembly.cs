using System.Collections.Generic;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a resolved definition of an assembly either being written or loaded from the context.
    /// </summary>
    public interface IAssembly
    {

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        AssemblyName Name { get; }

        /// <summary>
        /// Gets the modules of the assembly.
        /// </summary>
        IReadOnlyList<IModule> Modules { get; }

        /// <summary>
        /// Attempts to find the module with the given name on the assembly.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        bool TryFindModule(string name, out IModule? module);

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Attempts to find the type with the given name on the assembly.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryFindType(string namespaceName, string name, out IType? type);

    }

}
