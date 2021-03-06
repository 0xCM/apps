//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        [MethodImpl(Inline)]
        public static Digraph<V> digraph<V>()
            where V : IEquatable<V>, IVertex<V>
                => new Digraph<V>();

        [MethodImpl(Inline)]
        public static Digraph digraph(params Edge[] edges)
            => new Digraph(edges);
    }
}