namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a constraint placed on a generic parameter.
    /// </summary>
    public interface IGenericParameterConstraint
    {

        /// <summary>
        /// Gets the type signature that constrains the type.
        /// </summary>
        TypeSignature Constraint { get; }

    }

}
