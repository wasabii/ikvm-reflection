using System;

using IKVM.Reflection.Metadata;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.Reflection.Tests.Metadata
{

    [TestClass]
    public class TestClass
    {

        [TestMethod]
        public void Foo()
        {
            var opt = new AssemblyContextOptions() { CoreLibName = AssemblyContextOptions.NetCoreDefaultCoreLibName };
            var ctx = new DefaultAssemblyContext(opt, new[] { new MetadataAssemblyResolver(Array.Empty<string>(), new[] { "C:\\Program Files\\dotnet\\packs\\Microsoft.NETCore.App.Ref\\8.0.0\\ref\\net8.0" }) });
            if (ctx.TryResolveAssembly("System.Runtime", out var asm))
            {
                Console.WriteLine(asm!.Name);

                foreach (var t in asm.Types)
                {
                    Console.WriteLine(t);

                    foreach (var f in t.Fields)
                        Console.WriteLine("  F:{0}", f);

                    foreach (var m in t.Methods)
                        Console.WriteLine("  M:{0}", m);

                    foreach (var p in t.Properties)
                        Console.WriteLine("  P:{0}", p);

                    foreach (var e in t.Events)
                        Console.WriteLine("  E:{0}", e);
                }
            }
        }

    }

}
