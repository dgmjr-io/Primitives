#if !NET6_0_OR_GREATER
#region Assembly System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// /usr/local/share/dotnet/shared/Microsoft.NETCore.App/8.0.0-preview.5.23280.8/System.Private.CoreLib.dll
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method,
    Inherited = false
)]
public sealed class RequiresUnreferencedCodeAttribute : Attribute
{
    public string Message { get; }

    public string? Url { get; set; }

    public RequiresUnreferencedCodeAttribute(string message)
    {
        Message = message;
    }
}
#endif
