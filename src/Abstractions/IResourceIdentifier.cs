namespace Dgmjr.Abstractions;

public interface IResourceIdentifier
{
    string? Scheme { get; }
    string? PathAndQuery { get; }
}
