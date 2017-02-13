using System.Linq;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void TestAsEnumerable()
        {
            string x = null;
            Assert.Equal(0, x.AsEnumerable().Count());

            int y = 0;
            Assert.Equal(1, y.AsEnumerable().Count());

            y = 1;
            Assert.Equal(1, y.AsEnumerable().Count());

            int? z = null;
            Assert.Equal(0, z.AsEnumerable().Count());
        }

        [Fact]
        public void TestFirstOrOptional()
        {
            var optional = "test".AsEnumerable().FirstOrOptional();

            Assert.True(optional.HasValue);
            Assert.Equal("test", optional.Value);
        }

        [Fact]
        public void TestFirstOrOptionalNoValue()
        {
            var optional = new string[0].FirstOrOptional();

            Assert.False(optional.HasValue);
        }

        [Fact]
        public void TestSingleOrOptional()
        {
            var optional = "test".AsEnumerable().SingleOrOptional();

            Assert.True(optional.HasValue);
            Assert.Equal("test", optional.Value);
        }

        [Fact]
        public void TestSingleOrOptionalNoValue()
        {
            var optional = new string[0].SingleOrOptional();

            Assert.False(optional.HasValue);
        }


        [Fact]
        public void TestBatch()
        {
            var items = new string[] {"a", "b", "c"};

            var batches = items.Batch(2).ToList();

            Assert.Equal(2, batches.Count);
            var b = batches[0].ToList();
            Assert.Equal(2, b.Count);
            Assert.Equal("a", b[0]);
            Assert.Equal("b", b[1]);
            b = batches[1].ToList();
            Assert.Equal(1, b.Count);
            Assert.Equal("c", b[0]);
        }
    }
}