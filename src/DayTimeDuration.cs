using System;

/*
 * DayTimeDuration.cs
 *
 *   Created: 2023-08-30-01:44:46
 *   Modified: 2023-08-30-01:44:46
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Primitives;

[RegexDto(
    @"^(?<Negative:string?>\-?)P(?:(?<Days:int?>\d+)?D)?T?(?:(?<Hours:int?>\d+)H)?(?:(?<Minutes:int?>\d+)M)?(?:(?<Seconds:double?>\d+(?:\.(?:\d+)?)?S)?)"
)]
public partial record struct DayTimeDuration
{
    private const int TicksPerMillisecond = 1000;
    private const int TicksPerSecond = 1000000;

    public readonly bool IsNegative => !IsNullOrEmpty(Negative);
    public readonly int Sign => IsNegative ? -1 : 1;

    public static implicit operator duration(DayTimeDuration dtd) =>
        duration.FromTicks(
            new duration(
                dtd.Days ?? 0,
                dtd.Hours ?? 0,
                dtd.Minutes ?? 0,
                dtd.Seconds.HasValue ? (int)Math.Floor(dtd.Seconds.Value) : 0,
                dtd.Seconds.HasValue
                    ? (int)Math.Floor((dtd.Seconds.Value * TicksPerMillisecond) - Math.Floor(dtd.Seconds.Value))
                    : 0
#if NET7_0_OR_GREATER
                ,
                dtd.Seconds.HasValue
                    ? (int)
                        Math.Floor(
                            (dtd.Seconds.Value * TicksPerSecond)
                                - Math.Floor(dtd.Seconds.Value * TicksPerMillisecond)
                                - Math.Floor(dtd.Seconds.Value)
                        )
                    : 0
#endif
            ).Ticks * dtd.Sign
        );

    public static implicit operator string(DayTimeDuration dtd) =>
        $"{(dtd.IsNegative ? "-" : "")}P{(dtd.Days.HasValue ? $"{dtd.Days.Value}D" : "")}{(dtd.Hours.HasValue || dtd.Minutes.HasValue || dtd.Seconds.HasValue ? "T" : "")}{(dtd.Hours.HasValue ? $"{dtd.Hours.Value}H" : "")}{(dtd.Minutes.HasValue ? $"{dtd.Minutes.Value}M" : "")}{(dtd.Seconds.HasValue ? $"{dtd.Seconds.Value}S" : "")}";
}
