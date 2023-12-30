using System;
using System.Collections.Generic;
using System.Reflection;

using IKVM.Reflection.Extensions;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a generic parameter.
    /// </summary>
    public abstract class GenericParameter : MetadataMember, INameProvider, IHasCustomAttributes, IModuleProvider
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="token"></param>
        protected GenericParameter(ModuleDef module, MetadataToken token) :
            base(module, token)
        {

        }

        /// <summary>
        /// Gets the member that defines this generic parameter.
        /// </summary>
        public abstract IHasGenericParameters Owner { get; }

        /// <summary>
        /// Gets the name of this parameter.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the attributes of this parameter.
        /// </summary>
        public abstract GenericParameterAttributes Attributes { get; }

        /// <summary>
        /// Gets the index of this parameter within the list of generic parameters that the owner defines.
        /// </summary>
        public virtual ushort Number => Owner is null ? (ushort)0 : (ushort)Owner.GenericParameters.IndexOf(this);

        /// <summary>
        /// Gets the constraints of this generic parameter.
        /// </summary>
        public virtual IReadOnlyList<GenericParameterConstraint> Constraints => Array.Empty<GenericParameterConstraint>();

        /// <inheritdoc />
        public virtual IReadOnlyList<CustomAttribute> CustomAttributes => Array.Empty<CustomAttribute>();

    }

}
