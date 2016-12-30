using Narochno.Primitives.Parsing;
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
        /// One hundred million
        /// </summary>
        private const int Iterations = 100000000;

        [Fact]
        public void BenchGenericParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.True("true".To<bool>());
            }
        }

        [Fact]
        public void BenchTypedParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.True(bool.Parse("true"));
            }
        }

        [Fact]
        public void BenchGenericTryParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                Assert.True("true".ToOptional<bool>().Value);
            }
        }

        [Fact]
        public void BenchTypedTryParse()
        {
            for (var i = 0; i < Iterations; i++)
            {
                bool result = false;
                bool.TryParse("true", out result);
                Assert.True(result);
            }
        }
    }
}
