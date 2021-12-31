//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct OneOrMany<T>
    {
        public Index<T> Elements {get;}

        [MethodImpl(Inline)]
        public OneOrMany(Index<T> src)
            => Elements = src;

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => Elements.Count == 0;
        }

        public bool IsMore
        {
            [MethodImpl(Inline)]
            get => Elements.Count > 0;
        }

        public MultiplicityKind Kind
            => MultiplicityKind.OneOrMany;

        [MethodImpl(Inline)]
        public static implicit operator OneOrMany<T>(T[] src)
            => new OneOrMany<T>(src);
    }
}