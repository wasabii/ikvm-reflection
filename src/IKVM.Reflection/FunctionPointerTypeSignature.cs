using System;

namespace IKVM.Reflection
{

    /// <summary>
    /// Represents the type of an object referencing a function or method pointer.
    /// </summary>
    public class FunctionPointerTypeSignature : TypeSignature
    {

        readonly MethodSignature signature;

        /// <summary>
        /// Creates a new function pointer type signature.
        /// </summary>
        /// <param name="signature">The signature of the function pointer.</param>
        public FunctionPointerTypeSignature(MethodSignature signature)
        {
            this.signature = signature ?? throw new ArgumentNullException(nameof(signature));
        }

        /// <summary>
        /// Gets or sets the signature of the function or method that is referenced by the object.
        /// </summary>
        public MethodSignature Signature => signature;

        /// <inheritdoc />
        public override TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor) => visitor.VisitFunctionPointerType(this);

        /// <inheritdoc />
        public override TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state) => visitor.VisitFunctionPointerType(this, state);

    }

}
