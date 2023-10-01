using System;
using System.ComponentModel.DataAnnotations;
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

[RegexDto(uri._RegexString, regexOptions: uri._RegexOptions)]
[uri.JConverter]
[DebuggerDisplay("{ToString()}")]
[StructLayout(LayoutKind.Auto)]
#if NET6_0_OR_GREATER
#endif
public partial record struct uri : IStringWithRegexValueObject<uri>, IResourceIdentifier
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<uri>
#endif
{
    public const string Description = "a uniform resource identifier (uri)";
    public const string ExampleStringValue = "example:example";
    public const RegexOptions _RegexOptions =
        Compiled | IgnoreCase | Singleline | IgnorePatternWhitespace;
    public const string _RegexString =
        @"^(?<Scheme:string?>[^:]+):(?:(?<Authority:string?>(?<DoubleSlashes:string?>\/\/)?(?:(?<UserInfo:string?>(?:[^@]+))@)?(?<Host:string?>(?:[^\/]+))(?::(?<Port:int?>[0-9]+))?)?)?(?<Path:string?>\/(?:[^?]+)?)?(?:\?(?<Query:string?>(?:.+)))?(?:#(?<Fragment:string?>(?:.+?)))?$";

    // public const string _RegexString = @"^(?<Scheme:string?>[a-z][a-z0-9+\-.]*):(?<DoubleSlashes:string?>\/\/)?(?:(?<Authority:string?>(?<UserInfo:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:]|[a-z0-9])*))?@)?(?<Host:string?>(?:\[(?:(?:[0-9a-f]{1,4}:){6}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|::(?:[0-9a-f]{1,4}:){5}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?[0-9a-f]{1,4}:(?:[0-9a-f]{1,4}:){0,2}[0-9a-f]{1,4}|(?:[0-9a-f]{1,4}:){1,7}:|:(?:[0-9a-f]{1,4}:){1,7})(?![0-9a-f]))|[a-z0-9]+(?:[-.][a-z0-9]+)*)(?::(?<Port:int?>[0-9]+))?(?<Path:string?>(?:\/(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)*)?(?:\?(?<Query:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)?)?(?:#(?<Fragment:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)?)?$";
    public const string EmptyStringValue = "about:blank";
    public static uri Empty => From(EmptyStringValue);
    public bool IsEmpty => BaseToString() == EmptyStringValue;
    public string PathAndQuery =>
        $"{Path}{Query.FormatIfNotNullOrEmpty("?{0}")}{Fragment.FormatIfNotNullOrEmpty("#{0}")}";

    public string Value => ToString();
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
    string IStringWithRegexValueObject<uri>.Description => Description;
    uri IStringWithRegexValueObject<uri>.ExampleValue => ExampleStringValue;
    string IStringWithRegexValueObject<uri>.RegexString => RegexString;

    REx IStringWithRegexValueObject<uri>.Regex() => Regex();
#endif

    // public static uri Parse(string uri) => From(uri);

    public Uri Uri => this;

    // #if NET70_OR_GREATER
    //     [GeneratedRegex(RegexString, Compiled | RegexOptions)]
    //     public static partial REx Regex();

    //     // static uri IUriConvertible<uri>.FromUri(string s) => From(s);
    //     // static uri IUriConvertible<uri>.FromUri(Uri uri) => From(urn.ToString());
    // #else
    //     public static REx Regex() => new(RegexString, RegexOptions);
    // #endif
    // public uri(string uriString) : base(uriString) { }
    public uri(Uri uri)
        : this(uri.ToString()) { }

    // public uri() : base(EmptyStringValue) { }
    public static uri Parse(string s, IFormatProvider? formatProvider = null) =>
        From(s) with
        {
            OriginalString = s
        };

    public static Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out _))
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

    public static uri From(string s) =>
        Validate(s) == Validation.Ok ? new uri(s) with { OriginalString = s } : Empty;

    public static uri From(Uri uri) => new uri(uri) with { OriginalString = uri.ToString() };

    public static implicit operator System.Uri(uri u) =>
        Uri.TryCreate(u.BaseToString(), RelativeOrAbsolute, out var uri)
            ? uri
            : new(EmptyStringValue);

    public static implicit operator uri(string s) => From(s) with { OriginalString = s };

    public static implicit operator string(uri uri) => uri.ToString();

    // public static implicit operator uri(uri? uri) => uri.HasValue ? uri.Value : Empty;

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

    public int CompareTo(IResourceIdentifier other) =>
        other is uri uri ? CompareTo(uri) : CompareTo(other.ToString());

    // public override bool Equals(object? obj) => obj is uri uri && uri.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out uri uri) =>
        TryParse(s, out uri);

    public static bool TryParse(string? s, out uri uri)
    {
        try
        {
            if (string.IsNullOrEmpty(s))
            {
                uri = Empty;
                return false;
            }
            if (global::System.Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out var suri))
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

    public bool Equals(uri? other) => Equals(other.ToString());

    public int CompareTo(string? other) => Compare(ToString(), other, InvariantCultureIgnoreCase);

    public int CompareTo(object? obj) =>
        obj is uri uri
            ? CompareTo(uri)
            : obj is string str
                ? CompareTo(str)
                : throw new ArgumentException("Object is not a uri.");

    public bool Equals(string? other) => ToString().Equals(other, InvariantCultureIgnoreCase);

    public int CompareTo(uri other) => CompareTo(other.ToString());

#if NETSTANDARD2_0_OR_GREATER
    public class EfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<uri, string>
    {
        public EfCoreValueConverter()
            : base(v => v.ToString(), v => From(v)) { }
    }

    public class JConverterAttribute : System.Text.Json.Serialization.JsonConverterAttribute
    {
        public JConverterAttribute()
            : base(typeof(JsonConverter)) { }
    }

    public class JsonConverter : System.Text.Json.Serialization.JsonConverter<uri>
    {
        public override uri Read(
            ref System.Text.Json.Utf8JsonReader reader,
            Type typeToConvert,
            System.Text.Json.JsonSerializerOptions options
        ) => From(reader.GetString());

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            uri value,
            System.Text.Json.JsonSerializerOptions options
        ) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<uri>
    {
        public override uri Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options
        )
        {
            return uri.From(reader.GetString());
        }

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            uri value,
            global::System.Text.Json.JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class TypeConverter : global::System.ComponentModel.TypeConverter
    {
        public override global::System.Boolean CanConvertFrom(
            global::System.ComponentModel.ITypeDescriptorContext? context,
            global::System.Type? sourceType
        )
        {
            return sourceType == typeof(global::System.String)
                || base.CanConvertFrom(context, sourceType);
        }

        public override global::System.Object? ConvertFrom(
            global::System.ComponentModel.ITypeDescriptorContext? context,
            global::System.Globalization.CultureInfo? culture,
            global::System.Object? value
        )
        {
            var stringValue = value as global::System.String;
            if (stringValue is not null)
            {
                return uri.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(
            global::System.ComponentModel.ITypeDescriptorContext? context,
            global::System.Type? sourceType
        )
        {
            return sourceType == typeof(global::System.String)
                || base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(
            global::System.ComponentModel.ITypeDescriptorContext? context,
            global::System.Globalization.CultureInfo? culture,
            global::System.Object? value,
            global::System.Type? destinationType
        )
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
