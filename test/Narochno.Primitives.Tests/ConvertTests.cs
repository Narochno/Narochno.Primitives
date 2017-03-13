using Xunit;

namespace Narochno.Primitives.Parsing.Tests
{
    public class ConvertTests
    {
        [Fact]
        public void Parse()
        {
            Assert.Equal(ushort.MaxValue, Convert<ushort>.Parse("hello"));
            Assert.Equal(float.MinValue, Convert<float>.Parse("-3.40282347E+38"));
            Assert.Equal(long.MaxValue, Convert<long>.Parse("9223372036854775807"));
        }
    }
}