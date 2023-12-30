using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Represents an assembly definition loaded from metadata.
    /// </summary>
    internal class MetadataAssembly : MetadataAssemblyDefBase, IDisposable
    {

        /// <summary>
        /// Loads a new <see cref="MetadataAssembly"/> given the specified path.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="path"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MetadataAssembly Load(IAssemblyContext context, string path, IMetadataFileResolver resolver)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (resolver is null)
                throw new ArgumentNullException(nameof(resolver));
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            return Load(context, new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1, useAsync: false), path, resolver);
        }

        /// <summary>
        /// Loads a new <see cref="MetadataContext"/> given a stream to the specified manifest module.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="stream"></param>
        /// <param name="location"></param>
        /// <param name="resolver"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MetadataAssembly Load(IAssemblyContext context, Stream stream, string location, IMetadataFileResolver resolver)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));
            if (resolver is null)
                throw new ArgumentNullException(nameof(resolver));

            var pe = new PEReader(stream, PEStreamOptions.Default);
            return new MetadataAssembly(context, pe, pe.GetMetadataReader(), location, resolver);
        }

        readonly IMetadataFileResolver resolver;

        AssemblyName? name;
        MetadataModule manifestModule;
        MetadataModule[] modules;
        MetadataTypeDefBase[]? types;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pe"></param>
        /// <param name="reader"></param>
        /// <param name="location"></param>
        /// <param name="resolver"></param>
        public MetadataAssembly(IAssemblyContext context, PEReader pe, MetadataReader reader, string location, IMetadataFileResolver resolver) :
            base(context)
        {
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));

            // initial module is the current reader
            modules = new MetadataModule[reader.AssemblyFiles.Count + 1];
            modules[0] = manifestModule = new MetadataModule(this, pe, reader, location);

            int i = 1;
            foreach (var h in manifestModule.Reader.AssemblyFiles)
            {
                var f = manifestModule.Reader.GetAssemblyFile(h);
                if (f.ContainsMetadata == false)
                    continue;

                // attempt to resolve module
                if (resolver.TryResolve(manifestModule.Reader.GetString(f.Name), location, out var result) == false)
                    continue;

                // register module
                var rdr = result.PE.GetMetadataReader();
                modules[i++] = new MetadataModule(this, result.PE, rdr, result.Location);
            }
        }

        /// <inheritdoc />
        public override AssemblyName Name => LazyUtil.Get(ref name, () => manifestModule.Reader.GetAssemblyDefinition().GetAssemblyName());

        /// <inheritdoc />
        public override IReadOnlyList<MetadataModule> Modules => modules;

        /// <inheritdoc />
        public override IReadOnlyList<MetadataTypeDefBase> Types => LazyUtil.Get(ref types, LoadTypes);

        /// <summary>
        /// Loads the types of the assembly.
        /// </summary>
        /// <returns></returns>
        MetadataTypeDefBase[] LoadTypes()
        {
            var l = new MetadataTypeDef[modules.Sum(i => i.Types.Length)];

            int i = 0;
            foreach (var module in modules)
            {
                module.Types.CopyTo(l, i);
                i += module.Types.Length;
            }

            return l;
        }

        /// <inheritdoc />
        public override bool TryFindType(string namespaceName, string name, out TypeDef? type)
        {
            // scan modules instead of forcing load of all types

            foreach (var module in modules)
                if (module.TryFindType(namespaceName, name, out type))
                    return true;

            return false;
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            foreach (var module in modules)
                module?.Dispose();
        }

    }

}
