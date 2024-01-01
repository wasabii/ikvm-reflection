using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.Reflection.Tests
{

    [TestClass]
    public class MetadataLoadContextTests
    {

        [TestMethod]
        public void Foo()
        {
            var res = new PathAssemblyResolver(Directory.GetFiles("C:\\Program Files\\dotnet\\packs\\Microsoft.NETCore.App.Ref\\8.0.0\\ref\\net8.0", "*.dll"));
            var ctx = new MetadataLoadContext(res, "System.Runtime");
            var asm = ctx.LoadFromAssemblyName("System.Runtime");

            Console.WriteLine(asm.FullName);

            foreach (var t in asm.GetTypes())
            {
                Console.WriteLine(t);

                foreach (var f in t.GetFields())
                    Console.WriteLine("  F:{0}", f);

                foreach (var m in t.GetMethods())
                    Console.WriteLine("  M:{0}", m);

                foreach (var p in t.GetProperties())
                    Console.WriteLine("  P:{0}", p);

                foreach (var e in t.GetEvents())
                    Console.WriteLine("  E:{0}", e);
            }
        }

    }

}
