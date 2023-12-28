using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using IKVM.Xmil.Compile.Handles;
using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Reflection.Metadata.Compile
{

    /// <summary>
    /// Handles writing to a type using System.Reflection.Metadata.
    /// </summary>
    public class MetadataTypeBuilder : ITypeBuilder
    {

        readonly MetadataBuilder builder;
        readonly MetadataTypeBuilderHandle type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public MetadataTypeBuilder(MetadataBuilder builder, TypeDefinitionHandle handle)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
            type = new MetadataTypeBuilderHandle(handle);
        }

        /// <inheritdoc />
        public ITypeHandle Type => type;

        /// <inheritdoc />
        public IFieldBuilder CreateField(string name)
        {
            return new MetadataFieldBuilder(builder,builder.AddFieldDefinition());
        }

        /// <inheritdoc />
        public IMethodBuilder CreateMethod(string name)
        {
            return new MetadataMethodBuilder(builder, builder.AddMethodDefinition());
        }

    }

}