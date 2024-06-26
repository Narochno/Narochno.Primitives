﻿using System;
using Narochno.Primitives.Parsing;
using Xunit;

namespace Narochno.Primitives.Tests;

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

    [Fact(Skip = "Skipping Benchmarks")]
    public void GenericBoolParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            Assert.True("true".Parse<bool>());
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
    public void TypedBoolParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            Assert.True(bool.Parse("true"));
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
    public void GenericBoolTryParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            Assert.True("true".TryParse<bool>().NotNull());
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
    public void TypedBoolTryParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            bool result = false;
            bool.TryParse("true", out result);
            Assert.True(result);
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
    public void GenericEnumParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            Assert.Equal(DateTimeKind.Utc, "Utc".Parse<DateTimeKind>());
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
    public void TypedEnumParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            Assert.Equal(DateTimeKind.Utc, (DateTimeKind)Enum.Parse(typeof(DateTimeKind), "Utc"));
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
    public void GenericEnumTryParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            Assert.Equal(DateTimeKind.Utc, "Utc".TryParse<DateTimeKind>().NotNull());
        }
    }

    [Fact(Skip = "Skipping Benchmarks")]
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
