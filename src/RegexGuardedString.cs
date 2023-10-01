#if NET7_0_OR_GREATER
using System;
using System.ComponentModel;
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

public delegate REx RegexProvider();

public interface IRegexProvider
{
    public static abstract RegexProvider Regex { get; }
    public const RegexOptions DefaultRegexOptions =
        Compiled | CultureInvariant | IgnoreCase | IgnorePatternWhitespace;
}

public interface IRegexGuardedString<TSelf>
{
    public static abstract REx Regex();

    string Value { get; }
}

public interface IRegexGuardedString<TSelf, TRegexProvider> : IRegexGuardedString<TRegexProvider>
    where TSelf : RegexGuardedString<TSelf>
    where TRegexProvider : IRegexProvider
{
    public static new REx Regex() => TRegexProvider.Regex();
}

// [RegexGuardedString.JConverter]
public class RegexGuardedString<TSelf, TRegexProvider>
    : RegexGuardedString<TSelf>,
        IRegexGuardedString<TSelf, TRegexProvider>
    where TSelf : RegexGuardedString<TSelf, TRegexProvider>
    where TRegexProvider : IRegexProvider
{
    public static new REx Regex() => TRegexProvider.Regex();

    public RegexGuardedString(string value)
        : base(value, TRegexProvider.Regex()) { }

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

public class RegexGuardedString<TSelf> : IRegexGuardedString<TSelf>
    where TSelf : RegexGuardedString<TSelf>
{
    protected RegexGuardedString(string value, REx regex)
    {
        _regex = regex;
        Value = value;
    }

    protected RegexGuardedString(
        string value,
        string regex,
        RegexOptions options = IRegexProvider.DefaultRegexOptions
    )
        : this(value, new(regex, options)) { }

    private static REx _regex;

    public static REx Regex() => _regex;

    public static implicit operator string(RegexGuardedString<TSelf> value)
    {
        return value.Value;
    }

    public static implicit operator RegexGuardedString<TSelf>?(string value)
    {
        return (TSelf?)Activator.CreateInstance(typeof(TSelf), value);
    }

    public override string ToString()
    {
        return _value;
    }

    private string _value;
    public virtual string Value
    {
        get => _value;
        private set
        {
            if (IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty.");
            }

            if (!Regex().IsMatch(value))
            {
                throw new ArgumentException(
                    $"Value \"{value}\" does not match the specified pattern: {Regex()}"
                );
            }

            _value = value;
        }
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
