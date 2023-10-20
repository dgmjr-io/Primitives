#if !NET6_0_OR_GREATER
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    Inherited = false
)]
public sealed class DisallowNullAttribute : Attribute { }
#endif
