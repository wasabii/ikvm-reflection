using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a resolved definition of an assembly either being written or loaded from the context.
    /// </summary>
    public abstract class AssemblyDef
    {

        readonly ConcurrentDictionary<string, ModuleDef?> moduleByName = new();
        readonly ConcurrentDictionary<(string, string), TypeDef?> typeByName = new();

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public abstract AssemblyName Name { get; }

        /// <summary>
        /// Gets the modules of the assembly.
        /// </summary>
        public virtual IReadOnlyList<ModuleDef> Modules => Array.Empty<ModuleDef>();

        /// <summary>
        /// Attempts to find the module with the given name on the assembly.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public virtual bool TryFindModule(string name, out ModuleDef? module) => (module = moduleByName.GetOrAdd(name, _ => Modules.FirstOrDefault(i => i.Name == _))) != null;

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        public virtual IReadOnlyList<TypeDef> Types => Array.Empty<TypeDef>();

        /// <summary>
        /// Attempts to find the type with the given name on the assembly.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool TryFindType(string namespaceName, string name, out TypeDef? type) => (type = typeByName.GetOrAdd((namespaceName, name), _ => Types.FirstOrDefault(i => i.Namespace == _.Item1 && i.Name == _.Item2))) != null;

    }

}
