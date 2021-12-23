//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Expr;

    using static Root;

    partial struct expr
    {
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