using System.Reflection.Metadata;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a member that can be assigned a constant value, and can be referenced by a HasConstant coded index.
    /// </summary>
    public interface IHasConstant : IMetadataMember, INameProvider, IModuleProvider
    {

        /// <summary>
        /// Gets a constant that is assigned to the member.
        /// </summary>
        Constant? Constant { get; }

    }

}
