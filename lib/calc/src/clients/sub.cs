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
        public BitVector<T> sub<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => Calcs.bvsub<T>().Invoke(x,y);
    }
}