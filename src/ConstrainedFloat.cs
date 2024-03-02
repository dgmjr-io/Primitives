namespace System;
using System.Numerics;

public abstract class ConstrainedFloat<TSelf>
#if NET7_0_OR_GREATER
    // : IParsable<TSelf>
#endif
    where TSelf : ConstrainedFloat<TSelf>, new()
{
    private const float DefaultMin = float.MinValue;
    private const float DefaultMax = float.MaxValue;

    protected ConstrainedFloat(float value, float min = DefaultMin, float max = DefaultMax)
    {
        if (min > max)
        {
            throw new ArgumentOutOfRangeException(nameof(min), "Min value cannot be greater than max value.");
        }

        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be between min and max.");
        }

        Value = value;
        Min = min;
        Max = max;
    }

    protected ConstrainedFloat(float value, float[] range)
    {
        Range = range;
        Value = value;
        if(!range.Contains(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Value must be within the following values: {Join(", ", range)}.");
        }
    }

    public float[]? Range { get; }
    public float Value { get; }
    public float Min { get; }
    public float Max { get; }

    // public static implicit operator float(ConstrainedFloat<TSelf> cfloat) => cfloat.Value;

    // public static implicit operator ConstrainedFloat<TSelf>(float? value) => (TSelf)Activator.CreateInstance(typeof(TSelf), value);
    // public static implicit operator TSelf(ConstrainedFloat<TSelf> value) => (TSelf)value;

    public static bool operator ==(ConstrainedFloat<TSelf> left, ConstrainedFloat<TSelf> right) => left.Equals(right);

    public static bool operator !=(ConstrainedFloat<TSelf> left, ConstrainedFloat<TSelf> right) => !left.Equals(right);

    public override bool Equals(object? obj) => obj is ConstrainedFloat<TSelf> cfloat && Equals(cfloat);

    public bool Equals(ConstrainedFloat<TSelf> other) => Value == other.Value;

    public override int GetHashCode() => HashCode.Combine(Value, Min, Max, Range);

    public override string ToString() => Value.ToString();

    // public static TSelf Parse (string s, IFormatProvider? provider) => (ConstrainedFloat<TSelf>)float.Parse(s, provider);

    // public static bool TryParse (string? s, IFormatProvider? provider, out TSelf result)
    // {
    //     var bResult = float.TryParse(s, Globalization.NumberStyles.Any, provider, out var floatResult);
    //     result = bResult ? (TSelf)Activator.CreateInstance(typeof(TSelf), floatResult) : default;
    //     return bResult;
    // }
}
