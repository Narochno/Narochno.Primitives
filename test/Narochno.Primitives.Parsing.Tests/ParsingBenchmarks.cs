using Narochno.Primitives.Parsing;
using System;
using Xunit;

namespace Narochno.Primitives.Tests
{
    /// <summary>
    /// Test class to compare the timings of each
    /// parse method using a large number of iterations.
    /// 
    /// A good way to use this class is to test before changes
    /// and afterwards, to see if/how the time to parse has changed.
    /// </summary>
    public class ParsingBenchmarks
    {
        /// <summary>
        /// 10 million
        /// </summary>
        private const int Iterations = 10000000;

        [Fact]
        public void GenericBoolParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.True("true".To<bool>());
            }
        }

        [Fact]
        public void TypedBoolParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.True(bool.Parse("true"));
            }
        }

        [Fact]
        public void GenericBoolTryParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.True("true".ToOptional<bool>().Value);
            }
        }

        [Fact]
        public void TypedBoolTryParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                bool result = false;
                bool.TryParse("true", out result);
                Assert.True(result);
            }
        }

        [Fact]
        public void GenericEnumParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.Equal(DateTimeKind.Utc, "Utc".To<DateTimeKind>());
            }
        }

        [Fact]
        public void TypedEnumParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.Equal(DateTimeKind.Utc, (DateTimeKind)Enum.Parse(typeof(DateTimeKind), "Utc"));
            }
        }

        [Fact]
        public void GenericEnumTryParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.Equal(DateTimeKind.Utc, "Utc".ToOptional<DateTimeKind>().Value);
            }
        }

        [Fact]
        public void TypedEnumTryParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                DateTimeKind result;
                Enum.TryParse("Utc", out result);
                Assert.Equal(DateTimeKind.Utc, result);
            }
        }
    }
}
