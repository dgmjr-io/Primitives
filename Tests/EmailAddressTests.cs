namespace Dgmjr.Primitives.Tests;
using System.Net.Mail;

public class EmailAddressTests : PrimitivesTests<EmailAddress, EmailAddressTests>
{
    public EmailAddressTests(ITestOutputHelper output) : base(output) { }

    protected override string[][] InvalidValuesStrings =>
        new[] { new[] { "not an email" }, new[] { "missing@" }, new[] { "@missing-domain" } };

    protected override string[][] ValidValuesStrings =>
        new[]
        {
            new[] { "test@example.com" },
            new[] { "test123@subdomain.example.com" },
            new[] { "david@dgmjr.io" },
            new[] { "david.moore@dgmoore.com" }
        };
}
