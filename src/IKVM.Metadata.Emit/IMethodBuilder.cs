namespace IKVM.Metadata.Emit
{

    /// <summary>
    /// Provides access to writing to an method.
    /// </summary>
    public interface IMethodBuilder
    {

        /// <summary>
        /// Gets a reference to the method being written to.
        /// </summary>
        IMethodHandle Method { get; }

    }

}
