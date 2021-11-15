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
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(BitVector<T> src)
            where T : unmanaged
                => gmath.eq(gmath.and(Limits.maxval<T>(), src.State), Limits.maxval<T>());
    }
}