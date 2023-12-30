using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

using IKVM.Reflection.Util;

namespace IKVM.Reflection.Metadata
{

    [DebuggerDisplay(nameof(DisplayName))]
    internal class MetadataEvent : IEvent
    {

        readonly MetadataModule module;
        readonly MetadataTypeDef parentType;
        readonly EventDefinitionHandle handle;
        readonly EventDefinition def;

        MethodSignature? signature;
        Lazy<MetadataMethod?>? addMethod;
        Lazy<MetadataMethod?>? removeMethod;
        Lazy<MetadataMethod?>? raiseMethod;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="declaringType"></param>
        /// <param name="handle"></param>
        public MetadataEvent(MetadataModule module, MetadataTypeDef declaringType, EventDefinitionHandle handle)
        {
            Debug.Assert(handle.IsNil == false);
            this.module = module ?? throw new ArgumentNullException(nameof(module));
            this.parentType = declaringType ?? throw new ArgumentNullException(nameof(declaringType));
            this.handle = handle;
            this.def = module.Reader.GetEventDefinition(handle);
        }

        /// <summary>
        /// Gets the parent module of this event.
        /// </summary>
        public MetadataModule Module => module;

        /// <summary>
        /// Gets the parent module of this event.
        /// </summary>
        ModuleDef IEvent.Module => Module;

        /// <summary>
        /// Gets the parent type of this event.
        /// </summary>
        public MetadataTypeDef ParentType => parentType;

        /// <summary>
        /// Gets the parent type of this event.
        /// </summary>
        TypeDef IEvent.ParentType => ParentType;

        /// <summary>
        /// Gets the name of this event.
        /// </summary>
        public string Name => module.Reader.GetString(def.Name);

        /// <summary>
        /// Gets the display name of this event.
        /// </summary>
        public string DisplayName => MemberNameUtil.GetEventDisplayName(this);

        /// <summary>
        /// Gets the attributes of this event.
        /// </summary>
        public EventAttributes Attributes => def.Attributes;

        /// <summary>
        /// Gets the type signature of this event.
        /// </summary>
        public TypeSig EventType => module.DecodeTypeSignature(def.Type, new MetadataGenericContext(ParentType, null));

        /// <summary>
        /// Gets the add method.
        /// </summary>
        public MetadataMethod? AddMethod => LazyUtil.Get(ref addMethod, () => new Lazy<MetadataMethod?>(() => module.GetOrCreateMethod(def.GetAccessors().Adder))).Value;

        /// <summary>
        /// Gets the add method.
        /// </summary>
        IMethod? IEvent.AddMethod => AddMethod;

        /// <summary>
        /// Gets the remove method.
        /// </summary>
        public MetadataMethod? RemoveMethod => LazyUtil.Get(ref removeMethod, () => new Lazy<MetadataMethod?>(() => module.GetOrCreateMethod(def.GetAccessors().Remover))).Value;

        /// <summary>
        /// Gets the remove method.
        /// </summary>
        IMethod? IEvent.RemoveMethod => RemoveMethod;

        /// <summary>
        /// Gets the raise method.
        /// </summary>
        public MetadataMethod? RaiseMethod => LazyUtil.Get(ref raiseMethod, () => new Lazy<MetadataMethod?>(() => module.GetOrCreateMethod(def.GetAccessors().Raiser))).Value;

        /// <summary>
        /// Gets the raise method.
        /// </summary>
        IMethod? IEvent.RaiseMethod => RaiseMethod;

        /// <inheritdoc />
        public override string ToString()
        {
            return DisplayName;
        }

    }

}