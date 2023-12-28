using System;

using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Compile.Parsing
{

    /// <summary>
    /// Encapsulates access to the compilation state of a method.
    /// </summary>
    public class MethodCompileContext
    {

        readonly TypeCompileContext typeContext;
        readonly IMethodBuilder writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="typeContext"></param>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MethodCompileContext(TypeCompileContext typeContext, IMethodBuilder writer)
        {
            this.typeContext = typeContext ?? throw new ArgumentNullException(nameof(typeContext));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        /// <summary>
        /// Gets the current type context.
        /// </summary>
        public TypeCompileContext TypeContext => typeContext;

        /// <summary>
        /// Gets the method writer.
        /// </summary>
        public IMethodBuilder Writer => writer;

    }

}
