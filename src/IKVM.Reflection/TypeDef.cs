using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace IKVM.Reflection
{

    /// <summary>
    /// Describes a reference to a type either being written or loaded from the workspace.
    /// </summary>
    [DebuggerDisplay(nameof(FullName))]
    public abstract class TypeDef : IHasGenericParameters
    {

        readonly ConcurrentDictionary<string, FieldDef?> fieldByNameMap = new();
        readonly ConcurrentDictionary<string, MethodDef?> methodByNameMap = new();
        readonly ConcurrentDictionary<string, TypeDef?> nestedTypeByNameMap = new();
        readonly ConcurrentDictionary<string, PropertyDef?> propertyByNameMap = new();
        readonly ConcurrentDictionary<string, EventDef?> eventByNameMap = new();

        /// <summary>
        /// When this type is nested, gets the enclosing type.
        /// </summary>
        public abstract TypeDef? DeclaringType { get; }

        /// <summary>
        /// Gets the namespace of the type.
        /// </summary>
        public abstract string Namespace { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the full name of the type.
        /// </summary>
        public virtual string FullName => TypeNameUtil.GetTypeFullName(this);

        /// <summary>
        /// Gets the attributes of the type.
        /// </summary>
        public abstract TypeAttributes Attributes { get; }

        /// <summary>
        /// Gets the generic parameters of the type.
        /// </summary>
        public virtual IReadOnlyList<GenericParameter> GenericParameters => Array.Empty<GenericParameter>();

        /// <summary>
        /// Gets the signature of the base type.
        /// </summary>
        public virtual ITypeDefOrRef? BaseType => null;

        /// <summary>
        /// Gets the set of fields on the type.
        /// </summary>
        public virtual IReadOnlyList<FieldDef> Fields => Array.Empty<FieldDef>();

        /// <summary>
        /// Attempts to find the field with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public virtual bool TryFindField(string name, out FieldDef? field) => (field = fieldByNameMap.GetOrAdd(name, _ => Fields.FirstOrDefault(i => i.Name == _))) != null;

        /// <summary>
        /// Gets the set of methods on the type.
        /// </summary>
        public virtual IReadOnlyList<MethodDef> Methods => Array.Empty<MethodDef>();

        /// <summary>
        /// Attempts to find the method with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public virtual bool TryFindMethod(string name, out MethodDef? method) => (method = methodByNameMap.GetOrAdd(name, _ => Methods.FirstOrDefault(i => i.Name == _))) != null;

        /// <summary>
        /// Gets the set of properties on this type.
        /// </summary>
        public virtual IReadOnlyList<PropertyDef> Properties => Array.Empty<PropertyDef>();

        /// <summary>
        /// Attempts to find the property with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public virtual bool TryFindProperty(string name, out PropertyDef? property) => (property = propertyByNameMap.GetOrAdd(name, _ => Properties.FirstOrDefault(i => i.Name == _))) != null;

        /// <summary>
        /// Gets the set of events on this type.
        /// </summary>
        public virtual IReadOnlyList<EventDef> Events => Array.Empty<EventDef>();

        /// <summary>
        /// Attempts to find the event with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        public virtual bool TryFindEvent(string name, out EventDef? evt) => (evt = eventByNameMap.GetOrAdd(name, _ => Events.FirstOrDefault(i => i.Name == _))) != null;

        /// <summary>
        /// Gets a value indicating whether the type is enclosed by another type.
        /// </summary>
        public bool IsNested => DeclaringType != null;

        /// <summary>
        /// Gets the set of nested types on this type.
        /// </summary>
        public virtual IReadOnlyList<TypeDef> NestedTypes => Array.Empty<TypeDef>();

        /// <summary>
        /// Attempts to find the nested type with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual bool TryFindNestedType(string name, out TypeDef? type) => (type = nestedTypeByNameMap.GetOrAdd(name, _ => NestedTypes.FirstOrDefault(i => i.Name == _))) != null;

        #region Attribute Properties

        /// <summary>
        /// Gets a value indicating whether the type is in a public scope or not.
        /// </summary>
        public bool IsNotPublic => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic;

        /// <summary>
        /// Gets or sets a value indicating whether the type is in a public scope or not.
        /// </summary>
        public bool IsPublic => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public;

        /// <summary>
        /// Gets or sets a value indicating whether the type is nested with public visibility.
        /// </summary>
        /// <remarks>
        /// Updating the value of this property does not automatically make the type nested in another type.
        /// Similarly, adding this type to another enclosing type will not automatically update this property.
        /// </remarks>
        public bool IsNestedPublic => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic;

        /// <summary>
        /// Gets or sets a value indicating whether the type is nested with private visibility.
        /// </summary>
        /// <remarks>
        /// Updating the value of this property does not automatically make the type nested in another type.
        /// Similarly, adding this type to another enclosing type will not automatically update this property.
        /// </remarks>
        public bool IsNestedPrivate => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPrivate;

        /// <summary>
        /// Gets or sets a value indicating whether the type is nested with family visibility.
        /// </summary>
        /// <remarks>
        /// Updating the value of this property does not automatically make the type nested in another type.
        /// Similarly, adding this type to another enclosing type will not automatically update this property.
        /// </remarks>
        public bool IsNestedFamily => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamily;

        /// <summary>
        /// Gets or sets a value indicating whether the type is nested with assembly visibility.
        /// </summary>
        /// <remarks>
        /// Updating the value of this property does not automatically make the type nested in another type.
        /// Similarly, adding this type to another enclosing type will not automatically update this property.
        /// </remarks>
        public bool IsNestedAssembly => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedAssembly;

        /// <summary>
        /// Gets or sets a value indicating whether the type is nested with family and assembly visibility.
        /// </summary>
        /// <remarks>
        /// Updating the value of this property does not automatically make the type nested in another type.
        /// Similarly, adding this type to another enclosing type will not automatically update this property.
        /// </remarks>
        public bool IsNestedFamilyAndAssembly => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamANDAssem;

        /// <summary>
        /// Gets or sets a value indicating whether the type is nested with family or assembly visibility.
        /// </summary>
        /// <remarks>
        /// Updating the value of this property does not automatically make the type nested in another type.
        /// Similarly, adding this type to another enclosing type will not automatically update this property.
        /// </remarks>
        public bool IsNestedFamilyOrAssembly => (Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamORAssem;

        /// <summary>
        /// Gets or sets a value indicating whether the fields of the type are auto-laid out by the
        /// common language runtime (CLR).
        /// </summary>
        public bool IsAutoLayout => (Attributes & TypeAttributes.LayoutMask) == TypeAttributes.AutoLayout;

        /// <summary>
        /// Gets or sets a value indicating whether the fields of the type are laid out sequentially.
        /// </summary>
        public bool IsSequentialLayout => (Attributes & TypeAttributes.LayoutMask) == TypeAttributes.SequentialLayout;

        /// <summary>
        /// Gets or sets a value indicating whether the fields of the type are laid out explicitly.
        /// </summary>
        public bool IsExplicitLayout => (Attributes & TypeAttributes.LayoutMask) == TypeAttributes.ExplicitLayout;

        /// <summary>
        /// Gets or sets a value indicating whether the type is a class.
        /// </summary>
        public bool IsClass => (Attributes & TypeAttributes.ClassSemanticsMask) == TypeAttributes.Class;

        /// <summary>
        /// Gets or sets a value indicating whether the type is an interface.
        /// </summary>
        public bool IsInterface => (Attributes & TypeAttributes.ClassSemanticsMask) == TypeAttributes.Interface;

        /// <summary>
        /// Gets or sets a value indicating whether the type is defined abstract and should be extended before
        /// an object can be instantiated.
        /// </summary>
        public bool IsAbstract => (Attributes & TypeAttributes.Abstract) != 0;

        /// <summary>
        /// Gets or sets a value indicating whether the type is defined sealed and cannot be extended by a sub class.
        /// </summary>
        public bool IsSealed => (Attributes & TypeAttributes.Sealed) != 0;

        /// <summary>
        /// Gets or sets a value indicating whether the type has a special name.
        /// </summary>
        public bool IsSpecialName => (Attributes & TypeAttributes.SpecialName) != 0;

        /// <summary>
        /// Gets or sets a value indicating whether the runtime should check the encoding of the name.
        /// </summary>
        public bool IsRuntimeSpecialName => (Attributes & TypeAttributes.RTSpecialName) != 0;

        /// <summary>
        /// Gets or sets a value indicating whether the type is imported.
        /// </summary>
        public bool IsImport => (Attributes & TypeAttributes.Import) != 0;

        /// <summary>
        /// Gets or sets a value indicating whether the type is serializable.
        /// </summary>
        public bool IsSerializable => (Attributes & TypeAttributes.Serializable) != 0;

        /// <summary>
        /// Gets or sets a value indicating whether LPTSTR string instances are interpreted as ANSI strings.
        /// </summary>
        public bool IsAnsiClass => (Attributes & TypeAttributes.StringFormatMask) == TypeAttributes.AnsiClass;

        /// <summary>
        /// Gets or sets a value indicating whether LPTSTR string instances are interpreted as Unicode strings.
        /// </summary>
        public bool IsUnicodeClass => (Attributes & TypeAttributes.StringFormatMask) == TypeAttributes.UnicodeClass;

        /// <summary>
        /// Gets or sets a value indicating whether LPTSTR string instances are interpreted automatically by the runtime.
        /// </summary>
        public bool IsAutoClass => (Attributes & TypeAttributes.StringFormatMask) == TypeAttributes.AutoClass;

        /// <summary>
        /// Gets or sets a value indicating whether LPTSTR string instances are interpreted using a non-standard encoding.
        /// </summary>
        public bool IsCustomFormatClass => (Attributes & TypeAttributes.StringFormatMask) == TypeAttributes.CustomFormatClass;

        /// <summary>
        /// Gets or sets a value indicating the runtime should initialize the class before any time before the first
        /// static field access.
        /// </summary>
        public bool IsBeforeFieldInit => (Attributes & TypeAttributes.BeforeFieldInit) != 0;

        /// <summary>
        /// Gets or sets a value indicating the type has additional security attributes associated to it.
        /// </summary>
        public bool HasSecurity => (Attributes & TypeAttributes.HasSecurity) != 0;

        /// <summary>
        /// Accepts a visitor.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TState"></typeparam>
        /// <param name="visitor"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract TResult AcceptVisitor<TResult, TState>(ITypeDefVisitor<TResult, TState> visitor, TState state);

        #endregion

        /// <inheritdoc />
        public override string ToString() => FullName;

    }

}
