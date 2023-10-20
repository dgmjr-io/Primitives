/*
 * uri.cs
 *
 *   Created: 2022-12-20-04:48:32
 *   Modified: 2022-12-20-04:48:32
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;

/// <summary>Provides extension methods for working with URIs</summary>
public static class TryCreateUriExtensions
{
    /// <summary>Converts a string to a nullable Uri object</summary>
    public static uri? ToUri(this string uriString) => uriString.CreateUri(true);

    /// <summary>Converts a string to a nullable Uri object, with a default fallback Uri provided as a string</summary>
    public static uri? ToUri(this string uriString, string defaultFallbackUri) =>
    uri.From(string.Format(defaultFallbackUri, uriString));

    /// <summary>Converts a string to a nullable Uri object, with a default fallback Uri provided as a Uri object</summary>
    public static uri? ToUri(this string uriString, Uri defaultFallbackUri) =>
    uri.From(uriString.CreateUri(defaultFallbackUri.ToString()).ToString());

    /// <summary>Tries to create a Uri object from a string and returns true if successful, false otherwise</summary>
    public static bool TryCreateUri(this string uriString, out uri? uri)
    {
        try
        {
            uri = uriString.CreateUri(true);
            return true;
        }
        catch
        {
            uri = null;
            return false;
        }
    }

    /// <summary>Creates a Uri object from a string, with an option to throw an exception on invalid URIs</summary>
    public static uri? CreateUri(this string uriString, bool throwOnInvalidUri = true) =>
    !IsNullOrEmpty(uriString)
    ? System.uri.TryCreate(uriString, Absolute, out var uri)
    ? uri
    : throwOnInvalidUri
    ? throw new ArgumentException(
        "The provided string is not a valid URI.",
        nameof(uriString)
    )
    : null as uri?
    : throw new ArgumentException(
        "The provided URI string is null or empty.",
        nameof(uriString)
    );

    /// <summary>Creates a Uri object from a string, with a default fallback Uri provided as a string</summary>
    public static uri CreateUri(this string uriString, string defaultFallbackUri) =>
    uriString.TryCreateUri(out var uri) && uri.HasValue
    ? uri.Value
    : Format(defaultFallbackUri, uriString).CreateUri()!.Value;

    /// <summary>Creates a Uri object from a string, with a default fallback Uri provided as a Uri object</summary>
    public static uri CreateUri(this string uriString, Uri? defaultFallbackUri) =>
    !IsNullOrEmpty(defaultFallbackUri.ToString())
    ? System.uri.TryCreate(uriString, Absolute, out var uri)
    ? uri
    : System.uri.From(string.Format(defaultFallbackUri.ToString(), uriString))
    : throw new ArgumentException(
        "The provided default fallback URI is null or empty.",
        nameof(defaultFallbackUri)
    );
}
