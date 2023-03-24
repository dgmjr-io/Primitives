namespace System;
public interface IStringWithRegexValueObject<TSelf> : IComparable<TSelf>, IComparable, IEquatable<TSelf>
#if NET7_0_OR_GREATER
    , IParsable<TSelf>
#endif
    where TSelf : IStringWithRegexValueObject<TSelf>
{
    string Value { get; }

    bool IsEmpty { get; }

#if NET6_0_OR_GREATER
    abstract static REx Regex();
    abstract static string RegexString { get; }
    abstract static string Description { get; }
    abstract static TSelf Parse(string value);
    abstract static TSelf From(string value);
    abstract static TSelf ExampleValue { get; }
    abstract static TSelf Empty { get; }
#else
    string RegexString { get; }
    string Description { get; }
    TSelf ExampleValue { get; }
    REx Regex();
#endif
}
