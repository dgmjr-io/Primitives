using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Represents a 24-bit integer.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 3)]
    public readonly struct Int24 : IEquatable<i24>, IComparable<i24>, IFormattable, IConvertible
#if NE7_0_OR_GREATER
            ,
            IAdditionOperators<i24, i24, i24>,
            ISubtractionOperators<i24, i24, i24>,
            IMultiplicationOperators<i24, i24, i24>,
            IDivisionOperators<i24, i24, i24>,
            IUnaryNegationOperators<i24, i24>,
            IBinaryIntegerOperators<i24, i24, i24>,
            IComparisonOperators<i24, i24>,
            IMinMaxValue<i24>,
            IIncrementOperators<i24>,
            IDecrementOperators<i24>
#endif
    {
        /// <summary>
        /// The bit offset of the integer.
        /// </summary>
        private const int BitOffset = 8;

        /// <summary>
        /// The size of the bits in the integer.
        /// </summary>
        public const int Size = 24;

        /// <summary>
        /// The zero mask for the integer.
        /// </summary>
        public const uint Zero = 0x00800000;

        /// <summary>
        /// The mask for negative sign.
        /// </summary>
        private const uint NegativeSignMask = 0xFF000000;

        /// <summary>
        /// The mask for positive sign.
        ///</summary>
        private const uint PositiveSignMask = 0x00FFFFFF;

        [FieldOffset(0)]
        private readonly byte _b0;

        [FieldOffset(1)]
        private readonly byte _b1;

        [FieldOffset(2)]
        private readonly byte _b2;

        private readonly byte[] Bytes => [_b0, _b1, _b2];

        public static implicit operator uint(i24 value) =>
            (uint)value._b0 | (uint)(value._b1 >> BitOffset) | (uint)(value._b2 >> BitOffset * 2);

        public static implicit operator int(i24 value) =>
            (int)value._b0 | ((int)value._b1 >> BitOffset) | ((int)value._b2 >> BitOffset * 2);

        // /// <summary>
        // /// Gets the value of the integer.
        // /// </summary>
        // public i24 Value => this;

        /// <summary>
        /// Initializes a new instance of the i24 struct with three bytes.
        /// </summary>
        /// <param name="b0">The first byte.</param>
        /// <param name="b1">The second byte.</param>
        /// <param name="b2">The third byte.</param>
        public Int24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }
        /// <summary>
        /// Initializes a new instance of the i24 struct with three bytes.
        /// </summary>
        /// <param name="bytes">The array of three bytes holding the int24 value.</param>
        public Int24(byte[] bytes) : this(bytes[0], bytes[1], bytes[2]) { }

        /// <summary>
        /// Initializes a new instance of the i24 struct with a signed byte value.
        /// </summary>
        /// <param name="value">The signed byte value.</param>
        public Int24(sbyte value) : this((byte)value, 0x0, 0x0) { }

        /// <summary>
        /// Initializes a new instance of the i24 struct with a short integer value.
        /// </summary>
        ///<param name="value">The short integer value.</param>
        public Int24(short value) : this((byte)(value & 0xFF), (byte)(value >> BitOffset), 0x0) { }

        /// <summary>
        /// Initializes a new instance of the i24 struct with an integer value.
        /// </summary>
        ///<param name="value">The integer value.</param>
        public Int24(int value) : this((byte)(value & 0xFF), (byte)(value >> BitOffset), (byte)(value >> BitOffset * 2)) { }

        /// <summary>
        /// Initializes a new instance of the i24 struct with an unsigned integer value.
        /// </summary>
        /// <param name="value">The unsigned integer value.</param>
        public Int24(uint value)
        {
            if (value > (1 << Size - 1) - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value too large for i24");
            }

            _b0 = (byte)(value & 0xFF);
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        /// <summary>
        /// Initializes a new instance of the i24 struct with a read-only span of bytes.
        /// </summary>
        /// <param name="bytes">The read-only span of bytes.</param>
        public Int24(ReadOnlySpan<byte> bytes)
        {
            if (bytes.Length != 3)
            {
                throw new ArgumentException(
                    "Bytes span must be exactly 3 bytes long",
                    nameof(bytes)
                );
            }

            _b0 = bytes[0];
            _b1 = bytes[1];
            _b2 = bytes[2];
        }

        /// <summary>
        /// Gets or sets the byte at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the byte to get or set.</param>
        public byte this[int index]
        {
            get
            {
                return index switch
                {
                    0 => _b0,
                    1 => _b1,
                    2 => _b2,
                    _ => throw new IndexOutOfRangeException()
                };
            }
        }

        /// <summary>
        /// Compares this instance to another i24 instance and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        public int CompareTo(i24 other)
        {
            int thisValue = SignExtend();
            int otherValue = other.SignExtend();
            return thisValue.CompareTo(otherValue);
        }

        /// <summary>
        /// Determines whether this instance and another specified i24 object have the same value.
        /// </summary>
        /// <param name="other">The i24 to compare to this instance.</param>
        /// <returns>true if the value of the other parameter is the same as the value of this instance; otherwise, false.</returns>
        public bool Equals(i24 other)
        {
            return SignExtend()  == other.SignExtend();
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be an i24 object, have the same value.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>true if obj is an i24 and its value is the same as this instance; otherwise, false. If obj is null, the method returns false.</returns>
        public override bool Equals(object? obj)
        {
            return obj is i24 other && Equals(other);
        }

        /// <summary>
        /// Sign extends the current i24 struct.
        /// </summary>
        /// <returns>A new i24 struct with sign extension applied.</returns>
        public i24 SignExtend()
        {
            if ((this & Zero) != 0)
            {
                // Negative number: fill upper 8 bits with 1's
                return unchecked ((i24)(int)(this | NegativeSignMask));
            }
            // Positive number: fill upper 8 bits with 0's
            return (i24)(int)(this & PositiveSignMask);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///<returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return SignExtend().GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        ///<returns>The string representation of the value of this instance.</returns>
        public override string ToString()
        {
            return SignExtend().ToString();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using specified format and culture-specific format information.
        ///</summary>
        ///<param name="format">A standard or custom numeric format string.</param>
        ///<param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        ///<returns>The string representation of the value of this instance as specified by format and provider parameters. </returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return SignExtend().ToString(format, formatProvider);
        }

        private const int Int32MinValue = -8388608;
        private const int Int32MaxValue = 8388607;

        // Implementations of IComparable, IComparable<i24>, IEquatable<i24>, and IConvertible
        // ...

        /// <summary>
        /// Converts the value of this instance to a 32-bit signed integer.
        /// </summary>
        ///<returns>A 32-bit signed integer equal to the value of this instance.</returns>
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

        /// <summary>
        /// Implicitly converts an i24 struct to an integer.
        /// </summary>
        ///<param name="value">The i24 struct to convert.</param>
        public static implicit operator i24(int value) => new(value);

        /// <summary>
        /// Determines whether two specified i24 objects have the same value.
        /// </summary>
        /// <param name="left">The first i24 to compare.</param>
        /// <param name="right">The second i24 to compare.</param>
        /// <returns>true if the value of left is the same as the value of right; otherwise, false.</returns>
        public static bool operator ==(i24 left, i24 right) => left.Equals(right);

        /// <summary>
        /// Determines whether two specified i24 objects have different values.
        /// </summary>
        /// <param name="left">The first i24 to compare.</param>
        /// <param name="right">The second i24 to compare.</param>
        /// <returns>true if the value of left is different from the value of right; otherwise, false.</returns>
        public static bool operator !=(i24 left, i24 right) => !left.Equals(right);

        /// <summary>
        /// Determines whether one specified i24 is less than another specified i24.
        /// </summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is less than right; otherwise, false.</returns>
        public static bool operator <(i24 left, i24 right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines whether one specified i24 is greater than another specified i24.
        /// </summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is greater than right; otherwise, false.</returns>
        public static bool operator >(i24 left, i24 right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines whether one specified i24 is less than or equal to another specified int.
        ///</summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is less than or equal to right; otherwise, false.</returns>
        public static bool operator <=(i24 left, i24? right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether one specified i24 is greater than or equal to another specified int.
        ///</summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is greater than or equal to right; otherwise, false.</returns>
        public static bool operator >=(i24 left, i24? right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Returns the TypeCode for this instance.
        /// </summary>
        ///<returns>The enumerated constant that is the TypeCode of the class or value type that implements this interface.</returns>
        public TypeCode GetTypeCode() => TypeCode.Int32;

        /// <summary>The maximum value that can be assigned to an instance of this type.</summary>
        /// <returns>A constant equal to 8388607.</returns>
        /// <value>8388607</value>
        public static readonly i24 MaxValue = new(Int32MinValue);

        /// <summary>
        /// The minimum value that can be assigned to an instance of this type.
        /// </summary>
        /// <returns>A constant equal to -8388608.</returns>
        /// <value>-8388608</value>
        public static readonly i24 MinValue = new(Int32MaxValue);

        public static explicit operator i24(sbyte value) => new(value);

        public int ToInt32(IFormatProvider? formatProvider) => ToInt32();

        public uint ToUInt32(IFormatProvider? formatProvider) => (uint)ToInt32();

        public long ToInt64(IFormatProvider? formatProvider) => (long)ToInt32();

        public ulong ToUInt64(IFormatProvider? formatProvider) => (ulong)ToInt32();

        public short ToInt16(IFormatProvider? formatProvider) => (short)ToInt32();

        public ushort ToUInt16(IFormatProvider? formatProvider) => (ushort)ToInt32();

#if NET7_0_OR_GREATER
        public Int128 ToInt128(IFormatProvider? formatProvider) => (Int128)ToInt32();

        public UInt128 ToUInt128(IFormatProvider? formatProvider) => (UInt128)ToInt32();
#endif

        public byte ToByte(IFormatProvider? formatProvider) => (byte)ToInt32();

        public sbyte ToSByte(IFormatProvider? formatProvider) => (sbyte)ToInt32();

        public Single ToSingle(IFormatProvider? formatProvider) => (Single)ToInt32();

        public double ToDouble(IFormatProvider? formatProvider) => (double)ToInt32();

        public decimal ToDecimal(IFormatProvider? formatProvider) => (decimal)ToInt32();

        public char ToChar(IFormatProvider? formatProvider) => (char)ToInt32();

        public DateTime ToDateTime(IFormatProvider? formatProvider) =>
            DateTime.FromBinary((long)ToInt32());

        public bool ToBoolean(IFormatProvider? formatProvider) => ToInt32() > 0;

        public object ToType(Type conversionType, IFormatProvider? formatProvider) =>
            Convert.ChangeType(ToInt32(), conversionType, formatProvider);

        public string ToString(IFormatProvider? formatProvider) =>
            ((int)ToInt32()).ToString(formatProvider);

        public static i24 Parse(string s, Globalization.NumberStyles style = 0) =>
            new(int.Parse(s, style));
    }

#if NETSTANDARD2_0_OR_GREATER

#endif
}
