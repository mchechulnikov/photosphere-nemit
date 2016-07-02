using Photosphere.NativeEmit.x86;
using Photosphere.NativeEmit.x86.Enums;
using Xunit;

namespace Photosphere.NativeEmit.Tests
{
    public class NativeMethodGeneratorTests
    {
        private const int Number = 42;

        [Fact]
        internal void Generate_RetInt32_ExpectedValue()
        {
            var methodBuilder = new NativeMethodBuilder().Mov(Register.Eax, Number).Ret();
            var method = NativeMethodGenerator.Generate(methodBuilder);

            var result = method();

            Assert.Equal(Number, result);
        }
    }
}