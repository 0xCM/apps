//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public delegate void EdgeReader<V>(in Edge<V> e)
        where V : IDataType<V>, IExpr, IVertex<V>;
    public class Digraph<V>
        where V : IDataType<V>, IExpr, IVertex<V>
    {
        DataList<Edge<V>> _Edges;

        public Digraph()
        {
            _Edges = new();
        }

        public Edge<V> Connect(V src, V dst)
        {
            src.Targets.Add(dst);
            var edge = new Edge<V>(src, dst);
            _Edges.Add(edge);
            return edge;
        }

        public void Trace(EdgeReader<V> f)
        {
            foreach(var e in _Edges)
                f(e);
        }
    }

    public class Digraph
    {
        MutableSet<Edge> _EdgeSet;

        Index<Vertex> _Vertices;

        Index<Edge> _Edges;

        bool Sealed;

        public Digraph()
        {
            _EdgeSet = new();
            _Vertices = Index<Vertex>.Empty;
            _Edges = Index<Edge>.Empty;
            Sealed = false;
        }

        public Digraph(Edge[] src)
        {
            _EdgeSet = new MutableSet<Edge>(src);
            Sealed = false;
        }

        public void Connect(Vertex src, Vertex dst)
        {
            if(!Sealed)
                _EdgeSet.Include((src,dst));
        }

        public Digraph Seal()
        {
            if(!Sealed)
            {
                var vertices = hashset<Vertex>();
                foreach(var e in _EdgeSet)
                {
                    vertices.Add(e.Source);
                    vertices.Add(e.Target);
                }
                _Vertices = vertices.Array();
                _Edges = _EdgeSet.Array();
                Sealed = true;
            }
            return this;
        }

        public uint Order
        {
            [MethodImpl(Inline)]
            get => _Vertices.Count;
        }

        public uint EdgeCount
        {
            [MethodImpl(Inline)]
            get => _Edges.Count;
        }

        public ReadOnlySpan<Edge> Edges
        {
            [MethodImpl(Inline)]
            get => _Edges.View;
        }

        public ReadOnlySpan<Vertex> Vertices
        {
            [MethodImpl(Inline)]
            get => _Vertices.View;
        }

        public void Walk(Action<Edge> receiver)
            => iter(_EdgeSet, receiver);
    }
}