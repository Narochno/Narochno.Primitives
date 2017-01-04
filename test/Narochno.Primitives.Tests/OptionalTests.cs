using System;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class OptionalTests
    {
        class TestClass { public override string ToString() => "test class"; }

        [Fact]
        public void TestOptionalClassHasValue()
        {
            var test = new TestClass().Optional();
            Assert.True(test.HasValue);
            Assert.False(test.HasNoValue);
        }

        [Fact]
        public void TestOptionalClassSetToString()
        {
            var test = new TestClass().Optional();
            Assert.Equal("test class", test.ToString());
        }

        [Fact]
        public void TestOptionalHasNoValueToString()
        {
            var test = new Optional<TestClass>();
            Assert.Equal("Not Set", test.ToString());
        }

        [Fact]
        public void TestOptionalHasNoValue()
        {
            var test = new Optional<TestClass>();
            Assert.False(test.HasValue);
            Assert.True(test.HasNoValue);
        }

        [Fact]
        public void TestOptionalHasNoValueValueException()
        {
            var test = new Optional<TestClass>();
            Assert.Throws<InvalidOperationException>(() => test.Value);
        }

        [Fact]
        public void TestTypeToOptionalConversion()
        {
            var test = new TestClass();
            // A method that accepts an optional
            new Action<Optional<TestClass>>(x =>
            {
                Assert.True(x.HasValue);
                Assert.False(x.HasNoValue);
                Assert.Same(test, x.Value);
            })(test);
        }

        [Fact]
        public void TestOptionalCastToValue()
        {
            var test = (Optional<TestClass>)new TestClass();
            Assert.True(test.HasValue);
            Assert.False(test.HasNoValue);
        }

        [Fact]
        public void TestOptionalCastToNoValue()
        {
            var test = (Optional<TestClass>)null;
            Assert.False(test.HasValue);
            Assert.True(test.HasNoValue);
        }
    }
}
