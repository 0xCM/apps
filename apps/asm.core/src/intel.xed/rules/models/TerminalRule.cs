//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct TerminalRule : IRule
        {
            public readonly RuleTermTable Def;

            [MethodImpl(Inline)]
            public TerminalRule(RuleTermTable rule)
            {
                Def = rule;
            }

            public string Format()
                => Def.Format();


            public override string ToString()
                => Format();

            RuleTermTable IRule.Def
                => Def;

            public static implicit operator TerminalRule(RuleTermTable src)
                => new TerminalRule(src);

            public static TerminalRule Empty => new TerminalRule(RuleTermTable.Empty);
        }
    }
}