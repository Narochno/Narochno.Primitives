using System;
using Narochno.Primitives.Parsing;
using Newtonsoft.Json;
using Xunit;

namespace Narochno.Primitives.Json.Tests;

public class EnumStringConverterTests
{
    enum TestEnum
    {
        Undefined,

        [EnumString("First")]
        One,

        [EnumString("Second")]
        Two,
        Three
    }

    class TestObject
    {
        public TestEnum Test { get; set; }
    }

    private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
    {
        Converters = new[] { new EnumStringConverter() }
    };

    [Fact]
    public void ExpectSerialiseEnumNoValue()
    {
        var result = JsonConvert.SerializeObject(
            new TestObject { Test = TestEnum.Three },
            serializerSettings
        );

        Assert.Equal("{\"Test\":\"Three\"}", result);
    }

    [Fact]
    public void ExpectSerialiseEnum()
    {
        var result = JsonConvert.SerializeObject(
            new TestObject { Test = TestEnum.Two },
            serializerSettings
        );

        Assert.Equal("{\"Test\":\"Second\"}", result);
    }

    [Fact]
    public void ExpectDeserialiseEnum()
    {
        var result = JsonConvert.DeserializeObject<TestObject>(
            "{\"Test\":\"Second\"}",
            serializerSettings
        );

        Assert.Equal(TestEnum.Two, result?.Test);
    }

    [Fact]
    public void ExpectDeserialiseUnknownEnumString()
    {
        var result = JsonConvert.DeserializeObject<TestObject>(
            "{\"Test\":\"Three\"}",
            serializerSettings
        );

        Assert.Equal(TestEnum.Three, result?.Test);
    }

    [Fact]
    public void ExpectNotDeserialiseUnknownEnum() =>
        Assert.Throws<ArgumentException>(
            () => JsonConvert.DeserializeObject<TestObject>("{\"Test\":\"ok\"}", serializerSettings)
        );

    [Fact]
    public void ExpectNotDeserialiseNullEnum() =>
        Assert.Throws<ArgumentNullException>(
            () => JsonConvert.DeserializeObject<TestObject>("{\"Test\": null}", serializerSettings)
        );

    class TestObjectNullable
    {
        public TestEnum? Test { get; set; }
    }

    [Fact]
    public void ExpectDeserialiseNullableEnum()
    {
        var result = JsonConvert.DeserializeObject<TestObjectNullable>(
            "{\"Test\":\"Second\"}",
            serializerSettings
        );

        Assert.Equal(TestEnum.Two, result?.Test);
    }

    [Fact]
    public void ExpectNotDeserialiseNullableEnum()
    {
        var result = JsonConvert.DeserializeObject<TestObjectNullable>(
            "{\"Test\": null}",
            serializerSettings
        );
    }
}
