//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Calcs;

    partial struct CalcClients
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> and<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvand<T>().Invoke(x,y);
    }
}