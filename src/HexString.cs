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

public class HexString : RegexGuardedString<HexString>
{
    public const string HexChars = "^[0-9a-z]*$";

    public HexString(string? value = null) : base(value, HexChars, Compiled | IgnoreCase | Multiline | IgnorePatternWhitespace)
    {
    }

    public static implicit operator HexString(string value) => new(value);
    public static implicit operator string(HexString value) => value.Value;
}
