//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct Consequent<C>
        {
            public TermId Id {get;}

            public C Term {get;}

            [MethodImpl(Inline)]
            public Consequent(TermId id, C src)
            {
                Id = id;
                Term = src;
            }

            [MethodImpl(Inline)]
            public static implicit operator Consequent(Consequent<C> src)
                => new Consequent(src.Id, src.Term);
        }
    }
}