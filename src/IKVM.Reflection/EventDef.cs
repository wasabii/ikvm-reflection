using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a event resolved within .NET metadata.
    /// </summary>
    public abstract class EventDef : IHasCustomAttributes
    {

        /// <summary>
        /// Gets the custom attributes applied to the event.
        /// </summary>
        public abstract IReadOnlyList<CustomAttribute> CustomAttributes { get; }

        /// <summary>
        /// Gets the reference to the type that holds the event.
        /// </summary>
        public abstract TypeDef DeclaringType { get; }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        public abstract ITypeDefOrRef EventType { get; }

        /// <summary>
        /// Gets the add method implementation.
        /// </summary>
        public abstract MethodRef? AddMethod { get; }

        /// <summary>
        /// Gets the remove method implementation.
        /// </summary>
        public abstract MethodRef? RemoveMethod { get; }

        /// <summary>
        /// Gets the raise method implementation.
        /// </summary>
        public abstract MethodRef? RaiseMethod { get; }
    }

}
