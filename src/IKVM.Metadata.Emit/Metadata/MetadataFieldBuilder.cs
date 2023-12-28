using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace IKVM.Metadata.Emit.Metadata
{

    /// <summary>
    /// Handles writing to a field using System.Reflection.Metadata.
    /// </summary>
    public class MetadataFieldBuilder : IFieldBuilder
    {

        readonly MetadataBuilder builder;
        readonly MetadataFieldBuilderHandle field;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="handle"></param>
        public MetadataFieldBuilder(MetadataBuilder builder, FieldDefinitionHandle handle)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
            field = new MetadataFieldBuilderHandle(handle);
        }

        /// <inheritdoc />
        public IFieldHandle Field => field;

    }

}