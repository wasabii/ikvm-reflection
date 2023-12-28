namespace IKVM.Metadata.Emit
{

    /// <summary>
    /// Provides access to writing to an field.
    /// </summary>
    public interface IFieldBuilder
    {

        /// <summary>
        /// Gets a reference to the field being written to.
        /// </summary>
        IFieldHandle Field { get; }

    }

}
