#if NET7_0_OR_GREATER
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

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Expressions;
using static System.Activator;
namespace System;

public interface IRegexGuardedString
{
    public static abstract RegexOptions RegexOptions { get; }
    public static abstract REx Regex();

    string Value { get; set; }
}
public interface IRegexGuardedString<TSelf> : IRegexGuardedString
    where TSelf : RegexGuardedString<TSelf>
{
}

// [RegexGuardedString.JConverter]
public class RegexGuardedString : IRegexGuardedString
{
    private string _value;
    private const RegexOptions _defaultDRegexOptions = Compiled | CultureInvariant | IgnoreCase | IgnorePatternWhitespace;

    public static RegexOptions RegexOptions { get; set; }
    private static REx _regex = null!;
    public static REx Regex() => _regex;

    public RegexGuardedString(string value, string pattern, RegexOptions options = _defaultDRegexOptions)
    {
        if (IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));
        }

        if (IsNullOrEmpty(pattern))
        {
            throw new ArgumentException("Pattern cannot be null or empty.", nameof(pattern));
        }

        RegexOptions = options;
        _regex = new(pattern, RegexOptions);

        Value = value;
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

            if (!Regex().IsMatch(value))
            {
                throw new ArgumentException($"Value \"{value}\" does not match the specified pattern: {Regex()}");
            }

            _value = value;
        }
    }

    public override string ToString()
    {
        return _value;
    }

    //     public class JConverterAttribute : System.Text.Json.Serialization.JsonConverterAttribute
    //     {
    //         public JConverterAttribute() : base(typeof(JConverter)) { }
    //     }

    //     public class JConverter : System.Text.Json.Serialization.JsonConverter<RegexGuardedString>
    //     {
    //         public override RegexGuardedString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions jsonSerializerOptions)
    //         {
    //             string value = default!;
    //             string pattern = default!;
    //             RegexOptions options = None;

    //             if (reader.TokenType != JsonTokenType.StartObject)
    //             {
    //                 throw new JsonException($"Could not convert the value at index {reader.TokenStartIndex} to an object of type {nameof(RegexGuardedString)}; unexpected token: {reader.TokenType}");
    //             }

    //             while (reader.Read())
    //             {
    //                 if (reader.TokenType == JsonTokenType.EndObject)
    //                 {
    //                     return new(value, pattern, options);
    //                 }

    //                 if (reader.TokenType != JsonTokenType.PropertyName)
    //                 {
    //                     throw new JsonException();
    //                 }

    //                 string propertyName = reader.GetString();
    //                 reader.Read();

    //                 switch (propertyName)
    //                 {
    //                     case nameof(value):
    //                         value = reader.GetString();
    //                         break;
    //                     case nameof(options):
    //                         options = (RegexOptions)reader.GetInt32();
    //                         break;
    //                     case nameof(pattern):
    //                         pattern = reader.GetString();
    //                         break;
    //                     default:
    //                         throw new JsonException($"Unknown property: {propertyName}");
    //                 }
    //             }
    //             throw new JsonException($"Could not convert the value at index {reader.TokenStartIndex} to an object of type {nameof(RegexGuardedString)}: unknown error.");
    //         }

    //         public override void Write(Utf8JsonWriter writer, RegexGuardedString value, JsonSerializerOptions options)
    //         {
    //             writer.WriteStartObject();
    //             writer.WriteString("value", value.Value);
    // #if NET7_0_OR_GREATER
    //             writer.WriteString("pattern", value.Regex().ToString());
    //             writer.WriteNumber("options", (int)value.RegexOptions);
    // #else
    //             writer.WriteString("pattern", Regex().ToString());
    //             writer.WriteNumber("options", Regex().Options);
    // #endif
    //             writer.WriteEndObject();
    //         }
    //     }
}

public class RegexGuardedString<TSelf> : RegexGuardedString, IRegexGuardedString<TSelf>
    where TSelf : RegexGuardedString<TSelf>
{
    protected RegexGuardedString(string value) : base(value, Regex().ToString(), Regex().Options) { }

    public static implicit operator string(RegexGuardedString<TSelf> value)
    {
        return value.Value;
    }

    public static implicit operator RegexGuardedString<TSelf>?(string value)
    {
        return (TSelf?)Activator.CreateInstance(typeof(TSelf), value);
    }


    //     public class JConverterAttribute : System.Text.Json.Serialization.JsonConverterAttribute
    //     {
    //         public JConverterAttribute() : base(typeof(JConverter)) { }
    //     }

    //     public class JConverter : System.Text.Json.Serialization.JsonConverter<TSelf>
    //     {
    //         public override TSelf Read(ref Text.Json.Utf8JsonReader reader, Type typeToConvert, Text.Json.JsonSerializerOptions options)
    //         {
    //             string value = default!;
    //             string pattern = default!;
    //             RegexOptions options = None;

    //             if (reader.TokenType is not JsonTokenType.StartObject or JsonTokenType.String)
    //             {
    //                 throw new JsonException($"Could not convert the value at index {reader.TokenStartIndex} to an object of type {nameof(RegexGuardedString)}; unexpected token: {reader.TokenType}");
    //             }

    //             if (reader.TokenType is JsonTokenType.String)
    //             {
    //                 value = reader.GetString();
    //                 return (TSelf)CreateInstance(typeof(TSelf), value);
    //             }

    //             while (reader.Read())
    //             {
    //                 if (reader.TokenType == JsonTokenType.EndObject)
    //                 {
    //                     if ((pattern is null || pattern == RegexGuardedString<TSelf>.Regex().ToString()) && value is not null)
    //                     {
    //                         return (TSelf)CreateInstance(typeof(TSelf), value);
    //                     }
    //                     else
    //                     {
    //                         throw new JsonException($"Could not convert the value at index {reader.TokenStartIndex} to an object of type {typeof(TSelf).Name}. A pattern was speficied (\"{pattern}\") but it did not match the expected pattern: \"{new RegexGuardedString<TSelf>().Regex()}\"");
    //                     }
    //                 }

    //                 if (reader.TokenType != JsonTokenType.PropertyName)
    //                 {
    //                     throw new JsonException($"Could not convert the value at index {reader.TokenStartIndex} to an object of type {typeof(TSelf).Name}; unexpected token: {reader.TokenType}");
    //                 }

    //                 string propertyName = reader.GetString();
    //                 reader.Read();

    //                 switch (propertyName)
    //                 {
    //                     case nameof(value):
    //                         value = reader.GetString();
    //                         break;
    //                     case nameof(options):
    //                         options = (RegexOptions)reader.GetInt32();
    //                         break;
    //                     case nameof(pattern):
    //                         pattern = reader.GetString();
    //                         break;
    //                     default:
    //                         throw new JsonException($"Unknown property: {propertyName}");
    //                 }
    //             }
    //             throw new JsonException($"Could not convert the value at index {reader.TokenStartIndex} to an object of type {nameof(RegexGuardedString<TSelf>)}.");
    //         }

    //         public override void Write(Utf8JsonWriter writer, TSelf value, JsonSerializerOptions options)
    //         {
    //             writer.WriteStringValue(value.Value);
    //         }
}

#endif
