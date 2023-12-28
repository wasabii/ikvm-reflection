using System;

using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Compile.Parsing
{
    /// <summary>
    /// Encapsulates access to the compilation state.
    /// </summary>
    public class CompileContext
    {

        readonly IAssemblyFactory writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CompileContext(IAssemblyFactory writer)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        /// <summary>
        /// Gets the writer.
        /// </summary>
        public IAssemblyFactory Writer => writer;

    }

}
