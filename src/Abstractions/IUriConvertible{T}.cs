namespace System;

public interface IUriConvertible<T>
    where T : IUriConvertible<T>, IHaveAUri
{
#if NET70_OR_GREATER
  public static virtual T
  FromUri(Uri uri) => typeof(T).IsAssignableFrom(typeof(Uri))
                          ? (T)uri
                          : new FromUri(uri?.ToString() ?? string.Empty);
  public static virtual T
  FromUri(string uri) => typeof(T).IsAssignableFrom(typeof(Uri))
                             ? (T) new Uri(uri)
                             : new FromUri(uri ?? string.Empty);
#endif
}
