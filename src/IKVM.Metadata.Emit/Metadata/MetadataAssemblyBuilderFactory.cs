using System.Reflection.PortableExecutable;

namespace IKVM.Metadata.Emit.Metadata
{

    class MetadataAssemblyFactory : IAssemblyFactory
    {

        /// <summary>
        /// Creates a new assembly.
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="imageBase"></param>
        /// <param name="subsystem"></param>
        /// <param name="dllCharacteristics"></param>
        /// <param name="imageCharacteristics"></param>
        /// <returns></returns>
        public IAssemblyBuilder CreateAssembly(Machine machine, ulong imageBase, Subsystem subsystem, DllCharacteristics dllCharacteristics, Characteristics imageCharacteristics)
        {
            return new MetadataAssemblyBuilder(machine, imageBase, subsystem, dllCharacteristics, imageCharacteristics);
        }

    }

}
