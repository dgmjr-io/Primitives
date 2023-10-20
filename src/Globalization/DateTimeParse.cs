// #if !NET7_0_OR_GREATER
// internal enum ParseFailureKind
// {
//     None,

//     ArgumentNull_String,
//     Format_BadDatePattern,
//     Format_BadDateTime,
//     Format_BadDateTimeCalendar,
//     Format_BadDayOfWeek,
//     Format_BadFormatSpecifier,
//     Format_BadQuote,
//     Format_DateOutOfRange,
//     Format_MissingIncompleteDate,
//     Format_NoFormatSpecifier,
//     Format_OffsetOutOfRange,
//     Format_RepeatDateTimePattern,
//     Format_UnknownDateTimeWord,
//     Format_UTCOutOfRange,

//     Argument_InvalidDateStyles,
//     Argument_BadFormatSpecifier,
//     Format_BadDateOnly,
//     Format_BadTimeOnly,
//     Format_DateTimeOnlyContainsNoneDateParts,  // DateOnly and TimeOnly
//     specific value. Unrelated date parts when parsing DateOnly or Unrelated
//     time parts when parsing TimeOnly
// }

// [Flags]
// internal enum ParseFlags
// {
//     HaveYear = 0x00000001,
//     HaveMonth = 0x00000002,
//     HaveDay = 0x00000004,
//     HaveHour = 0x00000008,
//     HaveMinute = 0x00000010,
//     HaveSecond = 0x00000020,
//     HaveTime = 0x00000040,
//     HaveDate = 0x00000080,
//     TimeZoneUsed = 0x00000100,
//     TimeZoneUtc = 0x00000200,
//     ParsedMonthName = 0x00000400,
//     CaptureOffset = 0x00000800,
//     YearDefault = 0x00001000,
//     Rfc1123Pattern = 0x00002000,
//     UtcSortPattern = 0x00004000,
// }
// #endif
