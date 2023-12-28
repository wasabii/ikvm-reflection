using System.Reflection;

namespace IKVM.Xmil.Compile.Syntax
{

    public record class FieldDeclarationSyntax(string Name, TypeSpecificationSyntax FieldType, FieldAttributes Attributes) : MemberDeclarationSyntax(Name);

}
