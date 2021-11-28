//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVector
    {
        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of least significant bits</param>
        [MethodImpl(Inline), HiSeg, Closures(Closure)]
        public static BitVector<T> hiseg<T>(BitVector<T> x, byte n)
            where T : unmanaged
                => bitseg(x, (byte)(x.Width - n), (byte)(x.Width - 1));
    }
}