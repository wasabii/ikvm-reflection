using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace IKVM.Reflection.Emit.Metadata
{

    /// <summary>
    /// Handles writing to a type using System.Reflection.Metadata.
    /// </summary>
    public class MetadataTypeBuilder : ITypeBuilder, IType
    {

        readonly MetadataModuleBuilder module;
        readonly string namespaceName;
        readonly string name;
        readonly TypeAttributes attributes;
        readonly TypeSignature baseType;
        readonly int rowNumber;
        readonly List<MetadataFieldBuilder> fields = new();
        readonly List<MetadataMethodBuilder> methods = new();

        TypeDefinitionHandle handle;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="namespaceName"></param>
        /// <param name="name"></param>
        /// <param name="attributes"></param>
        /// <param name="baseType"></param>
        public MetadataTypeBuilder(MetadataModuleBuilder module, string namespaceName, string name, TypeAttributes attributes, TypeSignature baseType, int rowId)
        {
            this.module = this.module ?? throw new ArgumentNullException(nameof(module));
            this.namespaceName = namespaceName;
            this.name = name;
            this.attributes = attributes;
            this.baseType = baseType ?? throw new ArgumentNullException(nameof(baseType));
            this.rowNumber = rowId;
        }

        /// <summary>
        /// Gets the builder of the parent module.
        /// </summary>
        public MetadataModuleBuilder Module => module;

        /// <inheritdoc />
        public IType Type => this;

        /// <summary>
        /// Gets the namespace name of the type.
        /// </summary>
        public string Namespace => namespaceName;

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Gets the attributes of the type.
        /// </summary>
        public TypeAttributes Attributes => attributes;

        /// <summary>
        /// Gets the base type of the type.
        /// </summary>
        public TypeSignature BaseType => baseType;

        /// <summary>
        /// Gets the fields of the type.
        /// </summary>
        public IList<MetadataFieldBuilder> Fields => fields;

        IReadOnlyList<IField> IType.Fields => (IReadOnlyList<IField>)fields.AsReadOnly();

        /// <summary>
        /// Gets the methods of the type.
        /// </summary>
        public IList<MetadataMethodBuilder> Methods => methods;

        IReadOnlyList<IMethodRef> IType.Methods => methods.AsReadOnly();

        /// <inheritdoc />
        public IFieldBuilder CreateField(string name, FieldAttributes attributes, TypeSignature signature)
        {
            var f = new MetadataFieldBuilder(this, name, attributes, signature, module.Assembly.GetNextFieldId());
            fields.Add(f);
            return f;
        }

        /// <inheritdoc />
        public IMethodBuilder CreateMethod(string name, MethodAttributes attributes, MethodImplAttributes implAttributes, TypeSignature returnType)
        {
            var m = new MetadataMethodBuilder(this, name, attributes, implAttributes, returnType, module.Assembly.GetNextMethodId());
            methods.Add(m);
            return m;
        }

        /// <summary>
        /// Flushes the declared module information to the metadata builder.
        /// </summary>
        internal void Flush()
        {
            if (handle.IsNil)
            {
                foreach (var f in fields)
                    f.Flush();

                foreach (var m in methods)
                    m.Flush();

                var fHnd = MetadataTokens.FieldDefinitionHandle(fields.Count > 0 ? fields[0].RowNumber : 1);
                var mHnd = MetadataTokens.MethodDefinitionHandle(methods.Count > 0 ? methods[0].RowNumber : 1);
                handle = module.Assembly.MetadataBuilder.AddTypeDefinition(attributes, module.Assembly.MetadataBuilder.GetOrAddString(namespaceName), module.Assembly.MetadataBuilder.GetOrAddString(name), null, fHnd, mHnd);
                Debug.Assert(MetadataTokens.GetRowNumber(handle) == rowNumber);
            }
        }

    }

}