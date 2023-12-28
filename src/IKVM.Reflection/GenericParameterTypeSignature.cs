using System;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type signature that references a type argument from a generic type or method.
    /// </summary>
    public class GenericParameterTypeSignature : TypeSignature
    {

        readonly GenericParameterScope scope;
        readonly int index;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="index"></param>
        public GenericParameterTypeSignature(GenericParameterScope scope, int index)
        {
            this.scope = scope;
            this.index = index;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this parameter signature is declared by a type or a method.
        /// generic parameter.
        /// </summary>
        public GenericParameterScope Scope => scope;

        /// <summary>
        /// Gets or sets the index of the referenced generic parameter.
        /// </summary>
        public int Index => index;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitGenericParameterType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitGenericParameterType(this, state);

    }

}
