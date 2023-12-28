using System;

using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Compile.Parsing
{

    /// <summary>
    /// Encapsulates access to the compilation state of a module.
    /// </summary>
    public class TypeCompileContext
    {

        readonly ModuleCompileContext moduleContext;
        readonly ITypeBuilder writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="moduleContext"></param>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TypeCompileContext(ModuleCompileContext moduleContext, ITypeBuilder writer)
        {
            this.moduleContext = moduleContext ?? throw new ArgumentNullException(nameof(moduleContext));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        /// <summary>
        /// Gets the current module context.
        /// </summary>
        public ModuleCompileContext ModuleContext => moduleContext;

        /// <summary>
        /// Gets the type writer.
        /// </summary>
        public ITypeBuilder Writer => writer;

    }

}
