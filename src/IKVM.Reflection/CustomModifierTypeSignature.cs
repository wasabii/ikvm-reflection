namespace IKVM.Reflection
{

    /// <summary>
    /// Represents a type signature that is annotated with a required or optional custom modifier type.
    /// </summary>
    public class CustomModifierTypeSignature : TypeSpecificationSignature
    {

        readonly TypeSignature modifierType;
        readonly bool isRequired;

        /// <summary>
        /// Creates a new type signature annotated with a modifier type.
        /// </summary>
        /// <param name="baseType">The type signature that was annotated.</param>
        /// <param name="modifierType">The modifier type.</param>
        /// <param name="isRequired">Indicates whether the modifier is required or optional.</param>
        public CustomModifierTypeSignature(TypeSignature baseType, TypeSignature modifierType, bool isRequired) :
            base(baseType)
        {
            this.modifierType = modifierType ?? throw new System.ArgumentNullException(nameof(modifierType));
            this.isRequired = isRequired;
        }

        /// <summary>
        /// Gets or sets the type representing the modifier that is added to the type.
        /// </summary>
        public TypeSignature ModifierType => modifierType;

        /// <summary>
        /// Gets or sets a value indicating whether the custom modifier type is a required modifier.
        /// </summary>
        public bool IsRequired => isRequired;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitCustomModifierType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitCustomModifierType(this, state);

    }

}
