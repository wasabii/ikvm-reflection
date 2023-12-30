using System.Collections.Generic;
using System.Diagnostics;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a type that may not be loaded.
    /// </summary>
    [DebuggerDisplay(nameof(FullName))]
    public abstract class TypeRef : IFullNameProvider
    {

        /// <summary>
        /// Gets the assembly the type is declared in.
        /// </summary>
        public abstract AssemblyRef DeclaringAssembly { get; set; }

        /// <summary>
        /// When this type is nested, gets the enclosing type.
        /// </summary>
        public abstract TypeRef? DeclaringType { get; }

        /// <summary>
        /// Gets the namespace of the type.
        /// </summary>
        public abstract string Namespace { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the full name of the type.
        /// </summary>
        public virtual string FullName => TypeNameUtil.GetTypeFullName(this);

        /// <inheritdoc />
        public abstract bool TryResolve(out TypeDef? type);

        /// <inheritdoc />
        public abstract TResult AcceptVisitor<TResult, TState>(ITypeRefVisitor<TResult, TState> visitor, TState state);

        /// <inheritdoc />
        public override string ToString() => FullName;

    }

}
