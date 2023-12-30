using System;
using System.Text;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides methods for constructing the names of signatures.
    /// </summary>
    internal static class SignatureNameUtil
    {

        /// <summary>
        /// Computes the full name of a type signature, including its namespace and/or declaring types.
        /// </summary>
        /// <param name="builder">The builder to append the name to.</param>
        /// <param name="signature">The type to obtain the full name for.</param>
        public static void AppendTypeDisplayName(StringBuilder builder, TypeSig signature)
        {
            if (signature is null)
                throw new ArgumentNullException(nameof(signature));
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            signature.AcceptVisitor(TypeSigNameVisitor.Instance, builder);
        }

        /// <summary>
        /// Computes the full name of a type signature, including its namespace and/or declaring types.
        /// </summary>
        /// <param name="signature">The type to obtain the full name for.</param>
        /// <returns>The full name.</returns>
        public static string GetTypeDisplayName(TypeSig signature)
        {
            if (signature is null)
                throw new ArgumentNullException(nameof(signature));

            var builder = new StringBuilder();
            AppendTypeDisplayName(builder, signature);
            return builder.ToString();
        }

        /// <summary>
        /// Computes the full display name of a method signature.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="signature"></param>
        public static StringBuilder AppendMethodDisplayName(StringBuilder builder, MethodSignature signature)
        {
            if (signature is null)
                throw new ArgumentNullException(nameof(signature));
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            if (signature.HasThis)
                builder.Append("instance ");

            signature.ReturnType.AcceptVisitor(TypeSigNameVisitor.Instance, builder);

            builder.Append(" *");

            AppendMethodTypeArgumentPlaceholders(builder, signature);

            builder.Append('(');
            AppendMethodParameterTypes(builder, signature);
            builder.Append(')');

            return builder;
        }

        /// <summary>
        /// Appends the generic type argument placeholders for a method signature.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        static StringBuilder AppendMethodTypeArgumentPlaceholders(StringBuilder builder, MethodSignature? signature)
        {
            if (signature?.GenericParameterCount > 0)
            {
                builder.Append('<');

                for (int i = 0; i < signature.GenericParameterCount; i++)
                {
                    builder.Append('?');
                    if (i < signature.GenericParameterCount - 1)
                        builder.Append(", ");
                }

                builder.Append('>');
            }

            return builder;
        }

        /// <summary>
        /// Appends the parameter types for a method signature.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        static StringBuilder AppendMethodParameterTypes(StringBuilder builder, MethodSigBase? signature)
        {
            if (signature is null)
                return builder;

            for (int i = 0; i < signature.ParameterTypes.Count; i++)
            {
                signature.ParameterTypes[i].AcceptVisitor(TypeSigNameVisitor.Instance, builder);
                if (i < signature.ParameterTypes.Count - 1)
                    builder.Append(", ");
            }

            if (signature.CallingConvention == CallingConventionAttributes.VarArgs)
                builder.Append("...");

            return builder;
        }

    }

}
