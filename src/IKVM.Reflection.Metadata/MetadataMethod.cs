using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    [DebuggerDisplay(nameof(DisplayName))]
    internal class MetadataMethod : IMethod
    {

        readonly MetadataModule module;
        readonly MetadataTypeDef? parentType;
        readonly MethodDefinitionHandle handle;
        readonly MethodDefinition def;

        MethodSignature? signature;
        MetadataMethodGenericParameter[]? genericParameters;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="parentType"></param>
        /// <param name="handle"></param>
        public MetadataMethod(MetadataModule module, MetadataTypeDef? parentType, MethodDefinitionHandle handle)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.parentType = parentType;
            this.handle = handle;
            this.def = module.Reader.GetMethodDefinition(handle);
        }

        /// <summary>
        /// Gets the module in which this method is defined.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets the parent type of this method.
        /// </summary>
        ModuleDef IMethod.Module => Module;

        /// <summary>
        /// Gets the parent type of the method.
        /// </summary>
        public MetadataTypeDef? ParentType => parentType;

        /// <summary>
        /// Gets the parent type of this method.
        /// </summary>
        TypeDef? IMethod.ParentType => ParentType;

        /// <summary>
        /// Gets the name of the method.
        /// </summary>
        public string Name => module.Reader.GetString(def.Name);

        /// <summary>
        /// Gets the display name of this method.
        /// </summary>
        public string DisplayName => MemberNameUtil.GetMethodDisplayName(this);

        /// <summary>
        /// Gets the attributes of the method.
        /// </summary>
        public MethodAttributes Attributes => def.Attributes;

        /// <summary>
        /// Gets the implementation attributes of the method.
        /// </summary>
        public MethodImplAttributes ImplAttributes => def.ImplAttributes;

        /// <summary>
        /// Gets the signature for the method.
        /// </summary>
        public MethodSignature Signature => LazyUtil.Get(ref signature, () => module.DecodeMethodSignature(handle, new MetadataGenericContext(ParentType, this)));

        /// <summary>
        /// Gets the type signature of the method return.
        /// </summary>
        public TypeSig ReturnType => Signature.ReturnType;

        /// <summary>
        /// Gets the generic parameters of the method.
        /// </summary>
        public IReadOnlyList<MetadataMethodGenericParameter> GenericParameters => LazyUtil.Get(ref genericParameters, LoadGenericParameters);

        /// <summary>
        /// Gets the generic parameters of the method.
        /// </summary>
        IReadOnlyList<GenericParameter> IMethod.GenericParameters => GenericParameters;

        /// <summary>
        /// Loads the generic parameters of the method.
        /// </summary>
        /// <returns></returns>
        MetadataMethodGenericParameter[] LoadGenericParameters()
        {
            var t = def.GetGenericParameters();
            if (t.Count == 0)
                return Array.Empty<MetadataMethodGenericParameter>();

            var l = new MetadataMethodGenericParameter[t.Count];
            int i = 0;
            foreach (var h in t)
                l[i++] = new MetadataMethodGenericParameter(module, this, h);

            return l;
        }

        /// <summary>
        /// Gets the parameters of the method.
        /// </summary>
        public IReadOnlyList<IParameter> Parameters => throw new NotImplementedException();

        /// <inheritdoc />
        public override string ToString()
        {
            return DisplayName;
        }

    }

}