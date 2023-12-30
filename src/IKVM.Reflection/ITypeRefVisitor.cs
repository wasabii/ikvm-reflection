namespace IKVM.Reflection
{

    /// <summary>
    /// Provides members for visiting references to types.
    /// </summary>
    /// <typeparam name="TResult">The type of value to return.</typeparam>
    /// <typeparam name="TState">The type of additional state.</typeparam>
    public interface ITypeRefVisitor<out TResult, in TState>
    {

        /// <summary>
        /// Visits an instance of a type that represents a multi-dimensional array of another type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitArrayType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a boxed type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitBoxedType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a reference to another type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitByRefType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a custom modifier applied to a type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitCustomModifierType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a generic type instance.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitGenericInstanceType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a generic parameter.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitGenericParameterType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a pinned type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitPinnedType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a pointer to another type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitPointerType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a sentinal type.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitSentinelType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a single dimensions array.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitSzArrayType(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a concrete type definition.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitTypeRef(TypeRef type, TState state);

        /// <summary>
        /// Visits an instance of a type that represents a function pointer.
        /// </summary>
        /// <param name="type">The signature to visit.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitFunctionPointerType(TypeRef type, TState state);

    }

}
