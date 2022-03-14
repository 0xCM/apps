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
            public Identifier TableName;

            public Index<RuleTableRow> Data;

            [MethodImpl(Inline)]
            public RuleTableRows(Identifier table, RuleTableRow[] data)
            {
                TableName = table;
                Data = data;
            }
        }
    }
}