using System.Collections.Generic;
using Xunit;

namespace Narochno.Primitives.Tests;

public class DictionaryExtensionsTests
{
    [Fact]
    public void TestGetNullableExists()
    {
        var dict = new Dictionary<string, int> { { "test", 1 } };

        Assert.Equal(1, dict.GetValue("test").NotNull());
    }

    [Fact]
    public void TestGetNullableNotExists()
    {
        var dict = new Dictionary<string, int>();

        Assert.False(dict.GetValue("test").HasValue);
    }
}
