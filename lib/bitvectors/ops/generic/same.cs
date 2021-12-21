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
        [MethodImpl(Inline), Eq, Closures(Closure)]
        public static bit eq<T>(in ScalarBits<T> x, in ScalarBits<T> y)
            where T : unmanaged
                => gmath.eq(x.State, y.State);
    }
}