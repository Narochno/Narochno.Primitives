﻿using System;
using Xunit;

namespace Narochno.Primitives.Parsing.Tests;

public class EnumParserTests
{
    public enum TestEnum
    {
        [EnumString("test_one")]
        One,

        [EnumString("test_two")]
        Two,

        [EnumString("test_three")]
        Three
    }

    [Fact]
    public void TestParseAttribute()
    {
        Assert.Equal(TestEnum.One, "test_one".Parse<TestEnum>());
        Assert.Equal(TestEnum.Two, "test_two".Parse<TestEnum>());
        Assert.Equal(TestEnum.Three, "test_three".Parse<TestEnum>());
    }

    [Fact]
    public void TestParseNoAttribute()
    {
        Assert.Equal(TestEnum.One, "One".Parse<TestEnum>());
        Assert.Equal(TestEnum.Two, "Two".Parse<TestEnum>());
        Assert.Equal(TestEnum.Three, "Three".Parse<TestEnum>());
    }

    [Fact]
    public void TestParseAttributeToOptional()
    {
        Assert.Equal(TestEnum.One, "test_one".TryParse<TestEnum>().NotNull());
        Assert.Equal(TestEnum.Two, "test_two".TryParse<TestEnum>().NotNull());
        Assert.Equal(TestEnum.Three, "test_three".TryParse<TestEnum>().NotNull());
    }

    [Fact]
    public void TestParseNoAttributeToOptional()
    {
        Assert.Equal(TestEnum.One, "One".TryParse<TestEnum>().NotNull());
        Assert.Equal(TestEnum.Two, "Two".TryParse<TestEnum>().NotNull());
        Assert.Equal(TestEnum.Three, "Three".TryParse<TestEnum>().NotNull());
    }

    [Fact]
    public void TestParseInvalid()
    {
        Assert.Throws<ArgumentException>(() => "lol".Parse<TestEnum>());
        Assert.Throws<ArgumentException>(() => string.Empty.Parse<TestEnum>());
        Assert.Throws<ArgumentNullException>(() => ((string)null!).Parse<TestEnum>());
    }

    [Fact]
    public void TestParseInvalidToOptional()
    {
        Assert.False("lol".TryParse<TestEnum>().HasValue);
        Assert.False(string.Empty.TryParse<TestEnum>().HasValue);
        Assert.False(((string)null!).TryParse<TestEnum>().HasValue);
    }
}
