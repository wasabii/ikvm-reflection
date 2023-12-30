using System;
using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents the arguments that are passed into the attribute constructor.
    /// </summary>
    public abstract class CustomAttributeSignature
    {

        /// <summary>
        /// Gets a collection of fixed arguments that are passed onto the constructor of the attribute.
        /// </summary>
        public virtual IReadOnlyList<CustomAttributeArgument> FixedArguments => Array.Empty<CustomAttributeArgument>();

        /// <summary>
        /// Gets a collection of values that are assigned to fields and/or members of the attribute class.
        /// </summary>
        public virtual IReadOnlyList<CustomAttributeNamedArgument> NamedArguments => Array.Empty<CustomAttributeNamedArgument>();

        /// <inheritdoc />
        public override string ToString() => $"(Fixed: {{{string.Join(", ", FixedArguments)}}}, Named: {{{string.Join(", ", NamedArguments)}}})";

    }

}
