using Xunit;

namespace Narochno.Primitives.Tests
{
    public class OptionalEqualityTests
    {
        [Fact]
        public void TestClassNotSetAndSetEquality()
        {
            var one = new Optional<string>();
            var two = "test".Optional();

            Assert.False(one.Equals(two));
        }

        [Fact]
        public void TestClassNotSetEquality()
        {
            var one = new Optional<string>();
            var two = new Optional<string>();

            Assert.True(one.Equals(two));
        }

        [Fact]
        public void TestClassEquality()
        {
            var one = "one".Optional();
            var two = "one".Optional();

            Assert.True(one.Equals(two));
        }

        [Fact]
        public void TestClassNonEquality()
        {
            var one = "one".Optional();
            var two = "two".Optional();

            Assert.False(one.Equals(two));
        }

        [Fact]
        public void TestClassEqualityNonOptional()
        {
            var one = "one".Optional();
            var two = "one";

            Assert.True(one.Equals(two));
            Assert.False(two.Equals(one));
        }
    }
}
