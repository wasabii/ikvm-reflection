using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Metadata
{

    internal sealed class MetadataFieldDef : FieldDef
    {

        readonly MetadataModule module;
        readonly MetadataTypeDef declaringType;
        readonly FieldDefinition def;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="declaringType"></param>
        /// <param name="handle"></param>
        public MetadataFieldDef(MetadataModule module, MetadataTypeDef declaringType, FieldDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.declaringType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            this.def = module.Reader.GetFieldDefinition(handle);
        }

        /// <inheritdoc />
        public override MetadataModule Module => module;

        /// <inheritdoc />
        public override TypeDef DeclaringType => declaringType;

        /// <inheritdoc />
        public override string Name => module.Reader.GetString(def.Name);

        /// <inheritdoc />
        public override FieldAttributes Attributes => def.Attributes;

        /// <inheritdoc />
        public override TypeSig FieldType => throw new System.NotImplementedException();

    }

}
