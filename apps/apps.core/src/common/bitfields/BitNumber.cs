//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitNumber : IBitNumber<BitNumber,ulong>
    {
        [MethodImpl(Inline)]
        public static BitNumber<T> generic<T>(byte n, T src)
            where T : unmanaged
                => new BitNumber<T>(n, src);

        [MethodImpl(Inline)]
        public static BitNumber<T> generic<T>(int n, T src)
            where T : unmanaged
                => new BitNumber<T>((byte)n, src);

        [MethodImpl(Inline)]
        public static BitNumber<T> generic<T>(uint n, T src)
            where T : unmanaged
                => new BitNumber<T>((byte)n, src);

        [MethodImpl(Inline)]
        public static BitNumber<N,T> generic<N,T>(N n, T src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => new BitNumber<N,T>(src);

        [MethodImpl(Inline)]
        public static uint3 define(N3 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint4 define(N4 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint5 define(N5 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint6 define(N6 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint7 define(N7 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static uint8b define(N8 n, byte src)
            => src;

        [MethodImpl(Inline)]
        public static BitNumber define(byte n, ulong src)
            => new BitNumber(n,src);

        static string format<T>(W8 w, T src)
            where T : unmanaged, IBitNumber
        {
            var width = src.Width;
            var i=0u;
            Span<char> buffer = stackalloc char[8];
            BitRender.render8(bw8(src), ref i, buffer);
            var chars = slice(buffer, buffer.Length - width);
            return new string(chars);
        }

        public static string format<T>(T src)
            where T : unmanaged, IBitNumber
        {
            var width = src.Width;
            var dst = EmptyString;
            var i=0u;
            if(width <= 8)
                dst = format(w8,src);
            else if(width <= 16)
            {
                Span<char> buffer = stackalloc char[16];
                BitRender.render16(bw16(src), ref i, buffer);
                var chars = slice(buffer, buffer.Length - width);
                dst = new string(chars);
            }
            else if(width <= 32)
            {
                Span<char> buffer = stackalloc char[32];
                BitRender.render32(bw32(src), ref i, buffer);
                var chars = slice(buffer, buffer.Length - width);
                dst = new string(chars);
            }
            else
            {
                Span<char> buffer = stackalloc char[64];
                BitRender.render64(bw64(src), ref i, buffer);
                var chars = slice(buffer, buffer.Length - width);
                dst = new string(chars);
            }

            return dst;
        }

        [MethodImpl(Inline)]
        static void unpack<T>(T src, Span<bit> dst)
            where T : unmanaged, IBitNumber
        {
            var width = src.Width;
            if(size<T>() == 8)
                Bitfields.unpack8x1(u8(src), dst);
            else if(size<T>() <= 16)
                Bitfields.unpack16x1(u16(src), dst);
            else if(size<T>() <= 32)
                Bitfields.unpack64x1(u32(src), dst);
            else
                Bitfields.unpack64x1(u64(src), dst);
        }

        public static Span<bit> unpack<T,B>(T src, B dst)
            where T : unmanaged, IBitNumber
            where B : unmanaged, IStorageBlock<B>
        {
            var buffer = recover<bit>(dst.Bytes);
            unpack(src, buffer);
            return slice(buffer, 0, src.Width);
        }

        const byte WidthOffset = 56;

        const ulong WidthMask = 0xFF000000_00000000;

        const ulong ValueMask = ~WidthMask;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public BitNumber(byte n, ulong src)
        {
            Data = (src & WidthMask) | ((ulong)n << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint1 data)
        {
            Data = (ulong)data | ((ulong)1 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(bit data)
        {
            Data = (ulong)data | ((ulong)1 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint2 data)
        {
            Data = (ulong)data | ((ulong)2 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint3 data)
        {
            Data = (ulong)data | ((ulong)3 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint4 data)
        {
            Data = (ulong)data | ((ulong)4 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint5 data)
        {
            Data = (ulong)data | ((ulong)5 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint6 data)
        {
            Data = (ulong)data | ((ulong)6 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint7 data)
        {
            Data = (ulong)data | ((ulong)7 << WidthOffset);
        }

        [MethodImpl(Inline)]
        public BitNumber(uint8b data)
        {
            Data = (ulong)data | ((ulong)8 << WidthOffset);
        }

        public ulong Value
        {
            [MethodImpl(Inline)]
            get => Data & ValueMask;
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> WidthOffset);
        }

        bit Val1
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint2 Val2
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint3 Val3
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint4 Val4
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint5 Val5
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint6 Val6
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint7 Val7
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        uint8b Val8
        {
            [MethodImpl(Inline)]
            get => (byte)Data;
        }

        public void Bits<B>(B dst)
            where B : unmanaged, IStorageBlock<B>
                => BitNumber.unpack(this,dst);

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
        }

        public string Format()
            => BitNumber.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(BitNumber src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(BitNumber src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint1 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(bit src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint2 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint3 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint4 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint5 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint6 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint7 src)
            => new BitNumber(src);

        [MethodImpl(Inline)]
        public static implicit operator BitNumber(uint8b src)
            => new BitNumber(src);
    }
}