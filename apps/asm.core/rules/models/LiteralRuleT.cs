//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class LiteralRule<T> : Rule
    {
        public T Value {get;}

        public LiteralRule(T src)
        {
            Value = src;
        }

        public override string Format()
            => Value.ToString();

        public override bool IsTerminal
            => true;

        public static implicit operator LiteralRule<T>(T src)
            => new LiteralRule<T>(src);
    }
}