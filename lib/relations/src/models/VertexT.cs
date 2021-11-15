//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Vertex<T> : IVertex<Vertex<T>,T>
        where T : unmanaged
    {
        public T Key {get;}

        [MethodImpl(Inline)]
        public Vertex(T key)
        {
            Key = key;
        }

        ulong Key64
        {
            [MethodImpl(Inline)]
            get => core.bw64(Key);
        }

        public string Format()
            => Key64.ToString();

        [MethodImpl(Inline)]
        public int CompareTo(Vertex<T> src)
            => Key64.CompareTo(src.Key64);

        [MethodImpl(Inline)]
        public bool Equals(Vertex<T> src)
            => Key64.Equals(src.Key64);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Key64;

        public override bool Equals(object src)
            => src is Vertex<T> v && Equals(v);

        [MethodImpl(Inline)]
        public static implicit operator Vertex<T>(T key)
            => new Vertex<T>(key);

        [MethodImpl(Inline)]
        public static bool operator ==(Vertex<T> a, Vertex<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Vertex<T> a, Vertex<T> b)
            => !a.Equals(b);
    }
}