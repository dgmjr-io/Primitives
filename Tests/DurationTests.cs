namespace Dgmjr.Primitives.Tests;
using Dgmjr.Primitives;

using Xunit;


public class DurationTests
{
    [Theory]
    [MemberData(nameof(DayTimeDurationTestData))]
    public void Day_Time_Duration_Parses_Correctly(string dayTimeDuration, duration expectedDuration)
    {
        var dtd = DayTimeDuration.Parse(dayTimeDuration);
        ((duration)dtd).Should().Be(expectedDuration);
    }

    [Theory]
    [MemberData(nameof(YearMonthDurationTestData))]
    public void Year_Month_Duration_Parses_Correctly(string yearMonthDuration, duration expectedDuration)
    {
        var dtd = YearMonthDuration.Parse(yearMonthDuration);
        ((duration)dtd).Should().Be(expectedDuration);
    }

    public static IEnumerable<object[]> DayTimeDurationTestData =>
        new[] {
            new object[] { "-P12DT13H27M12S", duration.FromMilliseconds(new duration(12, 13, 27, 12).TotalMilliseconds * -1) },
            new object[] { "-P525600M", duration.FromMinutes(-525600) },
            new object[] { "P525600M", duration.FromMinutes(525600) }
            };

    public static IEnumerable<object[]> YearMonthDurationTestData =>
        new[] {
            new object[] { "-P6500Y1M", duration.FromDays(duration.FromDays((6500*365) + 30).TotalDays * -1) },
            new object[] { "P1Y3M", duration.FromDays(365 + 90) },
            new object[] { "-P1Y3M", duration.FromDays(-(365 + 90)) },
            new object[] { "P3M", duration.FromDays(90) }
            };
}
