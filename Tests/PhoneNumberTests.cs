/*
 * EmailAddressTests copy.cs
 *
 *   Created: 2023-09-02-03:25:55
 *   Modified: 2023-09-02-03:25:56
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Primitives.Tests;

using System.Domain;

public class PhoneNumberTests : PrimitivesTests<PhoneNumber, PhoneNumberTests>
{
    public PhoneNumberTests(ITestOutputHelper output)
        : base(output) { }

    protected override string[][] InvalidValuesStrings =>
    new[] { new[] { "not-a-phone-number" }, new[] { "+1+9172125869" } };

    protected override string[][] ValidValuesStrings =>
    new[]
    {
        new[] { "+1 202-503-4657" },
        new[] { "+12025034657" },
        new[] { "+1 202.503.4657" },
        new[] { "+1 202 503 4657" }
    };
}
