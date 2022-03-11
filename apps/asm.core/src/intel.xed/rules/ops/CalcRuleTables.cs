//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public ConstLookup<RuleSig,RuleTable> CalcRuleTables()
        {
            void OnError(string src)
                => Write(src, FlairKind.Error);

            var collector = new TableCollector(OnError, true);
            collector.Traverse(ExpandMacros(CalcRuleSet(RuleSetKind.EncDec)));
            var tables = collector.Tables;
            return tables;
        }

        public Index<RuleTermTable> CalcEncRuleTables()
            => Data(nameof(CalcEncRuleTables), () => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncRuleTable)));

        public Index<RuleTermTable> CalcDecRuleTables()
            => Data(nameof(CalcDecRuleTables), () => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.DecRuleTable)));

        public Index<RuleTermTable> CalcEncDecRuleTables()
            => Data(nameof(CalcEncDecRuleTables), () => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable)));
    }
}