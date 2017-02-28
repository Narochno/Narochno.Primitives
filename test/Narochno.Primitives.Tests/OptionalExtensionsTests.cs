using System;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class OptionalExtensionsTests
    {
        [Fact]
        public void TestClassToOptional()
        {
            var optional = "test".Optional();

            Assert.True(optional.HasValue);
            Assert.Equal("test", optional.Value);
        }

        [Fact]
        public void TestFallbackOptional()
        {
            var missing = new Optional<string>();

            var result = missing.Fallback("fallback".Optional());
            Assert.True(result.HasValue);
            Assert.Equal("fallback", result.Value);
        }

        [Fact]
        public void TestFallback()
        {
            var missing = new Optional<string>();

            var result = missing.Fallback("fallback");
            Assert.NotNull(result);
            Assert.Equal("fallback", result);
        }

        [Fact]
        public void TestNoFallbackOptional()
        {
            var existing = "test".Optional();

            var result = existing.Fallback("fallback".Optional());
            Assert.True(result.HasValue);
            Assert.Equal("test", result.Value);
        }

        [Fact]
        public void TestNoFallback()
        {
            var existing = "test".Optional();

            var result = existing.Fallback("fallback");
            Assert.NotNull(result);
            Assert.Equal("test", result);
        }

        [Fact]
        public void TestUnwrapClass()
        {
            var original = "test";

            var result = original.Optional();

            Assert.Same(original, result.Unwrap());
        }

        [Fact]
        public void TestUnwrapMissingClass()
        {
            var result = new Optional<string>();

            Assert.Null(result.Unwrap());
        }
    }
}
