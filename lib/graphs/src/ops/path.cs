//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct Graphs
    {
        [MethodImpl(Inline)]
        public static GraphPath<V> path<V>(params V[] src)
            where V : IEquatable<V>, IVertex<V>
                => new GraphPath<V>(src);
    }
}