// /*
//  * YesNoIdc.cs
//  *
//  *   Created: 2023-09-03-01:48:29
//  *   Modified: 2023-09-03-01:48:29
//  *
//  *   Author: David G. Moore, Jr. <david@dgmjr.io>
//  *
//  *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// namespace System;

// [Display(Name = "Yes/No", ShortName = "Yes/No", Description = "Yes/No", Prompt = "Yes or no?")]
// public partial record class YesNo : Dgmjr.Enumerations.EnumerationRecordClass<YesNo, byte, Enums.YesNo>
// {
//     public YesNo(Enums.YesNo value) : base((byte)value, value, value.ToString()) { }
//     public static implicit operator YesNo(Enums.YesNo value) => FromValue(value);
// }

// [Display(Name = "Yes/No/IDC", ShortName = "Yes/No/IDC", Description = "Yes/No/IDC", Prompt = "Yes/No/IDC?")]
// public partial record class YesNoIdc : YesNo, Dgmjr.Enumerations.Abstractions.IEnumeration<YesNoIdc, byte, Enums.YesNoIdc>
// {
//     public YesNoIdc(Enums.YesNoIdc value) : base((byte)value, value, value.ToString()) { }
//     public static implicit operator YesNoIdc(Enums.YesNoIdc value) => FromValue(value);
// }
