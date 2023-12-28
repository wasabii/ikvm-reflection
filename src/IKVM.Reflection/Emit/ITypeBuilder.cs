using System.Reflection;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Provides access to writing to an type.
    /// </summary>
    public interface ITypeBuilder
    {

        /// <summary>
        /// Gets a reference to the type being written to.
        /// </summary>
        IType Type { get; }

        /// <summary>
        /// Creates a new field.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        IFieldBuilder CreateField(string name, FieldAttributes attributes, TypeSignature signature);

        /// <summary>
        /// Creates a new method.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="implAttributes"></param>
        /// <param name="returnType"></param>
        /// <returns></returns>
        IMethodBuilder CreateMethod(string name, MethodAttributes attributes, MethodImplAttributes implAttributes, TypeSignature returnType);

    }

}
