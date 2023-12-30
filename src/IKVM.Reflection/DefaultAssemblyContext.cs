using System;
using System.Collections.Concurrent;
using System.Reflection;

using IKVM.Reflection.Emit;

namespace IKVM.Reflection
{

    /// <summary>
    /// Base implementation of <see cref="IAssemblyContext"/>.
    /// </summary>
    public class DefaultAssemblyContext : IAssemblyContext
    {

        readonly AssemblyContextOptions options;
        readonly IAssemblyResolver[] resolvers;
        readonly ConcurrentDictionary<AssemblyName, AssemblyDef?> assemblyByName = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="resolvers"></param>
        public DefaultAssemblyContext(AssemblyContextOptions options, IAssemblyResolver[] resolvers)
        {
            this.options = new AssemblyContextOptions(options ?? throw new ArgumentNullException(nameof(options)));
            Array.Copy(resolvers, this.resolvers = new IAssemblyResolver[resolvers.Length], resolvers.Length);
        }

        /// <summary>
        /// Gets the options of this context.
        /// </summary>
        public AssemblyContextOptions Options => options;

        /// <summary>
        /// Attempts to resolve an assembly with the given assembly name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <returns></returns>
        public bool TryResolveAssembly(AssemblyName name, ModuleDef? requestingModule, out AssemblyDef? assembly)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));

            assembly = assemblyByName.GetOrAdd(name, _ => ResolveAssemblyImpl(_, requestingModule));
            return assembly != null;
        }

        /// <summary>
        /// Attempts to resolve the assembly through the resolvers.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <returns></returns>
        AssemblyDef? ResolveAssemblyImpl(AssemblyName name, ModuleDef? requestingModule)
        {
            foreach (var resolver in resolvers)
                if (resolver.TryResolveAssembly(this, name, requestingModule, out var h))
                    return h;

            return null;
        }

        /// <summary>
        /// Attempts to resolve the type with the given name.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool TryResolveType(AssemblyName assemblyName, string namespaceName, string name, ModuleDef? requestingModule, out TypeDef? type)
        {
            type = null;

            if (TryResolveAssembly(assemblyName, requestingModule, out var assembly) && assembly != null)
                if (assembly.TryFindType(namespaceName, name, out type) && type != null)
                    return true;

            return false;
        }

        /// <summary>
        /// Creates a new assembly within the context.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IAssemblyBuilder CreateAssembly(AssemblyName name)
        {
            throw new NotImplementedException();
        }

    }

}
