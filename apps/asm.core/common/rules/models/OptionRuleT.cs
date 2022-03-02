//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
    public class OptionRule<T> : RuleExpr<OptionRule<T>,T>, IOptionRule
        where T : IRuleExpr
    {
        public OptionRule(T opt)
            : base(opt)
        {

        }

        public IRuleExpr Potential
            => Content;
        public override string Format()
            => text.bracket(Content.ToString());

        public static implicit operator OptionRule<T>(T value)
            => new OptionRule<T>(value);
    }
    }


}