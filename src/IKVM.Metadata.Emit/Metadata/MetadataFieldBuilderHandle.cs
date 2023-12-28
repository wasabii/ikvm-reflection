using System.Reflection.Metadata;

namespace IKVM.Metadata.Emit.Metadata
{

    /// <summary>
    /// Describes a handle to a field that is in the process of being built.
    /// </summary>
    public class MetadataFieldBuilderHandle : IFieldHandle
    {

        readonly FieldDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public MetadataFieldBuilderHandle(FieldDefinitionHandle handle)
        {
            this.handle = handle;
        }

        public FieldDefinitionHandle Handle => handle;

    }

}