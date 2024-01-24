using System;
/*
 * ObjectId.cs
 *
 *   Created: 2022-12-03-12:15:18
 *   Modified: 2022-12-03-12:15:18
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
namespace System;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography;

using Vogen;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif

[ValueObject(typeof(string), conversions: Conversions.SystemTextJson | Conversions.TypeConverter)]
// [RegexDto(ObjectId.RegexString)]
public readonly partial record struct ObjectId
    : IRegexValueObject<ObjectId>,
        IComparable<ObjectId>,
        IComparable,
        IEquatable<ObjectId>,
        IObjectId
{
    private static System.Security.Cryptography.RandomNumberGenerator Random =
        System.Security.Cryptography.RandomNumberGenerator.Create();

    public const string DescriptionString =
        "A ObjectId is a 24-digit (96-bit) hexadecimal string that uniquely identifies an object in a database";

    // #if NET6_0_OR_GREATER
    public static string Description => DescriptionString;

    // #endif
    public const string EmptyValue = "000000000000000000000000";
    public const int Length = 24;
    public const string RegexString = "^[0-9a-z]{24}$";

#if NET7_0_OR_GREATER
    [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    public static partial Regex Regex();
#else
    private static readonly Regex _regex = new Regex(
        RegexString,
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public static Regex Regex() => _regex;
#endif

    public const string UrnPrefix = "https://docs.mongodb.com/manual/reference/method/ObjectId";
    public const string UrnPattern = UrnPrefix + "/{0}";

    public readonly Uri Uri => IsEmpty ? null : new(Format(UrnPattern, ToString()));

    private static string NextId() => $"{CurrentTimestamp:x8}{ThisMachineId:x10}{NextCounter():x6}";

    public static ObjectId NewId()
    {
        var nextId = NextId();
        return From(nextId) with { OriginalString = nextId };
    }

    public static ObjectId Empty => From(EmptyValue) with { OriginalString = EmptyValue };

    public static ExternalDocsTuple ExternalDocs => ("ObjectId", new(UrnPrefix));

    public override readonly string ToString() => IsEmpty ? string.Empty : Value;

    public readonly bool IsNull => Value == EmptyValue;
    public readonly bool IsEmpty => Value == EmptyValue;
    public string OriginalString { get; init; }

    // #if NET6_0_OR_GREATER
    // static string IRegexValueObject<ObjectId>.RegexString => RegexString;

    // #endif

    public const string ExampleValueString = "abcdef0123456789abcdef01";
    public static ObjectId ExampleValue =>
        From(ExampleValueString) with
        {
            OriginalString = ExampleValueString
        };

#if !NET6_0_OR_GREATER
    // readonly Regex IRegexValueObject<ObjectId>.Regex() => Regex();

    // readonly string IRegexValueObject<ObjectId>.RegexString => RegexString;

    // readonly string IRegexValueObject<ObjectId>.Description => Description;

    // readonly ObjectId IRegexValueObject<ObjectId>.ExampleValue => ExampleValue;
#endif

    public static implicit operator ObjectId(byte[] value) => From(value);

    public static implicit operator byte[](ObjectId value) => value.GetBytes();

    public static implicit operator ObjectId(ReadOnlySpan<byte> value) => From(value);

    public static implicit operator ReadOnlySpan<byte>(ObjectId value) => value.GetBytes();

    public static ObjectId From(ReadOnlySpan<byte> bytes) => From(bytes.ToArray());

    public static ObjectId From(byte[] bytes)
    {
        if (bytes is null)
        {
            throw new ArgumentNullException(nameof(bytes));
        }

        if (bytes.Length != 12)
        {
            throw new ArgumentException(
                $"An ObjectId must be 12 bytes, but {bytes.Length} bytes were provided.",
                nameof(bytes)
            );
        }

        var hex = new StringBuilder(bytes.Length * 2);
        foreach (var b in bytes)
        {
            hex.AppendFormat("{0:x2}", b);
        }

        return From(hex.ToString());
    }

    public static ObjectId Parse(string s) =>
        TryParse(s, out var result)
            ? result with
            {
                OriginalString = s
            }
            : throw new FormatException($"The string '{s}' is not a valid {nameof(ObjectId)}");

    public static bool TryParse(string s, out ObjectId result)
    {
        if (s is null || s.Length != Length || !Regex().IsMatch(s))
        {
            result = Empty;
            return false;
        }

        result = ObjectId.From(s) with { OriginalString = s };
        return true;
    }

    // // public override bool Equals(object? obj) => obj is ObjectId other && Equals(other);
    // // public bool Equals(ObjectId other) => _value == other._value;
    // // public override int GetHashCode() => _value.GetHashCode();
    // // public int CompareTo(ObjectId other) => _value.CompareTo(other._value);
    // public readonly int CompareTo(object? obj) =>
    //     obj is ObjectId other
    //         ? CompareTo(other)
    //         : throw new ArgumentException($"object must be of type {nameof(ObjectId)}");

    // public override string ToString() => _value.ToString();

    public static Validation Validate(string value)
    {
        if (value is null)
            return Validation.Invalid($"The {nameof(ObjectId)} cannot be null.");
        else if (value?.Length != Length)
            return Validation.Invalid(
                $"The length of the {nameof(ObjectId)} must be {Length} characters."
            );
        else if (!Regex().IsMatch(value))
            return Validation.Invalid(
                $"The {nameof(ObjectId)} must match the regular expression {RegexString}."
            );

        return Validation.Ok;
    }

    public byte[] GetBytes()
    {
        var @this = this;
        return Enumerable
            .Range(0, Value.Length)
            .Where(x => x % 2 == 0)
            .Select(x => Convert.ToByte(@this.Value.Substring(x, 2), 16))
            .ToArray();
    }

    public static ObjectId Parse(string s, IFormatProvider? provider) =>
        From(s) with
        {
            OriginalString = s
        };

    public static bool TryParse(string? s, IFormatProvider? provider, out ObjectId result) =>
        (
            result = Validate(s).ErrorMessage is null
                ? From(s) with
                {
                    OriginalString = s
                }
                : default(ObjectId)
        ) != default(ObjectId);

    public static int CurrentTimestamp => (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    public static byte[] CurrentTimestampBytes =>
        BitConverter.IsLittleEndian
            ? BitConverter.GetBytes(CurrentTimestamp).Reverse().ToArray()
            : BitConverter.GetBytes(CurrentTimestamp);

    public readonly DateTimeOffset TimestampAsDateTimeOffset =>
        DateTimeOffset.FromUnixTimeSeconds(((IObjectId)this).Timestamp);
    public int Timestamp => int.Parse(Value.Substring(0, 8), NumberStyles.HexNumber);
    public readonly byte[] TimestampBytes =>
        BitConverter.IsLittleEndian
            ? BitConverter.GetBytes(((IObjectId)this).Timestamp).Reverse().ToArray()
            : BitConverter.GetBytes(((IObjectId)this).Timestamp);
    public readonly long MachineId => long.Parse(Value.Substring(7, 10), NumberStyles.HexNumber);
    public readonly byte[] MachineIdBytes =>
        BitConverter.IsLittleEndian
            ? BitConverter.GetBytes(((IObjectId)this).MachineId).Reverse().ToArray()
            : BitConverter.GetBytes(((IObjectId)this).MachineId);

    public readonly i24 Counter => i24.Parse(Value.Substring(17, 6), NumberStyles.HexNumber);
    public readonly byte[] CounterBytes =>
        BitConverter.IsLittleEndian
            ? BitConverter.GetBytes(((IObjectId)this).Counter).Reverse().ToArray()
            : BitConverter.GetBytes(((IObjectId)this).Counter);

    private static i24 _counter = (i24)Random.NextInt32(0, i24.MaxValue);

    public static int NextCounter() => _counter++;

    public static readonly long ThisMachineId = Environment.MachineName.GetHashCode();
    private static readonly byte[] ThisMachineIdBytes = BitConverter.IsLittleEndian
        ? BitConverter.GetBytes(ThisMachineId).Reverse().ToArray()
        : BitConverter.GetBytes(ThisMachineId);
}

public interface IObjectId
{
    int Timestamp { get; }
    long MachineId { get; }
    i24 Counter { get; }
    DateTimeOffset TimestampAsDateTimeOffset { get; }
#if NET6_0_OR_GREATER
    static abstract ObjectId NewId();
#endif
}

[System.Diagnostics.DebuggerDisplay("ObjectIdAttribute")]
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class ObjectIdAttribute : RegularExpressionAttribute
{
    public ObjectIdAttribute()
        : base(ObjectId.RegexString) { }
}
