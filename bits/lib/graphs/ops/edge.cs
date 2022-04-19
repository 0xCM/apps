//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Graphs
    {
        public static Edge<V> edge<V>(V src, V dst)
            where V : IEquatable<V>, IVertex<V>
                => new Edge<V>(src, dst);

        public static NamedEdge<V> edge<V>(Name name, V src, V dst)
            where V : IEquatable<V>, IVertex<V>
                => new NamedEdge<V>(name, src, dst);
    }
}