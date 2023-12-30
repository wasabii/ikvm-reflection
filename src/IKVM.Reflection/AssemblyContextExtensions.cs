using System.Reflection;

namespace IKVM.Reflection
{

    public static class AssemblyContextExtensions
    {

        /// <summary>
        /// Attempts to resolve an assembly with the specified name.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="name"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static bool TryResolveAssembly(this IAssemblyContext self, string name, out AssemblyDef? assembly)
        {
            return self.TryResolveAssembly(new AssemblyName(name), null, out assembly);
        }

        /// <summary>
        /// Attempts to resolve the type with the specified name.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="assemblyName"></param>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool TryResolveType(this IAssemblyContext self, string assemblyName, string namespaceName, string name, out TypeDef? type)
        {
            return self.TryResolveType(new AssemblyName(assemblyName), namespaceName, name, null, out type);
        }

    }

}
