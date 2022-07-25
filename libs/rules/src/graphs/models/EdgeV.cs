//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Edge<V> : IEdge<V>, IEquatable<Edge<V>>
        where V : IDataType<V>, IExpr, IVertex<V>
    {
        public V Source {get;}

        public V Target {get;}

        [MethodImpl(Inline)]
        public Edge(V src, V dst)
        {
            Source = src;
            Target = dst;
        }

        public override int GetHashCode()
            => (int)alg.hash.combine(Source.GetHashCode(), Target.GetHashCode());

        [MethodImpl(Inline)]
        public bool Equals(Edge<V> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target);

        public string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}