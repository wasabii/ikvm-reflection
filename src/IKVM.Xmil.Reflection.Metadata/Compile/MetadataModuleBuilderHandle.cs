using System.Reflection.Metadata;
using IKVM.Xmil.Compile.Handles;

namespace IKVM.Xmil.Reflection.Metadata.Compile
{

    /// <summary>
    /// Describes a handle to a module that is in the process of being built.
    /// </summary>
    public class MetadataModuleBuilderHandle : IModuleHandle
    {

        readonly ModuleDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public MetadataModuleBuilderHandle(ModuleDefinitionHandle handle)
        {
            this.handle = handle;
        }

        public ModuleDefinitionHandle Handle => handle;

    }

}