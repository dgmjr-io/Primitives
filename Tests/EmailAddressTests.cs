namespace Dgmjr.Primitives.Tests;
using System.Net.Mail;

public class EmailAddressTests
{
    [Fact]
    public static void EmptyEmailAddress_ShouldBeEmpty()
    {
        var emptyEmailAddress = EmailAddress.Empty;
        emptyEmailAddress.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public static void EmptyEmailAddressValue_ShouldBeNullOrEmpty()
    {
        var emptyEmailAddress = EmailAddress.Empty;
        emptyEmailAddress.ToString().Should().BeNullOrEmpty();
    }

    [Fact]
    public static void EmptyEmailAddressValue_ShouldBeNullOrEmpty()
    {
        var emptyEmailAddress = EmailAddress.Empty;
        emptyEmailAddress.ToString().Should().BeNullOrEmpty();
    }
}
