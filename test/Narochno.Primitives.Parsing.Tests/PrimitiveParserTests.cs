using System;
using Xunit;

namespace Narochno.Primitives.Parsing.Tests
{
    public class PrimitiveParserTests
    {
        [Theory]
        [InlineData(typeof(double), "-1.7976931348623157E+308", double.MinValue)]
        [InlineData(typeof(double), "1.7976931348623157E+308", double.MaxValue)]
        [InlineData(typeof(float), "-3.40282347E+38", float.MinValue)]
        [InlineData(typeof(float), "3.40282347E+38", float.MaxValue)]
        [InlineData(typeof(long), "-9223372036854775808", long.MinValue)]
        [InlineData(typeof(long), "9223372036854775807", long.MaxValue)]
        [InlineData(typeof(int), "2147483647", int.MaxValue)]
        [InlineData(typeof(int), "-2147483648", int.MinValue)]
        [InlineData(typeof(bool), "true", true)]
        [InlineData(typeof(bool), "false", false)]
        public void ToType(Type type, string input, object expected)
        {
            Assert.Equal(expected, input.To(type));
            Assert.Equal(expected, input.ToOptional(type).Value);
        }

        [Fact]
        public void GuidToType()
        {
            Assert.Equal(new Guid("433158F7-7B46-4E6D-8980-B5492D46F0DE"), "433158F7-7B46-4E6D-8980-B5492D46F0DE".To<Guid>());
            Assert.Equal(new Guid("433158F7-7B46-4E6D-8980-B5492D46F0DE"), "433158F7-7B46-4E6D-8980-B5492D46F0DE".ToOptional<Guid>().Value);
        }
    }
}
