using System;
using System.Collections.Generic;
using System.Text;

namespace IKVM.Reflection
{

    /// <summary>
    /// Provides methods for constructing the full name of a member in a .NET module.
    /// </summary>
    internal sealed class TypeNameVisitor : ITypeDefVisitor<StringBuilder, StringBuilder>
    {

        const string NullTypeToString = "<<???>>";
        const string NullMemberName = "<<<NULL NAME>>>";

        /// <summary>
        /// Gets a reference to the static instance of the <see cref="TypeNameVisitor"/>.
        /// </summary>
        public static TypeNameVisitor Instance = new();

        StringBuilder AppendTypeParameters(IReadOnlyList<ITypeDefOrRef> typeArguments, StringBuilder builder)
        {
            if (typeArguments.Count > 0)
            {
                builder.Append('<');
                AppendCommaSeparatedList(builder, typeArguments, (s, t) => t.AcceptVisitor(this, s));
                builder.Append('>');
            }

            return builder;
        }

        StringBuilder AppendTypeDisplayName(StringBuilder builder, TypeDef? type)
        {
            return type.AcceptVisitor(this, builder);
        }

        static StringBuilder AppendCommaSeparatedList<T>(StringBuilder state, IReadOnlyList<T> collection, Action<StringBuilder, T> action)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                action(state, collection[i]);
                if (i < collection.Count - 1)
                    state.Append(", ");
            }

            return state;
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitArrayType(ITypeDefOrRef type, StringBuilder state)
        {
            type.BaseType.AcceptVisitor(this, state);

            state.Append('[');

            AppendCommaSeparatedList(state, type.Dimensions, static (s, d) =>
            {
                if (d.LowerBound.HasValue)
                {
                    if (d.Size.HasValue)
                        AppendDimensionBound(s, d.LowerBound.Value, d.Size.Value);
                    else
                        s.Append(d.LowerBound.Value).Append("...");
                }

                if (d.Size.HasValue)
                    AppendDimensionBound(s, 0, d.Size.Value);

                static void AppendDimensionBound(StringBuilder state, int low, int size) => state.Append(low).Append("...").Append(low + size - 1);
            });

            return state.Append(']');
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitBoxedType(ITypeDefOrRef type, StringBuilder state)
        {
            return type.BaseType.AcceptVisitor(this, state);
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitByReferenceType(ByRefTypeSignature signature, StringBuilder state)
        {
            return signature.BaseType.AcceptVisitor(this, state).Append('&');
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitCustomModifierType(CustomModifierTypeSignature signature, StringBuilder state)
        {
            signature.BaseType.AcceptVisitor(this, state);
            state.Append(signature.IsRequired ? " modreq(" : " modopt(");
            AppendTypeDisplayName(state, signature.ModifierType);
            return state.Append(')');
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitGenericInstanceType(GenericInstanceTypeSignature signature, StringBuilder state)
        {
            AppendTypeDisplayName(state, signature.GenericType);
            return AppendTypeParameters(state, signature.TypeArguments);
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitGenericParameterType(GenericParameterTypeSignature signature, StringBuilder state)
        {
            state.Append(signature.Scope switch
            {
                GenericParameterScope.Type => "!",
                GenericParameterScope.Method => "!!",
                _ => throw new ArgumentOutOfRangeException()
            });

            return state.Append(signature.Index);
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitPinnedType(PinnedTypeSignature signature, StringBuilder state)
        {
            return signature.BaseType.AcceptVisitor(this, state);
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitPointerType(PointerTypeSignature signature, StringBuilder state)
        {
            return signature.BaseType
                .AcceptVisitor(this, state)
                .Append('*');
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitSentinelType(SentinelTypeSignature signature, StringBuilder state)
        {
            return state.Append("<<<SENTINEL>>>");
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitSzArrayType(SzArrayTypeSignature signature, StringBuilder state)
        {
            return signature.BaseType
                .AcceptVisitor(this, state)
                .Append("[]");
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitTypeRefType(TypeRefTypeSignature signature, StringBuilder state)
        {
            return TypeNameUtil.AppendTypeFullName(state, signature.Type);
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitTypeDefType(TypeDefTypeSignature signature, StringBuilder state)
        {
            return TypeNameUtil.AppendTypeFullName(state, signature.Type);
        }

        /// <inheritdoc />
        StringBuilder ITypeDefVisitor<StringBuilder, StringBuilder>.VisitFunctionPointerType(FunctionPointerTypeSignature signature, StringBuilder builder)
        {
            builder.Append("method ");
            return SignatureNameUtil.AppendMethodDisplayName(builder, signature.Signature);
        }

    }

}
