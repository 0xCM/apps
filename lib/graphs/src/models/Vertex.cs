//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class Vertex : IEquatable<Vertex>, IVertex
    {
        public object Value {get;}

        public DataList<Vertex> Targets {get;}

        [MethodImpl(Inline)]
        public Vertex(object value)
        {
            Value = value;
            Targets = new();
        }

        public string Format()
            => Value.ToString();

        [MethodImpl(Inline)]
        public bool Equals(Vertex src)
            => Value.Equals(src.Value);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

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