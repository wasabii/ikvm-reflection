using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to an assembly.
    /// </summary>
    public abstract class AssemblyRef
    {

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public abstract AssemblyName Name { get; }

        /// <summary>
        /// Attempts to resolve the assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public abstract bool TryResolve(out AssemblyDef? assembly);

    }

}
