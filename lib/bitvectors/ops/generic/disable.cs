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
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The position of the bit to disable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> disable<T>(ScalarBits<T> x, int index)
            where T : unmanaged
                => gbits.disable(x.State,index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The position of the bit to disable</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> disable<N,T>(ScalarBits<N,T> x, int index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.disable(x.State,index);
    }
}