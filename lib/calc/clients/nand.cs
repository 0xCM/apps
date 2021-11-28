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
        public BitVector<T> nand<T>(BitVector<T> x, BitVector<T> y)
            where T : unmanaged
                => bvnand<T>().Invoke(x,y);
    }
}