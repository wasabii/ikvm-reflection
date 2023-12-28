using System;
using System.Reflection;

using IKVM.Reflection.PortableExecutable;

namespace IKVM.Reflection.Emit
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
        IAssemblyBuilder CreateAssembly(string name, Version version, string culture);

    }

}
