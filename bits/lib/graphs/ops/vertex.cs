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
        public static Vertex<V> vertext<V>(V value)
            where V : IEquatable<V>
                => new Vertex<V>(value);

        [MethodImpl(Inline)]
        public static NamedVertex<V> vertex<V>(Name name, V value)
            where V : IEquatable<V>
                => new NamedVertex<V>(name,value);
    }
}