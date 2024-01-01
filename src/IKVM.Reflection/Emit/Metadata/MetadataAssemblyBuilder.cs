
using System.Resources;

namespace IKVM.Reflection.Emit.Metadata
{

    internal class MetadataAssemblyBuilder : AssemblyBuilder
    {

        readonly MetadataEmitContext context;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MetadataAssemblyBuilder(MetadataEmitContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override string Location => throw new NotImplementedException();

        public override IEnumerable<TypeInfo> DefinedTypes => throw new NotImplementedException();

        public override IEnumerable<Type> ExportedTypes => throw new NotImplementedException();

        public override string ImageRuntimeVersion => throw new NotImplementedException();

        public override Module ManifestModule => throw new NotImplementedException();

        public override MethodInfo? EntryPoint => throw new NotImplementedException();

        public override void AddResourceFile(string name, string fileName)
        {
            throw new NotImplementedException();
        }

        public override void AddResourceFile(string name, string fileName, ResourceAttributes attribs)
        {
            throw new NotImplementedException();
        }

        public override ModuleBuilder DefineModule(string name)
        {
            throw new NotImplementedException();
        }

        public override IResourceWriter DefineResource(string name, string description, string fileName)
        {
            throw new NotImplementedException();
        }

        public override IResourceWriter DefineResource(string name, string description, string fileName, ResourceAttributes attribute)
        {
            throw new NotImplementedException();
        }

        public override void DefineUnmanagedResource(string resourceFileName)
        {
            throw new NotImplementedException();
        }

        public override void DefineUnmanagedResource(byte[] resource)
        {
            throw new NotImplementedException();
        }

        public override void DefineVersionInfoResource()
        {
            throw new NotImplementedException();
        }

        public override void DefineVersionInfoResource(string product, string productVersion, string company, string copyright, string trademark)
        {
            throw new NotImplementedException();
        }

        public override IList<CustomAttributeData> GetCustomAttributesData()
        {
            throw new NotImplementedException();
        }

        public override Type[] GetForwardedTypes()
        {
            throw new NotImplementedException();
        }

        public override Module? GetModule(string name)
        {
            throw new NotImplementedException();
        }

        public override Module[] GetModules()
        {
            throw new NotImplementedException();
        }

        public override Module[] GetModules(bool getResourceModules)
        {
            throw new NotImplementedException();
        }

        public override AssemblyName GetName()
        {
            throw new NotImplementedException();
        }

        public override AssemblyName GetName(bool copiedName)
        {
            throw new NotImplementedException();
        }

        public override Type? GetType(string name, bool throwOnError, bool ignoreCase)
        {
            throw new NotImplementedException();
        }

        public override Type? GetType(string name, bool throwOnError)
        {
            throw new NotImplementedException();
        }

        public override Type? GetType(string name)
        {
            throw new NotImplementedException();
        }

        public override Type[] GetTypes()
        {
            throw new NotImplementedException();
        }

        public override void Save(string assemblyFileName)
        {
            throw new NotImplementedException();
        }

        public override void Save(string assemblyFileName, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            throw new NotImplementedException();
        }

        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
        {
            throw new NotImplementedException();
        }

        public override void SetEntryPoint(MethodInfo entryMethod)
        {
            throw new NotImplementedException();
        }

        public override void SetEntryPoint(MethodInfo entryMethod, PEFileKinds fileKind)
        {
            throw new NotImplementedException();
        }

        protected override Assembly AsAssembly()
        {
            throw new NotImplementedException();
        }

    }

}
