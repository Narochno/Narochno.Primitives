using System.Linq;
using Xunit;

namespace Narochno.Primitives.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void TestAsEnumerable()
        {
            string? x = null;
            Assert.Empty( x.AsEnumerable());

            int y = 0;
            Assert.Single(y.AsEnumerable());

            y = 1;
            Assert.Single(y.AsEnumerable());

            int? z = null;
            Assert.Empty(z.AsEnumerable());
        }



        [Fact]
        public void TestBatch()
        {
            var items = new[] {"a", "b", "c"};

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
