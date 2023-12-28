namespace IKVM.Xmil.Compile.Syntax
{

    public record class InterfaceDeclarationSyntax(string NamespaceName, string TypeName, TypeModifiers Visibility) : TypeDeclarationSyntax(NamespaceName, TypeName, Visibility);

}
