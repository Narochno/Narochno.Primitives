using Newtonsoft.Json;
using Xunit;

namespace Narochno.Primitives.Json.Tests
{
    public class OptionalJsonConverterTests
    {
        class TestClass
        {
            public Optional<string> String { get; set; }
            public int? Integer { get; set; }
        }

        class TestClassComplex
        {
            public Optional<TestClass> Test { get; set; }
        }

        [Fact]
        public void TestSerialisingWithValue()
        {
            var test = new TestClass { String = "test", Integer = 42 };

            var serialised = JsonConvert.SerializeObject(test, new OptionalJsonConverter());

            Assert.Equal("{\"String\":\"test\",\"Integer\":42}", serialised);
        }

        [Fact]
        public void TestSerialisingWithoutValue()
        {
            var test = new TestClass();

            var serialised = JsonConvert.SerializeObject(test, new OptionalJsonConverter());

            Assert.Equal("{\"String\":null,\"Integer\":null}", serialised);
        }

        [Fact]
        public void TestDeserialising()
        {
            var deserialised = JsonConvert.DeserializeObject<TestClass>("{\"String\":\"test\",\"Integer\":42}", new OptionalJsonConverter());

            Assert.Equal("test", deserialised.String);
            Assert.Equal(42, deserialised.Integer);
        }

        [Fact(Skip = "Skipping, this needs work")]
        public void TestComplexDeserialising()
        {
            var deserialised = JsonConvert.DeserializeObject<TestClassComplex>("{\"Test\":{\"String\":\"test\",\"Integer\":42}}", new OptionalJsonConverter());

            Assert.Equal("test", deserialised.Test.Value.String);
            Assert.Equal(42, deserialised.Test.Value.Integer);
        }
    }
}
