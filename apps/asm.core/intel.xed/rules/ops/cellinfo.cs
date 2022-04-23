
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline)]
        public static CellInfo cellinfo(in CellType type, LogicClass logic, string data)
            => new CellInfo(type, logic, data);

        [MethodImpl(Inline)]
        public static CellInfo cellinfo(RuleOperator op)
            => new CellInfo(op);
    }
}