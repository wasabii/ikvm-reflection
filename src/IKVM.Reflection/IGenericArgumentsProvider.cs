using System.Collections.Generic;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides members for describing an instantiation of a type or method.
    /// </summary>
    public interface IGenericArgumentsProvider
    {

        /// <summary>
        /// Gets a collection of type arguments used to instantiate the generic member.
        /// </summary>
        IReadOnlyList<ITypeDefOrRef> TypeArguments { get; }

    }

}
