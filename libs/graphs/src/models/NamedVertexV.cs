//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class NamedVertex<V> : IEquatable<NamedVertex<V>>
        where V : IEquatable<V>
    {
        public Name Name {get;}

        public V Value {get;}

        public DataList<Vertex<V>> Targets {get;}

        [MethodImpl(Inline)]
        public NamedVertex(Name name, V value)
        {
            Name = name;
            Value = value;
            Targets = new();
        }

        [MethodImpl(Inline)]
        public bool Equals(NamedVertex<V> src)
            => Name.Equals(src.Name);

        public override int GetHashCode()
            => (int)Name.Hash;

        public override bool Equals(object obj)
            => obj is NamedVertex<V> v && Equals(v);

        public string Format()
            => string.Format("{0}({1})", Name, Value);

        public override string ToString()
            => Format();
    }
}