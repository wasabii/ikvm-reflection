using System.Reflection.PortableExecutable;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Provides an implementation that is capable of resolving assembly files.
    /// </summary>
    public interface IMetadataFileResolver
    {

        /// <summary>
        /// Attempts to resolve a metadata file with the specified name, given the specified requesting module path.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requestingModulePath"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool TryResolve(string name, string requestingModulePath, out MetadataFileResult result);

    }

}