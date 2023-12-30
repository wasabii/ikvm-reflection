using System;
using System.Collections.Generic;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Base TypeDef implementation for the metadata implementation.
    /// </summary>
    internal abstract class MetadataTypeDefBase : TypeDef
    {

        readonly MetadataModule module;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MetadataTypeDefBase(MetadataModule module) :
            base()
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
        }

        /// <inheritdoc />
        public override MetadataAssembly Assembly => module.Assembly;

        /// <inheritdoc />
        public override MetadataModule Module => module;

        /// <inheritdoc />
        public override MetadataTypeDef? DeclaringType => null;

        /// <inheritdoc />
        public override IReadOnlyList<MetadataTypeGenericParameter> GenericParameters => Array.Empty<MetadataTypeGenericParameter>();

        /// <inheritdoc />
        public override IReadOnlyList<MetadataFieldDef> Fields => Array.Empty<MetadataFieldDef>();

        /// <inheritdoc />
        public override IReadOnlyList<MetadataMethod> Methods => Array.Empty<MetadataMethod>();

        /// <inheritdoc />
        public override IReadOnlyList<MetadataProperty> Properties => Array.Empty<MetadataProperty>();

        /// <inheritdoc />
        public override IReadOnlyList<MetadataEvent> Events => Array.Empty<MetadataEvent>();

        /// <inheritdoc />
        public override IReadOnlyList<MetadataTypeDefBase> NestedTypes => Array.Empty<MetadataTypeDefBase>();

    }

}
