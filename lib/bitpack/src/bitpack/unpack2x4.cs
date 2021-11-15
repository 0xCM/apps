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
    using static BitMaskLiterals;

    partial struct BitPack
    {
        /// <summary>
        /// [7:0] => [7:6 | 5:4 | 3:2 | 1:0]
        /// Evenly partitions an 8-bit source value into 4 target segments each of effective width of 2
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target memory location</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack2x4(byte src, ref byte dst)
        {
            seek(dst, 0) = (byte)(src >> 0 & Lsb8x8x2);
            seek(dst, 1) = (byte)(src >> 2 & Lsb8x8x2);
            seek(dst, 2) = (byte)(src >> 4 & Lsb8x8x2);
            seek(dst, 3) = (byte)(src >> 6 & Lsb8x8x2);
            return ref dst;
        }
    }
}