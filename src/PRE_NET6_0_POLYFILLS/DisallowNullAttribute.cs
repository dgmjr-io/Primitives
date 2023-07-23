#if !NET6_0_OR_GREATER
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, Inherited = false)]
public sealed class DisallowNullAttribute : Attribute
{
}
#endif
