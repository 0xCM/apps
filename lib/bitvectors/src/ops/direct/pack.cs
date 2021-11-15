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

    partial class BitVector
    {
        [MethodImpl(Inline), Op]
        public static void upack4x4(ushort src, Span<BitVector4> dst)
        {
            ref var target = ref @as<BitVector4,byte>(first(dst));
            BitPack.unpack4x4(src, ref target);
        }

        [MethodImpl(Inline), Op]
        public static void upack4x8(uint src, Span<BitVector4> dst)
        {
            ref var target = ref @as<BitVector4,byte>(first(dst));
            BitPack.unpack4x8(src, ref target);
        }

        [MethodImpl(Inline), Op]
        public static void part8x4(uint src, Span<BitVector8> dst)
        {
            ref var target = ref @as<BitVector8,byte>(first(dst));
            BitPack.unpack8x4(src, ref target);
        }

        [MethodImpl(Inline), Op]
        public static void pack16x2(uint src, Span<BitVector16> dst)
        {
            ref var target = ref @as<BitVector16,ushort>(first(dst));
            BitPack.unpack16x2(src, ref target);
        }

        [MethodImpl(Inline), Op]
        public static void part8x8(ulong src, Span<BitVector8> dst)
        {
            ref var target = ref @as<BitVector8,byte>(first(dst));
            BitPack.unpack8x8(src, ref target);
        }

        [MethodImpl(Inline), Op]
        public static void pack16x2(uint src, Span<BitVector<ushort>> dst)
        {
            ref var target = ref @as<BitVector<ushort>,ushort>(first(dst));
            BitPack.unpack16x2(src, ref target);
        }

        [MethodImpl(Inline), Op]
        public static void pack8x8(ulong src, Span<BitVector<byte>> dst)
        {
            ref var target = ref @as<BitVector<byte>,byte>(first(dst));
            BitPack.unpack8x8(src, ref target);
        }
    }
}