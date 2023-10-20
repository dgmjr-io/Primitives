using System;

using Dgmjr.Primitives;

namespace Primitives;

[RegexDto(
    @"^(?<Negative:string?>\-?)P(?:(?<Years:int?>\d+)?Y)?(?:(?<Months:int?>\d+)M)?(?:(?<Days:int?>\d+)?D)?T?(?:(?<Hours:int?>\d+)H)?(?:(?<Minutes:int?>\d+)M)?(?:(?<Seconds:double?>\d+(?:\.(?:\d+)?)?S)?)$"
)]
public partial record struct xsduration
{
    public readonly bool IsNegative => !IsNullOrEmpty(Negative);
    public readonly int Sign => IsNegative ? -1 : 1;

    public static implicit operator duration(xsduration xsd) =>
        duration.FromTicks(
            new duration(
                (int)
                    Math.Floor(
                        (xsd.Years.HasValue ? xsd.Years.Value * YearMonthDuration.DaysPerYear : 0)
                            + (
                                xsd.Months.HasValue
                                    ? xsd.Months.Value * YearMonthDuration.DaysPerMonth
                                    : 0
                            )
                            + (xsd.Days ?? 0)
                    ),
                xsd.Hours ?? 0,
                xsd.Minutes ?? 0,
                xsd.Seconds.HasValue ? (int)Math.Floor(xsd.Seconds.Value) : 0,
                xsd.Seconds.HasValue
                    ? (int)Math.Floor((xsd.Seconds.Value * 1000) - Math.Floor(xsd.Seconds.Value))
                    : 0
#if NET7_0_OR_GREATER
                ,
                xsd.Seconds.HasValue
                    ? (int)
                        Math.Floor(
                            (xsd.Seconds.Value * 1000000)
                                - Math.Floor(xsd.Seconds.Value * 1000)
                                - Math.Floor(xsd.Seconds.Value)
                        )
                    : 0
#endif
            ).Ticks * xsd.Sign
        );

    // public static implicit operator xsduration(System.TimeSpan d)
    //     => new xsduration { Seconds =  }

    public static implicit operator string(xsduration xsd) =>
        $"{(xsd.IsNegative ? "-" : "")}P{(xsd.Years.HasValue ? $"{xsd.Years.Value}Y" : "")}{(xsd.Months.HasValue ? $"{xsd.Months.Value}M" : "")}{(xsd.Days.HasValue ? $"{xsd.Days.Value}D" : "")}{(xsd.Hours.HasValue || xsd.Minutes.HasValue || xsd.Seconds.HasValue ? "T" : "")}{(xsd.Hours.HasValue ? $"{xsd.Hours.Value}H" : "")}{(xsd.Minutes.HasValue ? $"{xsd.Minutes.Value}M" : "")}{(xsd.Seconds.HasValue ? $"{xsd.Seconds.Value}S" : "")}";
}
