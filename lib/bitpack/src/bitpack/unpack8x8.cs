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
        /// Partitions a 64-bit source value into 8 segments of width 8
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack8x8(ulong src, ref byte dst)
        {
            seek64(dst,0) = src;
            return ref dst;
        }
    }
}