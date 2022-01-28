//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class OptionRule<T> : RuleExpr<T>, IOptionRule
        where T : IRuleExpr
    {
        public OptionRule(T opt)
            : base(opt)
        {

        }

        public IRuleExpr Potential
            => Content;

        public Index<IRuleExpr> Terms
            => core.array(Potential);
        public override string Format()
            => text.bracket(Content.ToString());

        public static implicit operator OptionRule<T>(T value)
            => new OptionRule<T>(value);
    }
}