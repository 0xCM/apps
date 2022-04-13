//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Datasets;

    partial class XedRules
    {
        public class TableSpecs : SortedLookup<RuleSig,TableSpec>
        {
            public static TableColumns Columns = new TableColumns(
                ("TableId", 10),
                ("TableKind", 10),
                ("TableName", 32),
                ("RowIndex", 10),
                ("CellIndex", 10),
                ("Type", 24),
                ("Field", 22),
                ("Op", 4),
                ("Value", 16)
                );

            public TableSpecs(Dictionary<RuleSig,TableSpec> src)
                : base(src)
            {


            }

            public static implicit operator TableSpecs(Dictionary<RuleSig,TableSpec> src)
                => new TableSpecs(src);
        }
    }
}