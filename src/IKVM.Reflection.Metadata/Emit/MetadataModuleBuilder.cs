using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Emit.Metadata
{

    /// <summary>
    /// Handles writing to a module using System.Reflection.Metadata.
    /// </summary>
    public class MetadataModuleBuilder : IModuleBuilder, IModuleRef
    {

        readonly MetadataAssemblyBuilder assembly;
        readonly string name;
        readonly Guid mvid;
        readonly List<MetadataTypeBuilder> types = new();

        ModuleDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <param name="mvid"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataModuleBuilder(MetadataAssemblyBuilder assembly, string name, Guid mvid)
        {
            this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.mvid = mvid;

            handle = assembly.MetadataBuilder.AddModule(0, assembly.MetadataBuilder.GetOrAddString(name), assembly.MetadataBuilder.GetOrAddGuid(mvid), default, default);
        }

        /// <summary>
        /// Gets the parent assembly builder.
        /// </summary>
        public MetadataAssemblyBuilder Assembly => assembly;

        /// <inheritdoc />
        public IModuleRef Module => this;

        /// <inheritdoc />
        public string Name => name;

        /// <inheritdoc />
        public Guid Mvid => mvid;

        /// <inheritdoc />
        public ITypeBuilder CreateType(string namespaceName, string name, TypeAttributes attributes, TypeSignature baseType)
        {
            var b = new MetadataTypeBuilder(this, namespaceName, name, attributes, baseType, assembly.GetNextTypeId());
            types.Add(b);
            return b;
        }

        /// <summary>
        /// Flushes the declared module information to the metadata builder.
        /// </summary>
        internal void Flush()
        {
            foreach (var type in types)
                type.Flush();
        }

    }

}
