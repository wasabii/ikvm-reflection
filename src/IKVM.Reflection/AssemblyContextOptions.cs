using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Options for the <see cref="DefaultAssemblyContext"/> implementation.
    /// </summary>
    public class AssemblyContextOptions
    {

        public static readonly AssemblyName NetCoreDefaultCoreLibName = new("System.Runtime");
        public static readonly AssemblyName NetFrameworkDefaultCoreLibName = new("mscorlib");
        public static readonly AssemblyName NetStandardDefaultCoreLibName = new("netstandard2.0");

        /// <summary>
        /// Gets the default core library name to use when none other specified.
        /// </summary>
        public static readonly AssemblyName DefaultCoreLibName = NetStandardDefaultCoreLibName;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AssemblyContextOptions()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="coreLibName"></param>
        public AssemblyContextOptions(AssemblyContextOptions other)
        {
            CoreLibName = other.CoreLibName;
        }

        /// <summary>
        /// Gets or sets the default CoreLib name. That is, the assembly name which holds core types such as System.Object.
        /// </summary>
        public AssemblyName CoreLibName { get; init; } = DefaultCoreLibName;

    }

}
