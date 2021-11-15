//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Vertex : IEquatable<Vertex>, IComparable<Vertex>
    {
        public uint Key {get;}

        [MethodImpl(Inline)]
        public Vertex(uint key)
        {
            Key = key;
        }

        public string Format()
            => Key.ToString();

        [MethodImpl(Inline)]
        public int CompareTo(Vertex src)
            => Key.CompareTo(src.Key);

        [MethodImpl(Inline)]
        public bool Equals(Vertex src)
            => Key.Equals(src.Key);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Key;

        public override bool Equals(object src)
            => src is Vertex v && Equals(v);

        [MethodImpl(Inline)]
        public static implicit operator Vertex(uint key)
            => new Vertex(key);

        [MethodImpl(Inline)]
        public static bool operator ==(Vertex a, Vertex b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(Vertex a, Vertex b)
            => !a.Equals(b);
    }
}