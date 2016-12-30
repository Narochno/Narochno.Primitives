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
            Assert.Equal(TestEnum.One, "test_one".To<TestEnum>());
            Assert.Equal(TestEnum.Two, "test_two".To<TestEnum>());
            Assert.Equal(TestEnum.Three, "test_three".To<TestEnum>());
        }

        [Fact]
        public void TestParseNoAttribute()
        {
            Assert.Equal(TestEnum.One, "One".To<TestEnum>());
            Assert.Equal(TestEnum.Two, "Two".To<TestEnum>());
            Assert.Equal(TestEnum.Three, "Three".To<TestEnum>());
        }

        [Fact]
        public void TestParseAttributeToOptional()
        {
            Assert.Equal(TestEnum.One, "test_one".ToOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Two, "test_two".ToOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Three, "test_three".ToOptional<TestEnum>().Value);
        }

        [Fact]
        public void TestParseNoAttributeToOptional()
        {
            Assert.Equal(TestEnum.One, "One".ToOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Two, "Two".ToOptional<TestEnum>().Value);
            Assert.Equal(TestEnum.Three, "Three".ToOptional<TestEnum>().Value);
        }

        [Fact]
        public void TestParseInvalid()
        {
            Assert.Throws<ArgumentException>(() => "lol".To<TestEnum>());
            Assert.Throws<ArgumentException>(() => string.Empty.To<TestEnum>());
            Assert.Throws<ArgumentNullException>(() => ((string)null).To<TestEnum>());
        }

        [Fact]
        public void TestParseInvalidToOptional()
        {
            Assert.False("lol".ToOptional<TestEnum>().IsSet);
            Assert.False(string.Empty.ToOptional<TestEnum>().IsSet);
            Assert.False(((string)null).ToOptional<TestEnum>().IsSet);
        }
    }
}
