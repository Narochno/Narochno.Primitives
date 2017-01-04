using Xunit;

namespace Narochno.Primitives.Tests
{
    public class OptionalExtensionsTests
    {
        [Fact]
        public void TestClassToOptional()
        {
            var optional = "test".Optional();

            Assert.True(optional.IsSet);
            Assert.Equal("test", optional.Value);
        }

        [Fact]
        public void TestFallback()
        {
            var missing = new Optional<string>();

            var result = missing.Fallback("fallback");
            Assert.True(result.IsSet);
            Assert.Equal("fallback", result.Value);
        }

        [Fact]
        public void TestNoFallback()
        {
            var missing = "test".Optional();

            var result = missing.Fallback("fallback");
            Assert.True(result.IsSet);
            Assert.Equal("test", result.Value);
        }
    }
}
