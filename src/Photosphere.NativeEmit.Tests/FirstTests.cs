using Xunit;

namespace Photosphere.NativeEmit.Tests
{
    public class FirstTests
    {
        [Fact]
        internal void Test()
        {
            Assert.Equal(42, Program.Get42());
        }
    }
}