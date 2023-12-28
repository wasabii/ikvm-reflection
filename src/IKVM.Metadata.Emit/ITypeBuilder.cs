namespace IKVM.Metadata.Emit
{

    /// <summary>
    /// Provides access to writing to an type.
    /// </summary>
    public interface ITypeBuilder
    {

        /// <summary>
        /// Gets a reference to the type being written to.
        /// </summary>
        ITypeHandle Type { get; }

        /// <summary>
        /// Creates a new field and returns the writer.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IFieldBuilder CreateField(string name);

        /// <summary>
        /// Creates a new method and returns the writer.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IMethodBuilder CreateMethod(string name);

    }

}
