using System.Runtime.Serialization;

using Microsoft.Extensions.Logging;

using Xunit.Abstractions;

namespace Dgmjr.Primitives.Tests;

public abstract class PrimitivesTests<TPrimitive, TSelf> : BaseTest
    where TPrimitive : IRegexValueObject<TPrimitive>
    where TSelf : PrimitivesTests<TPrimitive, TSelf>
{
    private static ITestOutputHelper _output;

    protected PrimitivesTests(ITestOutputHelper output)
        : base(output)
    {
        _output = output;
    }

    [Fact]
    public void Empty_Primitive_Is_Empty()
    {
        var emptyPrimitive = TPrimitive.Empty;
        Logger.LogInformation($"Testing that empty primitive {emptyPrimitive} IsEmpty == true");
        emptyPrimitive.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void Empty_Primitive_Value_Is_Null_Or_Empty()
    {
        var emptyPrimitive = TPrimitive.Empty;
        Logger.LogInformation(
            $"Testing that empty primitive {emptyPrimitive} ToString is NullOrEmpty"
        );
        emptyPrimitive.ToString().Should().BeNullOrEmpty();
    }

    [Theory]
    [MemberData(nameof(ValidValues))]
    public virtual void Valid_Primitive_Is_Valid_And_Not_Empty(string validValue)
    {
        var primitive = TPrimitive.Parse(validValue);
        Logger.LogInformation(
            $"Testing that valid primitive {validValue} IsEmpty == false && contains {validValue}"
        );
        Logger.LogOriginalValue(typeof(TPrimitive), primitive.OriginalString);
        primitive.IsEmpty.Should().BeFalse();
        primitive.Value
            .Trim()
            .ToLowerInvariant()
            .Should()
            .Contain(validValue.Trim().ToLowerInvariant());
    }

    // [Theory]
    // [MemberData(nameof(InvalidValues))]
    // public virtual void Invalid_Primitive_Is_Invalid_And_Empty(string invalidValue)
    // {
    //     var primitive = TPrimitive.TryParse(invalidValue, null, out var p) ? p : TPrimitive.Empty;
    //     primitive.IsEmpty.Should().BeTrue();
    //     primitive.Value.Should().Be(TPrimitive.Empty.Value);
    // }

    [Theory]
    [MemberData(nameof(InvalidValues))]
    public virtual void Invalid_Primitive_Throws_Exception_On_Parse(string invalidValue)
    {
        var parsePrimitive = () => TPrimitive.Parse(invalidValue);
        Logger.LogInformation(
            $"Testing that invalid primitive {invalidValue} throws exception on parse"
        );
        parsePrimitive.Should().Throw<Exception>();
    }

    public static object[][] ValidValues =>
        (Activator.CreateInstance(typeof(TSelf), _output) as TSelf).ValidValuesStrings;
    protected abstract string[][] ValidValuesStrings { get; }

    public static object[][] InvalidValues =>
        (Activator.CreateInstance(typeof(TSelf), _output) as TSelf).InvalidValuesStrings;
    protected abstract string[][] InvalidValuesStrings { get; }
}
