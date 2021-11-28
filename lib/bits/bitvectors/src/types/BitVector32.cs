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
    /// Defines a 32-bit bitvector
    /// </summary>
    public struct BitVector32 : IBitVector<BitVector32,uint>
    {
        internal uint Data;

        /// <summary>
        /// Initializes the vector with the source value it represents
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public BitVector32(uint src)
            => Data = src;

        /// <summary>
        /// Extracts the scalar represented by the vector
        /// </summary>
        public readonly uint State
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
            get => 32;
        }

        public BitVector16 Lo
        {
            [MethodImpl(Inline)]
            get => (ushort)bits.lo(Data);
        }

        public BitVector16 Hi
        {
            [MethodImpl(Inline)]
            get => (ushort)bits.hi(Data);
        }

        /// <summary>
        /// Presents bitvector content as a bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        /// <summary>
        /// Returns true if no bits are enabled, false otherwise
        /// </summary>
        public readonly bool Empty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        /// <summary>
        /// Returns true if the vector has at least one enabled bit; false otherwise
        /// </summary>
        public readonly bool NonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        /// <summary>
        /// Gets/sets the state of an index-identified bit
        /// </summary>
        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => bit.test(Data, (byte)index);

            [MethodImpl(Inline)]
            set => Data = bit.set(Data, (byte)index, value);
        }

        /// <summary>
        /// Selects a contiguous range of bits defined by an inclusive 0-based index range
        /// </summary>
        /// <param name="first">The position of the first bit</param>
        /// <param name="last">The position of the last bit</param>
        /// <remarks>Unfortuantely, the range spec/select syntanx [a..b] results in about 50 extra bytes
        /// of assembly (!) of the jmp/cmp/test variety. So, defining a range operator for
        /// performance-sensitive types is hard no-go </remarks>
        public BitVector32 this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get =>  bits.segment(Data, first, last);
        }

        [MethodImpl(Inline)]
        public bool Equals(BitVector32 y)
            => Data == y.Data;

        public override bool Equals(object obj)
            => obj is BitVector32 x ? Equals(x) : false;

        public override int GetHashCode()
            => Data.GetHashCode();

         public string Format(BitFormat config)
            => BitVector.format(this,config);

        public string Format()
            => BitVector.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitVector<uint>(BitVector32 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector64(BitVector32 src)
            => BitVector.create(n64,src.Data);

        [MethodImpl(Inline)]
        public static explicit operator BitVector4(BitVector32 src)
            => new BitVector4((byte)src.Data);

        [MethodImpl(Inline)]
        public static explicit operator BitVector8(BitVector32 src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator BitVector16(BitVector32 src)
            =>(ushort)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator uint(BitVector32 src)
            => src.Data;

        /// <summary>
        /// Implicitly converts a scalar value to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator BitVector32(byte src)
            => BitVector.create(N,src);

        /// <summary>
        /// Implicitly converts a scalar value to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator BitVector32(ushort src)
            => BitVector.create(N,src);

        /// <summary>
        /// Implicitly converts a scalar value to a 32-bit bitvector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator BitVector32(uint src)
            => new BitVector32(src);

        /// <summary>
        /// Computes the bitwise XOR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator ^(BitVector32 x, BitVector32 y)
            => BitVector.xor(x,y);

        /// <summary>
        /// Computes the bitwise AND of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator &(BitVector32 x, BitVector32 y)
            => BitVector.and(x,y);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(BitVector32 x, BitVector32 y)
            => BitVector.dot(x,y);

        /// <summary>
        /// Computes the bitwise OR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator |(BitVector32 x, BitVector32 y)
            => BitVector.or(x,y);

        /// <summary>
        /// Computes the bitwise complement of the operand.
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator ~(BitVector32 src)
            => BitVector.not(src);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator +(BitVector32 x, BitVector32 y)
            => BitVector.add(x,y);

        /// <summary>
        /// Arithmetically increments the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator ++(BitVector32 src)
            => BitVector.inc(src);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator --(BitVector32 src)
            => BitVector.dec(src);

        /// <summary>
        /// Computes the arithmetic difference between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator - (BitVector32 x, BitVector32 y)
            => BitVector.sub(x,y);

        /// <summary>
        /// Computes the two's complement of the operand
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator -(BitVector32 x)
            => BitVector.negate(x);

        /// <summary>
        /// Left-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator <<(BitVector32 x, int shift)
            => BitVector.sll(x,(byte)shift);

        /// <summary>
        /// Right-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector32 operator >>(BitVector32 x, int shift)
            => BitVector.srl(x,(byte)shift);

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(BitVector32 x)
            => x.NonEmpty;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(BitVector32 x)
            => x.Empty;

        /// <summary>
        /// Computes the operand's logical negation: if x = 0 then 1 else 0
        /// </summary>
        /// <param name="src">The ource operand</param>
        [MethodImpl(Inline)]
        public static bit operator !(BitVector32 src)
            => src.Empty;

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(BitVector32 x, BitVector32 y)
            => x.Data == y.Data;

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(BitVector32 x, BitVector32 y)
            => x.Data != y.Data;

        /// <summary>
        /// Determines whether the left operand is arithmetically less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <(BitVector32 x, BitVector32 y)
            => math.lt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >(BitVector32 x, BitVector32 y)
            => math.gt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <=(BitVector32 x, BitVector32 y)
            => math.lteq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >=(BitVector32 x, BitVector32 y)
            => math.gteq(x,y);

        /// <summary>
        /// Allocates a vector with all bits disabled
        /// </summary>
        public static BitVector32 Zero => default;

        /// <summary>
        /// Allocates a vector that has the least bit enabled and all others disabled
        /// </summary>
        public static BitVector32 One => 1;

        /// <summary>
        /// Allocates a vector with all bits enabled
        /// </summary>
        public static BitVector32 Ones => uint.MaxValue;

        public static N32 N => default;
   }
}