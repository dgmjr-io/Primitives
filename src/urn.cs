using System;
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
using System.Net.NetworkInformation;

namespace System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Vogen;

using static System.Text.RegularExpressions.RegexOptions;

[RegexDto(urn._RegexString, regexOptions: uri._RegexOptions)]
[global::System.Text.Json.Serialization.JsonConverter(typeof(urn.JsonConverter))]
[StructLayout(LayoutKind.Auto)]
[DebuggerDisplay("{ToString()}")]
public partial record struct urn : IStringWithRegexValueObject<urn>, IHaveAUri, IResourceIdentifier
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<urn>
#endif
{
    public const string Description = "a uniform resource name (urn)";
    public const string ExampleStringValue = "urn:isbn:978-951-0-18435-6 ";

    // public const string _RegexString = @"^(?<Scheme:string?>urn):(?<Namespace:string?>[a-zA-Z0-9][a-zA-Z0-9-]{0,31}):(?<NamespaceSpecificString:string?>(?:%[0-9a-fA-F]{2}|[-._~!$&'()*+,;=:@]|(?:[a-zA-Z0-9]|%[0-9a-fA-F]{2})*)*)$";
    public const string _RegexString =
        @"^(?<Scheme:string?>urn):(?<Namespace:string?>[a-zA-Z0-9][a-zA-Z0-9-]{0,31}):(?<NamespaceSpecificString:string?>(?:.)*)$";
    public const string EmptyStringValue = "urn:about:blank";
    public static urn Empty => From(EmptyStringValue);
    public bool IsEmpty => BaseToString() == EmptyStringValue;
    public string PathAndQuery => $"{Namespace}:{NamespaceSpecificString}";
    public string? DoubleSlashes = null;
    public string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<urn>.Description => Description;
    static string IStringWithRegexValueObject<urn>.RegexString => RegexString;
    static urn IStringWithRegexValueObject<urn>.Empty => EmptyStringValue;
    static urn IStringWithRegexValueObject<urn>.ExampleValue => new(ExampleStringValue);
#else
    string IStringWithRegexValueObject<urn>.Description => Description;
    urn IStringWithRegexValueObject<urn>.ExampleValue => ExampleStringValue;

    // urn IStringWithRegexValueObject<urn>.Empty => EmptyValue;
    string IStringWithRegexValueObject<urn>.RegexString => RegexString;

    REx IStringWithRegexValueObject<urn>.Regex() => Regex();
#endif

    // public static urn Parse(string urn) => From(urn);

    // #if NET70_OR_GREATER
    //     [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    //     public static partial REx Regex();
    //     // static urn IUriConvertible<urn>.FromUri(string s) => From(s);
    //     // static urn IUriConvertible<urn>.FromUri(Uri urn) => From(urn.ToString());
    // #else
    //     public static REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
    // #endif
    // public urn(string uriString) : base(uriString) { }
    public urn(Uri urn) : this(urn.ToString()) { }

    // public urn() : this(EmptyStringValue) { }
    public static urn Parse(string s, IFormatProvider? formatProvider = null) =>
        TryParse(s, out var urn)
            ? urn
            : throw new FormatException(
                $"The input string {s} was not in the correct format for a {nameof(urn)}."
            );

    public static Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        if (!Regex().IsMatch(value))
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
        if (TryParse(uriString, out var suri))
        {
            urn = From(uriString) with { OriginalString = uriString };
            return true;
        }
        urn = Empty;
        return false;
    }

    public Uri Uri => this;

    public static urn FromUri(string s) => From(s) with { OriginalString = s };

    public static urn FromUri(Uri u) => From(u) with { OriginalString = u.ToString() };

    public static urn From(string s) =>
        Validate(s) == Validation.Ok ? new urn(s) with { OriginalString = s } : Empty;

    public static urn From(Uri urn) => new urn(urn) with { OriginalString = urn.ToString() };

    public static implicit operator System.Uri(urn u) =>
        Uri.TryCreate(u.BaseToString(), RelativeOrAbsolute, out var uri)
            ? uri
            : new(EmptyStringValue);

    public static implicit operator urn(string s) => From(s) with { OriginalString = s };

    public static implicit operator string(urn urn) => urn.ToString();

    // public static implicit operator urn(urn? urn) => urn.HasValue ? urn.Value : Empty;

    public static bool operator ==(urn? left, IResourceIdentifier right) =>
        left?.CompareTo(right) == 0;

    public static bool operator !=(urn? left, IResourceIdentifier right) =>
        left?.CompareTo(right) != 0;

    public static bool operator <=(urn? left, IResourceIdentifier right) =>
        left?.CompareTo(right) <= 0;

    public static bool operator >=(urn? left, IResourceIdentifier right) =>
        left?.CompareTo(right) >= 0;

    public static bool operator <(urn? left, IResourceIdentifier right) =>
        left?.CompareTo(right) < 0;

    public static bool operator >(urn? left, IResourceIdentifier right) =>
        left?.CompareTo(right) > 0;

    public int CompareTo(IResourceIdentifier other) =>
        other is urn urn ? CompareTo(urn) : CompareTo(other.ToString());

    // public override bool Equals(object? obj) => obj is urn urn && urn.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();

    public override string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out urn urn) =>
        TryParse(s, out urn);

    public static bool TryParse(string? s, out urn urn)
    {
        try
        {
            if (string.IsNullOrEmpty(s))
            {
                urn = Empty;
                return false;
            }
            if (Regex().IsMatch(s))
            {
                urn = From(s) with { OriginalString = s };
                return true;
            }
        }
        catch
        {
            // ignore
        }
        urn = Empty;
        return false;
    }

    public bool Equals(urn? other) => Equals(other.ToString());

    public int CompareTo(string? other) => Compare(ToString(), other, InvariantCultureIgnoreCase);

    public int CompareTo(object? obj) =>
        obj is urn urn
            ? CompareTo(urn)
            : obj is string str
                ? CompareTo(str)
                : throw new ArgumentException("Object is not a urn.");

    public bool Equals(string? other) => ToString().Equals(other, InvariantCultureIgnoreCase);

    public int CompareTo(urn other) => CompareTo(other.ToString());

#if NETSTANDARD2_0_OR_GREATER
    public class EfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<urn, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public class JsonConverter : System.Text.Json.Serialization.JsonConverter<urn>
    {
        public override urn Read(
            ref System.Text.Json.Utf8JsonReader reader,
            Type typeToConvert,
            System.Text.Json.JsonSerializerOptions options
        ) => From(reader.GetString());

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            urn value,
            System.Text.Json.JsonSerializerOptions options
        ) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<urn>
    {
        public override urn Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options
        )
        {
            return urn.From(reader.GetString());
        }

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            urn value,
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
                return urn.From(stringValue);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(
            global::System.ComponentModel.ITypeDescriptorContext? context,
            global::System.Type? sourceType
        )
        {
            return sourceType == typeof(global::System.String)
                || base.CanConvertTo(context, sourceType)
                || base.CanConvertTo(context, sourceType);
        }

        public override object? ConvertTo(
            global::System.ComponentModel.ITypeDescriptorContext? context,
            global::System.Globalization.CultureInfo? culture,
            global::System.Object? value,
            global::System.Type? destinationType
        )
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
    public static void ConfigureUrn<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, urn>> propertyExpression
    ) where TEntity : class => modelBuilder.Entity<TEntity>().ConfigureUrn(propertyExpression);

    public static void ConfigureUrn<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, urn>> propertyExpression
    ) where TEntity : class =>
        entityBuilder.Property(propertyExpression).HasConversion<urn.EfCoreValueConverter>();
}
#endif
