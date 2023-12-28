using System;
using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Holds a reference to a type derived from metadata.
    /// </summary>
    internal class MetadataMethodRef : IMethodRef
    {

        readonly MetadataModule module;
        readonly MemberReference member;

        Lazy<IModuleRef?>? parentModule;
        Lazy<ITypeRef?>? parentType;
        IMethod? resolved;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="handle"></param>
        public MetadataMethodRef(MetadataModule module, MemberReferenceHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.member = module.Reader.GetMemberReference(handle);
        }

        /// <summary>
        /// Gets the module from which this method reference was loaded.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets the reference to the assembly that holds this method.
        /// </summary>
        IAssemblyRef IMethodRef.Assembly => ParentType?.Assembly ?? ParentModule?.Assembly ?? throw new InvalidOperationException("MethodRef does not have either a parent type or a parent module.");

        /// <summary>
        /// Gets the reference to the module that declares the method.
        /// </summary>
        public IModuleRef? ParentModule => LazyUtil.Get(ref parentModule, () => new Lazy<IModuleRef?>(LoadParentModule)).Value;

        /// <summary>
        /// Loads the reference to the module that declares the method.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        IModuleRef? LoadParentModule()
        {
            if (member.Parent.IsNil)
                return null;

            if (member.Parent.Kind == HandleKind.ModuleReference)
            {
                var h = (ModuleReferenceHandle)member.Parent;
                var r = Module.Reader.GetModuleReference(h);
                if (Module.Assembly.TryFindModule(Module.Reader.GetString(r.Name), out var m) == false || m == null)
                    return null;

                return m;
            }

            return null;
        }

        /// <summary>
        /// Gets the reference to the type that declares the method.
        /// </summary>
        public ITypeRef? ParentType => LazyUtil.Get(ref parentType, () => new Lazy<ITypeRef?>(LoadParentType)).Value;

        /// <summary>
        /// Loads the reference to the type that declares the method.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadImageFormatException"></exception>
        ITypeRef? LoadParentType()
        {
            if (member.Parent.IsNil)
                return null;

            if (member.Parent.Kind == HandleKind.TypeDefinition)
                return module.GetOrCreateType((TypeDefinitionHandle)member.Parent);

            return null;
        }

        /// <summary>
        /// Gets the name of the referenced method.
        /// </summary>
        public string Name => module.Reader.GetString(member.Name);

        /// <summary>
        /// Attempts to resolve the field.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public bool TryResolve(out IMethod? method)
        {
            method = resolved;
            if (method != null)
                return true;

            if (ParentModule != null)
            {
                if (ParentModule.TryResolve(out var parentModule) == false || parentModule == null)
                    return false;

                if (parentModule.TryFindMethod(Name, out method) == false || method == null)
                    return false;

                resolved = method;
                return true;
            }

            if (ParentType != null)
            {
                if (ParentType.TryResolve(out var parentType) == false || parentType == null)
                    return false;

                if (parentType.TryFindMethod(Name, out method) == false || method == null)
                    return false;

                resolved = method;
                return true;
            }

            return false;
        }

    }

}
