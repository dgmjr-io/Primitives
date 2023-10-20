#if !NET6_0_OR_GREATER
#region Assembly System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// /usr/local/share/dotnet/shared/Microsoft.NETCore.App/8.0.0-preview.5.23280.8/System.Private.CoreLib.dll
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion
#pragma warning disable CS0436
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(
    AttributeTargets.Method | AttributeTargets.Property,
    Inherited = false,
    AllowMultiple = true
)]
public sealed class MemberNotNullAttribute : Attribute
{
    public string[] Members { get; }

    public MemberNotNullAttribute(string member)
    {
        Members = new string[1] { member };
    }

    public MemberNotNullAttribute(params string[] members)
    {
        Members = members;
    }
}
#endif
#pragma warning restore CS0436
