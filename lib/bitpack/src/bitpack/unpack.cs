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
        /// <summary>
        /// Unpacks a specified number source bytes to a corresponding count of 32-bit target values
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bytes to pack</param>
        /// <param name="dst">The target reference, of size at least 256*count bits</param>
        [MethodImpl(Inline), Op]
        public static void unpack(in byte src, int count, ref uint dst)
        {
            var buffer = z64;
            ref var tmp = ref uint8(ref buffer);
            for(var i=0; i<count; i++)
            {
                unpack1x8(skip(src, i), ref tmp);
                vpack.vinflate8x256x32u(tmp).StoreTo(ref seek(dst, i*8));
            }
        }

        /// <summary>
        /// Unpacks a specified number source bytes to a corresponding count of 256-bit blocks comprising 32-bit target values
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="blocks">The number of bytes to pack</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack(in byte src, int blocks, in SpanBlock256<uint> dst)
            => unpack(src, blocks, ref dst.First);
    }
}