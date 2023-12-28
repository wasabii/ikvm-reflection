using System;

namespace IKVM.Xmil.Compile.Syntax
{

    [Flags]
    public enum TypeModifiers
    {

        Private = 1,
        Auto = 1 << 1,
        Ansi = 1 << 1,
        BeforeFieldInit = 1 << 3,
        Sealed = 1 << 4,


    }

}