//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedGrids
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
                    ref readonly var cell = ref src[k];
                    row.Index = cell.TableIndex;
                    row.Row = cell.RowIndex;
                    row.Cols[j] = col(cell);
                }
            }
            return dst;
        }
    }
}