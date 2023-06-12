using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Explicit, Size = 3)]
    public readonly struct Int24 : IEquatable<Int24>, IComparable<Int24>, IFormattable
#if NE7_0_OR_GREATER
    , IAdditionOperators<Int24, Int24, Int24>, ISubtractionOperators<Int24, Int24, Int24>, 
    IMultiplicationOperators<Int24, Int24, Int24>, IDivisionOperators<Int24, Int24, Int24>, 
    IUnaryNegationOperators<Int24, Int24>, IBinaryIntegerOperators<Int24, Int24, Int24>, 
    IComparisonOperators<Int24, Int24>, IMinMaxValue<Int24>, IIncrementOperators<Int24>,
    IDecrementOperators<Int24>
#endif
    {
        private const int BitOffset = 8;
        private const string BitsSize = 24;
        private const uint Zero = 0x00800000;
        private const uint NegativeSignMask = 0xFF000000;
        private const uint PositiveSignMask = 0x00FFFFFF;

        [FieldOffset(0)]
        private readonly byte _b0;

        [FieldOffset(1)]
        private readonly byte _b1;

        [FieldOffset(2)]
        private readonly byte _b2;

        public Int24 Value => this;


        public Int24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        public Int24(sbyte value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> 8);
            _b2 = (byte)(value >> 16);
        }

        public Int24(short value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        public Int24(int value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        public Int24(uint value)
        {
            if (value > (1 << BitsSize - 1) - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value too large for Int24");
            }

            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        public Int24(ReadOnlySpan<byte> bytes)
        {
            if (bytes.Length != 3)
            {
                throw new ArgumentException("Bytes span must be exactly 3 bytes long", nameof(bytes));
            }

            _b0 = bytes[0];
            _b1 = bytes[1];
            _b2 = bytes[2];
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index > 2)
                {
                    throw new IndexOutOfRangeException();
                }

                return Unsafe.Add(ref Unsafe.As<Int24, byte>(ref Unsafe.AsRef(this)), index);
            }
        }

        public int CompareTo(Int24 other)
        {
            int thisValue = this.SignExtend();
            int otherValue = other.SignExtend();
            return thisValue.CompareTo(otherValue);
        }

        public bool Equals(Int24 other)
        {
            return this.SignExtend() == other.SignExtend();
        }

        public override bool Equals(object? obj)
        {
            return obj is Int24 other && this.Equals(other);
        }

        public Int24 SignExtend()
        {
            if ((Value & Zero) != 0)
            {
                // Negative number: fill upper 8 bits with 1's
                return new Int24((int)(Value | NegativeSignMask));
            }
            else
            {
                // Positive number: fill upper 8 bits with 0's
                return new Int24((int)(Value & PositiveSignMask));
            }
        }

        public override int GetHashCode()
        {
            return this.SignExtend().GetHashCode();
        }

        public override string ToString()
        {
            return this.SignExtend().ToString();
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return this.SignExtend().ToString(format, formatProvider);
        }

        private const int Int32MinValue = -8388608;
        private const int Int32MaxValue = 8388607;


        // Implementations of IComparable, IComparable<Int24>, IEquatable<Int24>, and IConvertible
        // ...

        public int ToInt32()
        {
            int result = _b0;
            result |= _b1 << 8;
            result |= (_b2 & 0x7F) << 16;

            if ((_b2 & 0x80) == 0x80)
            {
                result |= 0xFF << 23;
            }

            return result;
        }

        private const int Bits = 24;
        private const int SignBit = 1 << (Bits - 1);
        private const int MaxValueWithoutSignBit = SignBit - 1;

        public static implicit operator Int24(int value) => new Int24(value);
        public static bool operator ==(Int24 left, Int24 right) => left.Equals(right);
        public static bool operator !=(Int24 left, Int24 right) => !left.Equals(right);
        public static bool operator <(Int24 left, Int24 right) => left.CompareTo(right) < 0;
        public static bool operator >(Int24 left, Int24 right) => left.CompareTo(right) > 0;
        public static bool operator <=(Int24 left, Int24 right) => left.CompareTo(right) <= 0;
        public static bool operator >=(Int24 left, Int24 right) => left.CompareTo(right) >= 0;

        public TypeCode GetTypeCode() => TypeCode.Int32;

        public static Int24 operator +(Int24 left, Int24 right) => new Int24(left.ToInt32() + right.ToInt32());

        public static Int24 operator -(Int24 left, Int24 right) => new Int24(left.ToInt32() - right.ToInt32());

        public static Int24 operator *(Int24 left, Int24 right) => new Int24(left.ToInt32() * right.ToInt32());

        public static Int24 operator /(Int24 left, Int24 right) => new Int24(left.ToInt32() / right.ToInt32());

        public static Int24 operator %(Int24 left, Int24 right) => new Int24(left.ToInt32() % right.ToInt32());

        public static Int24 operator &(Int24 left, Int24 right) => new Int24(left.ToInt32() & right.ToInt32());

        public static Int24 operator |(Int24 left, Int24 right) => new Int24(left.ToInt32() | right.ToInt32());

        public static Int24 operator ^(Int24 left, Int24 right) => new Int24(left.ToInt32() ^ right.ToInt32());

        public static Int24 operator ~(Int24 value) => new Int24(~value.ToInt32());

        public static Int24 operator <<(Int24 value, int shift) => new Int24(value.ToInt32() << shift);

        public static Int24 operator >>(Int24 value, int shift) => new Int24(value.ToInt32() >> shift);

        public static implicit operator int(Int24 value) => value.ToInt32();

        public int CompareTo(object obj)
        {
            if (obj is Int24 i24)
            {
                return CompareTo(i24);
            }
            else if (obj is decimal d && d >= Int32MinValue && d <= Int32MaxValue)
            {
                return CompareTo(new Int24((int)d));
            }
            else if (obj is int i32 && i32 >= Int32MinValue && i32 <= Int32MaxValue)
            {
                return CompareTo(new Int24(i32));
            }
            else if (obj is uint ui32 && ui32 >= Int32MinValue && ui32 <= Int32MaxValue)
            {
                return CompareTo(new Int24(ui32));
            }
            else if (obj is long i64 && i64 >= Int32MinValue && i64 <= Int32MaxValue)
            {
                return CompareTo(new Int24((int)i64));
            }
            else if (obj is ulong ui64 && (uint)ui64 >= Int32MinValue && (uint)ui64 <= Int32MaxValue)
            {
                return CompareTo(new Int24((int)ui64));
            }
            else if (obj is short s)
            {
                return CompareTo(new Int24(s));
            }
            throw new InvalidCastException($"Cannot compare an object of type {obj.GetType()} to an object of type {typeof(Int24)}");
        }


        public static readonly Int24 MaxValue = new(MaxValue);
        public static readonly Int24 MinValue = new(MinValue);
        public static explicit operator Int24(sbyte value) => new Int24(value);
    }
}
