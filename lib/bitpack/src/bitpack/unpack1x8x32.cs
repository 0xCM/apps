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

    partial struct BitPack
    {
        [MethodImpl(Inline), Unpack]
        public static ref ulong unpack1x8x32(uint src, ref ulong dst)
        {
            unpack1x8x16((ushort)src, ref dst);
            unpack1x16((ushort)(src >> 16), ref seek8(dst, 16));
            return ref dst;
        }

        /// <summary>
        /// Unpacks 8 source bits over 8 32-bit target segments
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="buffer">The intermediate buffer</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x8x32(byte src, Span<uint> dst)
        {
            var buffer = z64;
            ref var tmp = ref uint8(ref buffer);
            ref var lead = ref first(dst);
            unpack1x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp).StoreTo(ref lead);
        }
    }
}