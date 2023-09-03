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
[RegexDto(url._RegexString, regexOptions: uri._RegexOptions)]
[url.JConverter]
[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{ToString()}")]
public partial record struct url : IStringWithRegexValueObject<url>, IResourceIdentifierWithQueryAndFragment
#if NET7_0_OR_GREATER
, IUriConvertible<url>
#endif
{
    public const string Description = "a uniform resource locator (url)";
    public const string ExampleStringValue = "https://dgmjr.io/";
    public const string _RegexString = @"^(?<Scheme:string?>[^:]+):(?:(?<Authority:string?>(?<DoubleSlashes:string?>\/\/)?(?:(?<UserInfo:string?>(?:[^@]+))@)?(?<Host:string?>(?:[^\/]+))(?::(?<Port:int?>[0-9]+))?)?)?(?<Path:string?>\/(?:[^?]+)?)?(?:\?(?<Query:string?>(?:.+)))?(?:#(?<Fragment:string?>(?:.+?)))?$";
    // public const string _RegexString = @"^(?<Scheme:string?>[a-z][a-z0-9+\-.]*):(?<DoubleSlashes:string?>\/\/)?(?:(?<Authority:string?>(?<UserInfo:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:]|[a-z0-9])*))?@)?(?<Host:string?>(?:\[(?:(?:[0-9a-f]{1,4}:){6}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|::(?:[0-9a-f]{1,4}:){5}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?[0-9a-f]{1,4}:(?:[0-9a-f]{1,4}:){0,2}[0-9a-f]{1,4}|(?:[0-9a-f]{1,4}:){1,7}:|:(?:[0-9a-f]{1,4}:){1,7})(?![0-9a-f]))|[a-z0-9]+(?:[-.][a-z0-9]+)*)(?::(?<Port:int?>[0-9]+))?(?<Path:string?>(?:\/(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)*)?(?:\?(?<Query:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)?)?(?:#(?<Fragment:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)?)?$";
    public const string EmptyStringValue = "about:blank";
    public static url Empty => From(EmptyStringValue);
    public bool IsEmpty => OriginalString == EmptyStringValue;

    public string PathAndQuery => $"{Path}{(!IsNullOrEmpty(Query) ? $"?{Query})" : "")}{(!IsNullOrEmpty(Fragment) ? $"#{Fragment}" : "")}";

    public string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<url>.Description => Description;
    static string IStringWithRegexValueObject<url>.RegexString => RegexString;
    static url IStringWithRegexValueObject<url>.ExampleValue => ExampleStringValue;
#else
    string IStringWithRegexValueObject<url>.Description => Description;
    url IStringWithRegexValueObject<url>.ExampleValue => ExampleStringValue;
    string IStringWithRegexValueObject<url>.RegexString => RegexString;
    REx IStringWithRegexValueObject<url>.Regex() => Regex();
#endif
    // public static url Parse(string url) => From(url);


    public Uri? Uri => this;
    public static url FromUri(url url) => From(url.ToString()) with { OriginalString = url.ToString() };
    public static url FromUri(string s) => From(s) with { OriginalString = s };

    // #if NET70_OR_GREATER
    //     [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    //     public static partial REx Regex();
    // #else
    //     public static REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
    // #endif
    // public url(string urlString) : this(urlString) { }
    public url(Uri url) : this(url.ToString()) { }
    // public url() : this(EmptyStringValue) { }
    public static url Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        else if (!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out _))
        {
            return Validation.Invalid("The value is not a valid URL.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? urlString, UriKind? uriKind, out url url)
        => TryParse(urlString, out url);

    public static url From(string s) => Validate(s) == Validation.Ok ? new url(s) with { OriginalString = s } : Empty;
    public static url From(url url) => new url(url.ToString()) with { OriginalString = url.ToString() };

    public static implicit operator System.Uri?(url u) => Uri.TryCreate(u.BaseToString(), RelativeOrAbsolute, out var uri) ? uri : null;
    public static implicit operator url(string s) => From(s) with { OriginalString = s };
    public static implicit operator string(url url) => url.ToString();

    // public static implicit operator url(url? url) => url.HasValue ? url.Value : Empty;
    public static bool operator ==(url? left, IResourceIdentifier right) => left?.CompareTo(right) == 0;
    public static bool operator !=(url? left, IResourceIdentifier right) => left?.CompareTo(right) != 0;
    public static bool operator <=(url? left, IResourceIdentifier right) => left?.CompareTo(right) <= 0;
    public static bool operator >=(url? left, IResourceIdentifier right) => left?.CompareTo(right) >= 0;
    public static bool operator <(url? left, IResourceIdentifier right) => left?.CompareTo(right) < 0;
    public static bool operator >(url? left, IResourceIdentifier right) => left?.CompareTo(right) > 0;

    public int CompareTo(IResourceIdentifier other) => other is url url ? CompareTo(url) : CompareTo(other.ToString());

    // public override bool Equals(object? obj) => obj is url url && url.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : Uri.ToString();
    private string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out url url) => TryParse(s, out url);
    public static bool TryParse(string? s, out url url)
    {
        try
        {
            if (string.IsNullOrEmpty(s))
            {
                url = Empty;
                return false;
            }
            if (global::System.Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out var suri))
            {
                url = From(suri.ToString());
                return true;
            }
        }
        catch
        {
            // ignore it
        }
        url = Empty;
        return false;
    }

    public bool Equals(url? other) => Equals(other.ToString());
    public int CompareTo(string? other) => Compare(ToString(), other, InvariantCultureIgnoreCase);
    public int CompareTo(object? obj) => obj is url url ? CompareTo(url) : obj is string str ? CompareTo(str) : throw new ArgumentException("Object is not a url.");
    public bool Equals(string? other) => ToString().Equals(other, InvariantCultureIgnoreCase);
    public int CompareTo(url other) => CompareTo(other.ToString());

    public class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<url, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public class JConverterAttribute : System.Text.Json.Serialization.JsonConverterAttribute
    {
        public JConverterAttribute() : base(typeof(url.JsonConverter)) { }
    }

    public class JsonConverter : System.Text.Json.Serialization.JsonConverter<url>
    {
        public override url Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, url value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<url>
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


    public class TypeConverter : global::System.ComponentModel.TypeConverter
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
