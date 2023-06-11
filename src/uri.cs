/*
 * uri.cs
 *
 *   Created: 2022-12-20-04:48:32
 *   Modified: 2022-12-20-04:48:32
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Mooore, Jr., All Rights Reserved
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
[global::System.Text.Json.Serialization.JsonConverter(typeof(uri.JsonConverter))]
#endif
[DebuggerDisplay("{ToString()}")]
public partial class uri : Uri, IEquatable<uri>, IStringWithRegexValueObject<uri>
#if NET7_0_OR_GREATER
, IUriConvertible<uri>
#endif
{
    public static string Description => "a uniform resource identifier (uri)";
    public static uri ExampleValue => "https://www.google.com/";
    public const string RegexString = @"^(?<Scheme>[^:]+):(?<Address>(\/?\/?).+)&";
    public const string EmptyValue = "about:blank";
    public static uri Empty => From(EmptyValue);
    public bool IsEmpty => base.ToString() == EmptyValue;

    public string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<uri>.RegexString => RegexString;
#else
    string IStringWithRegexValueObject<uri>.Description => Description;
    uri IStringWithRegexValueObject<uri>.ExampleValue => ExampleValue;
#endif
    public static uri Parse(string uri) => From(uri);



#if !NET6_0_OR_GREATER
    string IStringWithRegexValueObject<uri>.RegexString => RegexString;
    REx IStringWithRegexValueObject<uri>.Regex() => Regex();
#endif

#if NET70_OR_GREATER
    [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    public static partial REx Regex();

    static uri IUriConvertible<uri>.FromUri(Uri uri) => From(uri.ToString());
    static uri IUriConvertible<uri>.FromUri(string s) => From(s);
#else
    public static REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
#endif
    public uri(string uriString) : base(uriString) { }
    public uri(Uri uri) : base(uri.ToString()) { }
    public uri() : base(EmptyValue) { }
    public static uri Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        else if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out _))
        {
            return Validation.Invalid("The value is not a valid URI.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? uriString, UriKind uriKind, out uri uri)
    {
        if (string.IsNullOrEmpty(uriString))
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

    public static uri From(string s) => Validate(s) == Validation.Ok ? new(s) : Empty;
    public static uri From(Uri uri) => new(uri);

    public static implicit operator uri(string s) => From(s);
    public static implicit operator string(uri uri) => uri.ToString();

    public static bool operator ==(uri? left, uri? right) => left?.ToString() == right?.ToString();
    public static bool operator !=(uri? left, uri? right) => left?.ToString() != right?.ToString();
    public static bool operator <=(uri? left, uri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) <= 0;
    public static bool operator >=(uri? left, uri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) >= 0;
    public static bool operator <(uri? left, uri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) < 0;
    public static bool operator >(uri? left, uri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) > 0;

    public override bool Equals(object? obj) => obj is uri uri && uri.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : base.ToString();

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out uri? uri) => TryParse(s, out uri);
    public static bool TryParse(string? s, out uri? uri)
    {
        if (string.IsNullOrEmpty(s))
        {
            uri = Empty;
            return false;
        }
        if (Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out var suri))
        {
            uri = From(suri.ToString());
            return true;
        }
        uri = Empty;
        return false;
    }

    public bool Equals(uri other) => ToString() == other.ToString();
    public int CompareTo(string other) => string.CompareOrdinal(ToString(), other);
    public int CompareTo(object obj) => obj is uri uri ? CompareTo(uri.ToString()) : throw new ArgumentException("Object is not a uri.");
    public bool Equals(string other) => ToString() == other;
    public int CompareTo(uri other) => string.CompareOrdinal(ToString(), other.ToString());

#if NETSTANDARD2_0_OR_GREATER
    public class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<uri, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public class JsonConverter : System.Text.Json.Serialization.JsonConverter<uri>
    {
        public override uri Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, uri value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<uri>
    {
        public override uri Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return uri.From(reader.GetString());
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, uri value, global::System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }


    public class TypeConverter : global::System.ComponentModel.TypeConverter
    {
        public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext context, global::System.Type sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertFrom(context, sourceType);
        }

        public override global::System.Object ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext context, global::System.Globalization.CultureInfo culture, global::System.Object value)
        {
            var stringValue = value as global::System.String;
            if (stringValue is not null)
            {
                return uri.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext context, global::System.Type sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertTo(context, sourceType);
        }

        public override object ConvertTo(global::System.ComponentModel.ITypeDescriptorContext context, global::System.Globalization.CultureInfo culture, global::System.Object value, global::System.Type destinationType)
        {
            if (value is uri idValue)
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
public static class UriEfCoreExtensions
{
    public static void ConfigureUri<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, uri>> propertyExpression)
        where TEntity : class
        => modelBuilder.Entity<TEntity>().ConfigureUri(propertyExpression);

    public static void ConfigureUri<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder, Expression<Func<TEntity, uri>> propertyExpression)
        where TEntity : class
        => entityBuilder.Property(propertyExpression).HasConversion<uri.EfCoreValueConverter>();
}
#endif
