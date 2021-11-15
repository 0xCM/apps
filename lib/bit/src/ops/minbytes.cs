//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct bit
    {
        /// <summary>
        /// Computes the minimum number of bytes required to cover a specified number of bits
        /// </summary>
        /// <param name="bits">The number of bits for which storage is required</param>
        [MethodImpl(Inline), Op]
        public static ulong minbytes(ulong bits)
            => bits/8ul + (bits % 8 == 0 ? 0ul : 1ul);

        [MethodImpl(Inline), Op]
        public static long minbytes(long bits)
            => bits/8L + (bits % 8 == 0 ? 0L : 1L);
    }
}