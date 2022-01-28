//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class OptionRule : OptionRule<RuleValue>
    {
        public OptionRule(RuleValue src)
            : base(src)
        {


        }

        [MethodImpl(Inline)]
        public static implicit operator OptionRule(RuleValue src)
            => new OptionRule(src);

        [MethodImpl(Inline)]
        public static implicit operator OptionRule(string src)
            => new OptionRule(src);
    }
}