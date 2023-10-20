namespace Dgmjr.Primitives.Tests;

public class urlTests : PrimitivesTests<url, urlTests>
{
    public urlTests(ITestOutputHelper output)
        : base(output) { }

    protected override string[][] InvalidValuesStrings => new[] { new[] { "fcku!!!!!!" } };

    protected override string[][] ValidValuesStrings =>
        new[]
        {
            new[] { xri.ExampleStringValue },
            new[] { url.ExampleStringValue },
            new[] { iri.ExampleStringValue },
            new[] { "https://dgmjr.io" },
            new[] { "ftp://dgmjr.io" },
            new[] { "telnet://dgmjr.io" },
            new[] { "tg://user/?id=10245674" },
            new[] { "https://dgmjr.🤯" },
        };
}
