using System.ComponentModel.DataAnnotations;
/*
 * url.cs
 *
 *   Created: 2023-06-17-01:41:48
 *   Modified: 2023-06-17-01:42:14
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Diagnostics;

namespace System;

using System.Linq.Expressions;
using System.Runtime.InteropServices;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Vogen;

using static System.Text.RegularExpressions.RegexOptions;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif
/// <summary>
/// Represents an "uniform resource locator (URL)"
/// </summary>
[RegexDto(url._RegexString, RegexOptions: uri._RegexOptions)]
[url.JConverter]
[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{ToString()}")]
public readonly partial record struct url
    : IStringWithRegexValueObject<url>,
        IResourceIdentifierWithQueryAndFragment
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<url>
#endif
{
    public const string Description = "a uniform resource locator (URL)";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string ExampleStringValue = "https://dgmjr.io/";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    public const string _RegexString =
        @"^(?<Scheme:string?>[^:]+):(?:(?<DoubleSlashes:string?>\/\/)?(?<Authority:string?>(?:(?<UserInfo:string?>(?:[^@]+))@)?(?<Host:string?>(?:[^\/]+))(?::(?<Port:int?>[0-9]+))?)?)?(?<Path:string?>\/(?:[^?]+)?)?(?:\?(?<Query:string?>(?:.+)))?(?:#(?<Fragment:string?>(?:.+?)))?$";

    public static ExternalDocsTuple ExternalDocs =>
        ("Uniform Resource Locator (URL)", new Uri("https://en.wikipedia.org/wiki/URL"));

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string EmptyStringValue = "about:blank";
    public static url Empty => From(EmptyStringValue);
    public readonly bool IsEmpty => OriginalString == EmptyStringValue;

    public readonly string PathAndQuery =>
        $"{Path}{(!IsNullOrEmpty(Query) ? $"?{Query})" : "")}{(!IsNullOrEmpty(Fragment) ? $"#{Fragment}" : "")}";

    public readonly string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<url>.Description => Description;
    static string IStringWithRegexValueObject<url>.RegexString => RegexString;
    static url IStringWithRegexValueObject<url>.ExampleValue => ExampleStringValue;
#else
    readonly string IStringWithRegexValueObject<url>.Description => Description;
    readonly url IStringWithRegexValueObject<url>.ExampleValue => ExampleStringValue;
    readonly string IStringWithRegexValueObject<url>.RegexString => RegexString;

    readonly Regex IStringWithRegexValueObject<url>.Regex() => Regex();
#endif

    public readonly Uri Uri => this;

    public static url FromUri(url url) =>
        From(url.ToString()) with
        {
            OriginalString = url.ToString()
        };

    public static url FromUri(string s) => From(s) with { OriginalString = s };

    public url(Uri url)
        : this(url.ToString()) { }

    public static url Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static Validation Validate(string value) =>
        value is null
            ? Validation.Invalid("Cannot create a value object with null.")
            : !Uri.TryCreate(value, RelativeOrAbsolute, out _)
                ? Validation.Invalid("The value is not a valid URL.")
                : Validation.Ok;

    public static bool TryCreate(string? urlString, UriKind? uriKind, out url url) =>
        TryParse(urlString, out url);

    public static url From(string s) =>
        Validate(s) == Validation.Ok ? new url(s) with { OriginalString = s } : Empty;

    public static url From(url url) =>
        new url(url.ToString()) with
        {
            OriginalString = url.ToString()
        };

    public static implicit operator System.Uri(url u) =>
        Uri.TryCreate(u.BaseToString(), RelativeOrAbsolute, out var uri)
            ? uri
            : new(EmptyStringValue);

    public static implicit operator url(string s) => From(s) with { OriginalString = s };

    public static implicit operator string(url url) => url.ToString();

    public static bool operator ==(url? left, IResourceIdentifier right) =>
        left?.CompareTo(right) == 0;

    public static bool operator !=(url? left, IResourceIdentifier right) =>
        left?.CompareTo(right) != 0;

    public static bool operator <=(url? left, IResourceIdentifier right) =>
        left?.CompareTo(right) <= 0;

    public static bool operator >=(url? left, IResourceIdentifier right) =>
        left?.CompareTo(right) >= 0;

    public static bool operator <(url? left, IResourceIdentifier right) =>
        left?.CompareTo(right) < 0;

    public static bool operator >(url? left, IResourceIdentifier right) =>
        left?.CompareTo(right) > 0;

    public readonly int CompareTo(IResourceIdentifier other) =>
        other is url url ? CompareTo(url) : CompareTo(other.ToString());

    public override readonly int GetHashCode() => ToString().GetHashCode();

    public override readonly string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private readonly string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out url url) =>
        TryParse(s, out url);

    public static bool TryParse(string? s, out url url)
    {
        try
        {
            if (IsNullOrEmpty(s))
            {
                url = Empty;
                return false;
            }
            if (Uri.TryCreate(s, RelativeOrAbsolute, out var suri))
            {
                url = From(suri.ToString());
                return true;
            }
        }
        catch (Exception e)
            when (e
                    is ValueObjectValidationException
                        or ArgumentNullException
                        or FormatException
                        or OverflowException
                        or ArgumentException
                        or InvalidCastException
                        or InvalidOperationException
            )
        { /* ignore it */
        }

        url = Empty;
        return false;
    }

    public readonly bool Equals(url? other) => Equals(other.ToString());

    public readonly int CompareTo(string? other) =>
        Compare(ToString(), other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(object? obj) =>
        obj is url url
            ? CompareTo(url)
            : obj is string str
                ? CompareTo(str)
                : throw new ArgumentException("Object is not a url.");

    public readonly bool Equals(string? other) =>
        ToString().Equals(other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(url other) => CompareTo(other.ToString());

    public class EfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<url, string>
    {
        public EfCoreValueConverter()
            : base(v => v.ToString(), v => From(v)) { }
    }

    public class NullableEfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<url?, string?>
    {
        public NullableEfCoreValueConverter()
            : base(v => v.HasValue ? v.ToString() : null, v => From(v)) { }
    }

    public class JConverterAttribute : JsonConverterAttribute
    {
        public JConverterAttribute()
            : base(typeof(url.JsonConverter)) { }
    }

    public class JsonConverter : JsonConverter<url>
    {
        public override url Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        ) => From(reader.GetString());

        public override void Write(
            Utf8JsonWriter writer,
            url value,
            JsonSerializerOptions options
        ) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : JsonConverter<url>
    {
        public override url Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
        {
            return From(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, url value, Jso options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class TypeConverter : System.ComponentModel.TypeConverter
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
                ? url.From(stringValue)
                : base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, type? sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(
            ITypeDescriptorContext? context,
            Globalization.CultureInfo? culture,
            object? value,
            type? destinationType
        ) =>
            value is url idValue && destinationType == typeof(string)
                ? idValue.ToString()
                : base.ConvertTo(context, culture, value, destinationType);
    }
}

#if NETSTANDARD2_0_OR_GREATER
public static class UrlEfCoreExtensions
{
    public static PropertyBuilder<url> UrlProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, url>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UrlProperty(propertyExpression);

    public static PropertyBuilder<url?> UrlProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, url?>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UrlProperty(propertyExpression);

    public static PropertyBuilder<url> UrlProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, url>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new url.EfCoreValueConverter())
            .HasMaxLength(UriMaxLength);

    public static PropertyBuilder<url?> UrlProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, url?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new url.NullableEfCoreValueConverter())
            .HasMaxLength(UriMaxLength);
}
#endif
