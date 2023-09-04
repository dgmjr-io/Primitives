/*
 * PhoneNumber.cs
 *
 *   Created: 2023-08-01-05:18:07
 *   Modified: 2023-08-01-05:18:08
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Domain;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using PhoneNumbers;

using Vogen;

using static System.Text.RegularExpressions.RegexOptions;

using Phone = PhoneNumbers.PhoneNumber;
using Util = PhoneNumbers.PhoneNumberUtil;
#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif

[ValueObject(
    typeof(string),
    conversions: Conversions.EfCoreValueConverter
        | Conversions.SystemTextJson
        | Conversions.TypeConverter
)]
[StructLayout(LayoutKind.Auto)]
[PhoneNumber.JConverter]
public partial record struct PhoneNumber : IStringWithRegexValueObject<PhoneNumber>
{
    public const string UriPrefix = "tel:";
    public const string UriPattern = $"{UriPrefix}{{0}}";
    public static string Description => "a phone number in e.164 format";
    public const string ExampleString = "+19174097331";
    public static PhoneNumber ExampleValue => From(ExampleString);
    public const string EmptyString = "+10000000000";
    public static PhoneNumber Empty => From(EmptyString);
    public const string RegexString =
        @"^[\+]?(?:[\s\.]+)?(?:[0-9]+)?[-\s\.]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    private static readonly Util _util = Util.GetInstance();
    public const string DefaultRegion = "US";
    public string? Number { get; private set; }
    public int? CountryCode => ParsedNumber?.CountryCode;
    public ulong? NationalNumber => ParsedNumber?.NationalNumber;
    public string? Extension => ParsedNumber?.Extension;
    public Phone ParsedNumber => _util.Parse(Value, DefaultRegion);
    public bool IsEmpty => this == Empty;
    public string OriginalString { get; set; }

    public Uri Uri => new(Format(UriPattern, ToString()));

    public static PhoneNumber FromUri(string s) =>
        From(s.Remove(0, UriPrefix.Length)) with
        {
            OriginalString = s.Remove(0, UriPrefix.Length)
        };

    public static PhoneNumber FromUri(Uri u) =>
        FromUri(u.ToString()) with
        {
            OriginalString = u.ToString()
        };

#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<PhoneNumber>.RegexString => RegexString;
    static string IStringWithRegexValueObject<PhoneNumber>.Description => Description;
    // PhoneNumber IStringWithRegexValueObject<PhoneNumber>.ExampleValue => ExampleValue;
#else
    // REx IStringWithRegexValueObject<PhoneNumber>.Regex() => Regex();
    string IStringWithRegexValueObject<PhoneNumber>.RegexString => RegexString;
    string IStringWithRegexValueObject<PhoneNumber>.Description => Description;
    PhoneNumber IStringWithRegexValueObject<PhoneNumber>.ExampleValue => ExampleValue;
#endif

    public override string ToString() =>
        IsEmpty ? string.Empty : _util.Format(this.ParsedNumber, PhoneNumberFormat.E164);

    public static PhoneNumber Parse(string s, IFormatProvider? formatProvider = null) =>
        From(s) with
        {
            OriginalString = s
        };

    public static bool TryParse(
        string? s,
        IFormatProvider? formatProvider,
        out PhoneNumber number
    ) => (number = TryParse(s, out var number1) ? number1!.Value : Empty) != Empty;

    public static bool TryParse(string s, out PhoneNumber? number)
    {
        try
        {
            number = From(s) with { OriginalString = s };
            return true;
        }
        catch
        {
            number = null;
            return false;
        }
    }

    private const RegexOptions RegexOptions =
        Compiled | CultureInvariant | IgnoreCase | Singleline | IgnorePatternWhitespace;

#if NET7_0_OR_GREATER
    [GeneratedRegex(RegexString, RegexOptions)]
    public static partial REx Regex();
#elif NET6_0_OR_GREATER
    public static REx Regex() => new(RegexString, RegexOptions);
    // REx IStringWithRegexValueObject<PhoneNumber>.RegexString => Regex();
#else
    private static REx _regex = new(RegexString, RegexOptions);

    REx IStringWithRegexValueObject<PhoneNumber>.Regex() => _regex;
#endif

    public static implicit operator PhoneNumber?(string? s) =>
        TryParse(s, out var number) ? number : default;

    public static implicit operator string?(PhoneNumber? n) =>
        n.HasValue ? _util.Format(n.Value.ParsedNumber, PhoneNumberFormat.E164) : default;

    public static bool operator <(PhoneNumber? a, PhoneNumber? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value, b.Value) < 0;

    public static bool operator ==(PhoneNumber? a, PhoneNumber? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value, b.Value) == 0;

    public static bool operator !=(PhoneNumber? a, PhoneNumber? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value, b.Value) != 0;

    public static bool operator >(PhoneNumber? a, PhoneNumber? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value, b.Value) > 0;

    public static bool operator <=(PhoneNumber? a, PhoneNumber? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value, b.Value) <= 0;

    public static bool operator >=(PhoneNumber? a, PhoneNumber? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value, b.Value) >= 0;

    public uri ToUri() => IsEmpty ? uri.Empty : uri.From($"tel:{this}");

#if NET6_0_OR_GREATER
    public static Validation Validate(string s) =>
        Util.IsViablePhoneNumber(s) && Regex().IsMatch(s)
            ? Validation.Ok
            : Validation.Invalid("Phone number is not valid.");
#else
    public static Validation Validate(string s) =>
        Util.IsViablePhoneNumber(s)
        && ((IStringWithRegexValueObject<PhoneNumber>)ExampleValue).Regex().IsMatch(s)
            ? Validation.Ok
            : Validation.Invalid("Phone number is not valid.");
#endif

    public static PhoneNumber Parse(string value) => From(value) with { OriginalString = value };

    public int CompareTo(object? obj) =>
        obj is not PhoneNumber n ? -1 : string.CompareOrdinal(Value, n.Value);

#if !NET7_0_OR_GREATER
    // REx IStringWithRegexValueObject<PhoneNumber>.Regex() => Regex();
    // string IStringWithRegexValueObject<PhoneNumber>.RegexString => RegexString;
#endif

#if !NETSTANDARD2_0_OR_GREATER
    public string Value { get; private set; }

    public static PhoneNumber From(string s) =>
        Validate(s) == Validation.Ok
            ? new PhoneNumber()
            {
                Value = _util.Parse(s, DefaultRegion).ToString(),
                OriginalString = s
            }
            : throw new ArgumentException("Phone number is not valid.", nameof(s));

    public int CompareTo(PhoneNumber other) => string.CompareOrdinal(Value, other.Value);
#endif

    public sealed class JConverterAttribute : System.Text.Json.Serialization.JsonConverterAttribute
    {
        public JConverterAttribute() : base(typeof(PhoneNumberSystemTextJsonConverter)) { }
    }
}

public static class PhoneNumberEfCoreExtensions
{
    public static void ConfigurePhoneNumber<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, PhoneNumber>> propertyExpression
    ) where TEntity : class =>
        modelBuilder.Entity<TEntity>().ConfigurePhoneNumber(propertyExpression);

    public static void ConfigurePhoneNumber<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, PhoneNumber>> propertyExpression
    ) where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion<PhoneNumber.EfCoreValueConverter>();
}

//"^\+((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))$"
