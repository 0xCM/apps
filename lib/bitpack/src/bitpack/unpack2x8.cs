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
        /// Partitions a 16-bit source into 8 target segments each with an effective width of 2
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target memory location</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack2x8(ushort src, ref byte dst)
        {
            unpack2x4((byte)src, ref dst);
            unpack2x4((byte)(src >> 8), ref seek(dst, 4));
            return ref dst;
        }
    }
}