/*
 * ObjectId.cs
 *
 *   Created: 2022-12-03-12:15:18
 *   Modified: 2022-12-03-12:15:18
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#pragma warning disable
namespace System;

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

using Vogen;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif

[ValueObject(
    typeof(string),
    conversions: Conversions.EfCoreValueConverter
        | Conversions.SystemTextJson
        | Conversions.TypeConverter
)]
// [RegexDto(ObjectId.RegexString)]
public partial record struct ObjectId
    : IStringWithRegexValueObject<ObjectId>,
        IComparable<ObjectId>,
        IComparable,
        IEquatable<ObjectId>
{
    public const string Description =
        "A ObjectId is a 24-digit (96-bit) hexadecimal string that uniquely identifies an object in a database";
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<ObjectId>.Description => Description;
#endif
    public const string EmptyValue = "000000000000000000000000";
    public const int Length = 24;
    public const string RegexString = "^[0-9a-z]{24}$";

#if NET7_0_OR_GREATER
    [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase)]
    public static partial REx Regex();
#else
    private static readonly REx _regex = new REx(
        RegexString,
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public static REx Regex() => _regex;
#endif

    public const string UrnPrefix = "urn:publicid:objectid:{0}";

    public Uri Uri => IsEmpty ? null : new(Format(UrnPrefix, ToString()));

    public static ObjectId NewId() => From(Guid.NewGuid().ToString("N").Substring(0, 24));

    public static ObjectId Empty => From(EmptyValue) with { OriginalString = EmptyValue };

    public bool IsNull => Value == EmptyValue;
    public bool IsEmpty => Value == EmptyValue;
    public string OriginalString { get; set; }

#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<ObjectId>.RegexString => RegexString;
#endif

    public const string ExampleValueString = "abcdef0123456789abcdef01";
    public static ObjectId ExampleValue =>
        From(ExampleValueString) with
        {
            OriginalString = ExampleValueString
        };

#if !NET6_0_OR_GREATER
    REx IStringWithRegexValueObject<ObjectId>.Regex() => Regex();

    string IStringWithRegexValueObject<ObjectId>.RegexString => RegexString;

    string IStringWithRegexValueObject<ObjectId>.Description => Description;

    ObjectId IStringWithRegexValueObject<ObjectId>.ExampleValue => ExampleValue;
#endif

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

    // public override bool Equals(object? obj) => obj is ObjectId other && Equals(other);
    // public bool Equals(ObjectId other) => _value == other._value;
    // public override int GetHashCode() => _value.GetHashCode();
    // public int CompareTo(ObjectId other) => _value.CompareTo(other._value);
    public int CompareTo(object? obj) =>
        obj is ObjectId other
            ? CompareTo(other)
            : throw new ArgumentException($"object must be of type {nameof(ObjectId)}");

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

    public static ObjectId Parse(string s, IFormatProvider? provider) =>
        From(s) with
        {
            OriginalString = s
        };

    public static bool TryParse(string? s, IFormatProvider? provider, out ObjectId result) =>
        (result = Validate(s).ErrorMessage is null ? From(s) with { OriginalString = s } : default)
        != default;
}

#if NETSTANDARD2_0_OR_GREATER
public class ObjectIdConverter
    : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<ObjectId, string>
{
    public ObjectIdConverter()
        : base(v => v.Value, v => ObjectId.Parse(v)) { }
}
#endif

[System.Diagnostics.DebuggerDisplay("ObjectIdAttribute")]
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class ObjectIdAttribute : RegularExpressionAttribute
{
    public ObjectIdAttribute()
        : base(ObjectId.RegexString) { }
}
