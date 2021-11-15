//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;
    using static BitNumbers;

    using U = uint24;
    using W = W24;
    using T = System.UInt32;
    using N = N24;
    using L = Limits24u;

    using api = BitNumbers;

    /// <summary>
    /// Represents the value of an unsigned integer of bit-width 24
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size)]
    public struct uint24 : IBitNumber<U,W,T>
    {
        internal ushort Lo;

        internal byte Hi;

        internal uint data
        {
            [MethodImpl(Inline)]
            get => (uint)Lo | ((uint)Hi << 16);

            [MethodImpl(Inline)]
            set => api.update(value, ref this);
        }

        public const L MinVal = L.Min;

        public const L MaxVal = L.Max;

        public const uint Mask = (T)MaxVal;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 24;

        public const byte Size = 3;

        public const uint Mod = (T)MaxVal + 1u;

        public static W W => default;

        public static N N => default;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => @as<L,U>(MinVal);
        }

        public T Content
        {
            [MethodImpl(Inline)]
            get => this;
        }

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => @as<L,U>(MaxVal);
        }

        /// <summary>
        /// Specifies  <see cref='U'/> type's zero-value
        /// </summary>
        public static U Zero
        {
            [MethodImpl(Inline)]
            get => @as<T,U>(0);
        }

        /// <summary>
        /// Specifies <see cref='U'/> type's one-value
        /// </summary>
        public static U One
        {
            [MethodImpl(Inline)]
            get => @as<T,U>(1);
        }

        [MethodImpl(Inline)]
        public static U @bool(bool x)
            => @as<uint,U>(core.u32(x));

        /// <summary>
        /// Queries the state of an index-identified bit
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(data, pos);
        }

        T Value
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
            get => data == (T)MaxVal;
        }

        /// <summary>
        /// Specifies whether the current value is the minimum value
        /// </summary>
        public bool IsMin
        {
            [MethodImpl(Inline)]
            get => data == (T)MinVal;
        }

        [MethodImpl(Inline)]
        internal uint24(T src)
            : this() => data = src & (T)MaxVal;

        [MethodImpl(Inline)]
        public uint24(bool src)
            : this() => Lo = @byte(src);

        [MethodImpl(Inline)]
        public uint24(byte src)
            : this() => Lo = src;

        [MethodImpl(Inline)]
        internal uint24(sbyte src)
            : this() => Lo = (byte)src;

        [MethodImpl(Inline)]
        internal uint24(short src)
            : this() => Lo = (ushort)src;

        [MethodImpl(Inline)]
        internal uint24(ushort src)
            : this() => Lo = src;

        [MethodImpl(Inline)]
        internal uint24(int src)
            : this() => data = (T)src & (T)MaxVal;

        [MethodImpl(Inline)]
        internal uint24(long src)
            : this() => data = (T)src & (T)MaxVal;

        [MethodImpl(Inline)]
        internal uint24(ulong src)
            : this() => data = (T)src & (T)MaxVal;

        [MethodImpl(Inline)]
        internal uint24(T src, bool @unchecked)
            : this() => data = src;

        [MethodImpl(Inline)]
        static U wrap(T x)
            => new U(x, true);

        [MethodImpl(Inline)]
        static U reduce(uint x)
            => new U(x % Mod);

        [MethodImpl(Inline)]
        static U dec(U x)
        {
            var y = (long)x.data - 1;
            return y < 0 ? Max : new U((T)y, true);
        }

        [MethodImpl(Inline)]
        public bool Equals(U rhs)
            => data == rhs.data;

        [Ignore]
        bool IEquatable<U>.Equals(U rhs)
            => data == rhs.data;

        bool IBitNumber.IsNonZero
        {
            [Ignore]
            get => IsNonZero;
        }

        bool IBitNumber.IsZero
        {
            [Ignore]
            get => IsZero;
        }

        uint IHashed.Hash
        {
            [Ignore]
            get => data;
        }

        [Ignore]
        public override int GetHashCode()
            => (int)data;

        [Ignore]
        public override bool Equals(object rhs)
            => data.Equals(rhs);

        [MethodImpl(Inline)]
        public string Format()
             => format(this);

        public override string ToString()
            => Format();

        public Span<bit> Bits
            => throw new NotImplementedException();

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.data == 0;

        [MethodImpl(Inline)]
        public static implicit operator U(byte src)
            => @as<T,U>(Mask & (T)src);

        [MethodImpl(Inline)]
        public static implicit operator T(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(U src)
            => (sbyte)src.data;

        [MethodImpl(Inline)]
        public static explicit operator short(U src)
            => (short)src.data;

        [MethodImpl(Inline)]
        public static explicit operator ushort(U src)
            => (ushort)src.data;

        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.data;

        [MethodImpl(Inline)]
        public static implicit operator long(U src)
            => (long)src.data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static U operator == (U lhs, U rhs)
            => new U(lhs.data == rhs.data);

        [MethodImpl(Inline)]
        public static U operator != (U lhs, U rhs)
            => new U(lhs.data != rhs.data);

        [MethodImpl(Inline)]
        public static U operator < (U lhs, U rhs)
            => new U(lhs.data < rhs.data);

        [MethodImpl(Inline)]
        public static U operator <= (U lhs, U rhs)
            => new U(lhs.data <= rhs.data);

        [MethodImpl(Inline)]
        public static U operator > (U lhs, U rhs)
            => new U(lhs.data > rhs.data);

        [MethodImpl(Inline)]
        public static U operator >= (U lhs, U rhs)
            => new U(lhs.data >= rhs.data);

        [MethodImpl(Inline)]
        public static U operator - (U src)
            => new U(~src.data + 1u);

        [MethodImpl(Inline)]
        public static U operator -- (U src)
            => api.dec(src);

        [MethodImpl(Inline)]
        public static U operator ++ (in U src)
            => api.inc(src);

        [MethodImpl(Inline)]
        public static U operator + (U lhs, U rhs)
            => reduce(lhs.data + rhs.data);

        [MethodImpl(Inline)]
        public static U operator - (U lhs, U rhs)
            => reduce(lhs.data - rhs.data);

        [MethodImpl(Inline)]
        public static U operator * (U lhs, U rhs)
            => reduce(lhs.data * rhs.data);

        [MethodImpl(Inline)]
        public static U operator / (U lhs, U rhs)
            => wrap(lhs.data / rhs.data);

        [MethodImpl(Inline)]
        public static U operator % (U lhs, U rhs)
            => wrap(lhs.data % rhs.data);

        [MethodImpl(Inline)]
        public static U operator & (U lhs, U rhs)
            => (U)(lhs.data & rhs.data);

        [MethodImpl(Inline)]
        public static U operator | (U lhs, U rhs)
            => wrap(lhs.data | rhs.data);

        [MethodImpl(Inline)]
        public static U operator ^ (U lhs, U rhs)
            => wrap(lhs.data ^ rhs.data);

        [MethodImpl(Inline)]
        public static U operator >> (U lhs, int rhs)
            => wrap(lhs.data >> rhs);

        [MethodImpl(Inline)]
        public static U operator << (U lhs, int rhs)
            => wrap(lhs.data << rhs);

        [MethodImpl(Inline)]
        public static U operator ~ (U src)
            => wrap(~src.data);
    }
}