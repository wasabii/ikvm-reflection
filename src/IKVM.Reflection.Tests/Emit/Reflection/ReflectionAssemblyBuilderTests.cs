using System.Reflection;

using FluentAssertions;

using IKVM.Reflection.Emit;
using IKVM.Reflection.Emit.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IKVM.Reflection.Tests.Emit.Reflection
{

    [TestClass]
    public class ReflectionAssemblyBuilderTests
    {

        [TestMethod]
        public void CanDefineAssembly()
        {
            var ctx = new ReflectionEmitContext();
            var asm = ctx.DefineAssembly(new AssemblyName("Hello"), AssemblyBuilderAccess.Run);
            asm.Location.Should().BeNull();
        }

    }

}
