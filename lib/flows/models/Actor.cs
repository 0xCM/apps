//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Actor : IActor<ulong>
    {
        public readonly ulong Kind;

        [MethodImpl(Inline)]
        public Actor(ulong kind)
        {
            Kind = kind;
        }

        ulong IActor<ulong>.Kind
            => Kind;

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Actor(ulong kind)
            => new Actor(kind);
    }
}