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