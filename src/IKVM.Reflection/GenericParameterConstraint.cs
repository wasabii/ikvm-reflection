using System;
using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a constraint placed on a generic parameter.
    /// </summary>
    public abstract class GenericParameterConstraint : MetadataMember, IHasCustomAttributes, IModuleProvider
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="token"></param>
        protected GenericParameterConstraint(ModuleDef module, MetadataToken token) : 
            base(module, token)
        {

        }

        /// <inheritdoc />
        public virtual IReadOnlyList<CustomAttribute> CustomAttributes => Array.Empty<CustomAttribute>();

        /// <summary>
        /// Gets the type signature that constrains the type.
        /// </summary>
        public abstract ITypeDefOrRef Constraint { get; }

    }

}
