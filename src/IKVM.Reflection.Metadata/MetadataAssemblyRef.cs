using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Holds a reference to an assembly derived from metadata.
    /// </summary>
    internal class MetadataAssemblyRef : IAssemblyRef
    {

        readonly MetadataModule module;
        readonly AssemblyReference reference;

        AssemblyDef? resolved;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="handle"></param>
        public MetadataAssemblyRef(MetadataModule module, AssemblyReferenceHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.reference = this.module.Reader.GetAssemblyReference(handle);
        }

        /// <summary>
        /// Gets the name of the referenced assembly.
        /// </summary>
        public AssemblyName Name => reference.GetAssemblyName();

        /// <summary>
        /// Attempts to resolve the assembly.
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool TryResolve(out AssemblyDef? def)
        {
            // check for cached lookup
            def = resolved;
            if (def != null)
                return true;

            // check the current assembly
            if (reference.GetAssemblyName() == module.Assembly.Name)
            {
                resolved = def = module.Assembly;
                return true;
            }

            // dispatch to assembly context and cache result
            var r = module.Assembly.Context.TryResolveAssembly(Name, module, out def);
            resolved = def;
            return r;
        }

    }

}
