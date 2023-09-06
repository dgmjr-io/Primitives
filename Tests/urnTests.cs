namespace Dgmjr.Primitives.Tests;

public class urnTests : PrimitivesTests<urn, urnTests>
{
    public urnTests(ITestOutputHelper output) : base(output) { }

    protected override string[][] InvalidValuesStrings =>
        new[] { new[] { "fcku!!!!!!" }, new[] { "not-a-urn:foo:bar-baz-quux" }, };

    protected override string[][] ValidValuesStrings =>
        new[]
        {
            new[] { urn.ExampleStringValue },
            new[] { "urn:uuid:1ffaa033-f06c-495c-a9f5-0f252dd740d8" },
            new[] { "urn:uuid:1ffaa033f06c495ca9f50f252dd740d8" },
        };
}
