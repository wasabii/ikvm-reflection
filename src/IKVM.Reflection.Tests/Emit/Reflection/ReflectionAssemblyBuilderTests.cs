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
            asm.DefinedTypes.Should().BeEmpty();
            asm.EntryPoint.Should().BeNull();
            asm.GetCustomAttributesData().Should().BeEmpty();
            asm.GetForwardedTypes().Should().BeEmpty();
            asm.GetModules().Should().BeEmpty();
            asm.GetName().Name.Should().Be("Hello");
            asm.GetTypes().Should().BeNull();
        }

    }

}
