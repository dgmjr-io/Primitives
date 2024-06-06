namespace Dgmjr.Primitives.Tests;

using Dgmjr.Primitives;

using Xunit;
using Xunit.Abstractions;

public class DurationTests(ITestOutputHelper output) : BaseTest(output)
{
    [Theory]
    [MemberData(nameof(DayTimeDurationTestData))]
    public void Day_Time_Duration_Parses_Correctly(
        string dayTimeDuration,
        duration expectedDuration
    )
    {
        var dtd = DayTimeDuration.Parse(dayTimeDuration);
        ((duration)dtd).Should().Be(expectedDuration);
    }

    [Theory]
    [MemberData(nameof(YearMonthDurationTestData))]
    public void Year_Month_Duration_Parses_Correctly(
        string yearMonthDuration,
        duration expectedDuration
    )
    {
        var dtd = YearMonthDuration.Parse(yearMonthDuration);
        ((duration)dtd).Should().Be(expectedDuration);
    }

    public static IEnumerable<object[]> DayTimeDurationTestData =>
        [
            [
                "-P12DT13H27M12S",
                -new duration(12, 13, 27, 12)
            ],
            [ "-PT525600M", duration.FromMinutes(-525600)],
            [ "PT525600M", duration.FromMinutes(525600)]
        ];

    public static IEnumerable<object[]> YearMonthDurationTestData =>
        [
            ["P1Y", duration.FromDays(YearMonthDuration.DaysPerYear)],
            [ "-P1Y", duration.FromDays(-YearMonthDuration.DaysPerYear)],
            [ "P1M", duration.FromDays(YearMonthDuration.DaysPerMonth)],
            [ "-P1M", duration.FromDays(-YearMonthDuration.DaysPerMonth)],
            [ "P1Y1M", duration.FromDays(YearMonthDuration.DaysPerYear + YearMonthDuration.DaysPerMonth)],
            [ "-P1Y1M", duration.FromDays(-(YearMonthDuration.DaysPerYear + YearMonthDuration.DaysPerMonth))],
            [ "P6500Y1M", duration.FromDays((6500 * YearMonthDuration.DaysPerYear) + YearMonthDuration.DaysPerMonth)],
            [ "-P6500Y1M", duration.FromDays(((6500 * YearMonthDuration.DaysPerYear) + YearMonthDuration.DaysPerMonth) * -1)],
            [ "P1Y3M", duration.FromDays(YearMonthDuration.DaysPerYear + (3 * YearMonthDuration.DaysPerMonth))],
            [ "-P1Y3M", duration.FromDays(-(YearMonthDuration.DaysPerYear + (3 * YearMonthDuration.DaysPerMonth)))],
            [ "P3M", duration.FromDays(90)],
            [
                "-P6500Y1M",
                duration.FromDays(
                    duration
                        .FromDays(
                            (6500 * YearMonthDuration.DaysPerYear) + YearMonthDuration.DaysPerMonth
                        )
                        .TotalDays * -1
                )
            ],
            [
                "P1Y3M",
                duration.FromDays(
                    YearMonthDuration.DaysPerYear + (3 * YearMonthDuration.DaysPerMonth)
                )
            ],
            [
                "-P1Y3M",
                duration.FromDays(
                    -(YearMonthDuration.DaysPerYear + (3 * YearMonthDuration.DaysPerMonth))
                )
            ],
            [ "P3M", duration.FromDays(90)]
        ];
}
