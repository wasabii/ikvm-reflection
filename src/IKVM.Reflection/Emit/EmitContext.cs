namespace IKVM.Reflection.Emit
{

    /// <summary>
    /// Provides a context for the reflection emit API based on System.Reflection.Emit.
    /// </summary>
    public abstract class EmitContext
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected EmitContext()
        {

        }

        /// <summary>
        /// Defines a assembly that has the specified name and access rights.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public abstract AssemblyBuilder DefineAssembly(AssemblyName name, AssemblyBuilderAccess access);

        /// <summary>
        /// Defines a assembly that has the specified name, access rights, and attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="access"></param>
        /// <param name="assemblyAttributes"></param>
        /// <returns></returns>
        public abstract AssemblyBuilder DefineAssembly(AssemblyName name, AssemblyBuilderAccess access, IEnumerable<CustomAttributeBuilder>? assemblyAttributes);

    }

}
