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
        public readonly struct Constraint<S,R>
        {
            public S Subject {get;}

            public R Rule {get;}

            [MethodImpl(Inline)]
            public Constraint(S subject, R rule)
            {
                Subject = subject;
                Rule = rule;
            }

            [MethodImpl(Inline)]
            public static implicit operator Constraint<S,R>((S s, R r) src)
                => new Constraint<S,R>(src.s,src.r);
        }
    }
}