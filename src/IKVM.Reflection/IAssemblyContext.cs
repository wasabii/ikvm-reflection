using System.Reflection;

using IKVM.Reflection.Emit;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a context of available and loaded assemblies.
    /// </summary>
    public interface IAssemblyContext
    {

        /// <summary>
        /// Gets the options applied to the assembly context.
        /// </summary>
        AssemblyContextOptions Options { get; }

        /// <summary>
        /// Attempts to resolve the specified assembly name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        bool TryResolveAssembly(AssemblyName name, ModuleDef? requestingModule, out AssemblyDef? assembly);

        /// <summary>
        /// Attempts to resolve the specified type within the specified assembly.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool TryResolveType(AssemblyName assemblyName, string namespaceName, string name, ModuleDef? requestingModule, out TypeDef? type);

        /// <summary>
        /// Creates a new assembly within the context.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IAssemblyBuilder CreateAssembly(AssemblyName name);

    }

}
