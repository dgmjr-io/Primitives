#if !NET6_0_OR_GREATER
#region Assembly System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// /usr/local/share/dotnet/shared/Microsoft.NETCore.App/8.0.0-preview.5.23280.8/System.Private.CoreLib.dll
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

namespace System.Resources;

internal enum ResourceTypeCode
{
    Null = 0,
    String = 1,
    Boolean = 2,
    Char = 3,
    Byte = 4,
    SByte = 5,
    Int16 = 6,
    UInt16 = 7,
    Int32 = 8,
    UInt32 = 9,
    Int64 = 10,
    UInt64 = 11,
    Single = 12,
    Double = 13,
    Decimal = 14,
    DateTime = 15,
    TimeSpan = 16,
    LastPrimitive = 16,
    ByteArray = 32,
    Stream = 33,
    StartOfUserTypes = 64
}
#endif
