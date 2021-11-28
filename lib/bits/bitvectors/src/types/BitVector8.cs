//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct BitVector8 : IBitVector<BitVector8,byte>
    {
        internal byte Data;

        [MethodImpl(Inline)]
        public BitVector8(byte src)
            => Data = src;

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
            get => 8;
        }

        /// <summary>
        /// Presents bitvector content as a bytespan
        /// </summary>
        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => core.bytes(Data);
        }

        /// <summary>
        /// Returns true if no bits are enabled, false otherwise
        /// </summary>
        public readonly bit Empty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        /// <summary>
        /// Returns true if the vector has at least one enabled bit; false otherwise
        /// </summary>
        public readonly bit NonEmpty
        {
            [MethodImpl(Inline)]
            get => !Empty;
        }

        /// <summary>
        /// Returns true if all bits are enabled, false otherwise
        /// </summary>
        public readonly bit AllOn
        {
            [MethodImpl(Inline)]
            get => (0xFF & Data) == 0xFF;
        }

        /// <summary>
        /// The vector's 4 most significant bits
        /// </summary>
        public readonly BitVector4 Hi
        {
            [MethodImpl(Inline)]
            get => bits.hi(Data);
        }

        /// <summary>
        /// The vector's 4 least significant bits
        /// </summary>
        public readonly BitVector4 Lo
        {
            [MethodImpl(Inline)]
            get => bits.lo(Data);
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
        /// Selects a contiguous range of bits
        /// </summary>
        /// <param name="first">The position of the first bit</param>
        /// <param name="last">The position of the last bit</param>
        public BitVector8 this[byte first, byte last]
        {
            [MethodImpl(Inline)]
            get => BitVector.bitseg(this,first,last);
        }

        [MethodImpl(Inline)]
        public readonly bool Equals(BitVector8 y)
            => Data == y.Data;

        public override bool Equals(object obj)
            => obj is BitVector8 x ? Equals(x) : false;

        public override int GetHashCode()
            => Data.GetHashCode();

        public string Format(BitFormat config)
            => BitVector.format(this,config);

        public string Format()
            => BitVector.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitVector<byte>(BitVector8 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector8(byte src)
            => new BitVector8(src);

        /// <summary>
        /// Implicitly converts a byte classifier to a vector
        /// </summary>
        /// <param name="src">The classifier</param>
        [MethodImpl(Inline)]
        public static implicit operator BitVector8(Hex8Seq src)
            => (byte)src;

        /// <summary>
        /// Implicitly converts a vector to a byte classifier
        /// </summary>
        /// <param name="src">The vector</param>
        [MethodImpl(Inline)]
        public static implicit operator Hex8Seq(BitVector8 src)
            => (Hex8Seq)src.Data;

        /// <summary>
        /// Converts the source vector to the underlying scalar
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(BitVector8 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector16(BitVector8 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector32(BitVector8 src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BitVector64(BitVector8 src)
            => src.Data;

        /// <summary>
        /// <summary>
        /// Computes the component-wise AND of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator &(BitVector8 x, BitVector8 y)
            => BitVector.and(x,y);

        /// <summary>
        /// Computes the bitwise OR of the source operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator |(BitVector8 x, BitVector8 y)
            => BitVector.or(x,y);

        /// Computes the XOR of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator ^(BitVector8 x, BitVector8 y)
            => BitVector.xor(x,y);

        /// <summary>
        /// Left-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator <<(BitVector8 x, int shift)
            => BitVector.sll(x,(byte)shift);

        /// <summary>
        /// Right-shifts the bits in the source
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator >>(BitVector8 x, int shift)
            => BitVector.srl(x,(byte)shift);

        /// <summary>
        /// Computes the one's complement of the operand.
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator ~(BitVector8 x)
            => BitVector.not(x);

        /// <summary>
        /// Computes the two's complement of the operand
        /// </summary>
        /// <param name="x">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator -(BitVector8 x)
            => BitVector.negate(x);

        /// <summary>
        /// Computes the arithmetic sum of the source operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator +(BitVector8 x, BitVector8 y)
            => BitVector.add(x,y);

        /// <summary>
        /// Computes the product of the operands.
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator *(BitVector8 x, BitVector8 y)
            => BitVector.gfmul(x,y);

        /// <summary>
        /// Computes the arithmetic difference between the operands
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator - (BitVector8 x, BitVector8 y)
            => BitVector.sub(x,y);

        /// <summary>
        /// Raises a vector b to a power n where n >= 0
        /// </summary>
        /// <param name="b">The base vector</param>
        /// <param name="n">The power</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator ^(BitVector8 b, int n)
            => BitVector.pow(b,n);

        /// <summary>
        /// Computes the scalar product of the operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static bit operator %(BitVector8 x, BitVector8 y)
            => BitVector.dot(x,y);

        /// <summary>
        /// Arithmetically increments the bitvector
        /// </summary>
        /// <param name="lhs">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator ++(BitVector8 src)
            => BitVector.inc(src);

        /// <summary>
        /// Arithmetically decrements the bitvector
        /// </summary>
        /// <param name="lhs">The source operand</param>
        [MethodImpl(Inline)]
        public static BitVector8 operator --(BitVector8 src)
            => BitVector.dec(src);

        /// <summary>
        /// Returns true if the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator true(BitVector8 src)
            => src.NonEmpty;

        /// <summary>
        /// Returns false if the source vector is the zero vector, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static bool operator false(BitVector8 src)
            => src.Empty;

        /// <summary>
        /// Computes the operand's logical negation: if x = 0 then 1 else 0
        /// </summary>
        /// <param name="src">The ource operand</param>
        [MethodImpl(Inline)]
        public static bit operator !(BitVector8 src)
            => src.Empty;

        /// <summary>
        /// Determines whether operand content is identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator ==(BitVector8 x, BitVector8 y)
            => math.eq(x,y);

        /// <summary>
        /// Determines whether operand content is non-identical
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator !=(BitVector8 x, BitVector8 y)
            => math.neq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <(BitVector8 x, BitVector8 y)
            => math.lt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than than the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >(BitVector8 x, BitVector8 y)
            => math.gt(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically less than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator <=(BitVector8 x, BitVector8 y)
            => math.lteq(x,y);

        /// <summary>
        /// Determines whether the left operand is arithmetically greater than or equal to the second
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static bit operator >=(BitVector8 x, BitVector8 y)
            => math.gteq(x,y);

        public static BitVector8 Zero => default;

        public static BitVector8 One => 1;

        public static BitVector8 Ones => byte.MaxValue;
    }
}