/*
 * ui24.cs
 *
 *   Created: 2023-07-16-03:40:58
 *   Modified: 2023-07-16-03:41:41
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Represents a 24-bit integer.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 3)]
    public readonly struct UInt24 : IEquatable<ui24>, IComparable<ui24>, IFormattable, IConvertible
#if NE7_0_OR_GREATER
            ,
            IAdditionOperators<ui24, ui24, ui24>,
            ISubtractionOperators<ui24, ui24, ui24>,
            IMultiplicationOperators<ui24, ui24, ui24>,
            IDivisionOperators<ui24, ui24, ui24>,
            IUnaryNegationOperators<ui24, ui24>,
            IBinaryIntegerOperators<ui24, ui24, ui24>,
            IComparisonOperators<ui24, ui24>,
            IMinMaxValue<ui24>,
            IIncrementOperators<ui24>,
            IDecrementOperators<ui24>
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

        [FieldOffset(0)]
        private readonly byte _b0;

        [FieldOffset(1)]
        private readonly byte _b1;

        [FieldOffset(2)]
        private readonly byte _b2;

        public static implicit operator uint(ui24 value) =>
            (uint)value | (uint)(value >> BitOffset) | (uint)(value >> BitOffset * 2);

        public static implicit operator int(ui24 value) =>
            (int)value | (value >> BitOffset) | (value >> BitOffset * 2);

        /// <summary>
        /// Gets the value of the integer.
        /// </summary>
        public ui24 Value => this;

        /// <summary>
        /// Initializes a new instance of the ui24 struct with three bytes.
        /// </summary>
        /// <param name="b0">The first byte.</param>
        /// <param name="b1">The second byte.</param>
        /// <param name="b2">The third byte.</param>
        public UInt24(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        /// <summary>
        /// Initializes a new instance of the ui24 struct with a signed byte value.
        /// </summary>
        /// <param name="value">The signed byte value.</param>
        public UInt24(sbyte value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> 8);
            _b2 = (byte)(value >> 16);
        }

        /// <summary>
        /// Initializes a new instance of the ui24 struct with a short integer value.
        /// </summary>
        ///<param name="value">The short integer value.</param>
        public UInt24(short value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        /// <summary>
        /// Initializes a new instance of the ui24 struct with an integer value.
        /// </summary>
        ///<param name="value">The integer value.</param>
        public UInt24(uint value)
        {
            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        /// <summary>
        /// Initializes a new instance of the ui24 struct with an unsigned integer value.
        /// </summary>
        /// <param name="value">The unsigned integer value.</param>
        public UInt24(int value)
        {
            if (value > (1 << BitsSize - 1) - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value too large for ui24");
            }

            _b0 = (byte)value;
            _b1 = (byte)(value >> BitOffset);
            _b2 = (byte)(value >> BitOffset * 2);
        }

        /// <summary>
        /// Initializes a new instance of the ui24 struct with a read-only span of bytes.
        /// </summary>
        /// <param name="bytes">The read-only span of bytes.</param>
        public UInt24(ReadOnlySpan<byte> bytes)
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
        public byte this[uint index]
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
        /// Compares this instance to another ui24 instance and returns an indication of their relative values.
        /// </summary> =
        /// <param name="other">An object to compare with this instance.</param> =
        public readonly int CompareTo(ui24 other)
        {
            uint thisValue = SignExtend();
            uint otherValue = other.SignExtend();
            return thisValue.CompareTo(otherValue);
        }

        /// <summary>
        /// Determines whether this instance and another specified ui24 object have the same value.
        /// </summary>
        /// <param name="other">The ui24 to compare to this instance.</param>
        /// <returns>true if the value of the other parameter is the same as the value of this instance; otherwise, false.</returns>
        public readonly bool Equals(ui24 other)
        {
            return SignExtend() == other.SignExtend();
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be an ui24 object, have the same value.
        /// </summary>
        /// <param name="obj">The object to compare to this instance.</param>
        /// <returns>true if obj is an ui24 and its value is the same as this instance; otherwise, false. If obj is null, the method returns false.</returns>
        public override bool Equals(object? obj)
        {
            return obj is ui24 other && Equals(other);
        }

        /// <summary>
        /// Sign extends the current ui24 struct.
        /// </summary>
        /// <returns>A new ui24 struct with sign extension applied.</returns>
        public ui24 SignExtend()
        {
            return this;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///<returns>A hash code for the current object.</returns>
        public override readonly int GetHashCode()
        {
            return ((int)this).GetHashCode();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        ///<returns>The string representation of the value of this instance.</returns>
        public override readonly string ToString()
        {
            return ((uint)this).ToString();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using specified format and culture-specific format information.
        ///</summary>
        ///<param name="format">A standard or custom numeric format string.</param>
        ///<param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        ///<returns>The string representation of the value of this instance as specified by format and provider parameters. </returns>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return ((uint)this).ToString(format, formatProvider);
        }

        private const uint Int32MinValue = 0;
        private const uint Int32MaxValue = 0x00FFFFFFFF;

        // Implementations of IComparable, IComparable<ui24>, IEquatable<ui24>, and IConvertible
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

        private const uint Bits = 24;

        /// <summary>
        /// Implicitly converts an ui24 struct to an integer.
        /// </summary>
        ///<param name="value">The ui24 struct to convert.</param>
        public static implicit operator ui24(uint value) => new ui24(value);

        /// <summary>
        /// Determines whether two specified ui24 objects have the same value.
        /// </summary>
        /// <param name="left">The first ui24 to compare.</param>
        /// <param name="right">The second ui24 to compare.</param>
        /// <returns>true if the value of left is the same as the value of right; otherwise, false.</returns>
        public static bool operator ==(ui24 left, ui24 right) => left.Equals(right);

        /// <summary>
        /// Determines whether two specified ui24 objects have different values.
        /// </summary>
        /// <param name="left">The first ui24 to compare.</param>
        /// <param name="right">The second ui24 to compare.</param>
        /// <returns>true if the value of left is different from the value of right; otherwise, false.</returns>
        public static bool operator !=(ui24 left, ui24 right) => !left.Equals(right);

        /// <summary>
        /// Determines whether one specified ui24 is less than another specified ui24.
        /// </summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is less than right; otherwise, false.</returns>
        public static bool operator <(ui24 left, ui24 right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines whether one specified ui24 is greater than another specified ui24.
        /// </summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is greater than right; otherwise, false.</returns>
        public static bool operator >(ui24 left, ui24 right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines whether one specified ui24 is less than or equal to another specified Int32.
        ///</summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is less than or equal to right; otherwise, false.</returns>
        public static bool operator <=(ui24 left, ui24? right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Determines whether one specified Int32 is greater than or equal to another specified uint.
        ///</summary>
        ///<param name="left">The first object to compare. </param>
        ///<param name="right">The second object to compare. </param>
        ///<returns>true if left is greater than or equal to right; otherwise, false.</returns>
        public static bool operator >=(ui24 left, ui24? right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Returns the TypeCode for this instance.
        /// </summary>
        ///<returns>The enumerated constant that is the TypeCode of the class or value type that implements this interface.</returns>
        public TypeCode GetTypeCode() => TypeCode.UInt32;

        /// <summary>The maximum value that can be assigned to an instance of this type.</summary>
        /// <returns>A constant equal to 16777214.</returns>
        /// <value>16777214</value>
        public static readonly ui24 MaxValue = new(Int32MinValue);

        /// <summary>
        /// The minimum value that can be assigned to an instance of this type.
        /// </summary>
        /// <returns>A constant equal to -8388608.</returns>
        /// <value>-8388608</value>
        public static readonly ui24 MinValue = new(Int32MaxValue);

        /// <summary>
        /// Explicitly converts a signed byte to an ui24 struct.
        /// </summary>
        ///<param name="value">The signed byte to convert.</param>
        ///<returns>An object that contains the value of the converted sbyte.</returns>
        public static explicit operator ui24(sbyte value) => new ui24(value);

        public int ToInt32(IFormatProvider? provider) => (int)ToInt32();

        public uint ToUInt32(IFormatProvider? provider) => (uint)ToInt32();

        public long ToInt64(IFormatProvider? provider) => (long)ToInt32();

        public ulong ToUInt64(IFormatProvider? provider) => (ulong)ToInt32();

        public short ToInt16(IFormatProvider? provider) => (short)ToInt32();

        public ushort ToUInt16(IFormatProvider? provider) => (ushort)ToInt32();

#if NET7_0_OR_GREATER
        public Int128 ToInt128(IFormatProvider? formatProvider) => (Int128)ToInt32();

        public UInt128 ToUInt128(IFormatProvider? formatProvider) => (UInt128)ToInt32();
#endif

        public byte ToByte(IFormatProvider? provider) => (byte)ToInt32();

        public sbyte ToSByte(IFormatProvider? provider) => (sbyte)ToInt32();

        public float ToSingle(IFormatProvider? provider) => (float)ToInt32();

        public double ToDouble(IFormatProvider? provider) => (double)ToInt32();

        public decimal ToDecimal(IFormatProvider? provider) => (decimal)ToInt32();

        public char ToChar(IFormatProvider? provider) => (char)ToInt32();

        public DateTime ToDateTime(IFormatProvider? provider) =>
            DateTime.FromBinary((long)ToInt32());

        public bool ToBoolean(IFormatProvider? provider) => ToInt32() > 0;

        public object ToType(Type conversionType, IFormatProvider? provider) =>
            Convert.ChangeType(ToInt32(), conversionType, provider);

        public string ToString(IFormatProvider? provider) => ToInt32().ToString(provider);
    }

#if NETSTANDARD2_0_OR_GREATER

#endif
}
