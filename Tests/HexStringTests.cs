/*
 * HexStringTests.cs
 *
 *   Created: 2023-09-03-12:33:55
 *   Modified: 2023-09-03-12:33:55
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Primitives.Tests;

public static class HexStringTests
{
    [Theory]
    [InlineData("0123456789abcdef")]
    [InlineData("ffffaabb")]
    [InlineData("FFffAAbb")]
    public static void Valid_Hex_String_Is_Valid(string validHexString)
    {
        var hexString = new HexString(validHexString);
        hexString.Value.Should().Be(validHexString);
    }

    [Theory]
    [InlineData("fcku!!!")]
    [InlineData("go the fuck away!")]
    [InlineData("NOW")]
    public static void Invalid_Hex_String_Is_Invalid(string invalidHexString)
    {
        var hexStringCtor = () => new HexString(invalidHexString);
        hexStringCtor.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("abcDEF09", "DEFab678")]
    public static void Hex_String_Can_Be_Changed_To_Another_Valid_Hex_String(string original, string @new)
    {
        var hexString = new HexString(original);
        hexString = @new;
        hexString.Value.Should().Be(@new);
    }
}
