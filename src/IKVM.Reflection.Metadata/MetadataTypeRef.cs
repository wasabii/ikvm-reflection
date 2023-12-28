using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Holds a reference to a type derived from metadata.
    /// </summary>
    [DebuggerDisplay(nameof(FullName))]
    internal class MetadataTypeRef : ITypeRef
    {

        readonly MetadataModule module;
        readonly TypeReference reference;

        IAssemblyRef? assembly;
        Lazy<ITypeRef?>? parentType;
        IType? resolved;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="handle"></param>
        public MetadataTypeRef(MetadataModule module, TypeReferenceHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.reference = module.Reader.GetTypeReference(handle);
        }

        /// <summary>
        /// Gets the module from which this type reference was loaded.
        /// </summary>
        internal MetadataModule Module => module;

        /// <summary>
        /// Gets the assembly under which this type is located.
        /// </summary>
        public IAssemblyRef Assembly => LazyUtil.Get(ref assembly, LoadAssembly);

        /// <summary>
        /// Gets the assembly under which this type is located.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        IAssemblyRef LoadAssembly()
        {
            switch (reference.ResolutionScope.Kind)
            {
                case HandleKind.TypeReference:
                    return module.GetOrCreateTypeRef((TypeReferenceHandle)reference.ResolutionScope).Assembly;
                case HandleKind.ModuleReference:
                    return module.Assembly;
                case HandleKind.ModuleDefinition:
                    throw new BadImageFormatException("Metadata should not contain TypeRef to ModuleDef.");
                case HandleKind.AssemblyReference:
                    return module.GetOrCreateAssemblyRef((AssemblyReferenceHandle)reference.ResolutionScope);
                default:
                    throw new BadImageFormatException($"Unknown TypeRef ResolutionScope: {reference.ResolutionScope.Kind}");
            }
        }

        /// <summary>
        /// Gets the assembly under which this type is located.
        /// </summary>
        public ITypeRef? ParentType => LazyUtil.Get(ref parentType, () => new Lazy<ITypeRef?>(LoadParentType)).Value;

        /// <summary>
        /// Gets the type under which this type is located.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        ITypeRef? LoadParentType()
        {
            switch (reference.ResolutionScope.Kind)
            {
                case HandleKind.TypeReference:
                    return module.GetOrCreateTypeRef((TypeReferenceHandle)reference.ResolutionScope);
                case HandleKind.ModuleReference:
                    return null;
                case HandleKind.ModuleDefinition:
                    throw new BadImageFormatException("Metadata should not contain TypeRef to ModuleDef.");
                case HandleKind.AssemblyReference:
                    return null;
                default:
                    throw new BadImageFormatException($"Unknown TypeRef ResolutionScope: {reference.ResolutionScope.Kind}");
            }
        }

        /// <summary>
        /// Gets the namespace of the referenced type.
        /// </summary>
        public string Namespace => module.Reader.GetString(reference.Namespace);

        /// <summary>
        /// Gets the name of the referenced type.
        /// </summary>
        public string Name => module.Reader.GetString(reference.Name);

        /// <summary>
        /// Gets the full name of the referenced type.
        /// </summary>
        public string FullName => TypeNameUtil.GetTypeFullName(this);

        /// <summary>
        /// Attempts to resolve the type.
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public bool TryResolve(out IType? def)
        {
            def = this.resolved;
            if (def != null)
                return true;

            switch (reference.ResolutionScope.Kind)
            {
                case HandleKind.TypeReference:
                    this.resolved = def = ResolveByTypeScope();
                    return def != null;
                case HandleKind.ModuleReference:
                    this.resolved = def = ResolveByModuleScope();
                    return def != null;
                case HandleKind.ModuleDefinition:
                    throw new BadImageFormatException("Metadata should not contain TypeRef to ModuleDef.");
                case HandleKind.AssemblyReference:
                    this.resolved = def = ResolveByAssemblyScope();
                    return def != null;
                default:
                    throw new BadImageFormatException($"Unknown TypeRef ResolutionScope: {reference.ResolutionScope.Kind}");
            }
        }

        /// <summary>
        /// Attempts to resolve this type by type scope.
        /// </summary>
        /// <returns></returns>
        IType? ResolveByTypeScope()
        {
            // create and resolve a reference to the declaring type
            var h = (TypeReferenceHandle)reference.ResolutionScope;
            if (module.GetOrCreateTypeRef(h).TryResolve(out var declaringType) == false || declaringType == null)
                return null;

            // search declaring type for nested type
            if (declaringType.TryFindNestedType(Name, out var type) == false || type == null)
                return null;

            return type;
        }

        /// <summary>
        /// Attempts to resolve this type by module scope.
        /// </summary>
        /// <returns></returns>
        MetadataType? ResolveByModuleScope()
        {
            // find module that should contain type
            var h = (ModuleReferenceHandle)reference.ResolutionScope;
            var m = Module.Reader.GetModuleReference(h);
            if (Module.Assembly.TryFindModule(Module.Reader.GetString(m.Name), out var module) == false || module == null)
                return null;

            // find type in module
            if (module.TryFindType(Namespace, Name, out var type) == false)
                return null;

            return type;
        }

        /// <summary>
        /// Attempts to resolve this type by assembly scope.
        /// </summary>
        /// <returns></returns>
        IType? ResolveByAssemblyScope()
        {
            // find assembly that should contain type
            var h = (AssemblyReferenceHandle)reference.ResolutionScope;
            var a = Module.Reader.GetAssemblyReference(h);

            // find type in context
            if (Module.Assembly.Context.TryResolveType(a.GetAssemblyName(), Namespace, Name, Module, out var type) == false)
                return null;

            return type;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return FullName;
        }

    }

}
