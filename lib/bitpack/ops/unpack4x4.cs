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
        /// [15:0] => [ 15:12 | 11:8 | 7:4 | 3:0]
        /// Distributes 4 4-bit source segments over 4 8-bit targets
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack4x4(ushort src, ref byte dst)
        {
            seek32(dst, 0) = scatter(src, Lsb32x8x4);
            return ref dst;
        }
    }
}