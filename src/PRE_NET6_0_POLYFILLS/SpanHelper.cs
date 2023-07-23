#if !NET6_0_OR_GREATER
internal static class SpanHelper
{
    public static long DigitsToInt64(int value, int length)
    {
        long result = 0;
        int multiplier = 1;

        for (int i = 0; i < length; i++)
        {
            int digit = value % 10;
            result += digit * multiplier;
            multiplier *= 10;
            value /= 10;
        }

        return result;
    }

    public static int ParseDigits(ReadOnlySpan<char> span, int startIndex, int length)
    {
        int result = 0;

        for (int i = startIndex; i < startIndex + length; i++)
        {
            char c = span[i];
            if (c < '0' || c > '9')
            {
                throw new FormatException("Invalid digit in input span.");
            }

            result = result * 10 + (c - '0');
        }

        return result;
    }

    public static int ParseDigits(ReadOnlySpan<byte> span, int startIndex, int length)
    {
        int result = 0;

        for (int i = startIndex; i < startIndex + length; i++)
        {
            byte b = span[i];
            if (b < '0' || b > '9')
            {
                throw new FormatException("Invalid digit in input span.");
            }

            result = result * 10 + (b - '0');
        }

        return result;
    }
}
#endif
