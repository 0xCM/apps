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
        public RuleTables CalcRules()
        {
            var dst = new RuleTables();
            var buffers = dst.CreateBuffers();
            exec(PllExec,
                () => buffers.Criteria.TryAdd(RuleTableKind.ENC, CalcRuleCriteria(RuleTableKind.ENC)),
                () => buffers.Criteria.TryAdd(RuleTableKind.DEC, CalcRuleCriteria(RuleTableKind.DEC))
                );

            dst.Seal(buffers, PllExec);
            return dst;
        }

        public SortedLookup<RuleSig,Index<KeyedCell>> CalcRuleFields(RuleTables src)
            => Data(nameof(CalcRuleFields), () => XedRules.fields(src));

        public RuleTables EmitRules(RuleTables src)
        {
            exec(PllExec,
                () => EmitTableSigs(src),
                () => EmitRuleSeq(),
                () => EmitRuleCells(src),
                () => EmitTableFiles(src)
            );
            Docs.EmitRuleDocs(src);
            return src;
        }
   }
}