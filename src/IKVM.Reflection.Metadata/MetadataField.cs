using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace IKVM.Reflection.Metadata
{

    internal class MetadataField : IField
    {

        readonly MetadataModule module;
        readonly MetadataType parentType;
        readonly FieldDefinition def;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="declaringType"></param>
        /// <param name="handle"></param>
        public MetadataField(MetadataModule module, MetadataType declaringType, FieldDefinitionHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.parentType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            this.def = module.Reader.GetFieldDefinition(handle);
        }

        /// <summary>
        /// Gets the parent module of this field.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets the parent module of this field.
        /// </summary>
        IModule IField.Module => Module;

        /// <summary>
        /// Gets the parent type of this field.
        /// </summary>
        public IType ParentType => parentType;

        /// <summary>
        /// Gets the name of this field.
        /// </summary>
        public string Name => module.Reader.GetString(def.Name);

        /// <summary>
        /// Gets the attributes of this field.
        /// </summary>
        public FieldAttributes Attributes => def.Attributes;

        /// <summary>
        /// Gets the type signature of this field.
        /// </summary>
        public TypeSignature FieldType => throw new System.NotImplementedException();

    }

}
