/*
 * urn.cs
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
[global::System.Text.Json.Serialization.JsonConverter(typeof(urn.JsonConverter))]
#endif
[DebuggerDisplay("{ToString()}")]
public partial class urn : uri, IEquatable<urn>, IStringWithRegexValueObject<urn>, IHaveAUri
#if NET7_0_OR_GREATER
// , IUriConvertible<urn>
#endif
{
    public new const string Description = "a uniform resource name (urn)";
    public new const string ExampleStringValue = "urn:isbn:978-951-0-18435-6 ";
    public new const string RegexString = @"^(?<Scheme>urn):(?<Name>[^\s].+)$";
    public new const string EmptyStringValue = "about:blank";
    public static new string Empty => From(EmptyStringValue);
    public override bool IsEmpty => base.ToString() == EmptyStringValue;

    public override string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<urn>.Description => Description;
    static string IStringWithRegexValueObject<urn>.RegexString => RegexString;
    static urn IStringWithRegexValueObject<urn>.Empty => EmptyStringValue;
    static urn IStringWithRegexValueObject<urn>.ExampleValue => new(ExampleStringValue);
#else
    string IStringWithRegexValueObject<urn>.Description => Description;
    urn IStringWithRegexValueObject<urn>.ExampleValue => ExampleStringValue;
    // urn IStringWithRegexValueObject<urn>.Empty => EmptyValue;
#endif
    public static new urn Parse(string urn) => From(urn);



#if !NET6_0_OR_GREATER
    string IStringWithRegexValueObject<urn>.RegexString => RegexString;
    REx IStringWithRegexValueObject<urn>.Regex() => Regex();
#endif

#if NET70_OR_GREATER
    [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    public static partial REx Regex();
    // static urn IUriConvertible<urn>.FromUri(string s) => From(s);
    // static urn IUriConvertible<urn>.FromUri(Uri uri) => From(urn.ToString());
#else
    public static new REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
#endif
    public urn(string uriString) : base(uriString) { }
    public urn(Uri uri) : this(uri.ToString()) { }
    public urn() : this(EmptyStringValue) { }
    public static new urn Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static new Validation Validate(string value)
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

    public static bool TryCreate(string? uriString, UriKind? uriKind, out urn urn)
    {
        uriKind ??= UriKind.Absolute;
        if (string.IsNullOrEmpty(uriString))
        {
            urn = Empty;
            return false;
        }
        if (Uri.TryCreate(uriString, default, out var suri))
        {
            urn = From(suri.ToString());
            return true;
        }
        urn = Empty;
        return false;
    }

    public static urn FromUri(string s) => From(s);
    public static urn FromUri(Uri u) => From(u);

    public static new urn From(string s) => Validate(s) == Validation.Ok ? new urn(s) : Empty;
    public static new urn From(Uri urn) => new(urn);

    public static implicit operator urn(string s) => From(s);
    public static implicit operator string(urn urn) => urn.ToString();

    public static bool operator ==(urn? left, urn? right) => left?.ToString() == right?.ToString();
    public static bool operator !=(urn? left, urn? right) => left?.ToString() != right?.ToString();
    public static bool operator <=(urn? left, urn? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) <= 0;
    public static bool operator >=(urn? left, urn? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) >= 0;
    public static bool operator <(urn? left, urn? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) < 0;
    public static bool operator >(urn? left, urn? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) > 0;

    public override bool Equals(object? obj) => obj is urn urn && urn.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : base.ToString();

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out urn urn) => TryParse(s, out urn);
    public static bool TryParse(string? s, out urn urn)
    {
        if (string.IsNullOrEmpty(s))
        {
            urn = Empty;
            return false;
        }
        if (Uri.TryCreate(s, global::System.UriKind.Absolute, out var suri))
        {
            urn = From(suri.ToString());
            return true;
        }
        urn = Empty;
        return false;
    }

    public bool Equals(urn? other) => ToString() == other?.ToString();
    public override int CompareTo(string? other) => string.CompareOrdinal(ToString(), other);
    public override int CompareTo(object? obj) => obj is urn urn ? CompareTo(urn?.ToString()) : throw new ArgumentException("Object is not a urn.");
    public override bool Equals(string? other) => ToString() == other;
    public int CompareTo(urn? other) => string.CompareOrdinal(ToString(), other?.ToString());

#if NETSTANDARD2_0_OR_GREATER
    public new class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<urn, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public new class JsonConverter : System.Text.Json.Serialization.JsonConverter<urn>
    {
        public override urn Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, urn value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public new class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<urn>
    {
        public override urn Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return urn.From(reader.GetString());
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, urn value, global::System.Text.Json.JsonSerializerOptions options)
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
                return urn.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertTo(context, sourceType) ||
                base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type? destinationType)
        {
            if (value is urn idValue)
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
public static class UrnEfCoreExtensions
{
    public static void ConfigureUrn<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, urn>> propertyExpression)
        where TEntity : class
        => modelBuilder.Entity<TEntity>().ConfigureUrn(propertyExpression);

    public static void ConfigureUrn<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder, Expression<Func<TEntity, urn>> propertyExpression)
        where TEntity : class
        => entityBuilder.Property(propertyExpression).HasConversion<urn.EfCoreValueConverter>();
}
#endif
