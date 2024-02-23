namespace System;
using System.Numerics;

public readonly struct ConstrainedFloat
#if NET7_0_OR_GREATER
    : IParsable<ConstrainedFloat>
#endif
{
    private const float DefaultMin = float.MinValue;
    private const float DefaultMax = float.MaxValue;

    public ConstrainedFloat(float value, float min = DefaultMin, float max = DefaultMax)
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

    public ConstrainedFloat(float value, float[] range)
    {
        Range = range;
        Value = value;
        if (!range.Contains(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Value must be within the following values: {Join(", ", range)}.");
        }
    }

    public float[]? Range { get; }
    public float Value { get; }
    public float Min { get; }
    public float Max { get; }

    public static implicit operator float(cfloat cfloat) => cfloat.Value;

    public static implicit operator cfloat(float value) => new(value, float.MinValue, float.MaxValue);

    public static bool operator ==(cfloat left, cfloat right) => left.Equals(right);

    public static bool operator !=(cfloat left, cfloat right) => !left.Equals(right);

    public override bool Equals(object? obj) => obj is cfloat cfloat && Equals(cfloat);

    public bool Equals(cfloat other) => Value == other.Value;

    public override int GetHashCode() => HashCode.Combine(Value, Min, Max, Range);

    public override string ToString() => Value.ToString();

    public static cfloat Parse(string s, IFormatProvider? provider) => float.Parse(s, provider);

    public static bool TryParse(string? s, IFormatProvider? provider, out cfloat result)
    {
        var bResult = float.TryParse(s, Globalization.NumberStyles.Any, provider, out var floatResult);
        result = bResult ? new(floatResult) : default;
        return bResult;
    }
}
