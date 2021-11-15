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
        /// [31:0] => [31:16 | 15:0]
        /// Partitions a 32-bit source value into 2 segments of width 16
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x2(uint src, ref ushort dst)
            => seek32(dst,0) = src;
    }
}