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
        public Index<TableCriteria> CalcRuleCriteria(RuleTableKind kind)
            => Data(nameof(CalcRuleCriteria) + kind.ToString(), () => CellParser.criteria(kind));
    }
}