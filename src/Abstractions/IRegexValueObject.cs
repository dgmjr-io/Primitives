namespace System;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif
public interface IRegexValueObject<TSelf>
    : IComparable<TSelf>,
        IComparable,
        IEquatable<TSelf>,
        IHaveAUri
#if NET7_0_OR_GREATER
        ,
        IParsable<TSelf>,
        IUriConvertible<TSelf>
#endif
    where TSelf : IRegexValueObject<TSelf>
{
    /// <summary>Gets The value of the value object as a string.  Will be <see langword="null" /> or <see cref="string.Empty" /> iff <see cref="IsEmpty" /> == <see langword="true" /></summary>
    string Value { get; }

    /// <summary><see langword="true" /> if the value object is empty, <see langword="false" /> otherwise</summary>
    /// <value><see langword="true" /> if the value object is empty, <see langword="false" /> otherwise</value>
    bool IsEmpty { get; }

#if NET6_0_OR_GREATER
    /// <summary>Gets <inheritdoc cref="Regex" path="/returns" /></summary>
    /// <returns>a <see cref="Regex" /> containing the regular expression, which can be used to parse/validate string versions of the value object</returns>
    public abstract static Regex Regex();

    /// <summary>Gets <inheritdoc cref="RegexString" path="/returns" /></summary>
    /// <returns>the regular expression (as a string), which can be used to parse/validate string versions of the value object</returns>
    public abstract static string RegexString { get; }

    /// <summary>Gets <inheritdoc cref="Description" path="/returns" /></summary>
    /// <returns>a description of the value object type</returns>
    public abstract static string Description { get; }

    /// <summary>Parses the <paramref name="value" /> into <inheritdoc cref="Parse" path="/returns" /></summary>
    /// <returns>an instance of <typeparamref name="TSelf" /> iff the <see langword="string" /> <paramref name="value" /> parses properly</returns>
    /// <exception cref="global::Vogen.ValueObjectValidationException">thrown if the value object fails validation</exception>
    /// <exception cref="global::System.Exception">thrown if parsing the <see langword="string" /> <paramref name="value" /> failed for some other reason</exception>
    public abstract static TSelf Parse(string value);

    /// <summary>Generates <inheritdoc cref="Parse" path="/returns" /></summary>
    /// <returns>an instance of <typeparamref name="TSelf" /> iff the <see langword="string" /> <paramref name="value" /> parses properly</returns>
    /// <exception cref="global::Vogen.ValueObjectValidationException">thrown if the value object fails validation</exception>
    /// <exception cref="global::System.Exception">thrown if parsing the <see langword="string" /> <paramref name="value" /> failed for some other reason</exception>
    public abstract static TSelf From(string value);

    /// <summary>Gets <inheritdoc cref="ExampleValue" path="/returns" /></summary>
    /// <returns>an example (archetypal) value for the value object</returns>
    public abstract static TSelf ExampleValue { get; }

    /// <summary>Gets the empty representation of this value object</summary>
    public static abstract TSelf Empty { get; }

    // public abstract static Validation Validate(string value);
    /// <summary>Gets the "external documentation" for the value object</summary>
    public static ExternalDocsTuple? ExternalDocumentation => null;
#else
    /// <summary>Gets <inheritdoc cref="RegexString" path="/returns" /></summary>
    /// <returns>the regular expression (as a string), which can be used to parse/validate string versions of the value object</returns>
    string RegexString { get; }

    /// <summary>Gets <inheritdoc cref="Description" path="/returns" /></summary>
    /// <returns>a description of the value object type</returns>
    string Description { get; }

    /// <summary>Gets <inheritdoc cref="ExampleValue" path="/returns" /></summary>
    /// <returns>an example (archetypal) value for the value object</returns>
    TSelf ExampleValue { get; }

    /// <summary>Returns <inheritdoc cref="Regex" path="/returns" /></summary>
    /// <returns>a <see cref="Regex" /> containing the regular expression, which can be used to parse/validate string versions of the value object</returns>
    Regex Regex();
#endif

    /// <summary>Gets the original string that was parsed to create the value object</summary>
    string OriginalString { get; }
}
