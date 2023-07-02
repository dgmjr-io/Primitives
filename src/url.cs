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
using static System.Text.RegularExpressions.RegexOptions;
#if NETSTANDARD2_0_OR_GREATER
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vogen;
[global::System.Text.Json.Serialization.JsonConverter(typeof(url.JsonConverter))]
#endif
[DebuggerDisplay("{ToString()}")]
public partial class url : uri, IEquatable<url>, IStringWithRegexValueObject<url>
#if NET7_0_OR_GREATER
// , IUriConvertible<url>
#endif
{
    public new const string Description = "a uniform resource locator (url)";
    public new const string ExampleStringValue = "https://dgmjr.io/";
    public new const string RegexString = @"^(?<Scheme>[^:]+):\/\/(?<Address>.+)&";
    public new const string EmptyStringValue = "about:blank";
    public static new url Empty => From(EmptyStringValue);
    public override bool IsEmpty => base.ToString() == EmptyStringValue;

    public override string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<url>.Description => Description;
    static string IStringWithRegexValueObject<url>.RegexString => RegexString;
    static url IStringWithRegexValueObject<url>.ExampleValue => ExampleStringValue;
#else
    string IStringWithRegexValueObject<url>.Description => Description;
    url IStringWithRegexValueObject<url>.ExampleValue => ExampleStringValue;
#endif
    public static new url Parse(string url) => From(url);



#if !NET6_0_OR_GREATER
    string IStringWithRegexValueObject<url>.RegexString => RegexString;
    REx IStringWithRegexValueObject<url>.Regex() => Regex();
#endif

#if NET70_OR_GREATER
    [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    public static partial REx Regex();

    // static url IUriConvertible<url>.FromUri(url url) => From(url.ToString());
    // static url IUriConvertible<url>.FromUri(string s) => From(s);
#else
    public static new REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
#endif
    public url(string urlString) : base(urlString) { }
    public url(url url) : base(url.ToString()) { }
    public url() : base(EmptyStringValue) { }
    public static new url Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static new Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        else if (!url.TryCreate(value, default, out _))
        {
            return Validation.Invalid("The value is not a valid url.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? urlString, UriKind? uriKind, out url url)
    {
        if (string.IsNullOrEmpty(urlString))
        {
            url = Empty;
            return false;
        }
        if (Validate(urlString) == Validation.Ok && Uri.TryCreate(urlString, uriKind ?? UriKind.RelativeOrAbsolute, out var surl))
        {
            url = From(surl.ToString());
            return true;
        }
        url = Empty;
        return false;
    }

    public static new url From(string s) => Validate(s) == Validation.Ok ? new(s) : Empty;
    public static url From(url url) => new(url);

    public static implicit operator url(string s) => From(s);
    public static implicit operator string(url url) => url.ToString();

    public static bool operator ==(url? left, url? right) => left?.ToString() == right?.ToString();
    public static bool operator !=(url? left, url? right) => left?.ToString() != right?.ToString();
    public static bool operator <=(url? left, url? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) <= 0;
    public static bool operator >=(url? left, url? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) >= 0;
    public static bool operator <(url? left, url? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) < 0;
    public static bool operator >(url? left, url? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) > 0;

    public override bool Equals(object? obj) => obj is url url && url.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : base.ToString();

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out url url) => TryParse(s, out url);
    public static bool TryParse(string? s, out url url)
    {
        if (string.IsNullOrEmpty(s))
        {
            url = Empty;
            return false;
        }
        if (url.TryCreate(s, default, out var surl))
        {
            url = From(surl.ToString());
            return true;
        }
        url = Empty;
        return false;
    }

    public bool Equals(url? other) => ToString() == other?.ToString();
    public override int CompareTo(string? other) => string.CompareOrdinal(ToString(), other);
    public override int CompareTo(object? obj) => obj is url url ? CompareTo(url?.ToString()) : throw new ArgumentException("Object is not a url.");
    public override bool Equals(string? other) => ToString() == other;
    public int CompareTo(url? other) => string.CompareOrdinal(ToString(), other?.ToString());

#if NETSTANDARD2_0_OR_GREATER
    public new class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<url, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public new class JsonConverter : System.Text.Json.Serialization.JsonConverter<url>
    {
        public override url Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, url value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public new class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<url>
    {
        public override url Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return url.From(reader.GetString());
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, url value, global::System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }


    public new class TypeConverter : global::System.ComponentModel.TypeConverter
    {
        public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertFrom(context, sourceType);
        }

        public override global::System.Object? ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value)
        {
            var stringValue = value as global::System.String;
            if (stringValue is not null)
            {
                return url.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type? destinationType)
        {
            if (value is url idValue)
            {
                if (destinationType == typeof(global::System.String))
                {
                    return idValue.ToString();
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
#endif
}


#if NETSTANDARD2_0_OR_GREATER
public static class urlEfCoreExtensions
{
    public static void Configureurl<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, url>> propertyExpression)
        where TEntity : class
        => modelBuilder.Entity<TEntity>().Configureurl(propertyExpression);

    public static void Configureurl<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder, Expression<Func<TEntity, url>> propertyExpression)
        where TEntity : class
        => entityBuilder.Property(propertyExpression).HasConversion<url.EfCoreValueConverter>();
}
#endif
