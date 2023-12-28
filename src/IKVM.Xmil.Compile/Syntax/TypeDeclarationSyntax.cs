namespace IKVM.Xmil.Compile.Syntax
{

    public abstract record class TypeDeclarationSyntax(string Namespace, string Name, TypeModifiers Modifiers) : MemberDeclarationSyntax(Name);

}
