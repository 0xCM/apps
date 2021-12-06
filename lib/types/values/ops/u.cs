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

    using Types;

    partial struct TV
    {
        [MethodImpl(Inline), Op]
        public static u1<bit> u1(bit src)
            => new u1<bit>(src);

        [MethodImpl(Inline), Op]
        public static u1<byte> u1(byte src)
            => new u1<byte>(src);

        [MethodImpl(Inline), Op]
        public static u2<byte> u2(byte src)
            => new u2<byte>(src);

        [MethodImpl(Inline), Op]
        public static u3<byte> u3(byte src)
            => new u3<byte>(src);

        [MethodImpl(Inline), Op]
        public static u4<byte> u4(byte src)
            => new u4<byte>(src);

        [MethodImpl(Inline), Op]
        public static u5<byte> u5(byte src)
            => new u5<byte>(src);

        [MethodImpl(Inline), Op]
        public static u6<byte> u6(byte src)
            => new u6<byte>(src);

        [MethodImpl(Inline), Op]
        public static u8 u8(byte src)
            => new u8(src);

        [MethodImpl(Inline), Op]
        public static u16<ushort> u16(ushort src)
            => new u16<ushort>(src);

        [MethodImpl(Inline), Op]
        public static u32<uint> u32(uint src)
            => new u32<uint>(src);

        [MethodImpl(Inline), Op]
        public static u64<ulong> u64(ulong src)
            => new u64<ulong>(src);

        [MethodImpl(Inline), Op]
        public static uN<T> uN<T>(uint n, T value = default)
            where T : unmanaged
                => new uN<T>(n,value);
    }
}
