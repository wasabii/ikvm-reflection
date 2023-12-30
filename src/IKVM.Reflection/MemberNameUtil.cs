using System.Collections.Generic;
using System.Text;

using IKVM.Reflection.Extensions;

namespace IKVM.Reflection
{

    public static class MemberNameUtil
    {

        const string NullMemberNameString = "<<<NULL NAME>>>";

        /// <summary>
        /// Computes the display name of a method.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetMethodDisplayName(IMethod method)
        {
            var builder = new StringBuilder();
            AppendMethodDisplayName(builder, method);
            return builder.ToString();
        }

        /// <summary>
        /// Computes the display name of a method.
        /// return type and parameters.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="method"></param>
        public static StringBuilder AppendMethodDisplayName(StringBuilder builder, IMethod method)
        {
            SignatureNameUtil.AppendTypeDisplayName(builder, method.ReturnType);
            builder.Append(' ');

            AppendMemberParentType(builder, method.ParentType);
            builder.Append(method.Name ?? NullMemberNameString);

            AppendTypeParameters(builder, method.GenericParameters);

            builder.Append('(');
            AppendSignatureParameterTypes(builder, method.Signature);
            builder.Append(')');

            return builder;
        }

        /// <summary>
        /// Appends the declaring type for a member.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="declaringType"></param>
        /// <returns></returns>
        static StringBuilder AppendMemberParentType(StringBuilder builder, TypeDef? declaringType)
        {
            if (declaringType is not null)
            {
                TypeNameUtil.AppendTypeFullName(builder, declaringType);
                builder.Append("::");
            }

            return builder;
        }

        /// <summary>
        /// Appends the declaring type for a member.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="declaringType"></param>
        /// <returns></returns>
        static StringBuilder AppendMemberParentType(StringBuilder builder, ITypeRef? declaringType)
        {
            if (declaringType is not null)
            {
                TypeNameUtil.AppendTypeFullName(builder, declaringType);
                builder.Append("::");
            }

            return builder;
        }

        /// <summary>
        /// Appends the signature parameters for a method.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        static StringBuilder AppendSignatureParameterTypes(StringBuilder state, MethodSigBase? signature)
        {
            if (signature is null)
                return state;

            for (int i = 0; i < signature.ParameterTypes.Count; i++)
            {
                signature.ParameterTypes[i].AcceptVisitor(TypeSigNameVisitor.Instance, state);
                if (i < signature.ParameterTypes.Count - 1)
                    state.Append(", ");
            }

            if (signature.CallingConvention == CallingConventionAttributes.VarArgs)
                state.Append("...");

            return state;
        }

        /// <summary>
        /// Appends the generic parameters for a method.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="genericParameters"></param>
        /// <returns></returns>
        static StringBuilder AppendTypeParameters(StringBuilder builder, IReadOnlyList<GenericParameter> genericParameters)
        {
            if (genericParameters.Count > 0)
            {
                builder.Append('<');
                builder.AppendJoin(genericParameters, ", ", static (s, t) => s.Append(t.Name));
                builder.Append('>');
            }

            return builder;
        }

        static StringBuilder AppendTypeParameters(StringBuilder builder, IReadOnlyList<TypeSig> typeArguments)
        {
            if (typeArguments.Count > 0)
            {
                builder.Append('<');
                builder.AppendJoin(typeArguments, ", ", static (s, t) => t.AcceptVisitor(TypeSigNameVisitor.Instance, s));
                builder.Append('>');
            }

            return builder;
        }

        /// <summary>
        /// Gets display name for <paramref name="field"/>.
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetFieldDisplayName(FieldDef field)
        {
            var builder = new StringBuilder();
            AppendFieldDisplayName(builder, field);
            return builder.ToString();
        }

        /// <summary>
        /// Appends the display name for <paramref name="field"/> to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        static StringBuilder AppendFieldDisplayName(StringBuilder builder, FieldDef field)
        {
            SignatureNameUtil.AppendTypeDisplayName(builder, field.FieldType);
            builder.Append(' ');
            AppendMemberParentType(builder, field.DeclaringType);
            builder.Append(field.Name ?? NullMemberNameString);
            return builder;
        }

        /// <summary>
        /// Gets the display name for <paramref name="property"/>.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyDisplayName(IProperty property)
        {
            var builder = new StringBuilder();
            AppendPropertyDisplayName(builder, property);
            return builder.ToString();
        }

        /// <summary>
        /// Appends the display name for <paramref name="property"/> to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        static StringBuilder AppendPropertyDisplayName(StringBuilder builder, IProperty property)
        {
            SignatureNameUtil.AppendTypeDisplayName(builder, property.PropertyType);
            builder.Append(' ');
            AppendMemberParentType(builder, property.ParentType);
            builder.Append(property.Name ?? NullMemberNameString);

            if (property.ParameterTypes.Count > 0)
            {
                builder.Append('[');
                AppendSignatureParameterTypes(builder, property.Signature);
                builder.Append(']');
            }

            return builder;
        }

        /// <summary>
        /// Gets the display name for <paramref name="evt"/>.
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public static string GetEventDisplayName(IEvent evt)
        {
            var builder = new StringBuilder();
            AppendEventDisplayName(builder, evt);
            return builder.ToString();
        }

        /// <summary>
        /// Appends the display name for <paramref name="evt"/> to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="evt"></param>
        /// <returns></returns>
        static StringBuilder AppendEventDisplayName(StringBuilder builder, IEvent evt)
        {
            SignatureNameUtil.AppendTypeDisplayName(builder, evt.EventType);
            builder.Append(' ');
            AppendMemberParentType(builder, evt.ParentType);
            builder.Append(evt.Name);
            return builder;
        }

    }

}
