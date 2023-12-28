using System.Reflection;

namespace IKVM.Xmil.Compile.Syntax
{

    public record class ParameterSyntax(string Name, ParameterAttributes Attributes) : SyntaxBase;

}