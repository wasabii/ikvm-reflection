using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a field either being written or loaded from the workspace.
    /// </summary>
    public interface IEvent
    {

        /// <summary>
        /// Gets the module from which this event was loaded from.
        /// </summary>
        ModuleDef Module { get; }

        /// <summary>
        /// Gets the type that contains the event.
        /// </summary>
        TypeDef? ParentType { get; }

        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the display name of the event.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the attributes of the event.
        /// </summary>
        EventAttributes Attributes { get; }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        TypeSig EventType { get; }

        /// <summary>
        /// Gets the add method implementation.
        /// </summary>
        IMethod? AddMethod { get; }

        /// <summary>
        /// Gets the remove method implementation.
        /// </summary>
        IMethod? RemoveMethod { get; }

        /// <summary>
        /// Gets the raise method implementation.
        /// </summary>
        IMethod? RaiseMethod { get; }

    }

}
