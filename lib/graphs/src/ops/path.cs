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
        public static Path<K,T> path<K,T>(params Node<K,T>[] nodes)
            where K : unmanaged
                => new Path<K,T>(nodes);
    }
}