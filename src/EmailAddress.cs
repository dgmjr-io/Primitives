/*
 * EmailAddress copy.cs
 *
 *   Created: 2022-12-19-11:36:46
 *   Modified: 2022-12-19-11:36:46
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace System.Net.Mail;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Vogen;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif

[ValueObject(
    typeof(string),
    conversions: Conversions.EfCoreValueConverter
        | Conversions.SystemTextJson
        | Conversions.TypeConverter
)]
[StructLayout(LayoutKind.Auto)]
[EmailAddress.JConverter]
public partial record struct EmailAddress
    : IStringWithRegexValueObject<EmailAddress>,
        IComparable<EmailAddress>,
        IComparable,
        IEquatable<EmailAddress>,
        IFormattable
{
    /// <summary>
    /// The example value string.
    /// </summary>
    public const string ExampleValueString = "somewhere@overtherainbow.com";

    /// <summary>
    /// The empty value string.
    /// </summary>
    public const string EmptyValueString = "nobody@nowhere.com";

    /// <summary>
    /// The description.
    /// </summary>
    public const string Description = "an email address in the form of *user@domain.ext*";

    public const string UriPrefix = "mailto:";
    public const string UriPattern = $"{UriPrefix}{{0}}";

    public Uri Uri => IsEmpty ? null! : new(Format(UriPrefix, ToString()));

    public string OriginalString { get; set; }

#if NET6_0_OR_GREATER
    /// <summary>
    /// Gets the description.
    /// </summary>
    static string IStringWithRegexValueObject<EmailAddress>.Description => Description;

    /// <summary>
    /// Gets the example value.
    /// </summary>
    static EmailAddress IStringWithRegexValueObject<EmailAddress>.ExampleValue =>
        From(ExampleValueString);

    /// <summary>
    /// Gets the regex string.
    /// </summary>
    static string IStringWithRegexValueObject<EmailAddress>.RegexString => RegexString;
#else
    REx IStringWithRegexValueObject<EmailAddress>.Regex() => Regex();

    string IStringWithRegexValueObject<EmailAddress>.RegexString => RegexString;
    string IStringWithRegexValueObject<EmailAddress>.Description => Description;
    EmailAddress IStringWithRegexValueObject<EmailAddress>.ExampleValue => From(ExampleValueString);
#endif

    /// <summary>
    /// Gets a value indicating whether is empty.
    /// </summary>
    public bool IsEmpty => Value == Empty.Value;

    /// <summary>
    /// Gets the empty.
    /// </summary>
    public static EmailAddress Empty =>
        From(EmptyValueString) with
        {
            OriginalString = EmptyValueString
        };

    /// <summary>
    /// The regex string.
    /// </summary>
    public const string RegexString =
        @"^(?<Username>[\w\-_\.]+)@(?<Domain>[\w\-_\.]+)\.(?<Tld>[\w\-_\.]+)$";

#if NET7_0_OR_GREATER
    /// <summary>
    /// Regexes the <see cref="REx"/>.
    /// </summary>
    /// <returns>A REx.</returns>
    [GeneratedRegex(RegexString)]
    public static partial REx Regex();
#else
    public static REx Regex() => new(RegexString, Compiled);
#endif

    public static EmailAddress FromUri(string s) =>
        s.IsNullOrEmpty()
            ? throw new ArgumentNullException(
                nameof(s),
                "Cannot convert a null or empty string to an email address"
            )
            : From(s.Remove(0, UriPrefix.Length)) with
            {
                OriginalString = s.Remove(0, UriPrefix.Length)
            };

    public static EmailAddress FromUri(Uri u) => FromUri(u.ToString());

    /// <summary>
    /// Validates the <see langword="string"/> <paramref name="s"/> to see if
    /// it's a valid <see cref="EmailAddress"/>
    /// </summary>
    /// <param name="s">The <see langword="string"/> to validate.</param>
    /// <returns><see cref="Validation.Ok"/> if the validation was successful,
    ///     <see cref="Validation.Invalid(string)"/> otherwise.</returns>
    public static Validation Validate(string? s) =>
        s is null
            ? Validation.Invalid("Email address cannot be null.")
            : s.Length == 0
                ? Validation.Invalid("Email address cannot be empty.")
                : !Regex().IsMatch(s)
                    ? Validation.Invalid("Email address is not valid.")
                    : Validation.Ok;

    public static bool operator !=(EmailAddress? a, EmailAddress? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) == 0;

    public static bool operator ==(EmailAddress? a, EmailAddress? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) != 0;

    public static bool operator <(EmailAddress? a, EmailAddress? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) < 0;

    public static bool operator >(EmailAddress? a, EmailAddress? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) > 0;

    public static bool operator <=(EmailAddress? a, EmailAddress? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) <= 0;

    public static bool operator >=(EmailAddress? a, EmailAddress? b) =>
        a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) >= 0;

    /// <summary>
    /// Returns <inheritdoc cref="ToString()" path="/returns"/>
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>the string representation of the <see cref="EmailAddress"/>.
    ///     </returns>
    public string ToString(string? format, IFormatProvider? formatProvider) => ToString();

    /// <summary>
    /// Returns <inheritdoc cref="ToString()" path="/returns"/>
    /// </summary>
    /// <returns>the string representation of the <see cref="EmailAddress"/>.
    ///     </returns>
    public override string ToString() => IsEmpty ? string.Empty : Value;

    /// <summary>
    /// Returns
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>a negative value if the current value is less than
    ///     <paramref name="obj"/>, 0 if they're equal, and a positive value if
    ///     it's greater than <paramref name="obj"/>..</returns>
    public int CompareTo(object? obj) =>
        string.CompareOrdinal(Value, obj?.ToString() ?? string.Empty);

    /// <summary>
    /// Parses the <see cref="EmailAddress"/>.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>An EmailAddress.</returns>
    public static EmailAddress Parse(string? s, IFormatProvider? formatProvider = null) =>
        From(s) with
        {
            OriginalString = s
        };

    /// <summary>
    /// Try parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="email">The email.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse(string? s, IFormatProvider? formatProvider, out EmailAddress email)
    {
        try
        {
            return (email = From(s) with { OriginalString = s }) != Empty;
        }
        catch (Vogen.ValueObjectValidationException)
        {
            email = Empty;
            return false;
        }
    }

    /// <summary>
    /// Try parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="email">The email.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse(string? s, out EmailAddress email) => TryParse(s, null, out email);

    /// <summary>
    /// Validates the <see cref="Validation"/>.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <returns>A Validation.</returns>
    public static Validation Validate(MailAddress s) => Validate(s.Address);

    /// <summary>
    /// Parses the <see cref="EmailAddress"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>An EmailAddress.</returns>
    public static EmailAddress Parse(string value) => From(value);

    public static implicit operator EmailAddress?(string? s)
    {
        try
        {
            return From(s);
        }
        catch
        {
            return Empty;
        }
    }

    public static implicit operator string?(EmailAddress? addr) =>
        addr.HasValue ? addr.Value.Value : string.Empty;

    public int CompareTo(EmailAddress? other) => CompareTo(other?.Value ?? string.Empty);

    // public static EmailAddress From(string s) => Validate(s) == Validation.Ok ? new() { Value = s } : Empty;

    public class JConverterAttribute : System.Text.Json.Serialization.JsonConverterAttribute
    {
        public JConverterAttribute() : base(typeof(EmailAddressSystemTextJsonConverter)) { }
    }
}

/// <summary>
/// The email address ef core extensions.
/// </summary>
public static class EmailAddressEfCoreExtensions
{
    /// <summary>
    /// Configures the email address.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="modelBuilder">The model builder.</param>
    /// <param name="propertyExpression">The property expression.</param>
    public static void ConfigureEmailAddress<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, EmailAddress>> propertyExpression
    ) where TEntity : class =>
        modelBuilder.Entity<TEntity>().ConfigureEmailAddress(propertyExpression);

    /// <summary>
    /// Configures the email address.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entityBuilder">The entity builder.</param>
    /// <param name="propertyExpression">The property expression.</param>
    public static void ConfigureEmailAddress<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, EmailAddress>> propertyExpression
    ) where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion<EmailAddress.EfCoreValueConverter>();
}

//"^\+((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))$"
