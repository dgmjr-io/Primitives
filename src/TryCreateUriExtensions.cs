/*
 * uri.cs
 *
 *   Created: 2022-12-20-04:48:32
 *   Modified: 2022-12-20-04:48:32
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;

public static partial class TryCreateUriExtensions
{
    public static uri? ToUri(this string uriString) => uriString.CreateUri(true);

    public static uri? ToUri(this string uriString, string defaultFallbackUri) =>
        uri.From(uriString.CreateUri(defaultFallbackUri).ToString());

    public static uri? ToUri(this string uriString, Uri defaultFallbackUri) =>
        uri.From(uriString.CreateUri(defaultFallbackUri.ToString()).ToString());

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

    public static uri? CreateUri(this string uriString, bool throwOnInvalidUri = true) =>
        !string.IsNullOrEmpty(uriString)
            ? System.uri.TryCreate(uriString, UriKind.Absolute, out var uri)
                ? uri
                : throwOnInvalidUri
                    ? throw new ArgumentException(
                        "The provided string is not a valid URI.",
                        nameof(uriString)
                    )
                    : null
            : throw new ArgumentException(
                "The provided URI string is null or empty.",
                nameof(uriString)
            );

    public static uri CreateUri(this string uriString, Uri defaultFallbackUri) =>
        uriString.CreateUri(defaultFallbackUri.ToString());

    public static uri CreateUri(this string uriString, string defaultFallbackUri) =>
        !string.IsNullOrEmpty(defaultFallbackUri)
            ? System.uri.TryCreate(uriString, UriKind.Absolute, out var uri)
                ? uri
                : System.uri.From(string.Format(defaultFallbackUri, uriString))
            : throw new ArgumentException(
                "The provided default fallback URI is null or empty.",
                nameof(defaultFallbackUri)
            );
}
