using System.Linq;
using System.Runtime.CompilerServices;

namespace IKVM.Reflection.Emit.Reflection
{

    /// <summary>
    /// Provides a context for the reflection emit API based on System.Reflection.Emit.
    /// </summary>
    public class ReflectionEmitContext : EmitContext
    {

        readonly ConditionalWeakTable<System.Reflection.Emit.AssemblyBuilder, ReflectionAssemblyBuilder> assemblies = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.ModuleBuilder, ReflectionModuleBuilder> modules = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.TypeBuilder, ReflectionTypeBuilder> types = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.EnumBuilder, ReflectionEnumBuilder> enums = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.FieldBuilder, ReflectionFieldBuilder> fields = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.MethodBuilder, ReflectionMethodBuilder> methods = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.ConstructorBuilder, ReflectionConstructorBuilder> constructors = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.PropertyBuilder, ReflectionPropertyBuilder> properties = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.EventBuilder, ReflectionEventBuilder> events = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.ParameterBuilder, ReflectionParameterBuilder> parameters = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.GenericTypeParameterBuilder, ReflectionGenericTypeParameterBuilder> genericTypeParameters = new();
        readonly ConditionalWeakTable<System.Reflection.Emit.ILGenerator, ReflectionILGenerator> ilGenerators = new();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ReflectionEmitContext()
        {

        }

        /// <summary>
        /// Creates a new <see cref="ReflectionAssemblyBuilder"/> for a given real <see cref="System.Reflection.Emit.AssemblyBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public AssemblyBuilder Adopt(System.Reflection.Emit.AssemblyBuilder wrapped) => assemblies.GetValue(wrapped, r => new ReflectionAssemblyBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionModuleBuilder"/> for a given real <see cref="System.Reflection.Emit.ModuleBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public ModuleBuilder Adopt(System.Reflection.Emit.ModuleBuilder wrapped) => modules.GetValue(wrapped, r => new ReflectionModuleBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionTypeBuilder"/> for a given real <see cref="System.Reflection.Emit.TypeBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public TypeBuilder Adopt(System.Reflection.Emit.TypeBuilder wrapped) => types.GetValue(wrapped, r => new ReflectionTypeBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionEnumBuilder"/> for a given real <see cref="System.Reflection.Emit.EnumBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public EnumBuilder Adopt(System.Reflection.Emit.EnumBuilder wrapped) => enums.GetValue(wrapped, r => new ReflectionEnumBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionFieldBuilder"/> for a given real <see cref="System.Reflection.Emit.FieldBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public FieldBuilder Adopt(System.Reflection.Emit.FieldBuilder wrapped) => fields.GetValue(wrapped, r => new ReflectionFieldBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionMethodBuilder"/> for a given real <see cref="System.Reflection.Emit.MethodBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public MethodBuilder Adopt(System.Reflection.Emit.MethodBuilder wrapped) => methods.GetValue(wrapped, r => new ReflectionMethodBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionConstructorBuilder"/> for a given real <see cref="System.Reflection.Emit.ConstructorBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public ConstructorBuilder Adopt(System.Reflection.Emit.ConstructorBuilder wrapped) => constructors.GetValue(wrapped, r => new ReflectionConstructorBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionPropertyBuilder"/> for a given real <see cref="System.Reflection.Emit.PropertyBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public PropertyBuilder Adopt(System.Reflection.Emit.PropertyBuilder wrapped) => properties.GetValue(wrapped, r => new ReflectionPropertyBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionEventBuilder"/> for a given real <see cref="System.Reflection.Emit.EventBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public EventBuilder Adopt(System.Reflection.Emit.EventBuilder wrapped) => events.GetValue(wrapped, r => new ReflectionEventBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionParameterBuilder"/> for a given real <see cref="System.Reflection.Emit.ParameterBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public ParameterBuilder Adopt(System.Reflection.Emit.ParameterBuilder wrapped) => parameters.GetValue(wrapped, r => new ReflectionParameterBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionGenericTypeParameterBuilder"/> for a given real <see cref="System.Reflection.Emit.GenericTypeParameterBuilder"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public GenericTypeParameterBuilder Adopt(System.Reflection.Emit.GenericTypeParameterBuilder wrapped) => genericTypeParameters.GetValue(wrapped, r => new ReflectionGenericTypeParameterBuilder(this, r));

        /// <summary>
        /// Creates a new <see cref="ReflectionILGenerator"/> for a given real <see cref="System.Reflection.Emit.ILGenerator"/>.
        /// </summary>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public ILGenerator Adopt(System.Reflection.Emit.ILGenerator wrapped) => ilGenerators.GetValue(wrapped, r => new ReflectionILGenerator(this, r));

        /// <summary>
        /// Defines a assembly that has the specified name and access rights.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public override AssemblyBuilder DefineAssembly(AssemblyName name, AssemblyBuilderAccess access)
        {
#if NET || NETSTANDARD
            if (access == AssemblyBuilderAccess.Save || access == AssemblyBuilderAccess.RunAndSave)
                throw new PlatformNotSupportedException("Saving assemblies with the Reflection provider is not supported on .NET or .NET Standard.");
#endif

            return Adopt(System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly(name, (System.Reflection.Emit.AssemblyBuilderAccess)(int)access));
        }

        /// <summary>
        /// Defines a assembly that has the specified name, access rights, and attributes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="access"></param>
        /// <param name="assemblyAttributes"></param>
        /// <returns></returns>
        public override AssemblyBuilder DefineAssembly(AssemblyName name, AssemblyBuilderAccess access, IEnumerable<CustomAttributeBuilder>? assemblyAttributes)
        {
#if NET || NETSTANDARD
            if (access == AssemblyBuilderAccess.Save || access == AssemblyBuilderAccess.RunAndSave)
                throw new PlatformNotSupportedException("Saving assemblies with the Reflection provider is not supported on .NET or .NET Standard.");
#endif

            return Adopt(System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly(name, (System.Reflection.Emit.AssemblyBuilderAccess)(int)access, assemblyAttributes?.Cast<ReflectionCustomAttributeBuilder>().Select(i => i.Wrapped)));
        }

    }

}
