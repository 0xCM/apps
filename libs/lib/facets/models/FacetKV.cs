//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Faceted;

    [DataTypeAttributeD("facet<k:{0},v:{1}>")]
    public readonly struct Facet<K,V> : IFacet<K,V>
    {
        public K Key {get;}

        public V Value {get;}

        [MethodImpl(Inline)]
        public Facet(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static implicit operator Facet<K,V>(Paired<K,V> src)
            => new Facet<K,V>(src.Left, src.Right);

        public static implicit operator Facet<K,V>((K key, V value) src)
            => new Facet<K,V>(src.key, src.value);
    }
}