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

    using S = eight;
    using W = W8;
    using K = BitSeq8;
    using T = System.Byte;
    using N = N8;

    /// <summary>
    /// Represents the value of a type-level octet and thus is an integer in the range [0,255]
    /// </summary>
    public readonly struct eight : IBitNumber<S,W,K,T>
    {
        public const byte BitCount = 8;

        internal readonly T data;

        [MethodImpl(Inline)]
        public eight(byte x)
            => data = x;

        [MethodImpl(Inline)]
        public eight(K x)
            => data =(byte)x;

        [MethodImpl(Inline)]
        internal eight(BitState src)
            => data = (byte)src;

        /// <summary>
        /// Queries the state of an index-identified bit
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

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public uint4 Lo
        {
            [MethodImpl(Inline)]
            get => lo(this);
        }

        public uint4 Hi
        {
            [MethodImpl(Inline)]
            get => hi(this);
        }

        [MethodImpl(Inline)]
        public eight WithLo(uint4 src)
            => movlo(src, this);

        [MethodImpl(Inline)]
        public eight WithHi(uint4 src)
            => movhi(src, this);

        [MethodImpl(Inline)]
        public bool Equals(S y)
            => data == y.data;


        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object y)
            => data.Equals(y);

        [MethodImpl(Inline)]
        public string Format()
             => format(this);

        public override string ToString()
            => Format();

       [MethodImpl(Inline)]
        public static implicit operator S(K src)
            => new S(src);

        [MethodImpl(Inline)]
        public static implicit operator K(S src)
            => (K)src.data;

        [MethodImpl(Inline)]
        public static S @bool(bool x)
            => x ? One : Zero;

        [MethodImpl(Inline)]
        public static bool operator true(S x)
            => x.data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(S x)
            => x.data == 0;

        [MethodImpl(Inline)]
        public static explicit operator bit(S src)
            => new bit(src.data & 1);

        [MethodImpl(Inline)]
        public static implicit operator S(byte src)
            => new S(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(S src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(S src)
            => (sbyte)src.data;

        [MethodImpl(Inline)]
        public static explicit operator short(S src)
            => (short)src.data;

        [MethodImpl(Inline)]
        public static implicit operator ushort(S src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator int(S src)
            => (int)src.data;

        [MethodImpl(Inline)]
        public static implicit operator uint(S src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator long(S src)
            => (long)src.data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(S src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator float(S src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator double(S src)
            => src.data;

        [MethodImpl(Inline)]
        public static S operator == (S x, S y)
            => @bool(x.data == y.data);

        [MethodImpl(Inline)]
        public static S operator != (S x, S y)
            => @bool(x.data != y.data);

        [MethodImpl(Inline)]
        public static S operator + (S x, S y)
            => wrap(x.data + y.data);

        [MethodImpl(Inline)]
        public static S operator - (S x, S y)
            => wrap(x.data - y.data);

        [MethodImpl(Inline)]
        public static S operator * (S x, S y)
            => wrap(x.data * y.data);

        [MethodImpl(Inline)]
        public static S operator / (S x, S y)
            => wrap(x.data / y.data);

        [MethodImpl(Inline)]
        public static S operator % (S x, S y)
            => wrap(x.data % y.data);

        [MethodImpl(Inline)]
        public static S operator < (S x, S y)
            => @bool(x.data < y.data);

        [MethodImpl(Inline)]
        public static S operator <= (S x, S y)
            => @bool(x.data <= y.data);

        [MethodImpl(Inline)]
        public static S operator > (S x, S y)
            => @bool(x.data > y.data);

        [MethodImpl(Inline)]
        public static S operator >= (S x, S y)
            => @bool(x.data >= y.data);

        [MethodImpl(Inline)]
        public static S operator & (S x, S y)
            => (S)(x.data & y.data);

        [MethodImpl(Inline)]
        public static S operator | (S x, S y)
            => wrap(x.data | y.data);

        [MethodImpl(Inline)]
        public static S operator ^ (S x, S y)
            => wrap(x.data ^ y.data);

        [MethodImpl(Inline)]
        public static S operator >> (S x, int y)
            => wrap(x.data >> y);

        [MethodImpl(Inline)]
        public static S operator << (S x, int y)
            => wrap(x.data << y);

        [MethodImpl(Inline)]
        public static S operator ~ (S src)
            => wrap(~ src.data);

        [MethodImpl(Inline)]
        public static S operator - (S src)
            => wrap(~src.data + 1);

        [MethodImpl(Inline)]
        public static S operator -- (S src)
            => dec(src);

        [MethodImpl(Inline)]
        public static S operator ++ (S src)
            => inc(src);

       public const T MinLiteral = 0;

        public const T MaxLiteral = byte.MaxValue;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='S'/>
        /// </summary>
        public const byte Width = 8;

        public const uint Mod = 256;

        public static W W => default;

        public static N N => default;

        public static S Zero => 0;

        public static S One => 1;

        /// <summary>
        /// Specifies the minimum <see cref='S'/> value
        /// </summary>
        public static S Min
        {
            [MethodImpl(Inline)]
            get => new S(MinLiteral);
        }

        /// <summary>
        /// Specifies the maximum <see cref='S'/> value
        /// </summary>
        public static S Max
        {
            [MethodImpl(Inline)]
            get => new S(MaxLiteral);
        }

        public Span<bit> Bits
        {
            [MethodImpl(Inline)]
            get => bits(this);
        }

        [MethodImpl(Inline)]
        static S wrap(int x)
            => new S((byte)x);
    }
}