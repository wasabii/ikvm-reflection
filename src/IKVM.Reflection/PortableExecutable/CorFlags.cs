using System;

namespace IKVM.Reflection.PortableExecutable
{

    [Flags]
    public enum CorFlags
    {

        ILOnly = 1,
        Requires32Bit = 2,
        ILLibrary = 4,
        StrongNameSigned = 8,
        NativeEntryPoint = 16,
        TrackDebugData = 65536,
        Prefers32Bit = 131072

    }

}
