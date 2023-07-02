using System.Text.RegularExpressions;
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

namespace System;
using System.Text.RegularExpressions;


public class RegexGuardedString
{
    private string _value;
    private readonly Regex _regex;

    public RegexGuardedString(string value, string pattern)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        if (string.IsNullOrEmpty(pattern))
            throw new ArgumentException("Pattern cannot be null or empty.", nameof(pattern));

        _value = value;
        _regex = new Regex(pattern);

        if (!_regex.IsMatch(_value))
            throw new ArgumentException($"Value does not match the specified pattern: {pattern}", nameof(value));
    }

    public string Value
    {
        get => _value;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value cannot be null or empty.");

            if (!_regex.IsMatch(value))
                throw new ArgumentException($"Value does not match the specified pattern: {_regex.ToString()}");

            _value = value;
        }
    }

    public override string ToString()
    {
        return _value;
    }

    public static implicit operator string(RegexGuardedString value)
    {
        return value._value;
    }
}
