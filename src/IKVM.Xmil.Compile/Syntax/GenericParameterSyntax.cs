using System.Reflection;

namespace IKVM.Xmil.Compile.Syntax
{

    public record class GenericParameterSyntax(string Name, GenericParameterAttributes Attributes) : SyntaxBase;

}