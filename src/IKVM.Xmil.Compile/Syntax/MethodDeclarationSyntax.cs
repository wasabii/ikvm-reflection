using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace IKVM.Xmil.Compile.Syntax
{

    public record class MethodDeclarationSyntax(string Name, MethodAttributes Attributes, MethodImplAttributes ImplAttributes, ImmutableList<GenericParameterSyntax> GenericParameters, ImmutableList<TypeSpecificationSyntax> Parameters, TypeSpecificationSyntax ReturnType) : MemberDeclarationSyntax(Name);

}
