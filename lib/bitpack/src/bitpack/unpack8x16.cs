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
    using static cpu;

    partial struct BitPack
    {
        /// <summary>
        /// Projects 8 8-bit integers partitioned from a 64-bit source onto 8 16-bit integers
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ushort> unpack8x16(ulong src)
            => recover<ushort>(bytes(vlo(vpack.vinflate256x16u(vbytes(w128, src)))));
    }
}