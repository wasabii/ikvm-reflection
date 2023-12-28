using System;
using System.Collections.Generic;
using System.Linq;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents an instantiation of a generic type.
    /// </summary>
    public class GenericInstanceTypeSignature : TypeSignature, IGenericArgumentsProvider
    {

        readonly TypeSignature genericType;
        readonly TypeSignature[] typeArguments;

        /// <summary>
        /// Creates a new instantiation of a generic type.
        /// </summary>
        /// <param name="genericType">The type to instantiate.</param>
        public GenericInstanceTypeSignature(TypeSignature genericType) :
            this(genericType, Array.Empty<TypeSignature>())
        {

        }

        /// <summary>
        /// Creates a new instantiation of a generic type.
        /// </summary>
        /// <param name="genericType">The type to instantiate.</param>
        /// <param name="typeArguments">The arguments to use for instantiating the generic type.</param>
        public GenericInstanceTypeSignature(TypeSignature genericType, params TypeSignature[] typeArguments)
        {
            this.genericType = genericType ?? throw new ArgumentNullException(nameof(genericType));
            Array.Copy(typeArguments, this.typeArguments = new TypeSignature[typeArguments.Length], typeArguments.Length);
        }

        /// <summary>
        /// Creates a new instantiation of a generic type.
        /// </summary>
        /// <param name="genericType">The type to instantiate.</param>
        /// <param name="typeArguments">The arguments to use for instantiating the generic type.</param>
        public GenericInstanceTypeSignature(TypeSignature genericType, IReadOnlyList<TypeSignature> typeArguments)
        {
            this.genericType = genericType ?? throw new ArgumentNullException(nameof(genericType));
            this.typeArguments = typeArguments?.ToArray() ?? throw new ArgumentNullException(nameof(typeArguments));
        }

        /// <summary>
        /// Gets the underlying generic type definition or reference.
        /// </summary>
        public TypeSignature GenericType => genericType;

        /// <summary>
        /// Gets a collection of type arguments used to instantiate the generic type.
        /// </summary>
        public IReadOnlyList<TypeSignature> TypeArguments => typeArguments;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitGenericInstanceType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitGenericInstanceType(this, state);

    }

}
