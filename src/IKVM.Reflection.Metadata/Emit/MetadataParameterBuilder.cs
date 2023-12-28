using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace IKVM.Reflection.Emit.Metadata
{

    public class MetadataParameterBuilder : IParameterBuilder, IParameter
    {

        readonly MetadataMethodBuilder method;
        readonly string name;
        readonly ParameterAttributes attributes;
        readonly TypeSignature parameterType;
        readonly int rowNumber;

        ParameterHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="parameterType"></param>
        public MetadataParameterBuilder(MetadataMethodBuilder method, string name, ParameterAttributes attributes, TypeSignature parameterType, int rowNumber)
        {
            this.method = method ?? throw new ArgumentNullException(nameof(method));
            this.name = name ?? throw new ArgumentNullException(nameof(method));
            this.attributes = attributes;
            this.parameterType = parameterType ?? throw new ArgumentNullException(nameof(parameterType));
        }

        /// <summary>
        /// Gets the row number of the parameter.
        /// </summary>
        public int RowNumber => rowNumber;

        /// <inheritdoc />
        public IParameter Parameter => this;

        /// <inheritdoc />
        public string Name => name;

        /// <inheritdoc />
        public TypeSignature ParameterType => parameterType;

        /// <summary>
        /// Flushes the parameter to the underlying metadata writer.
        /// </summary>
        /// <param name="sequenceNumber"></param>
        internal void Flush(int sequenceNumber)
        {
            if (handle.IsNil)
            {
                handle = method.Type.Module.Assembly.MetadataBuilder.AddParameter(attributes, method.Type.Module.Assembly.MetadataBuilder.GetOrAddString(name), sequenceNumber);
                Debug.Assert(MetadataTokens.GetRowNumber(handle) == rowNumber);
            }
        }

    }

}