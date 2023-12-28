using System.Collections.Immutable;

namespace IKVM.Xmil.Compile.Syntax
{

    public record class AssemblyDeclarationSyntax(IImmutableList<AttributeSyntax> Attributes, IImmutableList<ClassDeclarationSyntax> Classes);

}
