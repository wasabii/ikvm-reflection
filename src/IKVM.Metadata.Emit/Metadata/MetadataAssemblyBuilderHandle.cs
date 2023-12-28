﻿using System;

namespace IKVM.Metadata.Emit.Metadata
{

    /// <summary>
    /// Describes a handle to an assembly that is in the process of being built.
    /// </summary>
    public class MetadataAssemblyBuilderHandle : IAssemblyHandle
    {

        readonly MetadataAssemblyBuilder builder;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataAssemblyBuilderHandle(MetadataAssemblyBuilder builder)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

    }

}