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

    using U = uint5;
    using W = W5;
    using K = BitSeq5;
    using T = System.Byte;
    using N = N5;

    /// <summary>
    /// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxLiteral'/>]
    /// </summary>
    public readonly struct uint5 : IBitNumber<U,W,K,T>
    {
        public const byte BitCount = 5;

        internal readonly T data;

        [MethodImpl(Inline)]
        internal uint5(eight src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(byte src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(byte src, bool @unchecked)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint5(sbyte src)
            => data = (byte)((uint)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(short src)
            => data = (byte)((uint)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(ushort src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(int x)
            => data = (byte)((uint)x & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(uint src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(long src)
            => data = (byte)((uint)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint5(uint src, bool safe)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint5(K src)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint5(BitState src)
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

        [MethodImpl(Inline)]
        public string Format(N2 b)
            => BitRender.gformat(data);

        [MethodImpl(Inline)]
        public string Format(N16 b)
            => data.FormatHex(false, false);

        [MethodImpl(Inline)]
        public string Format()
             => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(U y)
            => eq(this,y);

        public override bool Equals(object y)
            => y is U x && Equals(x);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator eight(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator U(eight src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(K src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator K(U src)
            => (K)src.data;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => (byte)src.data;

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new bit(src.data & 1);

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => (ushort)src.data;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.data;

        /// <summary>
        /// Converts a 5-bit integer to an unsigned 65-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.data;

        /// <summary>
        /// Converts a 5-bit integer to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.data;

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(byte src)
            => uint5(src);

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => uint5(src);

        /// <summary>
        /// Creates a 5-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(ulong src)
            => uint5(src);

        [MethodImpl(Inline)]
        public static U @bool(bool src)
            => uint5(src);

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
        public static U operator * (U x, U y)
            => mul(x,y);

        [MethodImpl(Inline)]
        public static U operator / (U x, U y)
            => div(x,y);

        [MethodImpl(Inline)]
        public static U operator % (U x, U y)
            => mod(x,y);

        [MethodImpl(Inline)]
        public static U operator &(U x, U y)
            => and(x,y);

        [MethodImpl(Inline)]
        public static U operator |(U x, U y)
            => or(x,y);

        [MethodImpl(Inline)]
        public static U operator ^(U x, U y)
            => xor(x,y);

        [MethodImpl(Inline)]
        public static U operator >>(U x, int count)
            => srl(x, (byte)count);

        [MethodImpl(Inline)]
        public static U operator <<(U x, int count)
            => sll(x, (byte)count);

        [MethodImpl(Inline)]
        public static U operator ~(U src)
            => wrap5(~src.data & MaxLiteral);

        [MethodImpl(Inline)]
        public static U operator ++(U x)
            => inc(x);

        [MethodImpl(Inline)]
        public static U operator --(U x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bool operator ==(U x, U y)
            => eq(x,y);

        [MethodImpl(Inline)]
        public static bool operator !=(U x, U y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static U operator < (U x, U y)
            => @bool(x.data < y.data);

        [MethodImpl(Inline)]
        public static U operator <= (U x, U y)
            => @bool(x.data <= y.data);

        [MethodImpl(Inline)]
        public static U operator > (U x, U y)
            => @bool(x.data > y.data);

        [MethodImpl(Inline)]
        public static U operator >= (U x, U y)
            => @bool(x.data >= y.data);

        /// <summary>
        /// Specifies the inclusive lower bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MinLiteral = 0;

        /// <summary>
        /// Specifies the inclusive upper bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MaxLiteral = 31;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 5;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='U'/>
        /// </summary>
        public const byte Mod = (byte)MaxLiteral + 1;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level width
        /// </summary>
        public static W W => default;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level natural
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