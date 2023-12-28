using System;
using System.Reflection.Metadata;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Holds a reference to a type derived from metadata.
    /// </summary>
    internal class MetadataFieldRef : IFieldRef
    {

        readonly MetadataModule module;
        readonly MemberReferenceHandle handle;
        readonly MemberReference member;

        Lazy<MetadataAssemblyRef?>? parentAssemblyRef;
        Lazy<MetadataModuleRef?>? parentModuleRef;
        Lazy<MetadataTypeRef?>? parentTypeRef;
        Lazy<MetadataType?>? parentTypeDef;
        IField? resolved;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="handle"></param>
        public MetadataFieldRef(MetadataModule module, MemberReferenceHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.handle = handle;
            this.member = module.Reader.GetMemberReference(handle);
        }

        /// <summary>
        /// Gets the module from which this field reference was loaded.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets a reference to the assembly that holds the field.
        /// </summary>
        MetadataAssemblyRef? ParentAssemblyRef => LazyUtil.Get(ref parentAssemblyRef, () => new Lazy<MetadataAssemblyRef?>(LoadParentAssemblyRef)).Value;

        /// <summary>
        /// Loads the reference to the module that declares the field.
        /// </summary>
        /// <returns></returns>
        MetadataAssemblyRef? LoadParentAssemblyRef() => member.Parent is { IsNil: false, Kind: HandleKind.AssemblyReference } r ? module.GetOrCreateAssemblyRef((AssemblyReferenceHandle)r) : null;

        /// <summary>
        /// Gets the reference to the module that declares the field.
        /// </summary>
        MetadataModuleRef? ParentModuleRef => LazyUtil.Get(ref parentModuleRef, () => new Lazy<MetadataModuleRef?>(LoadParentModuleRef)).Value;

        /// <summary>
        /// Loads the reference to the module that declares the field.
        /// </summary>
        /// <returns></returns>
        MetadataModuleRef? LoadParentModuleRef() => member.Parent is { IsNil: false, Kind: HandleKind.ModuleReference } r ? module.GetOrCreateModuleRef((ModuleReferenceHandle)r) : null;

        /// <summary>
        /// Gets the reference to the type that declares the field.
        /// </summary>
        MetadataTypeRef? ParentTypeRef => LazyUtil.Get(ref parentTypeRef, () => new Lazy<MetadataTypeRef?>(LoadParentTypeRef)).Value;

        /// <summary>
        /// Loads the reference to the type that declares the field.
        /// </summary>
        /// <returns></returns>
        MetadataTypeRef? LoadParentTypeRef() => member.Parent is { IsNil: false, Kind: HandleKind.TypeReference } r ? module.GetOrCreateTypeRef((TypeReferenceHandle)r) : null;

        /// <summary>
        /// Gets the reference to the type that declares the field.
        /// </summary>
        MetadataType? ParentTypeDef => LazyUtil.Get(ref parentTypeDef, () => new Lazy<MetadataType?>(LoadParentTypeDef)).Value;

        /// <summary>
        /// Loads the reference to the type that declares the field.
        /// </summary>
        /// <returns></returns>
        MetadataType? LoadParentTypeDef() => member.Parent is { IsNil: false, Kind: HandleKind.TypeDefinition } r ? module.GetOrCreateType((TypeDefinitionHandle)r) : null;

        /// <summary>
        /// Gets the reference to the assembly that holds this field.
        /// </summary>
        IAssemblyRef IFieldRef.ParentAssembly => assembly;

        /// <summary>
        /// Gets the name of the referenced type.
        /// </summary>
        public string Name => module.Reader.GetString(member.Name);

        /// <summary>
        /// Attempts to resolve the field.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public bool TryResolve(out IField? field)
        {
            field = resolved;
            if (field != null)
                return true;

            if (ParentModule != null)
            {
                if (ParentModule.TryResolve(out var parentModule) == false || parentModule == null)
                    return false;

                if (parentModule.TryFindField(Name, out field) == false || field == null)
                    return false;

                resolved = field;
                return true;
            }

            if (ParentTypeDef != null)
            {
                if (ParentTypeDef.TryResolve(out var parentType) == false || parentType == null)
                    return false;

                if (parentType.TryFindField(Name, out field) == false || field == null)
                    return false;

                resolved = field;
                return true;
            }

            return false;
        }

    }

}
