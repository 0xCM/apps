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
            => Data(nameof(CalcRuleCriteria) + kind.ToString(), () => CellParser.criteria(kind));

        public KeyedCells CalcRuleCells(RuleTables src)
            => Data(nameof(CalcRuleCells), () => CellParser.cells(src));

        public Index<KeyedCellRecord> CalcCellRecords(KeyedCells src)
            => records(src);
   }
}