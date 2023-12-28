using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Describes a generic parameter available on a metadata method.
    /// </summary>
    internal class MetadataMethodGenericParameter : IGenericParameter
    {

        readonly MetadataModule module;
        readonly MetadataMethod method;
        readonly GenericParameter parameter;

        MetadataMethodGenericParameterConstraint[]? constraints;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="method"></param>
        /// <param name="handle"></param>
        public MetadataMethodGenericParameter(MetadataModule module, MetadataMethod method, GenericParameterHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.method = method ?? throw new ArgumentNullException(nameof(method));
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
        MetadataMethodGenericParameterConstraint[] LoadConstraints()
        {
            var c = parameter.GetConstraints();
            if (c.Count == 0)
                return Array.Empty<MetadataMethodGenericParameterConstraint>();

            var l = new MetadataMethodGenericParameterConstraint[c.Count];
            int i = 0;
            foreach (var h in c)
                l[i++] = new MetadataMethodGenericParameterConstraint(module, method, h);

            return l;
        }

    }

}