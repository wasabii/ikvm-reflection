using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides an interface to a context to allow it to resolve assemblies.
    /// </summary>
    public interface IAssemblyResolver
    {

        /// <summary>
        /// Attempts to resolve the specified assembly definition given the assembly reference.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        bool TryResolveAssembly(IAssemblyContext context, AssemblyName name, ModuleDef? requestingModule, out AssemblyDef? assembly);

    }

}
