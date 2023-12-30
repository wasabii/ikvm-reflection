using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a module either being written or loaded from the context.
    /// </summary>
    public abstract class ModuleDef : IHasCustomAttributes
    {

        readonly ConcurrentDictionary<(string, string), TypeDef?> typeByNameMap = new();

        /// <summary>
        /// Gets the custom attributes applied to the module.
        /// </summary>
        public virtual IReadOnlyList<CustomAttribute> CustomAttributes => Array.Empty<CustomAttribute>();

        /// <summary>
        /// Gets the reference to the assembly.
        /// </summary>
        public abstract AssemblyDef Assembly { get; }

        /// <summary>
        /// Gets the location of this module.
        /// </summary>
        public virtual string? Location => null;

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the MVID of the module.
        /// </summary>
        public abstract Guid Mvid { get; }

        /// <summary>
        /// Returns all the types defined within this module.
        /// </summary>
        public virtual IReadOnlyList<TypeDef> Types => Array.Empty<TypeDef>();

        /// <summary>
        /// Attempts to find the specified type by name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool TryFindType(string namespaceName, string name, out TypeDef? type) => (type = typeByNameMap.GetOrAdd((namespaceName, name), _ => Types.FirstOrDefault(i => i.Namespace == _.Item1 && i.Name == _.Item2))) != null;

    }

}
