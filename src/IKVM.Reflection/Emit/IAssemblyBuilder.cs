using System;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Supports building an assembly.
    /// </summary>
    public interface IAssemblyBuilder
    {

        /// <summary>
        /// Gets a reference to the assembly being built.
        /// </summary>
        IAssemblyRef Assembly { get; }

        /// <summary>
        /// Creates a new module and returns the builder.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mvid"></param>
        /// <returns></returns>
        IModuleBuilder CreateModule(string name, Guid mvid);

    }

}
