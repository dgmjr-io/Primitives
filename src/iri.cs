/* 
 * iri copy.cs
 * 
 *   Created: 2023-07-16-02:36:18
 *   Modified: 2023-07-16-02:36:19
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 * 
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

/*
 * iri.cs
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
[global::System.Text.Json.Serialization.JsonConverter(typeof(iri.JsonConverter))]
#endif
[DebuggerDisplay("{ToString()}")]
public partial class iri : uri, IEquatable<iri>, IStringWithRegexValueObject<iri>
#if NET7_0_OR_GREATER
// , IUriConvertible<iri>
#endif
{
    public new const string Description = "a internationalized resource identifier (iri)";
    public new const string ExampleStringValue = "urn:example:emoji:🤬😈🤮";
    public new const string RegexString = @"^(?:[^:/?#]+:)?(?://(?:[^/?#]*@)?(?:[^/?#]*\.)+[^/?#]*(?::\d+)?)?(?:[^?#]*)(?:\?[^#]*)?(?:#.*)?$";
    public new const string EmptyStringValue = "❌:🚫";
    public new static iri Empty => From(EmptyStringValue);
    public override bool IsEmpty => base.ToString() == EmptyStringValue;

    public override string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<iri>.RegexString => RegexString;
    static string IStringWithRegexValueObject<iri>.Description => Description;
    static iri IStringWithRegexValueObject<iri>.Empty => EmptyStringValue;
    static iri IStringWithRegexValueObject<iri>.ExampleValue => new(ExampleStringValue);
    static iri IStringWithRegexValueObject<iri>.Parse(string s) => From(s);
#else
    string IStringWithRegexValueObject<iri>.Description => Description;
    iri IStringWithRegexValueObject<iri>.ExampleValue => ExampleStringValue;
#endif
    public static new iri Parse(string iri) => From(iri);


#if !NET6_0_OR_GREATER
    string IStringWithRegexValueObject<iri>.RegexString => RegexString;
    REx IStringWithRegexValueObject<iri>.Regex() => Regex();
#endif

#if NET70_OR_GREATER
    [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    public static partial REx Regex();

    // static iri IUriConvertible<iri>.FromUri(string s) => From(s);
    // static iri IUriConvertible<iri>.FromUri(Uri iri) => From(urn.ToString());
#else
    public static new REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
#endif
    public iri(string uriString) : base(uriString) { }
    public iri(Uri iri) : base(iri.ToString()) { }
    public iri() : base(EmptyStringValue) { }
    public static new iri Parse(string s, IFormatProvider? formatProvider = null) => From(s);

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

    public static bool TryCreate(string? uriString, UriKind uriKind, out iri iri)
    {
        if (string.IsNullOrEmpty(uriString))
        {
            iri = Empty;
            return false;
        }
        if (Uri.TryCreate(uriString, uriKind, out var suri))
        {
            iri = From(suri.ToString());
            return true;
        }
        iri = Empty;
        return false;
    }
    public static iri FromUri(string s) => From(s);
    public static iri FromUri(Uri iri) => From(iri);

    public static new iri From(string s) => Validate(s) == Validation.Ok ? new(s) : Empty;
    public static new iri From(Uri iri) => new(iri);

    public static implicit operator iri(string s) => From(s);
    public static implicit operator string(iri iri) => iri.ToString();

    public static bool operator ==(iri? left, iri? right) => left?.ToString() == right?.ToString();
    public static bool operator !=(iri? left, iri? right) => left?.ToString() != right?.ToString();
    public static bool operator <=(iri? left, iri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) <= 0;
    public static bool operator >=(iri? left, iri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) >= 0;
    public static bool operator <(iri? left, iri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) < 0;
    public static bool operator >(iri? left, iri? right) => string.CompareOrdinal(left?.ToString(), right?.ToString()) > 0;

    public override bool Equals(object? obj) => obj is iri iri && iri.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : base.ToString();

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out iri iri) => TryParse(s, out iri);
    public static bool TryParse(string? s, out iri? iri)
    {
        if (string.IsNullOrEmpty(s))
        {
            iri = Empty;
            return false;
        }
        if (Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out var suri))
        {
            iri = From(suri.ToString());
            return true;
        }
        iri = Empty;
        return false;
    }

    public bool Equals(iri? other) => ToString() == other.ToString();
    public override int CompareTo(string? other) => string.CompareOrdinal(ToString(), other);
    public override int CompareTo(object? obj) => obj is iri iri ? CompareTo(iri?.ToString()) : throw new ArgumentException("Object is not a iri.");
    public override bool Equals(string? other) => ToString() == other;
    public int CompareTo(iri? other) => string.CompareOrdinal(ToString(), other?.ToString());

    public new class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<iri, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public new class JsonConverter : System.Text.Json.Serialization.JsonConverter<iri>
    {
        public override iri Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, iri value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public new class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<iri>
    {
        public override iri Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return iri.From(reader.GetString());
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, iri value, global::System.Text.Json.JsonSerializerOptions options)
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
                return iri.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? sourceType)
        {
            return sourceType == typeof(global::System.String) || base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type? destinationType)
        {
            if (value is iri idValue)
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
public static class IriEfCoreExtensions
{
    public static void ConfigureIri<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, iri>> propertyExpression)
        where TEntity : class
        => modelBuilder.Entity<TEntity>().ConfigureIri(propertyExpression);

    public static void ConfigureIri<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder, Expression<Func<TEntity, iri>> propertyExpression)
        where TEntity : class
        => entityBuilder.Property(propertyExpression).HasConversion<iri.EfCoreValueConverter>();
}
#endif
