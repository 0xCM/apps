//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BitNumbers;

    using U = uint2;
    using W = W2;
    using K = BitSeq2;
    using T = System.Byte;
    using N = N2;

    /// <summary>
    /// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxLiteral'/>]
    /// </summary>
    public readonly struct uint2 : IBitNumber<U,W,K,T>
    {
        public const byte BitCount = 2;

        internal readonly T data;

        [MethodImpl(Inline)]
        internal uint2(eight src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(byte src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(byte src, bool @unchecked)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint2(sbyte src)
            => data = (byte)((byte)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(short src)
            => data = (byte)((byte)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(ushort src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(int x)
            => data = (byte)((byte)x & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(uint src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(long src)
            => data = (byte)((byte)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint2(uint src, bool safe)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint2(K src)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint2(BitState src)
            => data = (byte)src;



        /// <summary>
        /// Queries an index-identified bit
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => test(this, pos);
        }

        public K Kind
        {
            [MethodImpl(Inline)]
            get => (K) data;
        }

        public T Content
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => data == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => data != 0;
        }

        /// <summary>
        /// Specifies whether the current value is the maximum value
        /// </summary>
        public bool IsMax
        {
            [MethodImpl(Inline)]
            get => data == MaxLiteral;
        }

        /// <summary>
        /// Specifies whether the current value is the minimum value
        /// </summary>
        public bool IsMin
        {
            [MethodImpl(Inline)]
            get => data == MinLiteral;
        }

        /// <summary>
        /// Renders the source value as as hexadecimal string
        /// </summary>
        [MethodImpl(Inline)]
        public string Format()
             => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(U rhs)
            => eq(this,rhs);

        public override bool Equals(object rhs)
            => rhs is U x && Equals(x);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public override int GetHashCode()
            => (int)Hash;

       [MethodImpl(Inline)]
        public static explicit operator U(uint3 src)
            => uint2(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint4 src)
            => uint2(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint5 src)
            => uint2(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint6 src)
            => uint2(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint7 src)
            => uint2(src);

        [MethodImpl(Inline)]
        public static implicit operator U(eight src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator uint3(U src)
            => new uint3(src.data);

        [MethodImpl(Inline)]
        public static implicit operator uint4(U src)
            => new uint4(src.data);

        [MethodImpl(Inline)]
        public static implicit operator uint5(U src)
            => new uint5(src.data);

        [MethodImpl(Inline)]
        public static implicit operator uint6(U src)
            => new uint6(src.data);

        [MethodImpl(Inline)]
        public static implicit operator uint7(U src)
            => new uint7(src.data);

        [MethodImpl(Inline)]
        public static implicit operator eight(U src)
            => new eight(src.data);

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new bit(src.data & 1);

        [MethodImpl(Inline)]
        public static implicit operator U(K src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator K(U src)
            => (K)src.data;

        [MethodImpl(Inline)]
        public static implicit operator U(Hex2Seq src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(X00 src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(X01 src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(X02 src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(X03 src)
            => (byte)src;

        /// <summary>
        /// Implicitly promotes a <see cref='U'> value to a <see cref='byte'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => (byte)src.data;

        /// <summary>
        /// Implicitly promotes a <see cref='U'> value to a <see cref='ushort'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => (ushort)src.data;

        /// <summary>
        /// Implicitly promotes a <see cref='U'> value to a <see cref='uint'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.data;

        /// <summary>
        /// Implicitly promotes a <see cref='U'> value to a <see cref='ulong'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.data;

        /// <summary>
        /// Implicitly promotes a <see cref='U'> value to a <see cref='int'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.data;

        /// <summary>
        /// Converts a <see cref='byte'> value to a <see cref='U'/> value, truncating as necessary
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(byte src)
            => create(W,src);

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => create(W,src);

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(ulong src)
            => create(W,src);

        [MethodImpl(Inline)]
        public static U @bool(bool src)
            => create(W,src);

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.data == 0;

        [MethodImpl(Inline)]
        public static U operator + (U x, U y)
            => add(x,y);

        [MethodImpl(Inline)]
        public static U operator - (U x, U y)
            => sub(x,y);

        [MethodImpl(Inline)]
        public static U operator * (U lhs, U rhs)
            => mul(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator / (U lhs, U rhs)
            => div(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator % (U lhs, U rhs)
            => mod(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator &(U lhs, U rhs)
            => and(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator |(U lhs, U rhs)
            => or(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator ^(U lhs, U rhs)
            => xor(lhs,rhs);

        [MethodImpl(Inline)]
        public static U operator >>(U lhs, int count)
            => srl(lhs, (byte)count);

        [MethodImpl(Inline)]
        public static U operator <<(U lhs, int count)
            => sll(lhs, (byte)count);

        [MethodImpl(Inline)]
        public static U operator ~(U src)
            => not(src);

        [MethodImpl(Inline)]
        public static U operator ++(U x)
            => inc(x);

        [MethodImpl(Inline)]
        public static U operator --(U x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bool operator ==(U lhs, U rhs)
            => eq(lhs,rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(U lhs, U rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static U operator < (U lhs, U rhs)
            => @bool(lhs.data < rhs.data);

        [MethodImpl(Inline)]
        public static U operator <= (U lhs, U rhs)
            => @bool(lhs.data <= rhs.data);

        [MethodImpl(Inline)]
        public static U operator > (U lhs, U rhs)
            => @bool(lhs.data > rhs.data);

        [MethodImpl(Inline)]
        public static U operator >= (U lhs, U rhs)
            => @bool(lhs.data >= rhs.data);

        /// <summary>
        /// Specifies the inclusive lower bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MinLiteral = 0;

        /// <summary>
        /// Specifies the inclusive upper bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MaxLiteral = 3;

        /// <summary>
        /// Specifies the bit-width of the <see cref='U'/> data type
        /// </summary>
        public const byte Width = 2;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='U'/>
        /// </summary>
        public const uint Mod = MaxLiteral + 1;

        /// <summary>
        /// Specifies a <see cref='U'/> bitwidth <see ref='W'/> representative
        /// </summary>
        public static W W => default;

        /// <summary>
        /// Specifies the <see cref='U'/> bit-width as a natural number
        /// </summary>
        public static N N => default;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => new U(MinLiteral,true);
        }

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => new U(MaxLiteral,true);
        }

        /// <summary>
        /// Specifies the <see cref='U'/> zero value
        /// </summary>
        public static U Zero
        {
            [MethodImpl(Inline)]
            get => new U(0,true);
        }

        /// <summary>
        /// Specifies the <see cref='U'/> one value
        /// </summary>
        public static U One
        {
            [MethodImpl(Inline)]
            get => new U(1,true);
        }

        public Span<bit> Bits
        {
            [MethodImpl(Inline)]
            get => bits(this);
        }
    }
}