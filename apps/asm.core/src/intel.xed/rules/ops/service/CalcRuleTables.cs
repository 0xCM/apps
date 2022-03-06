//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public Index<RuleTermTable> CalcEncRuleTables()
            => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));

        public Index<RuleTermTable> CalcDecRuleTables()
            => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));

        public Index<RuleTermTable> CalcEncDecRuleTables()
            => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
    }
}