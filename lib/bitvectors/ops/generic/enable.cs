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
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> enable<T>(ScalarBits<T> x, byte index)
            where T : unmanaged
                => gbits.enable(x.State, index);

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> enable<N,T>(ScalarBits<N,T> x, byte index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.enable(x.State, index);
    }
}