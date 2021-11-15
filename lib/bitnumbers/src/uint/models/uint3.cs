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

    using U = uint3;
    using K = BitSeq3;
    using W = W3;
    using T = System.Byte;
    using N = N3;

    /// <summary>
    /// Represents a value in the range [<see cef='MinLiteral'/>, <see cref='MaxLiteral'/>]
    /// </summary>
    public readonly struct uint3 : IBitNumber<U,W,K,T>
    {
        public const byte BitCount = 3;

        internal readonly T data;

        [MethodImpl(Inline)]
        internal uint3(eight src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(byte src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(byte src, bool @unchecked)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint3(sbyte src)
            => data = (byte)((uint)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(short src)
            => data = (byte)((uint)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(ushort src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(int x)
            => data = (byte)((uint)x & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(uint src)
            => data = (byte)(src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(long src)
            => data = (byte)((uint)src & MaxLiteral);

        [MethodImpl(Inline)]
        internal uint3(uint src, bool safe)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint3(K src)
            => data = (byte)src;

        [MethodImpl(Inline)]
        internal uint3(BitState src)
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
        public static implicit operator eight(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator uint5(U src)
            => new uint5(src.data);

        [MethodImpl(Inline)]
        public static implicit operator uint4(U src)
            => new uint4(src.data);

        [MethodImpl(Inline)]
        public static implicit operator uint6(U src)
            => new uint6(src.data);

        [MethodImpl(Inline)]
        public static implicit operator U(eight src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(K src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator K(U src)
            => (K)src.data;

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new bit(src.data & 1);

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => (byte)src.data;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => (ushort)src.data;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.data;

        /// <summary>
        /// Converts a 3-bit integer to an unsigned 63-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.data;

        /// <summary>
        /// Converts a 3-bit integer to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.data;

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(byte src)
            => uint3(src);

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator U(uint src)
            => uint3(src);

        /// <summary>
        /// Creates a 3-bit integer from the least four bits of the source operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static explicit operator U(ulong src)
            => uint3(src);

        [MethodImpl(Inline)]
        public static U @bool(bool a)
            => uint3(a);

        [MethodImpl(Inline)]
        public static bool operator true(U a)
            => a.data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U a)
            => a.data == 0;

        [MethodImpl(Inline)]
        public static U operator + (U a, U b)
            => add(a,b);

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
            => wrap3(~src.data & MaxLiteral);

        [MethodImpl(Inline)]
        public static U operator ++(U x)
            => inc(x);

        [MethodImpl(Inline)]
        public static U operator --(U x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bool operator ==(U a, U rhs)
            => eq(a,rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(U a, U rhs)
            => !a.Equals(rhs);

        [MethodImpl(Inline)]
        public static U operator < (U a, U rhs)
            => @bool(a.data < rhs.data);

        [MethodImpl(Inline)]
        public static U operator <= (U a, U rhs)
            => @bool(a.data <= rhs.data);

        [MethodImpl(Inline)]
        public static U operator > (U a, U rhs)
            => @bool(a.data > rhs.data);

        [MethodImpl(Inline)]
        public static U operator >= (U a, U rhs)
            => @bool(a.data >= rhs.data);

        /// <summary>
        /// Specifies the inclusive lower bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MinLiteral = 0;

        /// <summary>
        /// Specifies the inclusive upper bound of the <see cref='U'/> data type as a literal value
        /// </summary>
        public const T MaxLiteral = 7;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 3;

        /// <summary>
        /// Specifies the count of unique values representable by a <see cref='U'/>
        /// </summary>
        public const byte Mod = (byte)MaxLiteral + 1;

        /// <summary>
        /// Specifies the <see cref='Width'/> values as a type-level natural
        /// </summary>
        public static N N => default;

        public static W W => default;

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