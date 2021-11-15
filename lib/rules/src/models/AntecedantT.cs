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
        public readonly struct Antecedant<A> : IEquatable<Antecedant<A>>
            where A : IEquatable<A>
        {
            public TermId Id {get;}

            public Index<A> Terms {get;}

            [MethodImpl(Inline)]
            public Antecedant(TermId id, Index<A> terms)
            {
                Id = id;
                Terms = terms;
            }

            public bool Equals(Antecedant<A> src)
                => RuleModels.match(this,src);
        }
    }
}