//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct OneOfRule<T> : IRule
    {
        public Index<T> Elements {get;}

        [MethodImpl(Inline)]
        public OneOfRule(Index<T> src)
            => Elements = src;

        public string Format()
            => Elements.Delimit(Chars.Pipe).Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OneOfRule<T>(T[] src)
            => new OneOfRule<T>(src);
    }
}