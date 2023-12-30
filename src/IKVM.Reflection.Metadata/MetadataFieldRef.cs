using System;
using System.Diagnostics;
using System.Reflection.Metadata;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Holds a reference to a type derived from metadata.
    /// </summary>
    internal sealed class MetadataFieldRef : FieldRef
    {

        readonly MetadataModule module;
        readonly MemberReferenceHandle handle;
        readonly MemberReference reference;

        TypeSig? declaringType;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="handle"></param>
        public MetadataFieldRef(MetadataModule module, MemberReferenceHandle handle)
        {
            Debug.Assert(handle.IsNil == false);

            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.handle = handle;
            this.reference = module.Reader.GetMemberReference(handle);
        }

        /// <inheritdoc />
        public override MetadataModule Module => module;

        /// <inheritdoc />
        public override string Name => module.Reader.GetString(reference.Name);

        /// <inheritdoc />
        public override TypeSig DeclaringType => LazyUtil.Get(ref declaringType, LoadDeclaringType);

        /// <summary>
        /// Loads the declaring type.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        TypeSig LoadDeclaringType()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attempts to resolve the field.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public override bool TryResolve(out FieldDef? field)
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
