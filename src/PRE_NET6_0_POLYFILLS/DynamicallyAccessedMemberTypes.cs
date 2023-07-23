#if !NET6_0_OR_GREATER
#region Assembly System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// /usr/local/share/dotnet/shared/Microsoft.NETCore.App/8.0.0-preview.5.23280.8/System.Private.CoreLib.dll
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

namespace System.Diagnostics.CodeAnalysis;

[Flags]
public enum DynamicallyAccessedMemberTypes
{
    None = 0,
    PublicParameterlessConstructor = 1,
    PublicConstructors = 3,
    NonPublicConstructors = 4,
    PublicMethods = 8,
    NonPublicMethods = 0x10,
    PublicFields = 0x20,
    NonPublicFields = 0x40,
    PublicNestedTypes = 0x80,
    NonPublicNestedTypes = 0x100,
    PublicProperties = 0x200,
    NonPublicProperties = 0x400,
    PublicEvents = 0x800,
    NonPublicEvents = 0x1000,
    Interfaces = 0x2000,
    All = -1
}
#endif
