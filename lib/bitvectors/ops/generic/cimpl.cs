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
        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static ScalarBits<T> cimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gbits.cimpl(x.State, y.State);
    }
}