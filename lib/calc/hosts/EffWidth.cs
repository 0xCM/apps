//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CalcHosts
    {
        [Closures(Closure)]
        public readonly struct BvEffWidth<T> : IFunc<BitVector<T>,int>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly int Invoke(BitVector<T> a)
                => BitVector.effwidth(a);
        }
    }
}