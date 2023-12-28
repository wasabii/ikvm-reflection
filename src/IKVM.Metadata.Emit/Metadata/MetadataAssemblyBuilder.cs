using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace IKVM.Metadata.Emit.Metadata
{

    /// <summary>
    /// Handles writing to an assembly using System.Reflection.Metadata.
    /// </summary>
    public class MetadataAssemblyBuilder : IAssemblyBuilder
    {

        readonly MetadataAssemblyBuilderHandle assembly;
        readonly MetadataBuilder metadataBuilder;
        readonly BlobBuilder ilBuilder;
        readonly PEHeaderBuilder peHeaderBuilder;
        readonly ManagedPEBuilder peBuilder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MetadataAssemblyBuilder(Machine machine, ulong imageBase, Subsystem subsystem, DllCharacteristics dllCharacteristics, Characteristics imageCharacteristics)
        {
            ilBuilder = new BlobBuilder();
            metadataBuilder = new MetadataBuilder();
            peHeaderBuilder = new PEHeaderBuilder(machine: machine, imageBase: imageBase, subsystem: subsystem, dllCharacteristics: dllCharacteristics, imageCharacteristics: imageCharacteristics);
            peBuilder = new ManagedPEBuilder(peHeaderBuilder, new MetadataRootBuilder(metadataBuilder), ilBuilder, flags: CorFlags.ILOnly);
            assembly = new MetadataAssemblyBuilderHandle(this);
        }

        /// <inheritdoc />
        public IAssemblyHandle Assembly => assembly;

        /// <inheritdoc />
        public IModuleBuilder CreateModule(string name, Guid mvid)
        {
            return new MetadataModuleBuilder(metadataBuilder, metadataBuilder.AddModule(0, metadataBuilder.GetOrAddString(name), metadataBuilder.GetOrAddGuid(mvid), default, default));
        }

        /// <summary>
        /// Writes the assembly file.
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream)
        {
            var peBlob = new BlobBuilder();
            peBuilder.Serialize(peBlob);
            peBlob.WriteContentTo(stream);
        }

    }

}
