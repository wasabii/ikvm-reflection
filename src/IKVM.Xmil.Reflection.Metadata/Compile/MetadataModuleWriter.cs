using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using IKVM.Xmil.Compile.Handles;
using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Reflection.Metadata.Compile
{

    /// <summary>
    /// Handles writing to a module using System.Reflection.Metadata.
    /// </summary>
    public class MetadataModuleWriter : IModuleBuilder
    {

        readonly MetadataBuilder builder;
        readonly MetadataModuleBuilderHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="handle"></param>
        public MetadataModuleWriter(MetadataBuilder builder, ModuleDefinitionHandle handle)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
            this.handle = new MetadataModuleBuilderHandle(handle);
        }

        /// <inheritdoc />
        public IModuleHandle Module => handle;

        /// <inheritdoc />
        public ITypeBuilder CreateType(string namespaceName, string name, TypeAttributes attributes)
        {
            return new MetadataTypeBuilder(builder,
                builder.AddTypeDefinition(
                    attributes,
                    builder.GetOrAddString(namespaceName),
                    builder.GetOrAddString(name),
                    null,
                    null,
                    null));
        }

    }

}
