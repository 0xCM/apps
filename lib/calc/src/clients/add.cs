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
        public BitVector<T> add<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvadd<T>().Invoke(x,y);

    }
}
