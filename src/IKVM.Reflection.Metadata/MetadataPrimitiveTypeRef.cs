using System;
using System.Diagnostics;
using System.Reflection;

namespace IKVM.Reflection.Metadata
{

    /// <summary>
    /// Reference to a primitive type within the core assembly.
    /// </summary>
    [DebuggerDisplay(nameof(FullName))]
    internal class MetadataPrimitiveTypeRef : ITypeRef
    {

        /// <summary>
        /// Private <see cref="IAssemblyRef"/> instance for locating the core assembly.
        /// </summary>
        class CoreLibAssemblyRef : IAssemblyRef
        {

            readonly MetadataModule module;

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="module"></param>
            public CoreLibAssemblyRef(MetadataModule module)
            {
                this.module = module ?? throw new ArgumentNullException(nameof(module));
            }

            /// <summary>
            /// Gets the name of the core assembly.
            /// </summary>
            public AssemblyName Name => module.Assembly.Context.Options.CoreLibName;

            /// <summary>
            /// Attempts to resolve the core assembly.
            /// </summary>
            /// <param name="assembly"></param>
            /// <returns></returns>
            public bool TryResolve(out AssemblyDef? assembly)
            {
                return module.Assembly.Context.TryResolveAssembly(Name, module, out assembly);
            }

        }

        readonly MetadataModule module;
        readonly IAssemblyRef assembly;
        readonly PrimitiveTypeCode typeCode;
        readonly string name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="typeCode"></param>
        public MetadataPrimitiveTypeRef(MetadataModule module, PrimitiveTypeCode typeCode)
        {
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.assembly = new CoreLibAssemblyRef(module);
            this.typeCode = typeCode;

            name = typeCode switch
            {
                PrimitiveTypeCode.Void => "Void",
                PrimitiveTypeCode.Boolean => nameof(Boolean),
                PrimitiveTypeCode.Char => nameof(Char),
                PrimitiveTypeCode.SByte => nameof(SByte),
                PrimitiveTypeCode.Byte => nameof(Byte),
                PrimitiveTypeCode.Int16 => nameof(Int16),
                PrimitiveTypeCode.UInt16 => nameof(UInt16),
                PrimitiveTypeCode.Int32 => nameof(Int32),
                PrimitiveTypeCode.UInt32 => nameof(UInt32),
                PrimitiveTypeCode.Int64 => nameof(Int64),
                PrimitiveTypeCode.UInt64 => nameof(UInt64),
                PrimitiveTypeCode.Single => nameof(Single),
                PrimitiveTypeCode.Double => nameof(Double),
                PrimitiveTypeCode.String => nameof(String),
                PrimitiveTypeCode.TypedReference => nameof(TypedReference),
                PrimitiveTypeCode.IntPtr => nameof(IntPtr),
                PrimitiveTypeCode.UIntPtr => nameof(UIntPtr),
                PrimitiveTypeCode.Object => nameof(Object),
                _ => throw new InvalidOperationException(),
            };
        }

        /// <summary>
        /// Gets the assembly of this primitive type.
        /// </summary>
        public IAssemblyRef Assembly => assembly;

        /// <summary>
        /// Gets the parent type.
        /// </summary>
        public ITypeRef? ParentType => null;

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        public string? Namespace => "System";

        /// <summary>
        /// Gets the name of the primitive type.
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Gets the full name of the primitive type.
        /// </summary>
        public string FullName => TypeNameUtil.GetTypeFullName(this);

        /// <summary>
        /// Attempts to resolve the type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool TryResolve(out TypeDef? type)
        {
            return module.Assembly.Context.TryResolveType(assembly.Name, Namespace ?? throw new InvalidOperationException(), Name, module, out type);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return FullName;
        }

    }

}
