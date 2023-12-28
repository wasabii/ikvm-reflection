using System.Reflection.Metadata;

using IKVM.Xmil.Compile.Handles;

namespace IKVM.Xmil.Reflection.Metadata.Compile
{

    /// <summary>
    /// Describes a handle to a method that is in the process of being built.
    /// </summary>
    public class MetadataMethodBuilderHandle : IMethodHandle
    {

        readonly MethodDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public MetadataMethodBuilderHandle(MethodDefinitionHandle handle)
        {
            this.handle = handle;
        }

        public MethodDefinitionHandle Handle => handle;

    }

}