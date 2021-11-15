//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class BitVector
    {
        /// <summary>
        /// Initializes a generic bitvector with a supplied value
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector<T> init<T>(T src)
            where T : unmanaged
                => new BitVector<T>(src);
    }
}