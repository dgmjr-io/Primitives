namespace Dgmjr.Abstractions;

public interface IResourceIdentifier
{
    string Scheme {get;}
    string PathAndQuery {get;}
}

public interface IResourceIdentifierWithQueryAndFragment : IResourceIdentifier
{
    string? Path { get; }
    string? Query { get; }
    string? Fragment { get; }
}