//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LiteralProvider<T>
    {
        public LiteralSeq<T> Literals {get;}

        [MethodImpl(Inline)]
        public LiteralProvider(LiteralSeq<T> src)
        {
            Literals = src;
        }

        public Identifier Name => Literals.Name;

    }
}