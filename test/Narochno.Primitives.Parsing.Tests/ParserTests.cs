using System.Runtime.Serialization;
using Xunit;

namespace Narochno.Primitives.Parsing.Tests
{
    public class ParserTests
    {
        public enum Test
        {
            [EnumMember(Value = "test_one")]
            One,
            [EnumMember(Value = "test_two")]
            Two,
            [EnumMember(Value = "test_three")]
            Three
        }

        [Fact]
        public void TestEnum()
        {
            var test = "test_one".To<Test>();

            var test1 = StringExtensions.ToOptional<Test>("sss");

            var test2 = "test_one2".To<Test>();
        }

        [Fact]
        public void TestEnum2()
        {
            var test = "test_one".ToOptional<Test>();
            var test2 = "test_one2".ToOptional<Test>();
        }
    }
}
