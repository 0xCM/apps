//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct relations
    {
        [MethodImpl(Inline)]
        public static LabeledDigraph<V> digraph<V>()
            where V : unmanaged, ILabeledVertex, IEquatable<V>
                => new LabeledDigraph<V>();

        [MethodImpl(Inline)]
        public static Digraph digraph(params Edge[] edges)
            => new Digraph(edges);
    }
}