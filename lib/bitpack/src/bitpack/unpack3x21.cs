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
        /// Partitions the first 63 bits of a 64 bit source value into 21 target segments each of effective width 3
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="dst">The receiving buffer</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x21(ulong src, ref byte dst)
        {
            var x = lo(n63) & src;
            seek64(dst, 0) = scatter(x, Lsb64x8x3);
            seek64(dst, 1) = scatter(x >> 24, Lsb64x8x3);
            seek64(dst, 2) = scatter(x >> 48, Lsb64x8x3);
            return ref dst;
        }
    }
}