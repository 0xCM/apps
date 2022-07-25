//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NamedEdge<V> : IEdge<V>, IEquatable<NamedEdge<V>>
        where V : IEquatable<V>, IExpr, IHashed
    {
        public Name Name {get;}

        public V Source {get;}

        public V Target {get;}

        [MethodImpl(Inline)]
        public NamedEdge(Name name, V src, V dst)
        {
            Name = name;
            Source = src;
            Target = dst;
        }

        public override int GetHashCode()
            => (int)alg.hash.combine(Source.GetHashCode(), Target.GetHashCode());

        [MethodImpl(Inline)]
        public bool Equals(NamedEdge<V> src)
            => Source.Equals(src.Source) && Target.Equals(src.Target) && Name.Equals(src.Name);

        public string Format()
            => string.Format("{0}:{1} -> {2}", Name, Source, Target);

        public override string ToString()
            => Format();
    }
}