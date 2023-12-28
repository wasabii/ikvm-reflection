using System.Reflection;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Provides access to writing to an module.
    /// </summary>
    public interface IModuleBuilder
    {

        /// <summary>
        /// Gets a reference to the module being written to.
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Creates a new type and returns the writer.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="baseType"></param>
        /// <returns></returns>
        ITypeBuilder CreateType(string namespaceName, string name, TypeAttributes attributes, TypeSignature baseType);

    }

}
