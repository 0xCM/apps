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
        /// Partitions a 16-bit source value into 2 segments of width 8
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack8x2(ushort src, ref byte dst)
        {
            seek(dst, 0) = (byte)src;
            seek(dst, 1) = (byte)(src >> 8);
            return ref dst;
        }
    }
}