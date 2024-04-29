using System;
using Xunit;

namespace Narochno.Primitives.Parsing.Tests
{
    public class PrimitiveParserTests
    {
        public struct MyStruct { }

        [Theory]
        [InlineData(typeof(bool), "true", true)]
        [InlineData(typeof(bool), "false", false)]
        [InlineData(typeof(char), "\0", char.MinValue)]
        [InlineData(typeof(char), "\uffff", char.MaxValue)]
        [InlineData(typeof(double), "-1.7976931348623157E+308", double.MinValue)]
        [InlineData(typeof(double), "1.7976931348623157E+308", double.MaxValue)]
        [InlineData(typeof(float), "-3.40282347E+38", float.MinValue)]
        [InlineData(typeof(float), "3.40282347E+38", float.MaxValue)]
        [InlineData(typeof(int), "2147483647", int.MaxValue)]
        [InlineData(typeof(int), "-2147483648", int.MinValue)]
        [InlineData(typeof(long), "-9223372036854775808", long.MinValue)]
        [InlineData(typeof(long), "9223372036854775807", long.MaxValue)]
        [InlineData(typeof(sbyte), "-128", sbyte.MinValue)]
        [InlineData(typeof(sbyte), "127", sbyte.MaxValue)]
        [InlineData(typeof(short), "-32768", short.MinValue)]
        [InlineData(typeof(short), "32767", short.MaxValue)]
        [InlineData(typeof(uint), "0", uint.MinValue)]
        [InlineData(typeof(uint), "4294967295", uint.MaxValue)]
        [InlineData(typeof(ulong), "0", ulong.MinValue)]
        [InlineData(typeof(ulong), "18446744073709551615", ulong.MaxValue)]
        [InlineData(typeof(ushort), "0", ushort.MinValue)]
        [InlineData(typeof(ushort), "65535", ushort.MaxValue)]
        public void Parse(Type type, string input, object expected)
        {
            Assert.Equal(expected, input.Parse(type));
            Assert.Equal(expected, input.TryParse(type));
        }

        [Fact]
        public void GuidToType()
        {
            Assert.Equal(
                new Guid("433158F7-7B46-4E6D-8980-B5492D46F0DE"),
                "433158F7-7B46-4E6D-8980-B5492D46F0DE".Parse<Guid>()
            );
            Assert.Equal(
                new Guid("433158F7-7B46-4E6D-8980-B5492D46F0DE"),
                "433158F7-7B46-4E6D-8980-B5492D46F0DE".TryParse<Guid>().NotNull()
            );
        }

        [Fact]
        public void UnknownType()
        {
            Assert.Throws<ArgumentException>(() => "test".Parse<MyStruct>());
            Assert.Throws<ArgumentException>(() => "test".TryParse<MyStruct>());
        }
    }
}
