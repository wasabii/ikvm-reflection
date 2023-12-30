using System.Text;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides methods for constructing the names of signatures.
    /// </summary>
    public static class TypeNameUtil
    {

        const string NullTypeString = "<<???>>";
        const string NullTypeNameString = "<<<NULL NAME>>>";

        /// <summary>
        /// Computes the full name of the <see cref="ITypeRef"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeFullName(ITypeDefOrRef? type)
        {
            var builder = new StringBuilder();
            AppendTypeFullName(builder, type);
            return builder.ToString();
        }

        /// <summary>
        /// Appends the full name of a <see cref="ITypeRef"/> to the builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static StringBuilder AppendTypeFullName(StringBuilder builder, ITypeDefOrRef? type)
        {
            if (type is null)
                return builder.Append(NullTypeString);

            if (type.DeclaringType is { } declaringType)
            {
                AppendTypeFullName(builder, declaringType);
                builder.Append('+');
            }
            else if (type.Namespace != null)
            {
                builder.Append(type.Namespace);
                builder.Append('.');
            }

            return builder.Append(type.Name ?? NullTypeNameString);
        }

        /// <summary>
        /// Computes the full name of the <see cref="TypeDef"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeFullName(TypeDef? type)
        {
            var builder = new StringBuilder();
            AppendTypeFullName(builder, type);
            return builder.ToString();
        }

        /// <summary>
        /// Appends the full name of a <see cref="TypeDef"/> to the builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static StringBuilder AppendTypeFullName(StringBuilder builder, TypeDef? type)
        {
            if (type is null)
                return builder.Append(NullTypeString);

            if (type.DeclaringType is { } parentType)
            {
                AppendTypeFullName(builder, parentType);
                builder.Append('+');
            }
            else if (type.Namespace != null)
            {
                builder.Append(type.Namespace);
                builder.Append('.');
            }

            return builder.Append(type.Name ?? NullTypeNameString);
        }

    }

}
