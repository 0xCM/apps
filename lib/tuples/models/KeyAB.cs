//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Key<A,B> : ITextual, IHashed
    {
        public Paired<A,B> Content {get;}

        public uint Hash {get;}

        [MethodImpl(Inline)]
        public Key(A a, B b)
        {
            Content = (a,b);
            Hash = FastHash.combine(a.GetHashCode(), b.GetHashCode());
        }

        [MethodImpl(Inline)]
        public Key(Paired<A,B> src)
        {
            Content = src;
            Hash = FastHash.combine(src.Left.GetHashCode(), src.Right.GetHashCode());
        }

        public override int GetHashCode()
            => (int)Hash;
        public string Format()
            => string.Format("<{0},{1}>", Content.Left, Content.Right);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Key<A,B>((A a, B b) src)
            => new Key<A,B>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Key<A,B>(Paired<A,B> src)
            => new Key<A,B>(src);

    }
}