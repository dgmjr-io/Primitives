namespace System;
#if !NETSTANDARD2_0_OR_GREATER
using Validation = global::Validation;
#endif
public interface IStringWithRegexValueObject<TSelf> : IComparable<TSelf>, IComparable, IEquatable<TSelf>, IHaveAUri
#if NET7_0_OR_GREATER
    , IParsable<TSelf>, IUriConvertible<TSelf>
#endif
    where TSelf : IStringWithRegexValueObject<TSelf>
{
    string Value { get; }

    bool IsEmpty { get; }

#if NET6_0_OR_GREATER
    public abstract static REx Regex();
    public abstract static string RegexString { get; }
    public abstract static string Description { get; }
    public abstract static TSelf Parse(string value);
    public abstract static TSelf From(string value);
    public abstract static TSelf ExampleValue { get; }
    public abstract static TSelf Empty { get; }
    // public abstract static Validation Validate(string value);
#else
    string RegexString { get; }
    string Description { get; }
    TSelf ExampleValue { get; }
    REx Regex();
#endif
}
