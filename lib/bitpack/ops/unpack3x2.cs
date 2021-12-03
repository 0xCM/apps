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
        /// Partitions the first 6 bits of an 8-bit source value into 2 target segments each with an effective width of 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target memory location</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x2(byte src, ref byte dst)
        {
            seek(dst, 0) = (byte)(src >> 0 & Lsb8x8x3);
            seek(dst, 1) = (byte)(src >> 3 & Lsb8x8x3);
            return ref dst;
        }
    }
}