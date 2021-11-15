//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Vertex<K,P,T> : IVertex<Vertex<K,P,T>,P,K,T>
        where T : unmanaged
        where K : unmanaged
    {
        public K Kind {get;}

        public T Key {get;}

        public P Value {get;}

        [MethodImpl(Inline)]
        public Vertex(T key, K kind, P value)
        {
            Key = key;
            Kind = kind;
            Value = value;
        }

        ulong Key64
        {
            [MethodImpl(Inline)]
            get => core.bw64(Key);
        }

        public string Format()
            => Key64.ToString();

        [MethodImpl(Inline)]
        public int CompareTo(Vertex<K,P,T> src)
            => Key64.CompareTo(src.Key64);

        [MethodImpl(Inline)]
        public bool Equals(Vertex<K,P,T> src)
            => Key64.Equals(src.Key64);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Key64;

        public override bool Equals(object src)
            => src is Vertex<K,P,T> v && Equals(v);

        [MethodImpl(Inline)]
        public static bool operator ==(Vertex<K,P,T> a, Vertex<K,P,T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Vertex<K,P,T> a, Vertex<K,P,T> b)
            => !a.Equals(b);
    }
}