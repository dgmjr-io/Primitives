using System;
using System.ComponentModel.DataAnnotations;
/*
 * uri.cs
 *
 *   Created: 2022-12-20-04:48:32
 *   Modified: 2022-12-20-04:48:32
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
using System.Diagnostics;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace System;

using System.Linq.Expressions;
using System.Runtime.InteropServices;

using global::Vogen;

using Validation = global::Vogen.Validation;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static System.Text.RegularExpressions.RegexOptions;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif
/// <summary>
/// Represents an "uniform resource identifier (URI)"
/// </summary>
[RegexDto(uri._RegexString, RegexOptions: uri._RegexOptions)]
[uri.JConverter]
[DebuggerDisplay("{ToString()}")]
[StructLayout(LayoutKind.Auto)]
#if NET6_0_OR_GREATER
#endif
public readonly partial record struct uri : IStringWithRegexValueObject<uri>, IResourceIdentifier
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<uri>
#endif
{
#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string Description = "a uniform resource identifier (uri)";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string ExampleStringValue = "example:example";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    public const RegexOptions _RegexOptions =
        Compiled | IgnoreCase | Singleline | IgnorePatternWhitespace;

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    public const string _RegexString =
        @"^(?<Scheme:string?>[^:]+):(?:(?<DoubleSlashes:string?>\/\/)?(?<Authority:string?>(?:(?<UserInfo:string?>(?:[^@]+))@)?(?<Host:string?>(?:[^\/]+))(?::(?<Port:int?>[0-9]+))?)?)?(?<Path:string?>\/(?:[^?]+)?)?(?:\?(?<Query:string?>(?:.+)))?(?:#(?<Fragment:string?>(?:.+?)))?$";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string EmptyStringValue = "about:blank";
    public static uri Empty => From(EmptyStringValue);
    public readonly bool IsEmpty => BaseToString() == EmptyStringValue;
    public readonly string PathAndQuery =>
        $"{Path}{Query.FormatIfNotNullOrEmpty("?{0}")}{Fragment.FormatIfNotNullOrEmpty("#{0}")}";

    public readonly string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<uri>.RegexString => RegexString;
    static string IStringWithRegexValueObject<uri>.Description => Description;
    static uri IStringWithRegexValueObject<uri>.Empty => EmptyStringValue;
    static uri IStringWithRegexValueObject<uri>.ExampleValue => new(ExampleStringValue);

    static uri IStringWithRegexValueObject<uri>.Parse(string s) =>
        From(s) with
        {
            OriginalString = s
        };
#else
    readonly string IStringWithRegexValueObject<uri>.Description => Description;
    readonly uri IStringWithRegexValueObject<uri>.ExampleValue => ExampleStringValue;
    readonly string IStringWithRegexValueObject<uri>.RegexString => RegexString;

    readonly Regex IStringWithRegexValueObject<uri>.Regex() => Regex();
#endif

    public readonly Uri Uri => this;

    public uri(Uri uri)
        : this(uri.ToString()) { }

    public static uri Parse(string s, IFormatProvider? formatProvider) =>
        From(s) with
        {
            OriginalString = s
        };

    public static Validation Validate(string value) =>
        value is null
            ? Validation.Invalid("Cannot create a value object with null.")
            : !Uri.TryCreate(value, RelativeOrAbsolute, out _)
                ? Validation.Invalid("The value is not a valid URI.")
                : Validation.Ok;

    public static bool TryCreate(string? uriString, UriKind uriKind, out uri uri)
    {
        if (IsNullOrEmpty(uriString))
        {
            uri = Empty;
            return false;
        }
        if (Uri.TryCreate(uriString, uriKind, out var suri))
        {
            uri = From(suri.ToString());
            return true;
        }
        uri = Empty;
        return false;
    }

    public static uri From(string s) =>
        Validate(s) == Validation.Ok ? new uri(s) with { OriginalString = s } : Empty;

    public static uri From(Uri uri) => new uri(uri) with { OriginalString = uri.ToString() };

    public static implicit operator Uri(uri u) =>
        Uri.TryCreate(u.BaseToString(), RelativeOrAbsolute, out var uri)
            ? uri
            : new(EmptyStringValue);

    public static implicit operator uri(string s) => From(s) with { OriginalString = s };

    public static implicit operator string(uri uri) => uri.ToString();

    public static bool operator ==(uri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) == 0;

    public static bool operator !=(uri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) != 0;

    public static bool operator <=(uri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) <= 0;

    public static bool operator >=(uri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) >= 0;

    public static bool operator <(uri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) < 0;

    public static bool operator >(uri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) > 0;

    public readonly int CompareTo(IResourceIdentifier other) =>
        other is uri uri ? CompareTo(uri) : CompareTo(other.ToString());

    public override readonly int GetHashCode() => ToString().GetHashCode();

    public override readonly string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private readonly string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out uri uri) =>
        TryParse(s, out uri);

    public static bool TryParse(string? s, out uri uri)
    {
        try
        {
            if (IsNullOrEmpty(s))
            {
                uri = Empty;
                return false;
            }
            if (Uri.TryCreate(s, RelativeOrAbsolute, out var suri))
            {
                uri = From(suri.ToString());
                return true;
            }
        }
        catch
        {
            // ignore it
        }
        uri = Empty;
        return false;
    }

    public readonly bool Equals(uri? other) => Equals(other.ToString());

    public readonly int CompareTo(string? other) =>
        Compare(ToString(), other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(object? obj) =>
        obj is uri uri
            ? CompareTo(uri)
            : obj is string str
                ? CompareTo(str)
                : throw new ArgumentException("Object is not a uri.");

    public readonly bool Equals(string? other) =>
        ToString().Equals(other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(uri other) => CompareTo(other.ToString());

#if NETSTANDARD2_0_OR_GREATER
    public class EfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<uri, string>
    {
        public EfCoreValueConverter()
            : base(v => v.ToString(), v => From(v)) { }
    }

    public class JConverterAttribute : JsonConverterAttribute
    {
        public JConverterAttribute()
            : base(typeof(JsonConverter)) { }
    }

    public class JsonConverter : JsonConverter<uri>
    {
        public override uri Read(ref Utf8JsonReader reader, type typeToConvert, Jso options) =>
            From(reader.GetString());

        public override void Write(Utf8JsonWriter writer, uri value, Jso options) =>
            writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : JsonConverter<uri>
    {
        public override uri Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
        {
            return uri.From(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, uri value, Jso options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class TypeConverter : ComponentModel.TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, type? sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(
            ITypeDescriptorContext? context,
            Globalization.CultureInfo? culture,
            object? value
        )
        {
            var stringValue = value as string;
            return stringValue is not null
                ? From(stringValue)
                : base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, type? destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertTo(
            ITypeDescriptorContext? context,
            Globalization.CultureInfo? culture,
            object? value,
            type? destinationType
        ) =>
            value is uri idValue && destinationType == typeof(string)
                ? idValue.ToString()
                : base.ConvertTo(context, culture, value, destinationType);
    }
#endif
}

#if NETSTANDARD2_0_OR_GREATER
public static class UriEfCoreExtensions
{
    public static void ConfigureUri<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, uri>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().ConfigureUri(propertyExpression);

    public static void ConfigureUri<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, uri>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder.Property(propertyExpression).HasConversion<uri.EfCoreValueConverter>();
}
#endif
