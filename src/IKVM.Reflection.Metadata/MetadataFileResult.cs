using System.Reflection.PortableExecutable;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Describes the result of resolving a metadata file.
    /// </summary>
    /// <param name="PE"></param>
    /// <param name="Location"></param>
    public record struct MetadataFileResult(PEReader PE, string Location);

}
