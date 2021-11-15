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
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="count">The rotation magnitude</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Rotr, Closures(Closure)]
        public static BitVector<T> rotr<T>(BitVector<T> src, byte count)
            where T : unmanaged
                => gbits.rotr(src.State, count);
    }
}