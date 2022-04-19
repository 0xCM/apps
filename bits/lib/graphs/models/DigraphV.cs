//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class Digraph<V>
        where V : IEquatable<V>, IVertex<V>
    {
        DataList<Edge<V>> _Edges;

        public Digraph()
        {
            _Edges = new();
        }

        public Edge<V> Connect(V src, V dst)
        {
            src.Targets.Add(dst);
            var edge = Graphs.edge(src, dst);
            _Edges.Add(edge);
            return edge;
        }

        public void Trace(EdgeReader<V> f)
        {
            foreach(var e in _Edges)
                f(e);
        }
    }
}