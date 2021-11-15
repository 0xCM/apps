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
        /// Partitions a 32-bit source value into 4 segments of width 8
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x4(uint src, ref byte dst)
            => seek32(dst, 0) = src;
    }
}