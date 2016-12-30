using System;
using System.Runtime.Serialization;
using Xunit;

namespace Narochno.Primitives.Parsing.Tests
{
    public class EnumParserTests
    {
        public enum TestEnum
        {
            [EnumMember(Value = "test_one")]
            One,
            [EnumMember(Value = "test_two")]
            Two,
            [EnumMember(Value = "test_three")]
            Three
        }

        [Fact]
        public void TestParseAttribute()
        {
            Assert.Equal(TestEnum.One, "test_one".Parse<TestEnum>());
            Assert.Equal(TestEnum.Two, "test_two".Parse<TestEnum>());
            Assert.Equal(TestEnum.Three, "test_three".Parse<TestEnum>());
        }

        [Fact]
        public void TestParseNoAttribute()
        {
            Assert.Equal(TestEnum.One, "One".Parse<TestEnum>());
            Assert.Equal(TestEnum.Two, "Two".Parse<TestEnum>());
            Assert.Equal(TestEnum.Three, "Three".Parse<TestEnum>());
        }

        [Fact]
        public void TestParseAttributeToOptional()
        {
            Assert.Equal(TestEnum.One, "test_one".ParseOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Two, "test_two".ParseOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Three, "test_three".ParseOptional<TestEnum>().Value);
        }

        [Fact]
        public void TestParseNoAttributeToOptional()
        {
            Assert.Equal(TestEnum.One, "One".ParseOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Two, "Two".ParseOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Three, "Three".ParseOptional<TestEnum>().Value);
        }

        [Fact]
        public void TestParseInvalid()
        {
            Assert.Throws<ArgumentException>(() => "lol".Parse<TestEnum>());
            Assert.Throws<ArgumentException>(() => string.Empty.Parse<TestEnum>());
            Assert.Throws<ArgumentNullException>(() => ((string)null).Parse<TestEnum>());
        }

        [Fact]
        public void TestParseInvalidToOptional()
        {
            Assert.False("lol".ParseOptional<TestEnum>().IsSet);
            Assert.False(string.Empty.ParseOptional<TestEnum>().IsSet);
            Assert.False(((string)null).ParseOptional<TestEnum>().IsSet);
        }
    }
}
