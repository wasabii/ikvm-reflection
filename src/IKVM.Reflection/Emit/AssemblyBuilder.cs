
using System.Resources;

namespace IKVM.Reflection.Emit
{

    public abstract class AssemblyBuilder
    {

        public static implicit operator Assembly(AssemblyBuilder builder) => builder.AsAssembly();

        /// <summary>
        /// Gets an <see cref="AssemblyName"/> for this assembly.
        /// </summary>
        /// <returns></returns>
        public abstract AssemblyName GetName();

        /// <summary>
        /// Gets an <see cref="AssemblyName"/> for this assembly, setting the codebase as specified by copiedName.
        /// </summary>
        /// <param name="copiedName"></param>
        /// <returns></returns>
        public abstract AssemblyName GetName(bool copiedName);

        /// <summary>
        /// Gets the full path or UNC location of the loaded file that contains the manifest.
        /// </summary>
        public abstract string Location { get; }

        /// <summary>
        /// Gets a collection of the types defined in this assembly.
        /// </summary>
        public abstract IEnumerable<TypeInfo> DefinedTypes { get; }

        /// <summary>
        /// Gets a collection of the public types defined in this assembly that are visible outside the assembly.
        /// </summary>
        public abstract IEnumerable<Type> ExportedTypes { get; }

        /// <summary>
        /// Gets all types defined in this assembly.
        /// </summary>
        /// <returns></returns>
        public abstract Type[] GetTypes();

        /// <summary>
        /// Gets the <see cref="Type"/> object with the specified name in the assembly instance, with the options of ignoring the case, and of throwing an exception if the type is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="throwOnError"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public abstract Type? GetType(string name, bool throwOnError, bool ignoreCase);

        /// <summary>
        /// Gets the <see cref="Type"/> object with the specified name in the assembly instance and optionally throws an exception if the type is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public abstract Type? GetType(string name, bool throwOnError);

        /// <summary>
        /// Gets the <see cref="Type"/> object with the specified name in the assembly instance.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract Type? GetType(string name);

        /// <summary>
        /// Gets the forwarded types within the assembly.
        /// </summary>
        /// <returns></returns>
        public abstract Type[] GetForwardedTypes();

        /// <summary>
        /// Gets a string representing the version of the common language runtime (CLR) saved in the file containing the manifest.
        /// </summary>
        public abstract string ImageRuntimeVersion { get; }

        /// <summary>
        /// Gets the module that contains the manifest for the current assembly.
        /// </summary>
        public abstract Module ManifestModule { get; }

        /// <summary>
        /// Gets the entry point of this assembly.
        /// </summary>
        public abstract MethodInfo? EntryPoint { get; }

        /// <summary>
        /// Gets all the modules that are part of this assembly.
        /// </summary>
        /// <returns></returns>
        public abstract Module[] GetModules();

        /// <summary>
        /// Gets all the modules that are part of this assembly, specifying whether to include resource modules.
        /// </summary>
        /// <param name="getResourceModules"></param>
        /// <returns></returns>
        public abstract Module[] GetModules(bool getResourceModules);

        /// <summary>
        /// Gets the specified module in this assembly.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract Module? GetModule(string name);

        /// <summary>
        /// Defines a named module in this assembly.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract ModuleBuilder DefineModule(string name);

        /// <summary>
        /// Returns <see cref="CustomAttributeData"/> objects that contain information about the attributes that have been applied to the current AssemblyBuilder.
        /// </summary>
        /// <returns></returns>
        public abstract IList<CustomAttributeData> GetCustomAttributesData();

        /// <summary>
        /// Set a custom attribute on this assembly using a custom attribute builder.
        /// </summary>
        /// <param name="customBuilder"></param>
        public abstract void SetCustomAttribute(CustomAttributeBuilder customBuilder);

        /// <summary>
        /// Set a custom attribute on this assembly using a specified custom attribute blob.
        /// </summary>
        /// <param name="con"></param>
        /// <param name="binaryAttribute"></param>
        public abstract void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute);

        /// <summary>
        /// Sets the entry point for this dynamic assembly, assuming that a console application is being built.
        /// </summary>
        /// <param name="entryMethod"></param>
        public abstract void SetEntryPoint(MethodInfo entryMethod);

        /// <summary>
        /// Sets the entry point for this assembly and defines the type of the portable executable (PE file) being built.
        /// </summary>
        /// <param name="entryMethod"></param>
        /// <param name="fileKind"></param>
        public abstract void SetEntryPoint(MethodInfo entryMethod, PEFileKinds fileKind);

        /// <summary>
        /// Adds an existing resource file to this assembly.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fileName"></param>
        public abstract void AddResourceFile(string name, string fileName);

        /// <summary>
        /// Adds an existing resource file to this assembly.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fileName"></param>
        /// <param name="attribs"></param>
        public abstract void AddResourceFile(string name, string fileName, ResourceAttributes attribs);

        /// <summary>
        /// Defines a standalone managed resource for this assembly with the default public resource attribute.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public abstract IResourceWriter DefineResource(string name, string description, string fileName);

        /// <summary>
        /// Defines a standalone managed resource for this assembly. Attributes can be specified for the managed resource.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="fileName"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public abstract IResourceWriter DefineResource(string name, string description, string fileName, ResourceAttributes attribute);

        /// <summary>
        /// Defines an unmanaged resource file for this assembly given the name of the resource file.
        /// </summary>
        /// <param name="resourceFileName"></param>
        public abstract void DefineUnmanagedResource(string resourceFileName);

        /// <summary>
        /// Defines an unmanaged resource for this assembly as an opaque blob of bytes.
        /// </summary>
        /// <param name="resource"></param>
        public abstract void DefineUnmanagedResource(byte[] resource);

        /// <summary>
        /// Defines an unmanaged version information resource using the information specified in the assembly's AssemblyName object and the assembly's custom attributes.
        /// </summary>
        public abstract void DefineVersionInfoResource();

        /// <summary>
        /// Defines an unmanaged version information resource for this assembly with the given specifications.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productVersion"></param>
        /// <param name="company"></param>
        /// <param name="copyright"></param>
        /// <param name="trademark"></param>
        public abstract void DefineVersionInfoResource(string product, string productVersion, string company, string copyright, string trademark);

        /// <summary>
        /// Saves this assembly to disk.
        /// </summary>
        /// <param name="assemblyFileName"></param>
        public abstract void Save(string assemblyFileName);

        /// <summary>
        /// Saves this assembly to disk, specifying the nature of code in the assembly's executables and the target platform.
        /// </summary>
        /// <param name="assemblyFileName"></param>
        /// <param name="portableExecutableKind"></param>
        /// <param name="imageFileMachine"></param>
        public abstract void Save(string assemblyFileName, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine);

        /// <summary>
        /// Obtains a representation of the <see cref="AssemblyBuilder"/> which behaves like an <see cref="Assembly"/>.
        /// </summary>
        /// <returns></returns>
        protected abstract Assembly AsAssembly();

    }

}
