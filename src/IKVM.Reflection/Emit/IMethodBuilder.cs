using System.Reflection;

namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Provides access to writing to an method.
    /// </summary>
    public interface IMethodBuilder
    {

        /// <summary>
        /// Gets a reference to the method being written to.
        /// </summary>
        IMethod Method { get; }

        /// <summary>
        /// Creates a new parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        IParameterBuilder CreateParameter(string name, ParameterAttributes attributes, TypeSignature parameterType);

    }

}
