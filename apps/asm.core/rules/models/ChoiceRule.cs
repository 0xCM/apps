//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ChoiceRule : ChoiceRule<RuleValue>
    {
        public ChoiceRule(Index<RuleValue> src)
            : base(src)
        {


        }

        [MethodImpl(Inline)]
        public static implicit operator ChoiceRule(RuleValue[] src)
            => new ChoiceRule(src);
    }
}