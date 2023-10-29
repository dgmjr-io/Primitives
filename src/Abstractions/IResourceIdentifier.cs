namespace Dgmjr.Abstractions;

public interface IResourceIdentifier
{
    /// <summary>The <see cref="UriComponents.Scheme" />  of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.</summary>
    string? Scheme { get; }

    /// <summary>The <see cref="UriComponents.PathAndQuery" />  of the resource identifier (if it exists), <see langword="null" /> or <see cref="string.Empty" /> otherwise.</summary>
    string? PathAndQuery { get; }

    /// <summary>
    /// "<inheritdoc cref="DoubleSlashes" path="/value" />" iff they were included in the original string, <see langword="null" /> or <see cref="string.Empty" /> otherwise.
    /// </summary>
    /// <value>//</value>
    string? DoubleSlashes { get; }
}
