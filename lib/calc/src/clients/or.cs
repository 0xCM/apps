//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CalcClients
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public BitVector<T> or<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => Calcs.bvor<T>().Invoke(x,y);
    }
}
