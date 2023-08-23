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
using System.Runtime.InteropServices;

namespace System;
using static System.Text.RegularExpressions.RegexOptions;
#if NETSTANDARD2_0_OR_GREATER
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif

[RegexDto(iri._RegexString, regexOptions: uri._RegexOptions)]
[global::System.Text.Json.Serialization.JsonConverter(typeof(iri.JsonConverter))]
[StructLayout(LayoutKind.Auto)]
#endif
[DebuggerDisplay("{ToString()}")]
public partial record struct iri : IStringWithRegexValueObject<iri>, IResourceIdentifierWithAuthorityHostPortQueryAndFragment
#if NET7_0_OR_GREATER
, IUriConvertible<iri>
#endif
{
    public const string Description = "a internationalized resource identifier (iri)";
    public const string ExampleStringValue = "urn:example:emoji:🤬😈🤮";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    public const string _RegexString = @"^(?<Scheme:string?>[a-zA-Z][a-zA-Z0-9+.-]*):(?<Authority:string?>//(?<UserInfo:string?>(?:%[0-9a-fA-F]{2}|[-._~!$&'()*+,;=:]|(?:[a-zA-Z0-9]|%[0-9a-fA-F]{2})*)*)@)?(?<Host:string?>(?:\[(?:(?:[0-9a-fA-F]{1,4}:){6}|(?=(?:[0-9a-fA-F]{0,4}:){0,6}(?:[0-9a-fA-F]{1,4}:)?(?:[0-9a-fA-F]{1,4}|\*))\[(([0-9a-fA-F]{1,4}:){0,5}|:)((:[0-9a-fA-F]{1,4}){1,5}|:)|::(?:[0-9a-fA-F]{1,4}:){0,4})[0-9a-fA-F]{1,4}\])|(?<IPV4:string?>(?:[0-9]{1,3}\.){3}[0-9]{1,3})|(?<RegName:string?>(?:%[0-9a-fA-F]{2}|[-._~!$&'()*+,;=:@])|(?:[a-zA-Z0-9]|%[0-9a-fA-F]{2})*)*)(?::(?<Port:int?>[0-9]*))?)?(?<Path:string?>(?:%[0-9a-fA-F]{2}|[-._~!$&'()*+,;=:@]|(?:[a-zA-Z0-9]|%[0-9a-fA-F]{2})*)*)?(?:\?(?<Query:string?>(?:%[0-9a-fA-F]{2}|[-._~!$&'()*+,;=:@/?]|(?:[a-zA-Z0-9]|%[0-9a-fA-F]{2})*)*)?)?(?:#(?<Fragment:string?>(?:%[0-9a-fA-F]{2}|[-._~!$&'()*+,;=:@/?]|(?:[a-zA-Z0-9]|%[0-9a-fA-F]{2})*)*)?)?$";
    // @"^(?<Scheme:string?>
    // [a-z][a-z0-9+\-.]*
    // )
    // :
    // (?<DoubleSlashes:string?>\/\/)?
    // (?<Authority:string?>
    //     (?:
    //         (?<UserInfo:string?>
    //             (?:
    //                 %[0-9a-f]{2}|[-._~!$&'()*+,;=:]|[a-z0-9]
    //             )*
    //         )@
    //     )?
    //     (?<Host:string?>
    //         (?:
    //             \[(?:
    //                 (?:[0-9a-f]{1,4}:){6}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|::(?:[0-9a-f]{1,4}:){5}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?[0-9a-f]{1,4}:(?:[0-9a-f]{1,4}:){0,2}[0-9a-f]{1,4}|(?:[0-9a-f]{1,4}:){1,7}:|:(?:[0-9a-f]{1,4}:){1,7}
    //             )
    //             (?![0-9a-f])
    //         )
    //         |[a-z0-9]+
    //         (?:[-.][a-z0-9]+)*
    //     )
    //     (?:
    //         \:
    //         (?<Port:int?>[0-9]+)
    //     )?
    // )?
    // (?<Path:string?>(?:\/(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)*)?
    // (?:
    //     \?
    //     (?<Query:string?>
    //         (?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*
    //     )?
    // )?
    // (?:
    //     #
    //     (?<Fragment:string?>
    //         (?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*
    //     )?
    // )?$";
    // public const string _RegexString = @"^(?<Scheme:string?>[a-z][a-z0-9+\-.]*):(?<DoubleSlashes:string?>\/\/)?(?:(?<Authority:string?>(?<UserInfo:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:]|[a-z0-9])*))?@)?(?<Host:string?>(?:\[(?:(?:[0-9a-f]{1,4}:){6}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|::(?:[0-9a-f]{1,4}:){5}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?[0-9a-f]{1,4}:(?:[0-9a-f]{1,4}:){0,2}[0-9a-f]{1,4}|(?:[0-9a-f]{1,4}:){1,7}:|:(?:[0-9a-f]{1,4}:){1,7})(?![0-9a-f]))|[a-z0-9]+(?:[-.][a-z0-9]+)*)(?::(?<Port:int?>[0-9]+))?)?(?<Path:string?>(?:\/(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)*)?(?:\?(?<Query:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)?)?(?:#(?<Fragment:string?>(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)?)?$";
    public const string EmptyStringValue = "empty:about:🚫";
    public static iri Empty => From(EmptyStringValue);
    public bool IsEmpty => BaseToString() == EmptyStringValue;
    public string PathAndQuery => $"{Path}{(!IsNullOrEmpty(Query) ? $"?{Query})" : "")}{(!IsNullOrEmpty(Fragment) ? $"#{Fragment}" : "")}";

    public string Value => ToString();
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
    // public static iri Parse(string iri) => From(iri);

