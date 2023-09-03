namespace Dgmjr.Abstractions;

public interface IResourceIdentifier
{
    string? Scheme { get; }
    string? PathAndQuery { get; }
}

public interface IResourceIdentifierWithQueryAndFragment : IResourceIdentifier
{
    /// <summary>
    /// The path component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Path { get; }
    /// <summary>
    /// The query component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Query { get; }
    /// <summary>
    /// The <see cref="System.UriComponent.Fragment" /> component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Fragment { get; }
}

public interface IResourceIdentifierWithAuthorityHostPortQueryAndFragment : IResourceIdentifierWithQueryAndFragment
{
    /// <summary>
    /// <inheritdoc cref="DoubleSlashes" path="/value" /> iff they were included in the original string, <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    /// <value>//</value>
    string? DoubleSlashes { get; }
    /// <summary>
    /// The "authority" (user authentication) component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Authority { get; }
    /// <summary>
    /// The hostname of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Host { get; }
    /// <summary>
    /// The port of the resource identifier (if it exists), <see langword="null" /> otherwise
    /// </summary>
    int? Port { get; }
}
