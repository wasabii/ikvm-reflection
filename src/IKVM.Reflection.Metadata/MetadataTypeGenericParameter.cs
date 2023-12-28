using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{
    /// <summary>
    /// Describes a generic parameter available on a metadata type.
    /// </summary>
    internal class MetadataTypeGenericParameter : IGenericParameter
    {

        readonly MetadataModule module;
        readonly MetadataType type;
        readonly GenericParameter parameter;

        MetadataTypeGenericParameterConstraint[]? constraints;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="type"></param>
        /// <param name="handle"></param>
        public MetadataTypeGenericParameter(MetadataModule module, MetadataType type, GenericParameterHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.parameter = module.Reader.GetGenericParameter(handle);
        }

        /// <summary>
        /// Gets the name of this generic parameter.
        /// </summary>
        public string Name => module.Reader.GetString(parameter.Name);

        /// <summary>
        /// Gets the attributes of this generic parameter.
        /// </summary>
        public GenericParameterAttributes Attributes => parameter.Attributes;

        /// <summary>
        /// Gets the constraints of this generic parameter.
        /// </summary>
        public IReadOnlyList<IGenericParameterConstraint> Constraints => LazyUtil.Get(ref constraints, LoadConstraints);

        /// <summary>
        /// Loads the constraints of this generic parameter.
        /// </summary>
        /// <returns></returns>
        MetadataTypeGenericParameterConstraint[] LoadConstraints()
        {
            var c = parameter.GetConstraints();
            if (c.Count == 0)
                return Array.Empty<MetadataTypeGenericParameterConstraint>();

            var l = new MetadataTypeGenericParameterConstraint[c.Count];
            int i = 0;
            foreach (var h in c)
                l[i++] = new MetadataTypeGenericParameterConstraint(module, type, h);

            return l;
        }

    }

}