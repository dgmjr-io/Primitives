namespace Dgmjr.Primitives.Tests;

public class uriTests : PrimitivesTests<uri, uriTests>
{
    public uriTests(ITestOutputHelper output) : base(output) { }

    protected override string[][] InvalidValuesStrings => new[]
    {
        new[] { "fcku!!!!!!" }
    };

    protected override string[][] ValidValuesStrings => new[]
    {
        new[] { uri.ExampleStringValue },
        new[] { xri.ExampleStringValue },
        new[] { url.ExampleStringValue },
        new[] { urn.ExampleStringValue },
        new[] { iri.ExampleStringValue },
        new[] { "urn:uuid:1ffaa033-f06c-495c-a9f5-0f252dd740d8" },
        new[] { "urn:uuid:1ffaa033f06c495ca9f50f252dd740d8" },
        new[] { "https://dgmjr.io" },
        new[] { "ftp://dgmjr.io" },
        new[] { "telnet://dgmjr.io" },
        new[] { "tg://user/?id=10245674" },
        new[] { "dgmjr:foo" },
    };
}
