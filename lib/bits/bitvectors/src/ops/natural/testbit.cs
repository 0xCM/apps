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
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline)]
        public static bit testbit<N,T>(BitVector<N,T> x, byte index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.testbit(x.State, index);
    }
}