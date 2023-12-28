namespace IKVM.Xmil.Compile.Syntax
{

    public record class ClassDeclarationSyntax(string Namespace, string Name, TypeModifiers Modifiers) : TypeDeclarationSyntax(Namespace, Name, Modifiers);

}
