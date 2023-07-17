#if !NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
using System;
using System.Security.Cryptography;
/* 
 * DateOnly2.cs
 * 
 *   Created: 2023-07-04-03:18:28
 *   Modified: 2023-07-04-03:18:28
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;

using System.Diagnostics.Contracts;
using System.Text;

/// <summary>
/// Represents a date without a time component.
/// </summary>
public readonly partial struct DateOnly : IComparable, IComparable<DateOnly>, IEquatable<DateOnly>//, ISpanFormattable, IUtf8SpanFormattable
{
    // ...

    // /// <summary>
    // /// Compares the current instance with an object or DateOnly and returns an indication of their relative values.
    // /// </summary>
    // /// <param name="obj">The object or DateOnly to compare with this instance.</param>
    // /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    // public int CompareTo(object obj)
    // {
    //     if (obj is null)
    //     {
    //         return 1;
    //     }

    //     if (obj is DateOnly other)
    //     {
    //         return CompareTo(other);
    //     }

    //     throw new ArgumentException("Object must be of type DateOnly.");
    // }

    // /// <summary>
    // /// Compares the current instance with another DateOnly and returns an indication of their relative values.
    // /// </summary>
    // /// <param name="other">The DateOnly to compare with this instance.</param>
    // /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    // // public int CompareTo(DateOnly other)
    // // {
    // //     return _dayNumber.CompareTo(other._dayNumber);
    // // }
    // /// <summary>
    // /// Indicates whether the current DateOnly is equal to another DateOnly.
    // /// </summary>
    // /// <param name="other">A DateOnly to compare with this instance.</param>
    // /// <returns>True if the current instance is equal to the other parameter; otherwise, false.</returns>
    // public bool Equals(DateOnly other)
    // {
    //     return _dayNumber == other._dayNumber;
    // }

    /// <summary>
    /// Tries to format the DateOnly into a char span using the specified format and format provider.
    /// </summary>
    /// <param name="destination">The destination span where the formatted characters will be written to.</param>
    /// <param name="charsWritten">The number of characters written to the destination span.</param>
    /// <param name="format">The format string used to format the DateOnly (optional).</param>
    /// <param name="formatProvider">The provider used to format the DateOnly (optional).</param>
    /// <returns>True if the formatting is successful; otherwise, false.</returns>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? formatProvider = null)
    {
        if (format.IsEmpty || format.SequenceEqual("d".AsSpan()))
        {
            var result = dt.TryFormat(destination, out charsWritten, formatProvider);
            return result;
        }
        else if (format.SequenceEqual("D".AsSpan()))
        {
            return dt.ToString("D", formatProvider).AsSpan().TryCopyTo(destination, out charsWritten);
        }
        else if (format.SequenceEqual("O".AsSpan()))
        {
            return dt.ToString("yyyy-MM-dd", formatProvider).AsSpan().TryCopyTo(destination, out charsWritten);
        }
        else if (format.SequenceEqual("R".AsSpan()))
        {
            return dt.ToString("ddd, dd MMM yyyy", formatProvider).AsSpan().TryCopyTo(destination, out charsWritten);
        }

        charsWritten = 0;
        return false;
    }

    /// <summary>
    /// Tries to format the DateOnly into a UTF-8 byte span using the specified format and format provider.
    /// </summary>
    /// <param name="destination">The destination span where the formatted bytes will be written to.</param>
    /// <param name="bytesWritten">The number of bytes written to the destination span.</param>
    /// <param name="format">The format string used to format the DateOnly (optional).</param>
    /// <param name="formatProvider">The provider used to format the DateOnly (optional).</param>
    /// <returns>True if the formatting is successful; otherwise, false.</returns>
    public bool TryFormatUtf8(Span<byte> destination, out int bytesWritten, ReadOnlySpan<byte> format = default, IFormatProvider? formatProvider = null)
    {
        if (format.IsEmpty || format.SequenceEqual(Encoding.UTF8.GetBytes("d")))
        {
            var result = dt.TryFormatUtf8(destination, out bytesWritten, formatProvider);
            return result;
        }
        else if (format.SequenceEqual(Encoding.UTF8.GetBytes("D")))
        {
            return Encoding.UTF8.GetBytes(dt.ToString("D", formatProvider)).AsSpan().TryCopyTo(destination, out bytesWritten);
        }
        else if (format.SequenceEqual(Encoding.UTF8.GetBytes("O")))
        {
            return Encoding.UTF8.GetBytes(dt.ToString("yyyy-MM-dd", formatProvider)).AsSpan().TryCopyTo(destination, out bytesWritten);
        }
        else if (format.SequenceEqual(Encoding.UTF8.GetBytes("R")))
        {
            return Encoding.UTF8.GetBytes(dt.ToString("ddd, dd MMM yyyy", formatProvider)).AsSpan().TryCopyTo(destination, out bytesWritten);
        }

        bytesWritten = 0;
        return false;
    }
}

internal static class DateOnlyExtensions
{
    internal static bool TryFormat(this DateTime dt, Span<char> destination, out int charsWritten, IFormatProvider? formatProvider = null)
    {
        var result = dt.TryFormat(destination, out charsWritten, formatProvider);
        return result;
    }

    internal static bool TryFormatUtf8(this DateTime dt, Span<byte> destination, out int bytesWritten, IFormatProvider? formatProvider = null)
    {
        var result = dt.TryFormatUtf8(destination, out bytesWritten, formatProvider);
        return result;
    }
}

public static class SpanHelpers
{
    public static unsafe bool TryCopyTo<T>(this ReadOnlySpan<T> @from, Span<T> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            @from.CopyTo(destination);
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this ReadOnlySpan<char> @from, Span<byte> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (char* pFrom = @from)
            fixed (byte* pDest = destination)
            {
                var pFromByte = (byte*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this ReadOnlySpan<byte> @from, Span<char> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (byte* pFrom = @from)
            fixed (char* pDest = destination)
            {
                var pFromByte = (char*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this ReadOnlySpan<char> @from, Span<char> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (char* pFrom = @from)
            fixed (char* pDest = destination)
            {
                var pFromByte = (char*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this ReadOnlySpan<byte> @from, Span<byte> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (byte* pFrom = @from)
            fixed (byte* pDest = destination)
            {
                var pFromByte = (byte*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this Span<char> @from, Span<byte> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (char* pFrom = @from)
            fixed (byte* pDest = destination)
            {
                var pFromByte = (byte*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this Span<byte> @from, Span<char> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (byte* pFrom = @from)
            fixed (char* pDest = destination)
            {
                var pFromByte = (char*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this Span<char> @from, Span<char> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (char* pFrom = @from)
            fixed (char* pDest = destination)
            {
                var pFromByte = (char*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static unsafe bool TryCopyTo(this Span<byte> @from, Span<byte> destination, out int bytesWritten)
    {
        if (from.Length <= destination.Length)
        {
            bytesWritten = from.Length;
            fixed (byte* pFrom = @from)
            fixed (byte* pDest = destination)
            {
                var pFromByte = (byte*)pFrom;
                for (int i = 0; i < bytesWritten; i++)
                {
                    pDest[i] = pFromByte[i];
                }
            }
            return true;
        }

        bytesWritten = 0;
        return false;
    }

    public static void CopyTo<T>(this ReadOnlySpan<T> @from, Span<T> destination)
    {
        for (var i = 0; i < from.Length; i++)
        {
            destination[i] = from[i];
        }
    }
}
#endif
