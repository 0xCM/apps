//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Graphs
    {
        [MethodImpl(Inline)]
        public static Vertex<V> vertext<V>(V value)
            where V : IEquatable<V>
                => new Vertex<V>(value);

        [MethodImpl(Inline)]
        public static NamedVertex<V> vertex<V>(NameOld name, V value)
            where V : IEquatable<V>
                => new NamedVertex<V>(name,value);
    }
}