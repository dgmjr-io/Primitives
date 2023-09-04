/*
 * YesNoIdc.cs
 *
 *   Created: 2022-12-17-12:47:12
 *   Modified: 2022-12-17-12:47:12
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace System.Enums;

// [GenerateEnumerationRecordClass]
public enum YesNoIdc : sbyte
{
    /// <summary>I don't care</summary>
    [Display(Name = "I don't care", ShortName = "IDC", Description = "I don't care", Prompt = "Yes/No/IDC?")]
    Idc = -1,
    /// <summary>I don't give a fuck</summary>
    /// <remarks>Same as <see cref="Idc"/></remarks>
    [Display(Name = "I don't give a fuck", ShortName = "IDGAF", Description = "I don't give a fuck", Prompt = "Yes/No/IDC?")]
    Idgaf = Idc,
}

// [GenerateEnumerationRecordStruct]
public enum YesNo : sbyte
{
    /// <summary>No, negative, nope, fuck no, negatory, false, etc.</summary>
    [Display(Name = "No", ShortName = "No", Description = "Negative", Prompt = "Yes or no?")]
    No = 0,
    /// <summary>Yes, affirmative, yep, uh-huh, mmhmm, true, etc.</summary>
    [Display(Name = "Yes", ShortName = "Yes", Description = "Affirmative", Prompt = "Yes or no?")]
    Yes = 1,
}
