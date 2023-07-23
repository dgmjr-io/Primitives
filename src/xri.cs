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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vogen;
using static System.Text.RegularExpressions.RegexOptions;

public class xri : uri, IStringWithRegexValueObject<xri>
{
    public new const string Description = "an eXtensible resource locator (xri)";
    public new const string ExampleStringValue = "xri://@DGMJR-IO/=david.g.moore.jr";
    public new const string RegexString = @"^xri://[^/?#]+(?:/[^/?#]+)*(?:\?(?:[^#]*))?(?:#(?:.*))?$";
    public new const string EmptyStringValue = "xri://null";
    public static new xri Empty => From(EmptyStringValue);
    public override bool IsEmpty => base.ToString() == EmptyStringValue;

    private string _value = null!;
    public override string Value => _value;
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<xri>.Description => Description;
    static string IStringWithRegexValueObject<xri>.RegexString => RegexString;
    static xri IStringWithRegexValueObject<xri>.ExampleValue => ExampleStringValue;
#else
    string IStringWithRegexValueObject<xri>.Description => Description;
    xri IStringWithRegexValueObject<xri>.ExampleValue => ExampleStringValue;
#endif
    public static new xri Parse(string xri) => From(xri);

    public static xri FromUri(string s) => From(s);
    public static xri FromUri(Uri u) => From(u);

#if !NET6_0_OR_GREATER
    string IStringWithRegexValueObject<xri>.RegexString => RegexString;
    REx IStringWithRegexValueObject<xri>.Regex() => Regex();
#endif

    private const RegexOptions RegexOptions = Compiled | IgnoreCase | Singleline;
#if NET70_OR_GREATER
    [GeneratedRegex(RegexString, RegexOptions)]
    public static partial REx Regex();
#else
    public static new REx Regex() => new(RegexString, RegexOptions);
#endif
    public xri(string urlString) : base(urlString) { }
    public xri(Uri uri) : this(uri.ToString()) { }
    public xri(xri xri) : this(xri.ToString()) { }
    public xri() : this(EmptyStringValue) { }
    public static new xri Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static new Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        else if (!xri.TryCreate(value, default, out _))
        {
            return Validation.Invalid("The value is not a valid xri.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? urlString, UriKind? uriKind, out xri xri)
    {
        if (string.IsNullOrEmpty(urlString))
        {
            xri = Empty;
            return false;
        }
        if (Validate(urlString) == Validation.Ok && Uri.TryCreate(urlString, uriKind ?? UriKind.Absolute, out var surl))
        {
            xri = From(surl.ToString());
            return true;
        }
        xri = Empty;
        return false;
    }

    public static new xri From(string s) => Validate(s) == Validation.Ok ? new(s) : Empty;
    public static new xri From(Uri xri) => new(xri);

    public static implicit operator xri(string s) => From(s);
    public static implicit operator string(xri xri) => xri.ToString();
    public static bool operator ==(xri? left, xri? right) => string.Equals(left?.ToString(), right?.ToString());
    public static bool operator !=(xri? left, xri? right) => string.Equals(left?.ToString(), right?.ToString());
    public static bool operator <=(xri? left, xri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) <= 0;
    public static bool operator >=(xri? left, xri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) >= 0;
    public static bool operator <(xri? left, xri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) < 0;
    public static bool operator >(xri? left, xri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) > 0;

    public override bool Equals(object? obj) => obj is xri xri && string.Equals(xri.Value, Value);
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : base.ToString();

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out xri xri) => TryParse(s, out xri);
    public static bool TryParse(string? s, out xri xri)
    {
        if (string.IsNullOrEmpty(s))
        {
            xri = Empty;
            return false;
        }
        if (xri.TryCreate(s, default, out var surl))
        {
            xri = From(surl.ToString());
            return true;
        }
        xri = Empty;
        return false;
    }

    public bool Equals(xri? other) => ToString() == other?.ToString();
    public override int CompareTo(string? other) => string.CompareOrdinal(ToString(), other);
    public override int CompareTo(object? obj) => obj is xri xri ? CompareTo(xri?.ToString()) : throw new ArgumentException("Object is not a xri.");
    public override bool Equals(string? other) => ToString() == other;
    public int CompareTo(xri? other) => string.CompareOrdinal(ToString(), other?.ToString());

    public new class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<xri, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public new class JsonConverter : System.Text.Json.Serialization.JsonConverter<xri>
    {
        public override xri Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, xri value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public new class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<xri>
    {
        public override xri Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return xri.From(reader.GetString());
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, xri value, global::System.Text.Json.JsonSerializerOptions options)
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
                return xri.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type? destinationType)
        {
            if (value is xri idValue)
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


public static class xriEfCoreExtensions
{
    public static void ConfigureXri<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, xri>> propertyExpression)
        where TEntity : class
        => modelBuilder.Entity<TEntity>().ConfigureXri(propertyExpression);

    public static void ConfigureXri<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder, Expression<Func<TEntity, xri>> propertyExpression)
        where TEntity : class
        => entityBuilder.Property(propertyExpression).HasConversion<xri.EfCoreValueConverter>();
}
