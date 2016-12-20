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
        public void TestStructNotSetAndSetEquality()
        {
            var one = new Optional<int>();
            var two = 1.Optional();

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
        public void TestStructNotSetEquality()
        {
            var one = new Optional<int>();
            var two = new Optional<int>();

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
        public void TestStructEquality()
        {
            var one = 1.Optional();
            var two = 1.Optional();

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
        public void TestStructNonEquality()
        {
            var one = 1.Optional();
            var two = 2.Optional();

            Assert.False(one.Equals(two));
        }

        [Fact]
        public void TestClassEqualityNonOptional()
        {
            var one = "one".Optional();
            var two = "one";

            Assert.True(one.Equals(two));
            Assert.True(two.Equals(one));
        }

        [Fact]
        public void TestStructEqualityNonOptional()
        {
            var one = 1.Optional();
            var two = 1;

            Assert.True(one.Equals(two));
            Assert.True(two.Equals(one));
        }
    }
}
