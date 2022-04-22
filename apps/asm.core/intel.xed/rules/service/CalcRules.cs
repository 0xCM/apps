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
            var tables = new RuleTables();
            var buffers = tables.CreateBuffers();
            exec(PllExec,
                () => buffers.Criteria.TryAdd(RuleTableKind.Enc, CalcRuleCriteria(RuleTableKind.Enc)),
                () => buffers.Criteria.TryAdd(RuleTableKind.Dec, CalcRuleCriteria(RuleTableKind.Dec))
                );

            tables.Seal(buffers, PllExec);
            EmitRules(tables);
            return tables;
        }

        public void EmitRules(RuleTables tables)
        {
            exec(PllExec,
                () => EmitTableSigs(tables),
                () => EmitRuleSeq(),
                () => EmitRuleCriteria(tables),
                () => EmitRuleCells(tables),
                () => EmitRuleTables(tables)
            );
        }
   }
}