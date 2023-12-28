﻿namespace IKVM.Reflection
{

    /// <summary>
    /// Provides members for visiting type signatures.
    /// </summary>
    /// <typeparam name="TState">The type of additional state.</typeparam>
    /// <typeparam name="TResult">The type of value to return.</typeparam>
    public interface ITypeSignatureVisitor<in TState, out TResult>
    {

        /// <summary>
        /// Visits an instance of an <see cref="ArrayTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitArrayType(ArrayTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="BoxedTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitBoxedType(BoxedTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="ByRefTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitByReferenceType(ByRefTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="CustomModifierTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitCustomModifierType(CustomModifierTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="GenericInstanceTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitGenericInstanceType(GenericInstanceTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="GenericParameterTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitGenericParameterType(GenericParameterTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="PinnedTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitPinnedType(PinnedTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="PointerTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitPointerType(PointerTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="SentinelTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitSentinelType(SentinelTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="SzArrayTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitSzArrayType(SzArrayTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="TypeRefTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitTypeRefType(TypeRefTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="TypeDefTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitTypeDefType(TypeDefTypeSignature signature, TState state);

        /// <summary>
        /// Visits an instance of a <see cref="FunctionPointerTypeSignature"/>.
        /// </summary>
        /// <param name="signature">The signature to visit.</param>
        /// <param name="state">Additional state.</param>
        /// <returns>The result provided by the visitor.</returns>
        TResult VisitFunctionPointerType(FunctionPointerTypeSignature signature, TState state);

    }

}
