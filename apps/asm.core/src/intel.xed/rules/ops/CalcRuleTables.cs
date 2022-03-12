//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public ConstLookup<RuleSig,RuleTable> CalcRuleTables()
        {
            void OnError(string src)
                => Write(src, FlairKind.Error);

            var collector = new TableCollector(OnError, true);
            collector.Traverse(MacroExpander.expand(CalcEncDecRuleTables()));
            var encdec = collector.Tables();

            collector.Traverse(MacroExpander.expand(CalcEncRuleTables()));
            var enc = collector.Tables();

            var dst = dict<RuleSig,RuleTable>();

            foreach(var key in encdec.Keys)
                dst.Add(key, encdec[key]);

            foreach(var key in enc.Keys)
                dst.TryAdd(key, enc[key]);

            return dst;
        }

        public Index<RuleTermTable> CalcEncRuleTables()
            => Data(nameof(CalcEncRuleTables), () => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncRuleTable)));

        public Index<RuleTermTable> CalcDecRuleTables()
            => Data(nameof(CalcDecRuleTables), () => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.DecRuleTable)));

        public Index<RuleTermTable> CalcEncDecRuleTables()
            => Data(nameof(CalcEncDecRuleTables), () => new RuleTableParser().Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable)));
    }
}