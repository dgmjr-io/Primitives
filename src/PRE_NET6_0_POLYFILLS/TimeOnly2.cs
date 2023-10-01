#if !NET6_0_OR_GREATER
using System;
using System.Security;

namespace System;

public readonly partial struct TimeOnly : IComparable, IComparable<TimeOnly>, IEquatable<TimeOnly> //, ISpanFormattable//, IUtf8SpanFormattable
{
    // ...

    /// <summary>
    /// Compares this <see cref="TimeOnly"/> to another object.
    /// </summary>
    /// <param name="obj">The object to compare to.</param>
    /// <returns>
    /// A 32-bit signed integer that indicates whether this <see cref="TimeOnly"/> is earlier than, the same as, or later than the other object:
    /// Less than zero: This <see cref="TimeOnly"/> is earlier.
    /// Zero: This <see cref="TimeOnly"/> is the same.
    /// Greater than zero: This <see cref="TimeOnly"/> is later.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="obj"/> is not of type <see cref="TimeOnly"/>.</exception>
    public int CompareTo(object obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (obj is TimeOnly other)
        {
            return CompareTo(other);
        }

        throw new ArgumentException("Object must be of type TimeOnly.");
    }

    /// <summary>
    /// Compares this <see cref="TimeOnly"/> to another object.
    /// </summary>
    /// <param name="other">The object to compare to.</param>
    /// <returns>
    /// A 32-bit signed integer that indicates whether this <see cref="TimeOnly"/> is earlier than, the same as, or later than the other object:
    /// Less than zero: This <see cref="TimeOnly"/> is earlier.
    /// Zero: This <see cref="TimeOnly"/> is the same.
    /// Greater than zero: This <see cref="TimeOnly"/> is later.
    /// </returns>
    public int CompareTo(TimeOnly other)
    {
        return Ticks.CompareTo(other.Ticks);
    }

    /// <summary>
    /// Determines whether this instance is equal to another <see cref="TimeOnly"/> object.
    /// </summary>
    /// <param name="other">The <see cref="TimeOnly"/> object to compare with this instance.</param>
    /// <returns>
    /// <c>true</c> if the two objects are equal; otherwise, <c>false</c>.
    /// </returns>
    public bool Equals(TimeOnly other)
    {
        return Ticks == other.Ticks;
    }

    public TimeOnly(long ticks)
        : this(new TimeSpan(ticks)) { }

    public TimeOnly(TimeSpan timespan)
        : this(timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds) { }

    /// <summary>
    /// Tries to format the current <see cref="TimeOnly"/> object into a span of characters.
    /// </summary>
    /// <param name="destination">The span of characters where the formatted output will be written.</param>
    /// <param name="charsWritten">
    /// When this method returns, contains the number of characters written into <paramref name="destination"/>.
    /// </param>
    /// <param name="format">A read-only span representing the format string. (Optional)</param>
    /// <param name="formatProvider">An optional provider for formatting information. (Optional)</param>
    /// <returns>
    /// <c>true</c> if the formatting was successful and <paramref name="destination"/> contains the formatted output;
    /// otherwise, <c>false</c>.
    /// </returns>
    public bool TryFormat(
        Span<char> destination,
        out int charsWritten,
        ReadOnlySpan<char> format = default,
        IFormatProvider? formatProvider = null
    )
    {
        if (destination.Length < 8)
        {
            charsWritten = 0;
            return false;
        }

        var parts = GetParts(Ticks);
        var hour = parts.hour.ToString("D2");
        var minute = parts.minute.ToString("D2");
        var second = parts.second.ToString("D2");

        var length = 0;
        for (var i = 0; i < hour.Length; i++)
        {
            destination[length++] = hour[i];
        }

        destination[length++] = ':';

        for (var i = 0; i < minute.Length; i++)
        {
            destination[length++] = minute[i];
        }

        destination[length++] = ':';

        for (var i = 0; i < second.Length; i++)
        {
            destination[length++] = second[i];
        }

        charsWritten = length;
        return true;
    }

    /// <summary>
    /// Tries to format the current <see cref="TimeOnly"/> object into a span of UTF-8 bytes.
    /// </summary>
    /// <param name="destination">The span of bytes where the formatted output will be written.</param>
    /// <param name="bytesWritten">
    /// When this method returns, contains the number of bytes written into <paramref name="destination"/>.
    /// </param>
    /// <param name="format">A read-only span representing the format string. (Optional)</param>
    /// <param name="formatProvider">An optional provider for formatting information. (Optional)</param>
    /// <returns>
    /// <c>true</c> if the formatting was successful and <paramref name="destination"/> contains the formatted output;
    /// otherwise, <c>false</c>.
    /// </returns>
    public bool TryFormatUtf8(
        Span<byte> destination,
        out int bytesWritten,
        ReadOnlySpan<byte> format = default,
        IFormatProvider? formatProvider = null
    )
    {
        if (destination.Length < 8)
        {
            bytesWritten = 0;
            return false;
        }

        var parts = GetParts(Ticks);
        var hour = parts.hour.ToString("D2");
        var minute = parts.minute.ToString("D2");
        var second = parts.second.ToString("D2");

        var length = 0;
        for (var i = 0; i < hour.Length; i++)
        {
            destination[length++] = (byte)hour[i];
        }

        destination[length++] = (byte)':';

        for (var i = 0; i < minute.Length; i++)
        {
            destination[length++] = (byte)minute[i];
        }

        destination[length++] = (byte)':';

        for (var i = 0; i < second.Length; i++)
        {
            destination[length++] = (byte)second[i];
        }

        bytesWritten = length;
        return true;
    }

    public string ToLongTimeString() => Format("HH:MM:ss.ffff");

    public static implicit operator TimeOnly(TimeSpan time) =>
        new TimeOnly(time.Hours, time.Minutes, time.Seconds, time.Milliseconds);

    public static TimeOnly Parse(string s, string format = "HH:MM:ss.ffff") =>
        DateTime.ParseExact(s, format, null, Globalization.DateTimeStyles.None).TimeOfDay;

    public static TimeOnly Parse(string s, IFormatProvider provider) =>
        DateTime.Parse(s, provider).TimeOfDay;
}
#endif
