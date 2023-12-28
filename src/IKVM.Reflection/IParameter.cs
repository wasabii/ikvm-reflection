using System.Reflection;

namespace IKVM.Reflection
{

    public interface IParameter
    {

        /// <summary>
        /// Gets the module in which this parameter is defined.
        /// </summary>
        IModule Module { get; }

        /// <summary>
        /// Gets the method in which this parameter is defined.
        /// </summary>
        IMethod Method { get; }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the attributes of the parameter.
        /// </summary>
        ParameterAttributes Attributes { get; }

        /// <summary>
        /// Gets the type of the parameter.
        /// </summary>
        TypeSignature ParameterType { get; }

    }

}
