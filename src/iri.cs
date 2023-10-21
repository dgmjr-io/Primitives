using System.Data;
/*
 * iri.cs
 *
 *   Created: 2022-12-20-04:48:32
 *   Modified: 2022-12-20-04:48:32
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Moore, Jr., All Rights Reserved
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
using Validation = Vogen.Validation;
using Vogen;

/// <summary>
/// Represents an "internationalized resource identifier (IRI)"
/// </summary>
[RegexDto(_RegexString, RegexOptions: uri._RegexOptions)]
[SystemTextJsonConverter]
[StructLayout(LayoutKind.Auto)]
#endif
[DebuggerDisplay("{ToString()}")]
public readonly partial record struct iri
    : IStringWithRegexValueObject<iri>,
        IResourceIdentifierWithAuthorityHostPortQueryAndFragment
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<iri>
#endif
{
    public const string Description = "an internationalized resource identifier (iri)";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string ExampleStringValue = "urn:example:emoji:🤬😈🤮";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    public const string _RegexString =
        @"^(?<Scheme:string?>[^:]+):(?:(?<DoubleSlashes:string?>\/\/)?(?<Authority:string?>(?:(?<UserInfo:string?>(?:[^@]+))@)?(?<Host:string?>(?:[^\/]+))(?::(?<Port:int?>[0-9]+))?)?)?(?<Path:string?>\/(?:[^?]+)?)?(?:\?(?<Query:string?>(?:.+)))?(?:#(?<Fragment:string?>(?:.+?)))?$";
    // public string? DoubleSlashes => "//";

    public static IEnumerable<ExternalDocsTuple> ExternalDocs => [("Internationalized Resource Identifier (IRI)", new Uri("https://en.wikipedia.org/wiki/Internationalized_Resource_Identifier"))];

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string EmptyStringValue = "empty:about:🚫";
    public static iri Empty => From(EmptyStringValue);
    public readonly bool IsEmpty => BaseToString() == EmptyStringValue;
    public readonly string PathAndQuery =>
        $"{Path}{(!IsNullOrEmpty(Query) ? $"?{Query})" : "")}{(!IsNullOrEmpty(Fragment) ? $"#{Fragment}" : "")}";

    public readonly string Value => ToString();
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<iri>.RegexString => RegexString;
    static string IStringWithRegexValueObject<iri>.Description => Description;
    static iri IStringWithRegexValueObject<iri>.Empty => EmptyStringValue;
    static iri IStringWithRegexValueObject<iri>.ExampleValue => new(ExampleStringValue);
#else
    readonly string IStringWithRegexValueObject<iri>.Description => Description;
    readonly iri IStringWithRegexValueObject<iri>.ExampleValue => ExampleStringValue;
    readonly string IStringWithRegexValueObject<iri>.RegexString => RegexString;

    readonly Regex IStringWithRegexValueObject<iri>.Regex() => Regex();
#endif

    // public static iri Parse(string iri) => From(iri);

    // #if NET70_OR_GREATER
    //     [GeneratedRegex(RegexString, Compiled | IgnoreCase | Multiline | Singleline)]
    //     public static partial Regex Regex();

    //     // static iri IUriConvertible<iri>.FromUri(string s) => From(s);
    //     // static iri IUriConvertible<iri>.FromUri(Uri iri) => From(urn.ToString());
    // #else
    //     public static Regex Regex() => new(RegexString, Compiled | IgnoreCase | Multiline | Singleline);
    // #endif
    // public iri(string uriString) : base(uriString) { }
    public iri(Uri iri)
        : this(iri.ToString()) { }

    // public static iri Parse(string s) => From(s) with { OriginalString = s };
    public static iri Parse(string s, IFormatProvider? formatProvider = null) =>
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
        if (!Uri.TryCreate(value, RelativeOrAbsolute, out _))
        {
            return Validation.Invalid("The value is not a valid URI.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? uriString, UriKind uriKind, out iri iri)
    {
        try
        {
            if (IsNullOrEmpty(uriString))
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
        catch(Exception e) when (e is ValueObjectValidationException or ArgumentNullException or FormatException or OverflowException or ArgumentException or InvalidCastException or InvalidOperationException) { /* ignore it */ }

        iri = Empty;
        return false;
    }

    public readonly Uri Uri => this!;

    public static iri FromUri(string s) => From(s) with { OriginalString = s };

    public static iri FromUri(Uri iri) => From(iri) with { OriginalString = iri.ToString() };

    public static iri From(string s) =>
        Validate(s) == Validation.Ok ? new iri(s) with { OriginalString = s } : Empty;

    public static iri From(Uri iri) => new(iri);

    public static implicit operator System.Uri(iri i) =>
        Uri.TryCreate(i.BaseToString(), RelativeOrAbsolute, out var uri)
            ? uri
            : new(EmptyStringValue);

    public static implicit operator iri(string s) => From(s) with { OriginalString = s };

    public static implicit operator string(iri iri) => iri.ToString();

    public static bool operator ==(iri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) == 0;

    public static bool operator !=(iri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) != 0;

    public static bool operator <=(iri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) <= 0;

    public static bool operator >=(iri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) >= 0;

    public static bool operator <(iri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) < 0;

    public static bool operator >(iri? left, IResourceIdentifier right) =>
        left?.CompareTo(right) > 0;

    public readonly int CompareTo(IResourceIdentifier other) =>
        other is iri iri ? CompareTo(iri) : CompareTo(other.ToString());

    public override readonly int GetHashCode() => ToString().GetHashCode();

    public override readonly string ToString() => IsEmpty ? string.Empty : Uri.ToString();

    private readonly string BaseToString() => OriginalString;

    public static bool TryParse(string? s, IFormatProvider? formatProvider, out iri iri) =>
        TryParse(s, out iri);

    public static bool TryParse(string? s, out iri iri)
    {
        try
        {
            if (IsNullOrEmpty(s))
            {
                iri = Empty;
                return false;
            }
            if (Uri.TryCreate(s, RelativeOrAbsolute, out var suri))
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

    public readonly bool Equals(iri? other) => Equals(other.ToString());

    public readonly int CompareTo(string? other) =>
        Compare(ToString(), other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(object? obj) =>
        obj is iri iri
            ? CompareTo(iri)
            : obj is string str
                ? CompareTo(str)
                : throw new ArgumentException("Object is not a iri.");

    public readonly bool Equals(string? other) =>
        ToString().Equals(other, InvariantCultureIgnoreCase);

    public readonly int CompareTo(iri other) => CompareTo(other.ToString());

    public class EfCoreValueConverter
        : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<iri, string>
    {
        public EfCoreValueConverter()
            : base(v => v.ToString(), v => From(v)) { }
    }

    public class SystemTextJsonConverterAttribute : JsonConverterAttribute
    {
        public SystemTextJsonConverterAttribute()
            : base(typeof(SystemTextJsonConverter)) { }
    }

    public class SystemTextJsonConverter : JsonConverter<iri>
    {
        public override iri Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
        {
            return iri.From(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, iri value, Jso options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public class TypeConverter : ComponentModel.TypeConverter
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
                return From(stringValue);
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
            if (value is iri idValue)
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

#if NETSTANDARD2_0_OR_GREATER
public static class IriEfCoreExtensions
{
    public static void ConfigureIri<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, iri>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().ConfigureIri(propertyExpression);

    public static void ConfigureIri<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, iri>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder.Property(propertyExpression).HasConversion<iri.EfCoreValueConverter>();
}
#endif
