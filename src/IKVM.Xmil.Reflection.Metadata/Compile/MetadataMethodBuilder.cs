﻿using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using IKVM.Xmil.Compile.Handles;
using IKVM.Xmil.Compile.Writing;

namespace IKVM.Xmil.Reflection.Metadata.Compile
{

    /// <summary>
    /// Handles writing to a type using System.Reflection.Metadata.
    /// </summary>
    public class MetadataMethodBuilder : IMethodBuilder
    {

        readonly MetadataBuilder builder;
        readonly MetadataMethodBuilderHandle type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="handle"></param>
        public MetadataMethodBuilder(MetadataBuilder builder, MethodDefinitionHandle handle)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
            type = new MetadataMethodBuilderHandle(handle);
        }

        /// <inheritdoc />
        public ITypeHandle Type => type;

    }

}