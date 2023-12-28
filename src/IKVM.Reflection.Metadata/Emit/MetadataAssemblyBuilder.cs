using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Threading;

using IKVM.Reflection.Metadata.Emit;

namespace IKVM.Reflection.Emit.Metadata
{

    /// <summary>
    /// Handles writing to an assembly using System.Reflection.Metadata.
    /// </summary>
    public class MetadataAssemblyBuilder : IAssemblyBuilder, IAssemblyRef
    {

        readonly string name;
        readonly Version version;
        readonly string culture;
        readonly AssemblyFlags flags;
        readonly AssemblyHashAlgorithm hashAlgorithm;
        readonly List<MetadataModuleBuilder> modules = new();

        readonly MetadataBuilder mdBuilder;
        readonly BlobBuilder ilBuilder;
        readonly AssemblyDefinitionHandle handle;

        int nextTypeId = 1;
        int nextFieldId = 2;
        int nextMethodId = 2;
        int nextParameterId = 2;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="culture"></param>
        /// <param name="flags"></param>
        /// <param name="hashAlgorithm"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataAssemblyBuilder(string name, Version version, string culture, AssemblyFlags flags, AssemblyHashAlgorithm hashAlgorithm)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.version = version ?? throw new ArgumentNullException(nameof(version));
            this.culture = culture ?? throw new ArgumentNullException(nameof(culture));
            this.flags = flags;
            this.hashAlgorithm = hashAlgorithm;

            mdBuilder = new MetadataBuilder();
            ilBuilder = new BlobBuilder();

            handle = mdBuilder.AddAssembly(mdBuilder.GetOrAddString(name), version, mdBuilder.GetOrAddString(culture), new BlobHandle(), (System.Reflection.AssemblyFlags)flags, (System.Reflection.AssemblyHashAlgorithm)hashAlgorithm);
        }

        /// <summary>
        /// Gets the associated metadata builder.
        /// </summary>
        public MetadataBuilder MetadataBuilder => mdBuilder;

        /// <inheritdoc />
        public IAssemblyRef Assembly => this;

        /// <inheritdoc />
        public string Name => name;

        /// <inheritdoc />
        public Version Version => version;

        /// <inheritdoc />
        public string Culture => culture;

        /// <inheritdoc />
        public AssemblyFlags Flags => flags;

        /// <inheritdoc />
        public AssemblyHashAlgorithm HashAlgorithm => hashAlgorithm;

        /// <inheritdoc />
        public IModuleBuilder CreateModule(string name, Guid mvid)
        {
            var m = new MetadataModuleBuilder(this, name, mvid);
            modules.Add(m);
            return m;
        }

        /// <summary>
        /// Flushes the declared assembly information to the metadata writer.
        /// </summary>
        internal void Flush()
        {
            foreach (var module in modules)
                module.Flush();
        }

        /// <summary>
        /// Writes the assembly file.
        /// </summary>
        /// <param name="stream"></param>
        public void Save(Stream stream, MetadataSaveOptions options)
        {
            Flush();

            var peHeaderBuilder = new PEHeaderBuilder(machine: (Machine)options.Machine, imageBase: options.ImageBase, subsystem: (Subsystem)options.Subsystem, dllCharacteristics: (DllCharacteristics)options.DllCharacteristics, imageCharacteristics: (Characteristics)options.ImageCharacteristics);
            var peBuilder = new ManagedPEBuilder(peHeaderBuilder, new MetadataRootBuilder(mdBuilder), ilBuilder, flags: (CorFlags)options.CorFlags);

            // write PE contents to blob
            var peBlob = new BlobBuilder();
            peBuilder.Serialize(peBlob);

            // write blob to output
            peBlob.WriteContentTo(stream);
        }

        /// <summary>
        /// Gets the next available type row.
        /// </summary>
        /// <returns></returns>
        internal int GetNextTypeId() => Interlocked.Increment(ref nextTypeId);

        /// <summary>
        /// Gets the next available field row.
        /// </summary>
        /// <returns></returns>
        internal int GetNextFieldId() => Interlocked.Increment(ref nextFieldId);

        /// <summary>
        /// Gets the next available method row.
        /// </summary>
        /// <returns></returns>
        internal int GetNextMethodId() => Interlocked.Increment(ref nextMethodId);

        /// <summary>
        /// Gets the next available parameter row.
        /// </summary>
        /// <returns></returns>
        internal int GetNextParameterId() => Interlocked.Increment(ref nextParameterId);

    }

}
