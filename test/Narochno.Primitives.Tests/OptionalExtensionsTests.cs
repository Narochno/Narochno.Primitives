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
            var existing = "test".Optional();

            var result = existing.Fallback("fallback");
            Assert.True(result.IsSet);
            Assert.Equal("test", result.Value);
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

        [Fact]
        public void TestUnwrapStruct()
        {
            var original = 1;

            var missing = original.Optional();

            Assert.Equal<int>(original, missing.Unwrap());
        }

        [Fact]
        public void TestUnwrapMissingStruct()
        {
            var result = new Optional<Guid>();

            Assert.Equal<Guid>(Guid.Empty, result.Unwrap());
        }

        [Fact]
        public void ToNullableMissingTest()
        {
            var original = new Optional<int>().Nullable();

            Assert.False(original.HasValue);
        }

        [Fact]
        public void ToNillableTest()
        {
            var original = 1.Optional().Nullable();

            Assert.True(original.HasValue);
            Assert.Equal(1, original.Value);
        }
    }
}
