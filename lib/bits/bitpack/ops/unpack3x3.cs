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
        /// [8:0] => [8:6 | 5:3 | 2:0]
        /// Partitions the first 9 bits of a 16-bit source into 3 target segments each with an effective width of 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x3(ushort src, ref byte dst)
        {
            unpack3x2((byte)src, ref dst);
            seek(dst, 2) = (byte)(src >> 6 & Lsb8x8x3);
            return ref dst;
        }
    }
}