#if !NET6_0_OR_GREATER
    string IStringWithRegexValueObject<iri>.RegexString => RegexString;
    REx IStringWithRegexValueObject<iri>.Regex() => Regex();
#endif

    // #if NET70_OR_GREATER
    //     [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    //     public static partial REx Regex();

    //     // static iri IUriConvertible<iri>.FromUri(string s) => From(s);
    //     // static iri IUriConvertible<iri>.FromUri(Uri iri) => From(urn.ToString());
    // #else
    //     public static REx Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
    // #endif
    // public iri(string uriString) : base(uriString) { }
    public iri(Uri iri) : this(iri.ToString()) { }
    // public iri() : base(EmptyStringValue) { }
    public static iri Parse(string s, IFormatProvider? formatProvider = null) => From(s);

    public static Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        else if (!Uri.TryCreate(value, RelativeOrAbsolute, out _))
        {
            return Validation.Invalid("The value is not a valid URI.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? uriString, UriKind uriKind, out iri iri)
    {
        try
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
        }
        catch
        {
            // ignore
        }
        iri = Empty;
        return false;
    }

    public Uri Uri => this;
    public static iri FromUri(string s) => From(s);
    public static iri FromUri(Uri iri) => From(iri);

    public static iri From(string s) => Validate(s) == Validation.Ok ? new(s) : Empty;
    public static iri From(Uri iri) => new(iri);

    public static implicit operator System.Uri(iri i) => Uri.TryCreate(i.BaseToString(), RelativeOrAbsolute, out var uri) ? uri : null;
    public static implicit operator iri(string s) => From(s);
    public static implicit operator string(iri iri) => iri.ToString();

    public static bool operator ==(iri? left, IResourceIdentifier right) => left?.CompareTo(right) == 0;
    public static bool operator !=(iri? left, IResourceIdentifier right) => left?.CompareTo(right) != 0;
    public static bool operator <=(iri? left, IResourceIdentifier right) => left?.CompareTo(right) <= 0;
    public static bool operator >=(iri? left, IResourceIdentifier right) => left?.CompareTo(right) >= 0;
    public static bool operator <(iri? left, IResourceIdentifier right) => left?.CompareTo(right) < 0;
    public static bool operator >(iri? left, IResourceIdentifier right) => left?.CompareTo(right) > 0;

    public int CompareTo(IResourceIdentifier other) => other is iri iri ? CompareTo(iri) : CompareTo(other.ToString());

    // public override bool Equals(object? obj) => obj is iri iri && iri.ToString() == ToString();
    public override int GetHashCode() => ToString().GetHashCode();


    public override string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private string BaseToString() => $"{Scheme}:{DoubleSlashes}{UserInfo.FormatIfNotNullOrEmpty("{0}@")}{Host}{Port.ToString().FormatIfNotNullOrEmpty(":{0}")}{Path}{Query.FormatIfNotNullOrEmpty("?{0}")}{Fragment.FormatIfNotNullOrEmpty("#{0}")}";

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out iri iri) => TryParse(s, out iri);
    public static bool TryParse(string? s, out iri iri)
    {
        try
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
        }
        catch
        {
            // ignore
        }
        iri = Empty;
        return false;
    }

    public bool Equals(iri? other) => Equals(other.ToString());
    public int CompareTo(string? other) => Compare(ToString(), other, InvariantCultureIgnoreCase);
    public int CompareTo(object? obj) => obj is iri iri ? CompareTo(iri) : obj is string str ? CompareTo(str) : throw new ArgumentException("Object is not a iri.");
    public bool Equals(string? other) => ToString().Equals(other, InvariantCultureIgnoreCase);
    public int CompareTo(iri other) => CompareTo(other.ToString());

    public class EfCoreValueConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<iri, string>
    {
        public EfCoreValueConverter() : base(v => v.ToString(), v => From(v)) { }
    }

    public class JsonConverter : System.Text.Json.Serialization.JsonConverter<iri>
    {
        public override iri Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options) => From(reader.GetString());
        public override void Write(System.Text.Json.Utf8JsonWriter writer, iri value, System.Text.Json.JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : global::System.Text.Json.Serialization.JsonConverter<iri>
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
                return From(stringValue);
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
