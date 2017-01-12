using System.Collections.Generic;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void TestGetOptionalExists()
        {
            var dict = new Dictionary<string, string>
            {
                { "test", "testing" }
            };

            Assert.Equal("testing", dict.GetOptional("test").Value);
        }

        [Fact]
        public void TestGetOptionalNotExists()
        {
            var dict = new Dictionary<string, string>();

            Assert.False(dict.GetOptional("test").HasValue);
        }

        [Fact]
        public void TestGetNullableExists()
        {
            var dict = new Dictionary<string, int>
            {
                { "test", 1 }
            };

            Assert.Equal(1, dict.GetNullable("test").Value);
        }

        [Fact]
        public void TestGetNullableNotExists()
        {
            var dict = new Dictionary<string, int>();

            Assert.False(dict.GetNullable("test").HasValue);
        }
    }
}
