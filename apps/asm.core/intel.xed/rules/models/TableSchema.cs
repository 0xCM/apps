//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential)]
        public record struct TableSchema
        {
            public readonly RuleSig Table;

            public readonly TableColumn[] Columns;

            [MethodImpl(Inline)]
            public TableSchema(RuleSig table, TableColumn[] cols)
            {
                Table = table;
                Columns = cols;
            }
        }
    }
}