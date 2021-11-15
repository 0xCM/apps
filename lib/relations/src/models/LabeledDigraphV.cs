//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class LabeledDigraph<V>
        where V : unmanaged, ILabeledVertex, IEquatable<V>
    {
        MutableSet<V> _Vertices;

        MutableSet<LabeledEdge<V>> _Edges;

        public LabeledDigraph()
        {
            _Vertices = new();
            _Edges = new();
        }

        public void Connect(Label label, V src, V dst)
        {
            _Vertices.Union(src,dst);
            _Edges.Union(new LabeledEdge<V>(label, src,dst));
        }

        public void Trace(EdgeReader<V> f)
        {
            foreach(var e in _Edges)
                f(e);
        }
    }
}