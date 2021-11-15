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
        [MethodImpl(Inline)]
        public static Proposition<A,C> proposition<A,C>(TermId id,Antecedant<A> @if, Consequent<C> then)
            where A : IEquatable<A>
            where C : IEquatable<C>
                => new Proposition<A,C>(id, @if,then);
    }
}