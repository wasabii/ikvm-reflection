using System.Reflection;

namespace IKVM.Metadata.Emit
{

    /// <summary>
    /// Provides access to writing to an module.
    /// </summary>
    public interface IModuleBuilder
    {

        /// <summary>
        /// Gets a reference to the module being written to.
        /// </summary>
        IModuleHandle Module { get; }

        /// <summary>
        /// Creates a new type and returns the writer.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        ITypeBuilder CreateType(string namespaceName, string name, TypeAttributes attributes);

    }

}
