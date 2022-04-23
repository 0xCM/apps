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

        public Index<TableCriteria> CalcRuleCriteria(RuleTableKind kind)
            => Data(nameof(CalcRuleCriteria) + kind.ToString(), () => TableCalcs.criteria(kind));

        public KeyedCells CaclcRuleCells(RuleTables src)
            => Data(nameof(CaclcRuleCells), () => XedRules.cells(src));

        public Index<KeyedCellRecord> CalcRecords(KeyedCells src)
            => Data(nameof(CalcRecords), () => records(src));

        public void EmitRuleCells(KeyedCells src)
            => TableEmit(CalcRecords(src).View, KeyedCellRecord.RenderWidths, XedPaths.RuleTable<KeyedCellRecord>());

        public RuleTables EmitRules(RuleTables src)
        {
            var fields = CaclcRuleCells(src);
            exec(PllExec,
                () => EmitTableSigs(src),
                () => EmitRuleSeq(),
                () => EmitRuleCells(fields),
                () => EmitTableFiles(src)
            );
            Docs.EmitRuleDocs(src);
            return src;
        }
   }
}