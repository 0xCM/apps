//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct TerminalRule : IRule
        {
            public readonly RuleTable Def;

            [MethodImpl(Inline)]
            public TerminalRule(RuleTable rule)
            {
                Def = rule;
            }

            public string Format()
                => Def.Format();


            public override string ToString()
                => Format();

            RuleTable IRule.Def
                => Def;

            public static implicit operator TerminalRule(RuleTable src)
                => new TerminalRule(src);

            public static TerminalRule Empty => new TerminalRule(RuleTable.Empty);
        }
    }
}