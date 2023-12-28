using System.Reflection.PortableExecutable;

namespace IKVM.Metadata.Emit
{

    /// <summary>
    /// Provides access to writing.
    /// </summary>
    public interface IAssemblyFactory
    {

        /// <summary>
        /// Creates a new assembly.
        /// </summary>
        /// <returns></returns>
        IAssemblyBuilder CreateAssembly(Machine machine = 0, ulong imageBase = 0x00400000, Subsystem subsystem = Subsystem.WindowsCui, DllCharacteristics dllCharacteristics = DllCharacteristics.DynamicBase | DllCharacteristics.NxCompatible | DllCharacteristics.NoSeh | DllCharacteristics.TerminalServerAware, Characteristics imageCharacteristics = Characteristics.Dll);

    }

}
