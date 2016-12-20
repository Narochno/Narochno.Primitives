using System;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class OptionalTests
    {
        class TestClass { public override string ToString() => "test class"; }
        struct TestStruct { public override string ToString() => "test struct"; }

        [Fact]
        public void TestOptionalClassIsSet()
        {
            var test = new TestClass().Optional();
            Assert.True(test.IsSet);
            Assert.False(test.NotSet);
        }

        [Fact]
        public void TestOptionalClassSetToString()
        {
            var test = new TestClass().Optional();
            Assert.Equal("test class", test.ToString());
        }

        [Fact]
        public void TestOptionalStructIsSet()
        {
            var test = new TestStruct().Optional();
            Assert.True(test.IsSet);
            Assert.False(test.NotSet);
        }

        [Fact]
        public void TestOptionalStructNotSet()
        {
            var test = new Optional<TestStruct>();
            Assert.False(test.IsSet);
            Assert.True(test.NotSet);
        }

        [Fact]
        public void TestOptionalNotSetToString()
        {
            var test = new Optional<TestClass>();
            Assert.Equal("Not Set", test.ToString());
        }

        [Fact]
        public void TestOptionalNotSet()
        {
            var test = new Optional<TestClass>();
            Assert.False(test.IsSet);
            Assert.True(test.NotSet);
        }

        [Fact]
        public void TestOptionalNotSetValueException()
        {
            var test = new Optional<TestClass>();
            Assert.Throws<InvalidOperationException>(() => test.Value);
        }

        [Fact]
        public void TestOptionalToTypeConversion()
        {
            var test = new TestClass();
            // A method that accepts a certain type, not an optional
            new Action<TestClass>(x =>
            {
                Assert.Same(test, x);
            })(new Optional<TestClass>(test));
        }

        [Fact]
        public void TestTypeToOptionalConversion()
        {
            var test = new TestClass();
            // A method that accepts an optional
            new Action<Optional<TestClass>>(x =>
            {
                Assert.True(x.IsSet);
                Assert.False(x.NotSet);
                Assert.Same(test, x.Value);
            })(test);
        }
    }
}
