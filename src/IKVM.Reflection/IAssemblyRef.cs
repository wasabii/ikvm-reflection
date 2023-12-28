using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to an assembly either being written or loaded from the context.
    /// </summary>
    public interface IAssemblyRef
    {

        /// <summary>
        /// Gets the name of the referenced assembly.
        /// </summary>
        AssemblyName Name { get; }

        /// <summary>
        /// Attempts to resolve the reference into a definition.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        bool TryResolve(out IAssembly? assembly);

    }

}
