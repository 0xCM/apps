//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVectors
    {
        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the source vector
        /// </summary>
        /// <param name="n">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg, Closures(Closure)]
        public static ScalarBits<T> lo<T>(ScalarBits<T> src, byte n)
            where T : unmanaged
                => bitseg(src, 0, n -=1);
    }
}