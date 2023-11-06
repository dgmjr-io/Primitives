namespace System;

public interface IStringWithRegexValueObject<TSelf> : IRegexValueObject<TSelf>
    where TSelf : IStringWithRegexValueObject<TSelf>
{ }
