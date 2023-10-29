namespace Dgmjr.Abstractions;

public interface IResourceIdentifierWithAuthorityHostPortQueryAndFragment
    : IResourceIdentifierWithQueryAndFragment
{
    /// <summary>
    /// The <see cref="System.UriComponents.StrongAuthority" />  (user authentication) component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Authority { get; }

    /// <summary>
    /// The <see cref="System.UriComponents.Host" />  of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Host { get; }

    /// <summary>
    /// The <see cref="System.UriComponents.Port" />  of the resource identifier (if it exists), <see langword="null" /> otherwise
    /// </summary>
    int? Port { get; }
}
