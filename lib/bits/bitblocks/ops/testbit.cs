//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitBlocks
    {
        /// <summary>
        /// Tests a bit value in a T-sequence predicated on a linear index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The linear index of the target bit, relative to the sequence head</param>
        /// <typeparam name="T">The sequence type</typeparam>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(in SpanBlock256<T> src, int index)
            where T : unmanaged
        {
            var pos = bit.bitpos<T>((uint)index);
            return gbits.testbit(src[pos.CellIndex], (byte)pos.BitOffset);
        }
    }
}