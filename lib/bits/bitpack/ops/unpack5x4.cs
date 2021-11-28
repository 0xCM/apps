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
    using static BitMasks;
    using static BitMaskLiterals;

    partial struct BitPack
    {
        /// <summary>
        /// Partitions the first 20 bits of a 32-bit source value into 4 segments of effective width 5
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack5x4(uint src, ref byte dst)
        {
            seek32(dst, 0) = scatter(src, Lsb32x8x5);
            return ref dst;
        }
    }
}