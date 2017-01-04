﻿using System;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class OptionalTests
    {
        class TestClass { public override string ToString() => "test class"; }

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

        [Fact]
        public void TestOptionalCastToValue()
        {
            var test = (Optional<TestClass>)new TestClass();
            Assert.True(test.IsSet);
            Assert.False(test.NotSet);
        }

        [Fact]
        public void TestOptionalCastToNoValue()
        {
            var test = (Optional<TestClass>)null;
            Assert.False(test.IsSet);
            Assert.True(test.NotSet);
        }
    }
}
