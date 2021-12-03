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
        /// Partitions the first 15 bits of a 16-bit source into 5 target segments each with an effective width of 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x5(ushort src, ref byte dst)
        {
            seek32(dst, 0) = scatter(src, Lsb32x8x3);
            seek(dst, 4) = (byte)scatter((byte)(src >> 12), Lsb8x8x3);
            return ref dst;
        }
    }
}