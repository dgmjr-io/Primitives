#if NET7_0_OR_GREATER
using System.Text.RegularExpressions;

/*
 * HexString.cs
 *
 *   Created: 2023-07-09-05:13:06
 *   Modified: 2023-07-09-05:13:07
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;

using static System.Text.RegularExpressions.RegexOptions;

public partial class HexString : RegexGuardedString<HexString, HexString>, IRegexProvider
{
    public const string HexChars = "^[0-9a-f]*$";

    static RegexProvider IRegexProvider.Regex => HexString.Regex;

#if NET7_0_OR_GREATER
    [GeneratedRegex(HexChars, Compiled | IgnoreCase | Multiline | IgnorePatternWhitespace)]
    public static new partial Regex Regex();
#else
    private static readonly Regex _regex = new (HexChars, Compiled | IgnoreCase | Multiline | IgnorePatternWhitespace);
    public static new Regex Regex() => _regex;
#endif

    public HexString(string? value = null)
        : base(value) { }

    public static implicit operator HexString(string value) => new(value);

    public static implicit operator string(HexString value) => value.Value;
}
#endif
