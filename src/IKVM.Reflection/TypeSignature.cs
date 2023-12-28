using System.Diagnostics;

using IKVM.Reflection.Util;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a .NET type signature.
    /// </summary>
    [DebuggerDisplay(nameof(DisplayName))]
    public abstract class TypeSignature
    {

        string? displayName;

        /// <summary>
        /// Gets the display name of this type signature.
        /// </summary>
        public virtual string DisplayName => LazyUtil.Get(ref displayName, () => SignatureNameUtil.GetTypeDisplayName(this));

        /// <summary>
        /// Visit the current type signature using the provided visitor.
        /// </summary>
        /// <param name="visitor">The visitor to accept.</param>
        /// <typeparam name="TResult">The type of result the visitor produces.</typeparam>
        /// <returns>The result the visitor produced after visiting this type signature.</returns>
        public abstract TResult AcceptVisitor<TResult>(ITypeSignatureVisitor<TResult> visitor);

        /// <summary>
        /// Visit the current type signature using the provided visitor.
        /// </summary>
        /// <param name="visitor">The visitor to accept.</param>
        /// <param name="state">Additional state.</param>
        /// <typeparam name="TState">The type of additional state.</typeparam>
        /// <typeparam name="TResult">The type of result the visitor produces.</typeparam>
        /// <returns>The result the visitor produced after visiting this type signature.</returns>
        public abstract TResult AcceptVisitor<TState, TResult>(ITypeSignatureVisitor<TState, TResult> visitor, TState state);

        /// <inheritdoc />
        public override string ToString() => DisplayName;

    }

}
