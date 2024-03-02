namespace System;
using System.Numerics;

public abstract class ConstrainedDouble<TSelf>
#if NET7_0_OR_GREATER
    // : IParsable<TSelf>
#endif
    where TSelf : ConstrainedDouble<TSelf>, new()
{
    private const double DefaultMin = double.MinValue;
    private const double DefaultMax = double.MaxValue;

    protected ConstrainedDouble(double value, double min = DefaultMin, double max = DefaultMax)
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

    protected ConstrainedDouble(double value, double[] range)
    {
        Range = range;
        Value = value;
        if (!range.Contains(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Value must be within the following values: {Join(", ", range)}.");
        }
    }

    public double[]? Range { get; }
    public double Value { get; }
    public double Min { get; }
    public double Max { get; }

    // public static implicit operator double(ConstrainedDouble<TSelf> cdouble) => cdouble.Value;

    // public static implicit operator ConstrainedDouble<TSelf>(double? value) => (TSelf)Activator.CreateInstance(typeof(TSelf), value);
    // public static implicit operator TSelf(ConstrainedDouble<TSelf> value) => (TSelf)value;

    public static bool operator ==(ConstrainedDouble<TSelf> left, ConstrainedDouble<TSelf> right) => left.Equals(right);

    public static bool operator !=(ConstrainedDouble<TSelf> left, ConstrainedDouble<TSelf> right) => !left.Equals(right);

    public override bool Equals(object? obj) => obj is ConstrainedDouble<TSelf> cdouble && Equals(cdouble);

    public bool Equals(ConstrainedDouble<TSelf> other) => Value == other.Value;

    public override int GetHashCode() => HashCode.Combine(Value, Min, Max, Range);

    public override string ToString() => Value.ToString();

    // public static TSelf Parse (string s, IFormatProvider? provider) => (ConstrainedDouble<TSelf>)double.Parse(s, provider);

    // public static bool TryParse (string? s, IFormatProvider? provider, out TSelf result)
    // {
    //     var bResult = double.TryParse(s, Globalization.NumberStyles.Any, provider, out var doubleResult);
    //     result = bResult ? (TSelf)Activator.CreateInstance(typeof(TSelf), doubleResult) : default;
    //     return bResult;
    // }
}
