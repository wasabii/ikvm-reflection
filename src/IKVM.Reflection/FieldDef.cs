using System.Diagnostics;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a field either being written or loaded from the workspace.
    /// </summary>
    [DebuggerDisplay(nameof(DisplayName))]
    public abstract class FieldDef
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected FieldDef()
        {

        }

        /// <summary>
        /// Gets the assembly that contains the field.
        /// </summary>
        public virtual AssemblyDef Assembly => Module.Assembly;

        /// <summary>
        /// Gets the module that contains the field.
        /// </summary>
        public abstract ModuleDef Module { get; }

        /// <summary>
        /// Gets the type that contains the field.
        /// </summary>
        public abstract TypeDef? DeclaringType { get; }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the display name of the field.
        /// </summary>
        public virtual string DisplayName => MemberNameUtil.GetFieldDisplayName(this);

        /// <summary>
        /// Gets the attributes of the field.
        /// </summary>
        public abstract FieldAttributes Attributes { get; }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        public abstract ITypeDefOrRef FieldType { get; }

    }

}
