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
        partial class RuleGrids
        {
            public static Index<GridRow> rows(RuleSig rule, ushort rows, byte cols, Index<GridCell> src)
            {
                var dst = alloc<GridRow>(rows);
                var k=0u;
                for(var i=0; i<rows; i++)
                {
                    ref var row = ref seek(dst,i);
                    row.ColCount = cols;
                    row.Rule = rule;
                    row.Cols = alloc<GridCol>(cols);
                    for(var j=0; j<cols; j++, k++)
                    {
                        ref readonly var field = ref src[k];
                        row.Index = field.Table;
                        row.Row = field.Row;
                        row.Cols[j] = new GridCol(field.Col, field.Size, field.Field);
                    }
                }
                return dst;
            }
        }
    }
}