using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Represents a 24-bit integer.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 3)]
    public readonly struct Int24 : IEquatable<Int24>, IComparable<Int24>, IFormattable, IConvertible
#if NE7_0_OR_GREATER
    , IAdditionOperators<Int24, Int24, Int24>, ISubtractionOperators<Int24, Int24, Int24>,
    IMultiplicationOperators<Int24, Int24, Int24>, IDivisionOperators<Int24, Int24, Int24>,
    IUnaryNegationOperators<Int24, Int24>, IBinaryIntegerOperators<Int24, Int24, Int24>,
    IComparisonOperators<Int24, Int24>, IMinMaxValue<Int24>, IIncrementOperators<Int24>,
    IDecrementOperators<Int24>
#endif
    {
        /// <summary>
        /// The bit offset of the integer.
        /// </summary>
        private const int BitOffset = 8;
        /// <summary>
        /// The size of the bits in the integer.
        /// </summary>
        private const int BitsSize = 24;
        /// <summary>
        /// The zero mask for the integer.
        /// </summary>
        private const uint Zero = 0x00800000;
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

        public static implicit operator uint(Int24 value) =>
            (uint)value | (uint)(value >> BitOffset) | (uint)(value >> BitOffset * 2);

        public static implicit operator int(Int24 value) =>
            (int)value | (int)(value >> BitOffset) | (int)(value >> BitOffset * 2);

        /// <summary>
        /// Gets the value of the integer.
        /// </summary>
        public Int24 Value => this;

        /// <summary>
        /// Initializes a new instance of the Int24 struct with three bytes.
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
        /// Initializes a new instance of the Int24 struct with a signed byte value.
        /// </summary>
        /// <param name="value">The signed byte value.</param>
        public Int24(sbyte value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> 8);
            _b2 = (byte)(value >> 16);
        }

        /// <summary>
        /// Initializes a new instance of the Int24 struct with a short integer value.
        /// </summary>
        ///<param name="value">The short integer value.</param>
        public Int24(short value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        /// <summary>
        /// Initializes a new instance of the Int24 struct with an integer value.
        /// </summary>
        ///<param name="value">The integer value.</param>
        public Int24(int value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        /// <summary>
        /// Initializes a new instance of the Int24 struct with an unsigned integer value.
        /// </summary>
        /// <param name="value">The unsigned integer value.</param>
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

        /// <summary>
        /// Initializes a new instance of the Int24 struct with a read-only span of bytes.
        /// </summary>
        /// <param name="bytes">The read-only span of bytes.</param>
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
        /// Compares this instance to another Int24 instance and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        public int CompareTo(Int24 other)
        {
            int thisValue = this.SignExtend();
            int otherValue = other.SignExtend();
            return thisValue.CompareTo(otherValue);
        }

        /// <summary>
        /// Determines whether this instance and another specified Int24 object have the same value.
        /// </summary>
        /// <param name="other">The Int24 to compare to this instance.</param>
        /// <returns>true if the value of the other parameter is the same as the value of this instance; otherwise, false.</returns>
        public bool Equals(Int24 other)
        {
            return this.SignExtend() == other.SignExtend();
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be an Int24 object, have the same value.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>true if obj is an Int24 and its value is the same as this instance; otherwise, false. If obj is null, the method returns false.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Int24 other && this.Equals(other);
        }

        /// <summary>
        /// Sign extends the current Int24 struct.
        /// </summary>
        /// <returns>A new Int24 struct with sign extension applied.</returns>
        public Int24 SignExtend()
        {
            if ((Value & Zero) != 0)
            {
                // Negative number: fill upper 8 bits with 1's
                return new Int24((int)(Value | NegativeSignMask));
            }
            // Positive number: fill upper 8 bits with 0's
            return new Int24((int)(Value & PositiveSignMask));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///<returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.SignExtend().GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        ///<returns>The string representation of the value of this instance.</returns>
        public override string ToString()
        {
            return this.SignExtend().ToString();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using specified format and culture-specific format information.
        ///</summary>
        ///<param name="format">A standard or custom numeric format string.</param>
        ///<param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        ///<returns>The string representation of the value of this instance as specified by format and provider parameters. </returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return this.SignExtend().ToString(format, formatProvider);
        }

        private const int Int32MinValue = -8388608;
        private const int Int32MaxValue = 8388607;


        // Implementations of IComparable, IComparable<Int24>, IEquatable<Int24>, and IConvertible
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
        /// Implicitly converts an Int24 struct to an integer.
        /// </summary>
        ///<param name="value">The Int24 struct to convert.</param>
        public static implicit operator Int24(int value) => new Int24(value);

        /// <summary>
        /// Determines whether two specified Int24 objects have the same value.
        /// </summary>
        /// <param name="left">The first Int24 to compare.</param>
        /// <param name="right">The second Int24 to compare.</param>
        /// <returns>true if the value of left is the same as the value of right; otherwise, false.</returns>
        public static bool operator ==(Int24 left, Int24 right) => left.Equals(right);

        /// <summary>
        /// Determines whether two specified Int24 objects have different values.
        /// </summary>
        /// <param name="left">The first Int24 to compare.</param>
        /// <param name="right">The second Int24 to compare.</param>
        /// <returns>true if the value of left is different from the value of right; otherwise, false.</returns>
        public static bool operator !=(Int24 left, Int24 right) => !left.Equals(right);

        /// <summary>
        /// Determines whether one specified Int24 is less than another specified Int24.
        /// </summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is less than right; otherwise, false.</returns>
        public static bool operator <(Int24 left, Int24 right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines whether one specified Int24 is greater than another specified Int24.
        /// </summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is greater than right; otherwise, false.</returns>
        public static bool operator >(Int24 left, Int24 right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines whether one specified Int24 is less than or equal to another specified Int32.
        ///</summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is less than or equal to right; otherwise, false.</returns>
        public static bool operator <=(Int24 left, Int24? right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether one specified Int24 is greater than or equal to another specified Int32.
        ///</summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is greater than or equal to right; otherwise, false.</returns>
        public static bool operator >=(Int24 left, Int24? right)
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
        public static readonly Int24 MaxValue = new(Int32MinValue);

        /// <summary>
        /// The minimum value that can be assigned to an instance of this type.
        /// </summary>
        /// <returns>A constant equal to -8388608.</returns>
        /// <value>-8388608</value>
        public static readonly Int24 MinValue = new(Int32MaxValue);
        public static explicit operator Int24(sbyte value) => new Int24(value);

        public int ToInt32(IFormatProvider? formatProvider) => (int)this.ToInt32();
        public uint ToUInt32(IFormatProvider? formatProvider) => (uint)this.ToInt32();
        public long ToInt64(IFormatProvider? formatProvider) => (long)this.ToInt32();
        public ulong ToUInt64(IFormatProvider? formatProvider) => (ulong)this.ToInt32();
        public short ToInt16(IFormatProvider? formatProvider) => (short)this.ToInt32();
        public ushort ToUInt16(IFormatProvider? formatProvider) => (ushort)this.ToInt32();
#if NET7_0_OR_GREATER
        public Int128 ToInt128(IFormatProvider? formatProvider) => (Int128)this.ToInt32();
        public UInt128 ToUInt128(IFormatProvider? formatProvider) => (UInt128)this.ToInt32();
#endif
        public byte ToByte(IFormatProvider? formatProvider) => (byte)this.ToInt32();
        public sbyte ToSByte(IFormatProvider? formatProvider) => (sbyte)this.ToInt32();
        public Single ToSingle(IFormatProvider? formatProvider) => (Single)this.ToInt32();
        public double ToDouble(IFormatProvider? formatProvider) => (double)this.ToInt32();
        public decimal ToDecimal(IFormatProvider? formatProvider) => (decimal)this.ToInt32();
        public char ToChar(IFormatProvider? formatProvider) => (char)this.ToInt32();
        public DateTime ToDateTime(IFormatProvider? formatProvider) => DateTime.FromBinary((long)this.ToInt32());
        public bool ToBoolean(IFormatProvider? formatProvider) => this.ToInt32() > 0;
        public object ToType(Type conversionType, IFormatProvider? formatProvider) => Convert.ChangeType(this.ToInt32(), conversionType, formatProvider);
        public string ToString(IFormatProvider? formatProvider) => ((Int32)this.ToInt32()).ToString(formatProvider);
    }
}
