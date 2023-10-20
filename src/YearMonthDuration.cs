/*
 * YearMonthDuration.cs
 *
 *   Created: 2023-08-30-02:23:38
 *   Modified: 2023-08-30-02:23:53
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;

namespace Dgmjr.Primitives;

[RegexDto(
    @"^(?<Negative:string?>\-?)P(?:(?<Years:int?>\d+)?Y)?(?:(?<Months:int?>\d+)M)?")]
public partial record struct YearMonthDuration {
  public const float DaysPerMonth = 30.437f;
  public const float DaysPerYear = 365.2425f;
  public readonly bool IsNegative => !IsNullOrEmpty(Negative);
  public readonly int Sign => IsNegative ? -1 : 1;

  public static implicit
  operator duration(YearMonthDuration ymd) => duration.FromMilliseconds(
      new duration(
          (int)Math.Floor(
              (ymd.Years.HasValue ? ymd.Years.Value * DaysPerYear : 0) +
              (ymd.Months.HasValue ? ymd.Months.Value * DaysPerMonth : 0)),
          0, 0, 0)
          .TotalMilliseconds *ymd.Sign);

  public static implicit operator string(YearMonthDuration ymd) =>
      $"{(ymd.IsNegative ? "-" : "")}P{(ymd.Years.HasValue ? $" {
        ymd.Years.Value
    } Y" : "")}{(ymd.Months.HasValue ? $" {ymd.Months.Value} M" : "")}";
}
