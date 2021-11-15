//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ItemMatch<T> : IExpr
        where T : IEquatable<T>
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public ItemMatch(T match)
        {
            Value = match;
        }

        public string Format()
            => rules.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ItemMatch<T>(T src)
            => new ItemMatch<T>(src);
    }
}