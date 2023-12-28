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
        public static string GetTypeFullName(ITypeRef? type)
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
        public static StringBuilder AppendTypeFullName(StringBuilder builder, ITypeRef? type)
        {
            if (type is null)
                return builder.Append(NullTypeString);

            if (type.ParentType is { } parentType)
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

        /// <summary>
        /// Computes the full name of the <see cref="IType"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeFullName(IType? type)
        {
            var builder = new StringBuilder();
            AppendTypeFullName(builder, type);
            return builder.ToString();
        }

        /// <summary>
        /// Appends the full name of a <see cref="IType"/> to the builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static StringBuilder AppendTypeFullName(StringBuilder builder, IType? type)
        {
            if (type is null)
                return builder.Append(NullTypeString);

            if (type.ParentType is { } parentType)
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
