using System;

using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Compile.Parsing
{

    /// <summary>
    /// Encapsulates access to the compilation state of a field.
    /// </summary>
    public class FieldCompileContext
    {

        readonly TypeCompileContext typeContext;
        readonly IFieldBuilder writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="typeContext"></param>
        /// <param name="writer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FieldCompileContext(TypeCompileContext typeContext, IFieldBuilder writer)
        {
            this.typeContext = typeContext ?? throw new ArgumentNullException(nameof(typeContext));
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        /// <summary>
        /// Gets the current type context.
        /// </summary>
        public TypeCompileContext TypeContext => typeContext;

        /// <summary>
        /// Gets the field writer.
        /// </summary>
        public IFieldBuilder Writer => writer;

    }

}
