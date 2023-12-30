using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Represents a parameter loaded from metadata.
    /// </summary>
    internal class MetadataParameter : IParameter
    {

        readonly MetadataMethod method;
        readonly Parameter parameter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="parameter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataParameter(MetadataMethod method, ParameterHandle parameter)
        {
            this.method = method ?? throw new ArgumentNullException(nameof(method));
            this.parameter = method.Module.Reader.GetParameter(parameter);
        }

        /// <summary>
        /// Gets the module in which this parameter is defined.
        /// </summary>
        public MetadataModule Module => method.Module;

        ModuleDef IParameter.Module => Module;

        /// <summary>
        /// Gets the method on which this parameter is defined.
        /// </summary>
        public MetadataMethod Method => method;

        IMethod IParameter.Method => Method;

        /// <inheritdoc />
        public string Name => Module.Reader.GetString(parameter.Name);

        /// <inheritdoc />
        public ParameterAttributes Attributes => parameter.Attributes;

        /// <inheritdoc />
        public TypeSig ParameterType => throw new NotImplementedException();

    }

}
