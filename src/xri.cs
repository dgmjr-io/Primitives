/*
 * xri.cs
 *
 *   Created: 2023-07-20-11:53:36
 *   Modified: 2023-07-20-11:53:36
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

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
/// Represents an "extensible resource identifier"
/// </summary>
[RegexDto(xri._RegexString, RegexOptions: uri._RegexOptions)]
[StructLayout(LayoutKind.Auto)]
public partial record struct xri
    : IStringWithRegexValueObject<xri>,
        IResourceIdentifierWithQueryAndFragment
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<xri>
#endif
{
    public const string Description = "an eXtensible resource locator (xri)";
    public const string ExampleStringValue = "xri://@DGMJR-IO/=david.g.moore.jr";
    public const string _RegexString =
        @"^(?<Scheme:string?>xri):(?<DoubleSlashes:string?>\/\/)?(?<Path:string?>[^\/?#]+(?:\/[^\/?#]+))*(?:\?(?<Query:string?>(?:[^#]*)))?(?:#(?<Fragment:string?>(?:.*)))?$";
    public const string EmptyStringValue = "xri://null";
    public static xri Empty => From(EmptyStringValue);
    public bool IsEmpty => base.ToString() == EmptyStringValue;

    public string PathAndQuery =>
        $"{Path}{(Path.EndsWith("/") ? "" : "/")}{(!IsNullOrEmpty(Query) ? $" ?{Query})" : "")}{(!IsNullOrEmpty(Fragment) ? $"#{Fragment}" : "")}";

    private string _value = null!;
    public string Value => _value;
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<xri>.Description => Description;
    static string IStringWithRegexValueObject<xri>.RegexString => RegexString;
    static xri IStringWithRegexValueObject<xri>.ExampleValue => ExampleStringValue;
#else
    readonly string IStringWithRegexValueObject<xri>.Description => Description;
    readonly xri IStringWithRegexValueObject<xri>.ExampleValue => ExampleStringValue;
    readonly string IStringWithRegexValueObject<xri>.RegexString => RegexString;

    readonly REx IStringWithRegexValueObject<xri>.Regex() => Regex();
#endif

    public readonly Uri Uri => this;

    public static xri FromUri(string s) => From(s) with { OriginalString = s };

    public static xri FromUri(Uri u) => From(u) with { OriginalString = u.ToString() };

    public xri(Uri xri)
        : this(xri.ToString()) { }

    public xri(xri xri)
        : this(xri.ToString()) { }

    public static xri Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static Validation Validate(string value) =>
        value is null
            ? Validation.Invalid("Cannot create a value object with null.")
            : !xri.TryCreate(value, default, out _)
                ? Validation.Invalid("The value is not a valid xri.")
                : Validation.Ok;

    public static bool TryCreate(string? urlString, UriKind? uriKind, out xri xri)
    {
        if (string.IsNullOrEmpty(urlString))
        {
            xri = Empty;
            return false;
        }
        if (
            Validate(urlString) == Validation.Ok
            && Uri.TryCreate(urlString, uriKind ?? UriKind.Absolute, out var surl)
        )
        {
            xri = From(surl.ToString());
            return true;
        }
        xri = Empty;
        return false;
    }

    public static xri From(string s) =>
        Validate(s) == Validation.Ok ? new xri(s) with { OriginalString = s } : Empty;

    public static xri From(Uri xri) => new xri(xri) with { OriginalString = xri.ToString() };

    public static implicit operator System.Uri(xri u) =>
        Uri.TryCreate(u.BaseToString(), RelativeOrAbsolute, out var uri)
            ? uri
            : new(EmptyStringValue);

    public static implicit operator xri(string s) => From(s) with { OriginalString = s };

    public static implicit operator string(xri xri) => xri.ToString();

    public static bool operator ==(xri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) == 0;

    public static bool operator !=(xri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) != 0;

    public static bool operator <=(xri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) <= 0;

    public static bool operator >=(xri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) >= 0;

    public static bool operator <(xri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) < 0;

    public static bool operator >(xri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) > 0;

    public readonly int CompareTo(IResourceIdentifier other) =>
        other is xri xri ? CompareTo(xri) : CompareTo(other.ToString());

    public override readonly int GetHashCode() => ToString().GetHashCode();

    public override readonly string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private readonly string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out xri xri) =>
        TryParse(s, out xri);

    public static bool TryParse(string? s, out xri xri)
    {
        try
        {
            if (string.IsNullOrEmpty(s))
            {
                xri = Empty;
                return false;
            }
            if (xri.TryCreate(s, default, out var surl))
            {
                xri = From(surl.ToString()) with { OriginalString = surl.ToString() };
                return true;
            }
        }
        catch
        {
            // ignore
        }
        xri = Empty;
        return false;
    }

    public readonly bool Equals(xri? other) => Equals(other.ToString());

    public readonly int CompareTo(string? other) =>
        Compare(ToString(), other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(object? obj) =>
        obj is xri xri
            ? CompareTo(xri)
            : obj is string str
                ? CompareTo(str)
                : throw new ArgumentException("Object is not a xri.");

    public readonly bool Equals(string? other) =>
        ToString().Equals(other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(xri other) => CompareTo(other.ToString());

    public class EfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<xri, string>
    {
        public EfCoreValueConverter()
            : base(v => v.ToString(), v => From(v)) { }
    }

    public class JsonConverter : System.Text.Json.Serialization.JsonConverter<xri>
    {
        public override xri Read(
            ref System.Text.Json.Utf8JsonReader reader,
            Type typeToConvert,
            System.Text.Json.JsonSerializerOptions options
        ) => From(reader.GetString());

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            xri value,
            System.Text.Json.JsonSerializerOptions options
        ) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<xri>
    {
        public override xri Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options
        )
        {
            return xri.From(reader.GetString());
        }

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            xri value,
            global::System.Text.Json.JsonSerializerOptions options
        )
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
            if (stringValue is not null)
            {
                return xri.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
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
        )
        {
            if (value is xri idValue)
            {
                if (destinationType == typeof(string))
                {
                    return idValue.ToString();
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

public static class xriEfCoreExtensions
{
    public static void ConfigureXri<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, xri>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().ConfigureXri(propertyExpression);

    public static void ConfigureXri<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, xri>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder.Property(propertyExpression).HasConversion<xri.EfCoreValueConverter>();
}
