namespace Dgmjr.Abstractions;

public interface IResourceIdentifierWithQueryAndFragment : IResourceIdentifier
{
    /// <summary>
    /// The <see cref="System.UriComponents.Path" />  component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Path { get; }

    /// <summary>
    /// The <see cref="System.UriComponents.Query" />  component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Query { get; }

    /// <summary>
    /// The <see cref="System.UriComponents.Fragment" /> component of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    string? Fragment { get; }
}
