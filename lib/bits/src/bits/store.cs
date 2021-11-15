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
    using static math;

    partial class bits
    {
        [MethodImpl(Inline), Op]
        public static ref byte store(byte i0, byte i1, in byte src, ref byte dst)
        {
            dst = or(dst, sll(src, u8(i1 - i0 + 1)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort store(byte i0, byte i1, in ushort src, ref ushort dst)
        {
            dst = or(dst, sll(src, u8(i1 - i0 + 1)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref uint store(byte i0, byte i1, in uint src, ref uint dst)
        {
            dst = or(dst, sll(src, u8(i1 - i0 + 1)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ulong store(byte i0, byte i1, in ulong src, ref ulong dst)
        {
            dst = or(dst, sll(src, u8(i1 - i0 + 1)));
            return ref dst;
        }
    }
}
