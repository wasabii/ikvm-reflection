using System.Reflection.Metadata;

using IKVM.Xmil.Compile.Handles;

namespace IKVM.Xmil.Reflection.Metadata.Compile
{

    /// <summary>
    /// Describes a handle to a type that is in the process of being built.
    /// </summary>
    public class MetadataTypeBuilderHandle : ITypeHandle
    {

        readonly TypeDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public MetadataTypeBuilderHandle(TypeDefinitionHandle handle)
        {
            this.handle = handle;
        }

        public TypeDefinitionHandle Handle => handle;

    }

}