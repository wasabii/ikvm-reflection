using System;
using System.IO;
using System.Reflection.PortableExecutable;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Resolve that attempts to load relative modules to a given requesting module path.
    /// </summary>
    public class DefaultMetadataFileResolver : IMetadataFileResolver
    {

        /// <summary>
        /// Attempts to resolve the given file name given the specified requesting module path.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requestingModulePath"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool TryResolve(string name, string requestingModulePath, out MetadataFileResult file)
        {
            if (name is null)
                throw new ArgumentNullException(nameof(name));
            if (requestingModulePath is null)
                throw new ArgumentNullException(nameof(requestingModulePath));

            file = default;

            try
            {
                // check that parent directory exists
                var basePath = Path.GetDirectoryName(requestingModulePath);
                if (Directory.Exists(basePath) == false)
                    return false;

                // check that module path exists
                var path = Path.Combine(basePath, name);
                if (File.Exists(path) == false)
                    return false;

                // load new module
                var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 1, useAsync: false);
                var pe = new PEReader(fs);

                // return loaded module
                file = new MetadataFileResult(pe, path);
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