using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

using IKVM.Reflection.Metadata.Emit;

namespace IKVM.Reflection.Emit.Metadata
{

    /// <summary>
    /// Handles writing to a field using System.Reflection.Metadata.
    /// </summary>
    public class MetadataFieldBuilder : IFieldBuilder, IField
    {

        readonly MetadataTypeBuilder type;
        readonly string name;
        readonly FieldAttributes attributes;
        readonly TypeSignature fieldType;
        readonly int rowNumber;

        FieldDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="fieldType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataFieldBuilder(MetadataTypeBuilder type, string name, FieldAttributes attributes, TypeSignature fieldType, int rowNumber)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.attributes = attributes;
            this.fieldType = fieldType ?? throw new ArgumentNullException(nameof(fieldType));
            this.rowNumber = rowNumber;
        }

        /// <summary>
        /// Gets the row number of the field.
        /// </summary>
        public int RowNumber => rowNumber;

        /// <inheritdoc />
        public IField Field => this;

        /// <inheritdoc />
        public string Name => name;

        /// <inheritdoc />
        public FieldAttributes Attributes => attributes;

        /// <inheritdoc />
        public TypeSignature FieldType => fieldType;

        /// <summary>
        /// Flushes the field to the underlying metadata.
        /// </summary>
        public void Flush()
        {
            if (handle.IsNil)
            {
                handle = type.Module.Assembly.MetadataBuilder.AddFieldDefinition(attributes, type.Module.Assembly.MetadataBuilder.GetOrAddString(name), MetadataTypeSignatureConverter.Convert(fieldType));
                Debug.Assert(MetadataTokens.GetRowNumber(handle) == rowNumber);
            }
        }

    }

}