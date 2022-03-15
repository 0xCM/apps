//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleTableRows
        {
            public RuleTableSig TableSig;

            public Index<RuleTableRow> Data;

            [MethodImpl(Inline)]
            public RuleTableRows(RuleTableSig sig, RuleTableRow[] data)
            {
                TableSig = sig;
                Data = data;
            }
        }
    }
}