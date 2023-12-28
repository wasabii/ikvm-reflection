using System;

namespace IKVM.Reflection.Emit.Metadata
{

    public class MetadataAssemblyFactory : IAssemblyFactory
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="culture"></param>
        /// <param name="machine"></param>
        /// <param name="imageBase"></param>
        /// <param name="subsystem"></param>
        /// <param name="dllCharacteristics"></param>
        /// <param name="imageCharacteristics"></param>
        /// <param name="corFlags"></param>
        /// <param name="flags"></param>
        /// <param name="hashAlgorithm"></param>
        /// <returns></returns>
        public IAssemblyBuilder CreateAssembly(string name, Version version, string culture, PortableExecutable.Machine machine, ulong imageBase, PortableExecutable.Subsystem subsystem, PortableExecutable.DllCharacteristics dllCharacteristics, PortableExecutable.Characteristics imageCharacteristics, PortableExecutable.CorFlags corFlags, AssemblyFlags flags, AssemblyHashAlgorithm hashAlgorithm)
        {
            return new MetadataAssemblyBuilder(machine, imageBase, subsystem, dllCharacteristics, imageCharacteristics, corFlags, name, version, culture, flags, hashAlgorithm);
        }

    }

}
