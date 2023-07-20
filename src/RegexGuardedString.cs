/* 
 * RegexGuardedString.cs
 * 
 *   Created: 2023-06-28-07:41:53
 *   Modified: 2023-06-28-07:41:53
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using Microsoft.OpenApi.Expressions;

namespace System;

public interface IRegexGuardedString<TSelf>
    where TSelf : RegexGuardedString<TSelf>
{
#if NET7_0_OR_GREATER
    public static abstract REx Regex { get; set; }
#endif
}

public abstract class RegexGuardedString<TSelf> : IRegexGuardedString<TSelf>
    where TSelf : RegexGuardedString<TSelf>
{
    private string _value;

#if NET7_0_OR_GREATER
    private static REx _regex => Regex;
    public static REx Regex { get; set; }
#else
    private REx _regex => Regex;
    public REx Regex { get; init; }
#endif


    protected RegexGuardedString(string value, string pattern, RegexOptions options = Compiled | CultureInvariant | IgnoreCase | IgnorePatternWhitespace)
    {
        if (IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));
        }

        if (IsNullOrEmpty(pattern))
        {
            throw new ArgumentException("Pattern cannot be null or empty.", nameof(pattern));
        }

        _value = value;
        Regex = new(pattern, options);

        if (!Regex.IsMatch(_value))
        {
            throw new ArgumentException($"Value \"{value}\" does not match the specified pattern: {pattern}", nameof(value));
        }
    }

    public string Value
    {
        get => _value;
        set
        {
            if (IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty.");
            }

            if (!_regex.IsMatch(value))
            {
                throw new ArgumentException($"Value \"{value}\" does not match the specified pattern: {_regex}");
            }

            _value = value;
        }
    }

    public override string ToString()
    {
        return _value;
    }

    public static implicit operator string(RegexGuardedString<TSelf> value)
    {
        return value._value;
    }

#if NET7_0_OR_GREATER
    public static implicit operator RegexGuardedString<TSelf>(string value)
    {
        return (TSelf)Activator.CreateInstance(typeof(TSelf), value, RegexGuardedString<TSelf>.Regex.ToString(), RegexGuardedString<TSelf>.Regex.Options);
    }
#endif
}
