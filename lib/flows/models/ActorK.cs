//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Actor<K> : IActor<K>
        where K : unmanaged
    {
        public readonly K Kind;

        [MethodImpl(Inline)]
        public Actor(K kind)
        {
            Kind = kind;
        }

        K IActor<K>.Kind
            => Kind;

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Actor<K>(K kind)
            => new Actor<K>(kind);
    }
}