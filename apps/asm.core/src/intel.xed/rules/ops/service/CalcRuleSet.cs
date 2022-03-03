//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public RuleSet CalcRuleSet(RuleSetKind kind)
        {
            var set = RuleSet.Empty;
            switch(kind)
            {
                case RuleSetKind.Enc:
                    set = new RuleSet(kind, CalcEncPatternInfo(), CalcEncRuleTables());
                break;
                case RuleSetKind.Dec:
                    set = new RuleSet(kind, CalcDecPatternInfo(), CalcDecRuleTables());
                break;
                case RuleSetKind.EncDec:
                    set = new RuleSet(kind, CalcEncPatternInfo(), CalcEncDecRuleTables());
                break;
            }
            return set;
        }
    }
}