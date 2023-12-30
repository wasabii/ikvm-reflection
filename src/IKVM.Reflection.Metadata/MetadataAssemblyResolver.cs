using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Provides resolution of assemblies from a combination of direct assembly paths and assembly directory paths.
    /// </summary>
    public class MetadataAssemblyResolver : IAssemblyResolver
    {

        readonly string[] assemblyPaths;
        readonly string[] assemblyLibPaths;
        readonly IMetadataFileResolver fileResolver;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assemblyPaths"></param>
        /// <param name="assemblyLibPaths"></param>
        /// <param name="fileResolver"></param>
        public MetadataAssemblyResolver(string[] assemblyPaths, string[] assemblyLibPaths, IMetadataFileResolver? fileResolver = null)
        {
            Array.Copy(assemblyPaths, this.assemblyPaths = new string[assemblyPaths?.Length ?? 0], assemblyPaths?.Length ?? 0);
            Array.Copy(assemblyLibPaths, this.assemblyLibPaths = new string[assemblyLibPaths?.Length ?? 0], assemblyLibPaths?.Length ?? 0);
            this.fileResolver = fileResolver ?? new DefaultMetadataFileResolver();
        }

        /// <summary>
        /// Attempts to resolve an assembly with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requestingModule"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public bool TryResolveAssembly(IAssemblyContext context, AssemblyName name, ModuleDef? requestingModule, out AssemblyDef? assembly)
        {
            // check direct file references
            foreach (var path in assemblyPaths)
                if (TryLoad(context, name, path, out assembly))
                    return true;

            // check indirect file library paths
            foreach (var libPath in assemblyLibPaths)
                if (TryLoad(context, name, Path.Combine(libPath, name.Name + ".dll"), out assembly))
                    return true;

            assembly = null;
            return false;
        }

        /// <summary>
        /// Attempts to load an assembly with the given name at the given path.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="asm"></param>
        /// <returns></returns>
        bool TryLoad(IAssemblyContext context, AssemblyName name, string path, out AssemblyDef? asm)
        {
            asm = null;

            if (File.Exists(path) == false)
                return false;

            if (TryGetAssemblyName(path, out var n) == false || AssemblyName.ReferenceMatchesDefinition(n, name) == false)
                return false;

            try
            {
                asm = MetadataAssembly.Load(context, path, fileResolver);
                return true;
            }
            catch (BadImageFormatException)
            {
                return false;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to read a <see cref="AssemblyName"/> from a file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool TryGetAssemblyName(string path, out AssemblyName? name)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            name = null;

            try
            {
#if NET8_0_OR_GREATER
                name = MetadataReader.GetAssemblyName(path);
#else
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1, useAsync: false);
                using var pe = new PEReader(fs);
                if (pe.HasMetadata == false)
                    return false;

                var md = pe.GetMetadataReader();
                name = md.GetAssemblyDefinition().GetAssemblyName();
#endif
                return true;
            }
            catch (BadImageFormatException)
            {

            }
            catch (FileNotFoundException)
            {

            }

            return false;
        }

    }

}
