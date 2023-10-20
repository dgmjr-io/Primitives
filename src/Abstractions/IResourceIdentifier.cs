namespace Dgmjr.Abstractions;

public interface IResourceIdentifier {
  string? Scheme { get; }
  string? PathAndQuery { get; }
}

public interface IResourceIdentifierWithQueryAndFragment : IResourceIdentifier {
  /// <summary>
  /// The <see cref="System.UriComponents.Path" />  component of the resource
  /// identifier (if it exists), <see langword="null" /> or <see
  /// cref="string.Empty" /> otherwise.
  /// </summary>
  string? Path { get; }

  /// <summary>
  /// The <see cref="System.UriComponents.Query" />  component of the resource
  /// identifier (if it exists), <see langword="null" /> or <see
  /// cref="string.Empty" /> otherwise.
  /// </summary>
  string? Query { get; }

  /// <summary>
  /// The <see cref="System.UriComponents.Fragment" /> component of the resource
  /// identifier (if it exists), <see langword="null" /> or <see
  /// cref="string.Empty" /> otherwise.
  /// </summary>
  string? Fragment { get; }
}

public interface IResourceIdentifierWithAuthorityHostPortQueryAndFragment
    : IResourceIdentifierWithQueryAndFragment {
  /// <summary>
  /// "<inheritdoc cref="DoubleSlashes" path="/value" />" iff they were included
  /// in the original string, <see langword="null" /> or <see
  /// cref="string.Empty" /> otherwise.
  /// </summary>
  /// <value>//</value>
  string? DoubleSlashes { get; }

  /// <summary>
  /// The <see cref="System.UriComponents.StrongAuthority" />  (user
  /// authentication) component of the resource identifier (if it exists), <see
  /// langword="null" /> or <see cref="string.Empty" /> otherwise.
  /// </summary>
  string? Authority { get; }

  /// <summary>
  /// The <see cref="System.UriComponents.Host" />  of the resource identifier
  /// (if it exists), <see langword="null" /> or <see cref="string.Empty" />
  /// otherwise.
  /// </summary>
  string? Host { get; }

  /// <summary>
  /// The <see cref="System.UriComponents.Port" />  of the resource identifier
  /// (if it exists), <see langword="null" /> otherwise
  /// </summary>
  int? Port { get; }
}
