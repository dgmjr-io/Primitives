namespace System;

#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif
public interface IStringWithRegexValueObject<TSelf>
    : IComparable<TSelf>,
      IComparable,
      IEquatable<TSelf>,
      IHaveAUri
#if NET7_0_OR_GREATER
    ,
      IParsable<TSelf>,
      IUriConvertible<TSelf>
#endif
      where TSelf : IStringWithRegexValueObject<TSelf>
{
    /// <summary>
    /// The value of the value object as a string.  Will be <see langword="null" /> or <see cref="string.Empty" /> iff <see cref="IsEmpty" /> == <see langword="true" />
    /// </summary>
    string Value {
        get;
    }

    /// <summary>
    /// <see langword="true" /> if the value object is empty, <see langword="false" /> otherwise
    /// </summary>
    bool IsEmpty {
        get;
    }

#if NET6_0_OR_GREATER
    /// <summary>
    /// Returns <inheritdoc cref="Regex" path="/returns" />
    /// </summary>
    /// <returns>a <see cref="Regex" /> containing the regular expression, which can be used to parse/validate string versions of the value object</returns>
    public abstract static Regex Regex();

    /// <summary>
    /// Returns <inheritdoc cref="RegexString" path="/returns" />
    /// </summary>
    /// <returns>the regular expression (as a string), which can be used to parse/validate string versions of the value object</returns>
    public abstract static string RegexString {
        get;
    }

    /// <summary>
    /// Returns <inheritdoc cref="Description" path="/returns" />
    /// </summary>
    /// <returns>a description of the value object type</returns>
    public abstract static string Description {
        get;
    }

    /// <summary>
    /// Returns <inheritdoc cref="Parse" path="/returns" />
    /// </summary>
    /// <returns>an instance of <typeparamref name="TSelf" /> iff the <see langword="string" /> <paramref name="value" /> parses properly</returns>
    /// <exception cref="global::Vogen.ValueObjectValidationException">thrown if the value object fails validation</exception>
    /// <exception cref="global::System.Exception">thrown if parsing the <see langword="string" /> <paramref name="value" /> failed for some other reason</exception>
    public abstract static TSelf Parse(string value);

    /// <summary>
    /// Generates <inheritdoc cref="Parse" path="/returns" />
    /// </summary>
    /// <returns>an instance of <typeparamref name="TSelf" /> iff the <see langword="string" /> <paramref name="value" /> parses properly</returns>
    /// <exception cref="global::Vogen.ValueObjectValidationException">thrown if the value object fails validation</exception>
    /// <exception cref="global::System.Exception">thrown if parsing the <see langword="string" /> <paramref name="value" /> failed for some other reason</exception>
    public abstract static TSelf From(string value);

    /// <summary>
    /// Returns <inheritdoc cref="ExampleValue" path="/returns" />
    /// </summary>
    /// <returns>an example (archetypal) value for the value object</returns>
    public abstract static TSelf ExampleValue {
        get;
    }
    public static abstract TSelf Empty {
        get;
    }
    // public abstract static Validation Validate(string value);
#else
    /// <summary>
    /// Returns <inheritdoc cref="RegexString" path="/returns" />
    /// </summary>
    /// <returns>the regular expression (as a string), which can be used to parse/validate string versions of the value object</returns>
    string RegexString {
        get;
    }

    /// <summary>
    /// Returns <inheritdoc cref="Description" path="/returns" />
    /// </summary>
    /// <returns>a description of the value object type</returns>
    string Description {
        get;
    }

    /// <summary>
    /// Returns <inheritdoc cref="ExampleValue" path="/returns" />
    /// </summary>
    /// <returns>an example (archetypal) value for the value object</returns>
    TSelf ExampleValue {
        get;
    }

    /// <summary>
    /// Returns <inheritdoc cref="Regex" path="/returns" />
    /// </summary>
    /// <returns>a <see cref="Regex" /> containing the regular expression, which can be used to parse/validate string versions of the value object</returns>
    Regex Regex();
#endif

    string OriginalString {
        get;
    }
}
