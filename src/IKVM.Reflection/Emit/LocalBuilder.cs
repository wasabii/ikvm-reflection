namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Represents a local variable within a method or constructor.
    /// </summary>
    public abstract class LocalBuilder
    {

        public static bool operator ==(LocalBuilder? left, LocalVariableInfo? right) => Equals(left?.AsLocalVariableInfo(), right);

        public static bool operator !=(LocalBuilder? left, LocalVariableInfo? right) => Equals(left?.AsLocalVariableInfo(), right) == false;

        /// <summary>
        /// Returns a <see cref="LocalVariableInfo"/> instance that represents the method being generated.
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator LocalVariableInfo(LocalBuilder builder) => builder.AsLocalVariableInfo();

        /// <summary>
        /// Gets a value indicating whether the object referred to by the local variable is pinned in memory.
        /// </summary>
        public abstract bool IsPinned { get; }

        /// <summary>
        /// Gets the zero-based index of the local variable within the method body.
        /// </summary>
        public abstract int LocalIndex { get; }

        /// <summary>
        /// Gets the type of the local variable.
        /// </summary>
        public abstract Type LocalType { get; }

        /// <summary>
        /// Obtains a representation of the <see cref="LocalBuilder"/> which behaves like an <see cref="LocalVariableInfo"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract LocalVariableInfo AsLocalVariableInfo();

        /// <inheritdoc />
        public override bool Equals(object? obj) => object.ReferenceEquals(this, obj);

        /// <inheritdoc />
        public override int GetHashCode() => base.GetHashCode();


    }

}
