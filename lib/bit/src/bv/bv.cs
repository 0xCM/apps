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

    [ApiHost]
    public readonly partial struct BV
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static bit state<T>(in T src, uint pos)
            where T : unmanaged, IIndexedBits
        {
            var b = core.bytes(src);
            var i = pos / 8u;
            var j = (byte)(pos % 8u);
            return bit.test(skip(b,i),j);
        }

        [MethodImpl(Inline), Op]
        public static void state<T>(bit src, uint pos, ref T dst)
            where T : unmanaged, IIndexedBits
        {
            var data = core.bytes(src);
            var i = pos / 8u;
            var j = (byte)(pos % 8u);
            bit.set(ref seek(data,i),j,src);
        }

        [MethodImpl(Inline), Op]
        public static bv1 bv(N1 n, byte src)
            => new bv1(src);

        [MethodImpl(Inline), Op]
        public static bv2 bv(N2 n, byte src)
            => new bv2(src);

        [MethodImpl(Inline), Op]
        public static bv3 bv(N3 n,byte src)
            => new bv3(src);

        [MethodImpl(Inline), Op]
        public static bv4 bv(N4 n,byte src)
            => new bv4(src);

        [MethodImpl(Inline), Op]
        public static bv5 bv(N5 n,byte src)
            => new bv5(src);

        [MethodImpl(Inline), Op]
        public static bv6 bv(N6 n,byte src)
            => new bv6(src);

        [MethodImpl(Inline), Op]
        public static bv7 bv(N7 n,byte src)
            => new bv7(src);

        [MethodImpl(Inline), Op]
        public static bv8 bv(N8 n,byte src)
            => new bv8(src);

        [MethodImpl(Inline), Op]
        public static bv16 bv(N16 n, ushort src)
            => new bv16(src);

        [MethodImpl(Inline), Op]
        public static bv32 bv(N32 n, uint src)
            => new bv32(src);

        [MethodImpl(Inline), Op]
        public static bv64 bv(N64 n, ulong src)
            => new bv64(src);

        [MethodImpl(Inline), Op]
        public static bv128 bv(N128 n, in ByteBlock16 src)
            => new bv128(src);

        [MethodImpl(Inline), Op]
        public static bv256 bv(N256 n, in ByteBlock32 src)
            => new bv256(src);

        [MethodImpl(Inline), Op]
        public static bv512 bv(N512 n, in ByteBlock64 src)
            => new bv512(src);

        [MethodImpl(Inline), Op]
        public static bv1024 bv(N1024 n, in ByteBlock128 src)
            => new bv1024(src);

        [MethodImpl(Inline), Op]
        public static bv1 bv(N1 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv2 bv(N2 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv3 bv(N3 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv4 bv(N4 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv5 bv(N5 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv6 bv(N6 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv7 bv(N7 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv8 bv(N8 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv16 bv(N16 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv32 bv(N32 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv64 bv(N64 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv128 bv(N128 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv256 bv(N256 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv512 bv(N512 n)
            => default;

        [MethodImpl(Inline), Op]
        public static bv1024 bv(N1024 n)
            => default;
    }
}