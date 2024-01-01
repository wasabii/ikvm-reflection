using System.Reflection.Emit;

namespace IKVM.Reflection.Emit.Metadata
{

    public class MetadataEmitContext : EmitContext
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MetadataEmitContext()
        {

        }

        public override AssemblyBuilder DefineAssembly(AssemblyName name, AssemblyBuilderAccess access)
        {
            throw new NotImplementedException();
        }

        public override AssemblyBuilder DefineAssembly(AssemblyName name, AssemblyBuilderAccess access, IEnumerable<CustomAttributeBuilder>? assemblyAttributes)
        {
            throw new NotImplementedException();
        }

    }

}
