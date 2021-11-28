//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a generic bitvector over a primal cell
    /// </summary>
    /// <typeparam name="T">The cell type</typeparam>
    public struct BitVector<T> : IBitVector<BitVector<T>,T>
        where T : unmanaged
    {
        T Data;

        [MethodImpl(Inline)]
        internal BitVector(T src)
            => Data = src;

        /// <summary>
        /// Specifies the data over which the vector is defined
        /// </summary>
        public readonly T State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// Extracts the lower bits
        /// </summary>
        public readonly T Lo
        {
            [MethodImpl(Inline)]
            get => gbits.lo(Data);
        }

        /// <summary>
        /// Extracts the upper bits
        /// </summary>
        public readonly T Hi
        {
            [MethodImpl(Inline)]
            get => gbits.hi(Data);
        }

        /// <summary>
        /// The number of bits represented by the vector
        /// </summary>
        public readonly int Width
        {
            [MethodImpl(Inline)]
            get => (int)width<T>();
        }

        /// <summary>
        /// Converts the encapsulated data to a bytespan
        /// </summary>
        public readonly Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        /// <summary>
        /// Specifies whether all bits are disabled
        /// </summary>
        public bit Empty
        {
            [MethodImpl(Inline)]
            get => !gmath.nonz(Data);
        }

        /// <summary>
        /// Specifies whether at least one bit is enabled
        /// </summary>
        public readonly bit NonEmpty
        {
            [MethodImpl(Inline)]
            get => gmath.nonz(Data);
        }

        /// <summary>
        /// Reads/Manipulates a single bit
        /// </summary>
        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => gbits.testbit(Data, (byte)index);

            [MethodImpl(Inline)]
            set => Data = gbits.setbit(Data, (byte)index, value);
        }

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        public BitVector<T> this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get => BitVector.bitseg(this, first, last);
        }

        [MethodImpl(Inline)]
        public readonly bool Equals(BitVector<T> y)
            => gmath.eq(Data, y.Data);

        public readonly override bool Equals(object obj)
            => obj is BitVector<T> x && Equals(x);

        public readonly override int GetHashCode()
            => Data.GetHashCode();

        public string Format(BitFormat config)
            => BitVector.format(this,config);

        public string Format()
            => BitVector.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitVector<T>(T src)
            => new BitVector<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(BitVector<T> src)
            => src.Data;

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator &(BitVector<T> x, BitVector<T> y)
            => BitVector.and(x,y);

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator |(BitVector<T> x, BitVector<T> y)
            => BitVector.or(x,y);

        /// <summary>
        /// Computes the bitwise XOR between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator ^(BitVector<T> x, BitVector<T> y)
            => BitVector.xor(x,y);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(BitVector<T> x, BitVector<T> y)
            => BitVector.dot(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator ~(BitVector<T> src)
            => BitVector.not(src);

        /// <summary>
        /// Computes the two's complement negation of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator -(BitVector<T> src)
            => BitVector.negate(src);

        /// <summary>
        /// Shifts the source bits leftwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator <<(BitVector<T> x, int offset)
            => BitVector.sll(x,(byte)offset);

        /// <summary>
        /// Shifts the source bits rightwards
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator >>(BitVector<T> x, int offset)
            => BitVector.srl(x,(byte)offset);

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(BitVector<T> src)
            => src.NonEmpty;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(BitVector<T> src)
            => src.Empty;

        /// <summary>
        /// Increments the vector arithmetically
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator ++(BitVector<T> src)
            => BitVector.inc(src);

        /// <summary>
        /// Decrements the vector arithmetically
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator --(BitVector<T> src)
            => BitVector.dec(src);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator +(BitVector<T> x, BitVector<T> y)
            => BitVector.add(x,y);

        /// <summary>
        /// Arithmetically subtracts the second operand from the first.
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector<T> operator - (BitVector<T> x, BitVector<T> y)
            => BitVector.sub(x,y);

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(BitVector<T> x, BitVector<T> y)
            => gmath.eq(x.Data,y.Data);

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(BitVector<T> x, BitVector<T> y)
            => gmath.neq(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <(BitVector<T> x, BitVector<T> y)
            => gmath.lt(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >(BitVector<T> x, BitVector<T> y)
            => gmath.gt(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <=(BitVector<T> x, BitVector<T> y)
            => gmath.lteq(x.Data,y.Data);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >=(BitVector<T> x, BitVector<T> y)
            => gmath.gteq(x.Data,y.Data);
   }
}