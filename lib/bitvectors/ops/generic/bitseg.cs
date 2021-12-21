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
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg, Closures(Closure)]
        public static ScalarBits<T> bitseg<T>(ScalarBits<T> x, byte first, byte last)
            where T : unmanaged
                => gbits.segment(x.State, first, last);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> bitseg<N,T>(ScalarBits<N,T> x, byte first, byte last)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.segment(x.State, first, last);
    }
}