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
        /// [11:0] => [11:9 | 8:6 | 5:3 | 2:0]
        /// Distributes the first 12 bits of a 16-bit over 4 8-bit segments, each of effective width of 3
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x4(ushort src, ref byte dst)
        {
            unpack3x3(src, ref dst);
            seek(dst, 3) = (byte)(src >> 9 & Lsb8x8x3);
            return ref dst;
        }
    }
}