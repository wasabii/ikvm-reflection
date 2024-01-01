using System.Resources;

namespace IKVM.Reflection.Emit.Reflection
{

    internal class ReflectionAssemblyBuilder : AssemblyBuilder
    {

        readonly ReflectionEmitContext context;
        readonly System.Reflection.Emit.AssemblyBuilder wrapped;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="wrapped"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ReflectionAssemblyBuilder(ReflectionEmitContext context, System.Reflection.Emit.AssemblyBuilder wrapped)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }

        public System.Reflection.Emit.AssemblyBuilder Wrapped => wrapped;

        /// <inheritdoc />
        public override string Location => wrapped.Location;

        /// <inheritdoc />
        public override string ImageRuntimeVersion => wrapped.ImageRuntimeVersion;

        /// <inheritdoc />
        public override Module ManifestModule => wrapped.ManifestModule;

        /// <inheritdoc />
        public override MethodInfo? EntryPoint => wrapped.EntryPoint;

        /// <inheritdoc />
        public override IEnumerable<TypeInfo> DefinedTypes => wrapped.DefinedTypes;

        /// <inheritdoc />
        public override IEnumerable<Type> ExportedTypes => wrapped.ExportedTypes;

        /// <inheritdoc />
        public override ModuleBuilder DefineModule(string name) => context.Adopt(wrapped.DefineDynamicModule(name));

        /// <inheritdoc />
        public override AssemblyName GetName() => wrapped.GetName();

        /// <inheritdoc />
        public override AssemblyName GetName(bool copiedName) => wrapped.GetName(copiedName);

        /// <inheritdoc />
        public override Type[] GetTypes() => wrapped.GetTypes();

        /// <inheritdoc />
        public override Type? GetType(string name) => wrapped.GetType(name);

        /// <inheritdoc />
        public override Type? GetType(string name, bool throwOnError) => wrapped.GetType(name, throwOnError);

        /// <inheritdoc />
        public override Type? GetType(string name, bool throwOnError, bool ignoreCase) => wrapped.GetType(name, throwOnError, ignoreCase);

        /// <inheritdoc />
        public override Type[] GetForwardedTypes()
        {
#if NET6_0_OR_GREATER
            return wrapped.GetForwardedTypes();
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override Module[] GetModules() => wrapped.GetModules();

        /// <inheritdoc />
        public override Module[] GetModules(bool getResourceModules) => wrapped.GetModules(getResourceModules);

        /// <inheritdoc />
        public override Module? GetModule(string name) => wrapped.GetModule(name);

        /// <inheritdoc />
        public override IList<CustomAttributeData> GetCustomAttributesData() => wrapped.GetCustomAttributesData();

        /// <inheritdoc />
        public override void SetCustomAttribute(CustomAttributeBuilder customBuilder)
        {
            if (customBuilder is ReflectionCustomAttributeBuilder b)
                wrapped.SetCustomAttribute(b.Wrapped);

            throw new ArgumentException("SetCustomAttribute requires a CustomAttributeBuilder derived from the Reflection provider.");
        }

        /// <inheritdoc />
        public override void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute) => wrapped.SetCustomAttribute(con, binaryAttribute);

        /// <inheritdoc />
        public override void SetEntryPoint(MethodInfo entryMethod)
        {
#if NETFRAMEWORK
            wrapped.SetEntryPoint(entryMethod);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void SetEntryPoint(MethodInfo entryMethod, PEFileKinds fileKind)
        {
#if NETFRAMEWORK
            wrapped.SetEntryPoint(entryMethod, (System.Reflection.Emit.PEFileKinds)(int)fileKind);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void AddResourceFile(string name, string fileName)
        {
#if NETFRAMEWORK
            wrapped.AddResourceFile(name, fileName);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void AddResourceFile(string name, string fileName, ResourceAttributes attribs)
        {
#if NETFRAMEWORK
            wrapped.AddResourceFile(name, fileName, attribs);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override IResourceWriter DefineResource(string name, string description, string fileName)
        {
#if NETFRAMEWORK
            return wrapped.DefineResource(name, description, fileName);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override IResourceWriter DefineResource(string name, string description, string fileName, ResourceAttributes attribute)
        {
#if NETFRAMEWORK
            return wrapped.DefineResource(name, description, fileName, attribute);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void DefineUnmanagedResource(string resourceFileName)
        {
#if NETFRAMEWORK
            wrapped.DefineUnmanagedResource(resourceFileName);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void DefineUnmanagedResource(byte[] resource)
        {
#if NETFRAMEWORK
            wrapped.DefineUnmanagedResource(resource);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void DefineVersionInfoResource()
        {
#if NETFRAMEWORK
            wrapped.DefineVersionInfoResource();
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void DefineVersionInfoResource(string product, string productVersion, string company, string copyright, string trademark)
        {
#if NETFRAMEWORK
            wrapped.DefineVersionInfoResource(product, productVersion, company, copyright, trademark);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void Save(string assemblyFileName)
        {
#if NETFRAMEWORK
            wrapped.Save(assemblyFileName);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        public override void Save(string assemblyFileName, PortableExecutableKinds portableExecutableKind, ImageFileMachine imageFileMachine)
        {
#if NETFRAMEWORK
            wrapped.Save(assemblyFileName, portableExecutableKind, imageFileMachine);
#else
            throw new PlatformNotSupportedException();
#endif
        }

        /// <inheritdoc />
        protected override Assembly AsAssembly() => Wrapped;

        /// <inheritdoc />
        public override string ToString() => wrapped.ToString();

    }

}
