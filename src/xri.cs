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

using Vogen;

using static System.Text.RegularExpressions.RegexOptions;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif

/// <summary>Represents an "eXtensible resource identifier" (XRI)</summary>
[RegexDto(xri._RegexString, RegexOptions: uri._RegexOptions)]
[StructLayout(LayoutKind.Auto)]
public readonly partial record struct xri
    : IRegexValueObject<xri>,
        IResourceIdentifierWithQueryAndFragment
#if NET7_0_OR_GREATER
        ,
        IUriConvertible<xri>
#endif
{
    public const string Description = "an eXtensible resource locator (xri)";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string ExampleStringValue = "xri://@DGMJR-IO/=david.g.moore.jr";

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Regex)]
#endif
    public const string _RegexString =
        @"^(?<Scheme:string?>xri):(?<DoubleSlashes:string?>\/\/)?(?<Path:string?>[^\/?#]+(?:\/[^\/?#]+))*(?:\?(?<Query:string?>(?:[^#]*)))?(?:#(?<Fragment:string?>(?:.*)))?$";

    public static ExternalDocsTuple ExternalDocs =>
        (
            "Extensible Resource Identifier (XRI)",
            new Uri("https://en.wikipedia.org/wiki/Extensible_Resource_Identifier")
        );

#if NET7_0_OR_GREATER
    [StringSyntax(StringSyntaxAttribute.Uri)]
#endif
    public const string EmptyStringValue = "xri://null";
    public static xri Empty => From(EmptyStringValue);
    public readonly bool IsEmpty => base.ToString() == EmptyStringValue;

    public readonly string PathAndQuery =>
        $"{Path}{(Path.EndsWith("/") ? "" : "/")}{(!IsNullOrEmpty(Query) ? $" ?{Query})" : "")}{(!IsNullOrEmpty(Fragment) ? $"#{Fragment}" : "")}";

    public readonly string Value { get; init; }
#if NET6_0_OR_GREATER
    static string IRegexValueObject<xri>.Description => Description;
    static string IRegexValueObject<xri>.RegexString => RegexString;
    static xri IRegexValueObject<xri>.ExampleValue => ExampleStringValue;
#else
    readonly string IRegexValueObject<xri>.Description => Description;
    readonly xri IRegexValueObject<xri>.ExampleValue => ExampleStringValue;
    readonly string IRegexValueObject<xri>.RegexString => RegexString;

    readonly Regex IRegexValueObject<xri>.Regex() => Regex();
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
        if (IsNullOrEmpty(urlString))
        {
            xri = Empty;
            return false;
        }
        if (
            Validate(urlString) == Validation.Ok
            && Uri.TryCreate(urlString, uriKind ?? Absolute, out var surl)
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
            if (IsNullOrEmpty(s))
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
        catch (Exception e)
            when (e
                    is ValueObjectValidationException
                        or ArgumentNullException
                        or FormatException
                        or OverflowException
                        or ArgumentException
                        or InvalidCastException
                        or InvalidOperationException
            )
        { /* ignore it */
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

    public class JsonConverter : JsonConverter<xri>
    {
        public override xri Read(ref Utf8JsonReader reader, Type typeToConvert, Jso options) =>
            From(reader.GetString());

        public override void Write(Utf8JsonWriter writer, xri value, Jso options) =>
            writer.WriteStringValue(value.ToString());
    }

    public class SystemTextJsonConverter : JsonConverter<xri>
    {
        public override xri Read(ref Utf8JsonReader reader, type typeToConvert, Jso options)
        {
            return From(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, xri value, Jso options)
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
            return stringValue is not null
                ? xri.From(stringValue)
                : base.ConvertFrom(context, culture, value);
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
        ) =>
            value is xri idValue && destinationType == typeof(string)
                ? idValue.ToString()
                : base.ConvertTo(context, culture, value, destinationType);
    }
}
