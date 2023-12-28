using System;

using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Compile.Parsing
{

    /// <summary>
    /// Encapsulates access to the compilation state of an assembly.
    /// </summary>
    public class AssemblyCompileContext
    {

        readonly CompileContext context;
        readonly IAssemblyBuilder writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AssemblyCompileContext(CompileContext context, IAssemblyBuilder writer)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        /// <summary>
        /// Gets the current assembly context.
        /// </summary>
        public CompileContext Context => context;

        /// <summary>
        /// Gets the module writer.
        /// </summary>
        public IAssemblyBuilder Writer => writer;

    }

}
