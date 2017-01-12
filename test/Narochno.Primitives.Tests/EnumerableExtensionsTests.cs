using Xunit;

namespace Narochno.Primitives.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void TestFirstOrOptional()
        {
            var optional = "test".AsEnumerable().FirstOrOptional();

            Assert.True(optional.HasValue);
            Assert.Equal("test", optional.Value);
        }
        [Fact]
        public void TestFirstOrOptionalNoValue()
        {
            var optional = new string[0].FirstOrOptional();

            Assert.False(optional.HasValue);
        }

        [Fact]
        public void TestSingleOrOptional()
        {
            var optional = "test".AsEnumerable().SingleOrOptional();

            Assert.True(optional.HasValue);
            Assert.Equal("test", optional.Value);
        }

        [Fact]
        public void TestSingleOrOptionalNoValue()
        {
            var optional = new string[0].SingleOrOptional();

            Assert.False(optional.HasValue);
        }
    }
}