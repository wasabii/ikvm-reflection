using System;
using System.Collections.Concurrent;
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
    internal class MetadataAssembly : IAssembly, IDisposable
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

        readonly IAssemblyContext context;
        readonly IMetadataFileResolver resolver;

        AssemblyName? name;
        MetadataModule manifestModule;
        MetadataModule[] modules;
        MetadataType[]? types;

        readonly ConcurrentDictionary<(string, string), MetadataType?> typesByName = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal MetadataAssembly(IAssemblyContext context, PEReader pe, MetadataReader reader, string location, IMetadataFileResolver resolver)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.resolver = resolver;
            this.modules = new MetadataModule[reader.AssemblyFiles.Count + 1];
            this.modules[0] = manifestModule = new MetadataModule(this, pe, reader, location);

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

        /// <summary>
        /// Reference to the hosting assembly context.
        /// </summary>
        internal IAssemblyContext Context => context;

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public AssemblyName Name => LazyUtil.Get(ref name, () => manifestModule.Reader.GetAssemblyDefinition().GetAssemblyName());

        /// <summary>
        /// Gets the modules of the assembly.
        /// </summary>
        internal IReadOnlyList<MetadataModule> Modules => modules;

        /// <summary>
        /// Gets the modules of the assembly.
        /// </summary>
        IReadOnlyList<IModule> IAssembly.Modules => Modules;

        /// <summary>
        /// Attempts to resolve the specified module by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        internal bool TryFindModule(string name, out MetadataModule? module)
        {
            module = Modules.FirstOrDefault(i => i.Name == name);
            return module != null;
        }

        /// <summary>
        /// Attempts to resolve the specified module by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        bool IAssembly.TryFindModule(string name, out IModule? module)
        {
            var r = TryFindModule(name, out var m);
            module = m;
            return r;
        }

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        internal IReadOnlyList<MetadataType> Types => LazyUtil.Get(ref types, LoadTypes);

        /// <summary>
        /// Gets the types of the assembly.
        /// </summary>
        IReadOnlyList<IType> IAssembly.Types => Types;

        /// <summary>
        /// Attempts to find the specified type by name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal bool TryFindType(string namespaceName, string name, out MetadataType? type)
        {
            return (type = typesByName.GetOrAdd((namespaceName, name), _ => FindTypeImpl(_.Item1, _.Item2))) != null;
        }

        /// <summary>
        /// Attempts to find the specified type by name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IAssembly.TryFindType(string namespaceName, string name, out IType? type)
        {
            var r = TryFindType(namespaceName, name, out var t);
            type = t;
            return r;
        }

        /// <summary>
        /// Attempts to resolve the specified type by name.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        MetadataType? FindTypeImpl(string namespaceName, string name)
        {
            foreach (var module in modules)
                if (module.TryFindType(namespaceName, name, out var t))
                    return t;

            return null;
        }

        /// <summary>
        /// Loads the types of the assembly.
        /// </summary>
        /// <returns></returns>
        MetadataType[] LoadTypes()
        {
            var l = new MetadataType[modules.Sum(i => i.Types.Length)];

            int i = 0;
            foreach (var module in modules)
            {
                module.Types.CopyTo(l, i);
                i += module.Types.Length;
            }

            return l;
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
