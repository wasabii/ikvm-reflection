using System;

using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Compile.Parsing
{

    /// <summary>
    /// Encapsulates access to the compilation state of a module.
    /// </summary>
    public class ModuleCompileContext
    {

        readonly AssemblyCompileContext assemblyContext;
        readonly IModuleBuilder writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="assemblyContext"></param>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ModuleCompileContext(AssemblyCompileContext assemblyContext, IModuleBuilder writer)
        {
            this.assemblyContext = assemblyContext ?? throw new ArgumentNullException(nameof(assemblyContext));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        /// <summary>
        /// Gets the current assembly context.
        /// </summary>
        public AssemblyCompileContext AssemblyContext => assemblyContext;

        /// <summary>
        /// Gets the module writer.
        /// </summary>
        public IModuleBuilder Writer => writer;

    }

}
