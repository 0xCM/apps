//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
    [DataType("u<w:24>", Width, 24), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct uint24
    {
        byte B0;

        byte B1;

        byte B2;

        [MethodImpl(Inline)]
        public uint24(byte b0, byte b1, byte b2)
        {
            B0 = b0;
            B1 = b1;
            B2 = b2;
        }

        [MethodImpl(Inline)]
        public void Split(out byte b0, out byte b1, out byte b2)
        {
            b0 = B0;
            b1 = B1;
            b2 = B2;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => core.bytes(this);
        }


        [MethodImpl(Inline)]
        public ref byte Seg(byte i)
            =>  ref seek(Bytes,i);

        [MethodImpl(Inline)]
        public ref byte Seg(N0 n)
            =>  ref seek(Bytes,0);

        [MethodImpl(Inline)]
        public ref byte Seg(N1 n)
            =>  ref seek(Bytes,1);

        [MethodImpl(Inline)]
        public ref byte Seg(N2 n)
            =>  ref seek(Bytes,2);

        internal uint data
        {
            [MethodImpl(Inline)]
            get =>api.join(B0, B1, B2);

            [MethodImpl(Inline)]
            set => api.update(value, ref this);
        }

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
            get => data == (T)MaxValue;
        }

        /// <summary>
        /// Specifies whether the current value is the minimum value
        /// </summary>
        public bool IsMin
        {
            [MethodImpl(Inline)]
            get => data == (T)MinValue;
        }

        [MethodImpl(Inline)]
        internal uint24(T src)
            : this() => data = src & (T)MaxValue;

        [MethodImpl(Inline)]
        public uint24(bool src)
        {
            B0 = @byte(src);
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        public uint24(bit src)
        {
            B0 = @byte(src);
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        public uint24(byte src)
        {
            B0 = src;
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(sbyte src)
        {
            B0 = (byte)src;
            B1 = 0;
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(short src)
        {
            B0 = (byte)src;
            B1 = (byte)(((uint)(byte)src) << 8);
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(ushort src)
        {
            B0 = (byte)src;
            B1 = (byte)(((uint)(byte)src) << 8);
            B2 = 0;
        }

        [MethodImpl(Inline)]
        internal uint24(int src)
            : this() => data = (T)src & (T)MaxValue;

        [MethodImpl(Inline)]
        internal uint24(long src)
            : this() => data = (T)src & (T)MaxValue;

        [MethodImpl(Inline)]
        internal uint24(ulong src)
            : this() => data = (T)src & (T)MaxValue;

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
        public bool Equals(U b)
            => data == b.data;

        [Ignore]
        public override int GetHashCode()
            => (int)data;

        [Ignore]
        public override bool Equals(object src)
            => src is uint24 x && Equals(x);

        [MethodImpl(Inline)]
        public string Format()
             => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.data == 0;

        [MethodImpl(Inline)]
        public static implicit operator U(bit src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(bool src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint1 src)
            => new U((bit)src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint2 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint3 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint4 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint5 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint6 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint7 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(uint8b src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(Hex8 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(Hex16 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(byte src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(ushort src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator U(short src)
            => new U(src);

        [MethodImpl(Inline)]
        public static explicit operator U(uint src)
            => new U(src);

        [MethodImpl(Inline)]
        public static explicit operator U(Hex32 src)
            => new U(src);

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => (bit)src.data;

        [MethodImpl(Inline)]
        public static explicit operator bool(U src)
            => (bit)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint1(U src)
            => (uint1)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint2(U src)
            => (uint2)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint3(U src)
            => (uint3)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint4(U src)
            => (uint4)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint5(U src)
            => (uint5)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint6(U src)
            => (uint6)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint7(U src)
            => (uint7)src.data;

        [MethodImpl(Inline)]
        public static explicit operator uint8b(U src)
            => (uint8b)src.data;

        [MethodImpl(Inline)]
        public static explicit operator byte(U src)
            => (byte)src.data;

        [MethodImpl(Inline)]
        public static explicit operator Hex8(U src)
            => (Hex8)src.data;

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
        public static explicit operator Hex16(U src)
            => (Hex16)src.data;

        [MethodImpl(Inline)]
        public static implicit operator int(U src)
            => (int)src.data;

        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator long(U src)
            => (long)src.data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static U operator == (U a, U b)
            => new U(a.data == b.data);

        [MethodImpl(Inline)]
        public static U operator != (U a, U b)
            => new U(a.data != b.data);

        [MethodImpl(Inline)]
        public static U operator < (U a, U b)
            => new U(a.data < b.data);

        [MethodImpl(Inline)]
        public static U operator <= (U a, U b)
            => new U(a.data <= b.data);

        [MethodImpl(Inline)]
        public static U operator > (U a, U b)
            => new U(a.data > b.data);

        [MethodImpl(Inline)]
        public static U operator >= (U a, U b)
            => new U(a.data >= b.data);

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
        public static U operator + (U a, U b)
            => reduce(a.data + b.data);

        [MethodImpl(Inline)]
        public static U operator - (U a, U b)
            => reduce(a.data - b.data);

        [MethodImpl(Inline)]
        public static U operator * (U a, U b)
            => reduce(a.data * b.data);

        [MethodImpl(Inline)]
        public static U operator / (U a, U b)
            => wrap(a.data / b.data);

        [MethodImpl(Inline)]
        public static U operator % (U a, U b)
            => wrap(a.data % b.data);

        [MethodImpl(Inline)]
        public static U operator & (U a, U b)
            => (U)(a.data & b.data);

        [MethodImpl(Inline)]
        public static U operator | (U a, U b)
            => wrap(a.data | b.data);

        [MethodImpl(Inline)]
        public static U operator ^ (U a, U b)
            => wrap(a.data ^ b.data);

        [MethodImpl(Inline)]
        public static U operator >> (U a, int b)
            => wrap(a.data >> b);

        [MethodImpl(Inline)]
        public static U operator << (U a, int b)
            => wrap(a.data << b);

        [MethodImpl(Inline)]
        public static U operator ~ (U src)
            => wrap(~src.data);

        public const L MinValue = L.Min;

        public const L MaxValue = L.Max;

        public const T Mask = (T)MaxValue;

        public const byte Width = 24;

        public const byte Size = 3;

        public const uint Mod = (T)MaxValue + 1u;

        public static W W => default;

        public static N N => default;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => @as<L,U>(MinValue);
        }

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => @as<L,U>(MaxValue);
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
    }
}