using System;
using System.IO;

namespace IKVM.Metadata.Emit
{

    /// <summary>
    /// Supports building an assembly.
    /// </summary>
    public interface IAssemblyBuilder
    {

        /// <summary>
        /// Gets a reference to the assembly being built.
        /// </summary>
        IAssemblyHandle Assembly { get; }

        /// <summary>
        /// Creates a new module and returns the builder.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mvid"></param>
        /// <returns></returns>
        IModuleBuilder CreateModule(string name, Guid mvid);

        /// <summary>
        /// Saves the assembly to the specified <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream"></param>
        void Save(Stream stream);

    }

}
