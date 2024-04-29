
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Narochno.Primitives;

public static class NotNullExtensions
{
    public static IEnumerable<T> Empty<T>(this IEnumerable<T>? source) => source ?? Enumerable.Empty<T>();
#if NET8_0
    public static async Task<T> NotNull<T>(this Task<T?> task, [CallerArgumentExpression(nameof(task))] string? paramName = null)
        where T : class
    {
        var x = await task;
        ArgumentNullException.ThrowIfNull(x, paramName);
        return x;
    }
    public static async ValueTask<T> NotNull<T>(this ValueTask<T?> task, [CallerArgumentExpression(nameof(task))] string? paramName = null)
        where T : class
    {
        var x = await task;
        ArgumentNullException.ThrowIfNull(x, paramName);
        return x;
    }

    public static async Task<T> NotNull<T>(this Task<T?> task, [CallerArgumentExpression(nameof(task))] string? paramName = null)
        where T : struct
    {
        var x = await task;
        ArgumentNullException.ThrowIfNull(x, paramName);
        return x.Value;
    }
    public static async ValueTask<T> NotNull<T>(this ValueTask<T?> task, [CallerArgumentExpression(nameof(task))] string? paramName = null)
        where T : struct
    {
        var x = await task;
        ArgumentNullException.ThrowIfNull(x, paramName);
        return x.Value;
    }

    public static T NotNull<T>([NotNull] this T? obj, [CallerArgumentExpression(nameof(obj))] string? paramName = null)
        where T : class
    {
        ArgumentNullException.ThrowIfNull(obj, paramName);
        return obj;
    }

    public static T NotNull<T>([NotNull] this T? obj, [CallerArgumentExpression(nameof(obj))] string? paramName = null)
        where T : struct
    {
        ArgumentNullException.ThrowIfNull(obj, paramName);
        return obj.Value;
    }
    #else

    public static async Task<T> NotNull<T>(this Task<T?> task, string? message = null)
        where T : class
    {
        var x = await task;
        if (x is null)
        {
            throw new ArgumentNullException(message ?? "Value is null");
        }
        return x;
    }

    public static async Task<T> NotNull<T>(this Task<T?> task, string? message = null)
        where T : struct
    {
        var x = await task;
        if (x is null)
        {
            throw new ArgumentNullException(message ?? "Value is null");
        }
        return x.Value;
    }

    public static T NotNull<T>(this T? obj,  string? message = null)
        where T : class
    {
        if (obj is null)
        {
            throw new ArgumentNullException(message ?? "Value is null");
        }
        return obj;
    }

    public static T NotNull<T>(this T? obj,  string? message = null)
        where T : struct
    {
        if (obj is null)
        {
            throw new ArgumentNullException(message ?? "Value is null");
        }
        return obj.Value;
    }

#endif
}
