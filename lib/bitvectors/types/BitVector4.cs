//---------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 4-bit bitvector
    /// </summary>
    public struct BitVector4
    {
        internal byte Data;

        [MethodImpl(Inline)]
        internal BitVector4(byte data, bit direct)
            => Data = data;

        [MethodImpl(Inline)]
        public BitVector4(byte data)
            => Data = (byte)(data & 0xF);

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public byte State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The number of bits represented by the vector
        /// </summary>
        public readonly int Width
        {
            [MethodImpl(Inline)]
            get => 4;
        }

        /// <summary>
        /// Returns true if all bits are disabled, false otherwise
        /// </summary>
        public readonly bit Empty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        /// <summary>
        /// Returns true if at least one bit is enabled, false otherwise
        /// </summary>
        public readonly bit NonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public bool AllOn
        {
            [MethodImpl(Inline)]
            get => (0xF & Data) == 0xF;
        }

        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => (Data & (1 << pos)) != 0;

            [MethodImpl(Inline)]
            set => Data = bit.set(Data, pos, value);
        }

        public BitVector4 this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get => BitVector.bitseg(this,first,last);
        }

        [MethodImpl(Inline)]
        public bool Equals(in BitVector4 y)
            => Data == y.Data;

        [MethodImpl(Inline)]
        public bool Equals(BitVector4 other)
            => Data == other.Data;

        public override bool Equals(object obj)
            => obj is BitVector4 x  && Equals(x);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override string ToString()
            => this.Format();

        [MethodImpl(Inline)]
        public static implicit operator BitVector4(byte src)
            => new BitVector4(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(BitVector4 src)
            => src.Data;

        /// <summary>
        /// Computes the XOR of the source operands.
        /// Note that this operator is equivalent to the addition operator (+)
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator ^(in BitVector4 x, in BitVector4 y)
            => (byte)(x.Data ^ y.Data);

        /// <summary>
        /// Computes the bitwise AND of the source operands
        /// Note that the AND operator is equivalent to the (*) operator
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator &(in BitVector4 x, in BitVector4 y)
            => (byte)(x.Data & y.Data);

        /// <summary>
        /// Computes the bitwise OR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator |(in BitVector4 x, in BitVector4 y)
            => BitVector.or(x,y);

        /// <summary>
        /// Computes the bitwise complement
        /// </summary>
        /// <param name="x">The left bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator ~(BitVector4 src)
            => BitVector.not(src);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator +(BitVector4 x, BitVector4 y)
            => BitVector.add(x,y);

        /// <summary>
        /// Computes the product of the operands.
        /// Note that this operator is equivalent to the AND operator (&)
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator *(in BitVector4 x, in BitVector4 y)
            => (byte)(x.Data & y.Data);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(BitVector4 x, BitVector4 y)
            => BitVector.dot(x,y);

        [MethodImpl(Inline)]
        public static BitVector4 operator -(in BitVector4 src)
            => BitVector.negate(src);

        /// <summary>
        /// Subtracts the second operand from the first.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector4 operator - (BitVector4 x, BitVector4 y)
            => BitVector.sub(x,y);

        [MethodImpl(Inline)]
        public static BitVector4 operator >>(BitVector4 x, int shift)
            => BitVector.srl(x,(byte)shift);

        [MethodImpl(Inline)]
        public static BitVector4 operator <<(BitVector4 x, int shift)
            => BitVector.sll(x,(byte)shift);

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(BitVector4 x, BitVector4 y)
            => math.eq(x,y);

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(BitVector4 x, BitVector4 y)
            => math.neq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <(BitVector4 x, BitVector4 y)
            => math.lt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >(BitVector4 x, BitVector4 y)
            => math.gt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <=(BitVector4 x, BitVector4 y)
            => math.lteq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >=(BitVector4 x, BitVector4 y)
            => math.gteq(x,y);

        public static BitVector4 Zero => default;

        public static BitVector4 One => 1;

        public static BitVector4 Ones => 0xF;
    }
}