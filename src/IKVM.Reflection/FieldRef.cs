namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a field either being written or loaded from the context.
    /// </summary>
    public abstract class FieldRef
    {

        /// <summary>
        /// Gets teh assembly that is making the reference to the field.
        /// </summary>
        public virtual AssemblyDef Assembly => Module.Assembly;

        /// <summary>
        /// Gets the module that is making the reference to the field.
        /// </summary>
        public abstract ModuleDef Module { get; }

        /// <summary>
        /// Gets the type on which the field exists.
        /// </summary>
        public abstract TypeSig DeclaringType { get; }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Attempts to resolve the reference into a definition.
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public abstract bool TryResolve(out FieldDef? def);

    }

}
