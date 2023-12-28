using IKVM.Reflection.PortableExecutable;

namespace IKVM.Reflection.Metadata.Emit
{

    /// <summary>
    /// Defines the options available for saving an assembly.
    /// </summary>
    public class MetadataSaveOptions
    {

        public Machine Machine { get; set; } = Machine.Unknown;

        public ulong ImageBase { get; set; } = 0x00400000;

        public Subsystem Subsystem { get; set; } = Subsystem.WindowsCui;

        public DllCharacteristics DllCharacteristics { get; set; } = DllCharacteristics.DynamicBase | DllCharacteristics.NxCompatible | DllCharacteristics.NoSeh | DllCharacteristics.TerminalServerAware;

        public Characteristics ImageCharacteristics { get; set; } = Characteristics.Dll;

        public CorFlags CorFlags { get; set; } = CorFlags.ILOnly;

        public AssemblyFlags Flags { get; set; } = 0;

        public AssemblyHashAlgorithm AssemblyHashAlgorithm { get; set; } = AssemblyHashAlgorithm.None;

    }

}
