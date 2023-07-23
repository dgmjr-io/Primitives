namespace System;
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
#else
    string RegexString { get; }
    string Description { get; }
    TSelf ExampleValue { get; }
    REx Regex();
#endif
}
