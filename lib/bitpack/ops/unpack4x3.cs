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
        /// [11:0] => [11:8 | 7:4 | 3:0]
        /// Partitions the first 12 bits of the source value into 3 target segments each of effective width of 4
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack4x3(ushort src, ref byte dst)
        {
            seek(dst, 0) = (byte)((src >> 0) & Lsb8x8x4);
            seek(dst, 1) = (byte)((src >> 4) & Lsb8x8x4);
            seek(dst, 2) = (byte)((src >> 8) & Lsb8x8x4);
            return ref dst;
        }
    }
}