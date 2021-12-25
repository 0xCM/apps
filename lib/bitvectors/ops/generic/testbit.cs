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
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(ScalarBits<T> src, byte index)
            where T : unmanaged
                => gbits.test(src.State, index);

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline)]
        public static bit testbit<N,T>(ScalarBits<N,T> src, byte index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.test(src.State, index);

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(BitVector128<T> src, byte index)
            where T : unmanaged
                => index < 64 ? bit.test(src.Lo,index) : bit.test(src.Hi, (byte)(index - 64));
    }
}