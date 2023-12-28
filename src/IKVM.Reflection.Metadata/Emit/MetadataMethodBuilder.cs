using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

using IKVM.Reflection.Metadata.Emit;

namespace IKVM.Reflection.Emit.Metadata
{

    /// <summary>
    /// Handles building a method using System.Reflection.Metadata.
    /// </summary>
    public class MetadataMethodBuilder : IMethodBuilder, IMethodRef
    {

        readonly MetadataTypeBuilder type;
        readonly string name;
        readonly MethodAttributes attributes;
        readonly MethodImplAttributes implAttributes;
        readonly TypeSignature returnType;
        readonly List<MetadataParameterBuilder> parameters = new();
        readonly int rowNumber;

        MethodDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="implAttributes"></param>
        /// <param name="returnType"></param>
        /// <param name="rowNumber"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataMethodBuilder(MetadataTypeBuilder type, string name, MethodAttributes attributes, MethodImplAttributes implAttributes, TypeSignature returnType, int rowNumber)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.attributes = attributes;
            this.implAttributes = implAttributes;
            this.returnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
            this.rowNumber = rowNumber;
        }

        /// <summary>
        /// Gets the row number of the method.
        /// </summary>
        public int RowNumber => rowNumber;

        /// <summary>
        /// Gets the builder for the parent type.
        /// </summary>
        public MetadataTypeBuilder Type => type;

        /// <inheritdoc />
        public IMethodRef Method => this;

        /// <inheritdoc />
        public string Name => name;

        /// <inheritdoc />
        public MethodAttributes Attributes => attributes;

        /// <inheritdoc />
        public MethodImplAttributes ImplAttributes => implAttributes;

        /// <inheritdoc />
        public TypeSignature ReturnType => returnType;

        /// <inheritdoc />
        public IReadOnlyList<IParameterBuilder> Parameters => parameters;

        /// <inheritdoc />
        IReadOnlyList<IParameter> IMethodRef.Parameters => parameters.AsReadOnly();

        /// <inheritdoc />
        public IParameterBuilder CreateParameter(string name, ParameterAttributes attributes, TypeSignature parameterType)
        {
            if (handle.IsNil == false)
                throw new InvalidOperationException("Method builder is already flushed.");

            var p = new MetadataParameterBuilder(this, name, attributes, parameterType, type.Module.Assembly.GetNextParameterId());
            parameters.Add(p);
            return p;
        }

        /// <summary>
        /// Flushes the method to the underlying metadata writer.
        /// </summary>
        internal void Flush()
        {
            var i = 0;
            foreach (var parameter in parameters)
                parameter.Flush(++i);

            if (handle.IsNil)
            {
                handle = type.Module.Assembly.MetadataBuilder.AddMethodDefinition(attributes, implAttributes, type.Module.Assembly.MetadataBuilder.GetOrAddString(name), MetadataTypeSignatureConverter.Convert(returnType), 0, parameters[0].RowNumber);
                Debug.Assert(MetadataTokens.GetRowNumber(handle) == rowNumber);
            }
        }

    }

}
