using System;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Base type for assembly definitions loaded from metadata.
    /// </summary>
    internal abstract class MetadataAssemblyDefBase : AssemblyDef
    {

        readonly IAssemblyContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MetadataAssemblyDefBase(IAssemblyContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Reference to the hosting assembly context.
        /// </summary>
        public IAssemblyContext Context => context;

    }

}
