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
        [MethodImpl(Inline), Op]
        public static GridRow grow(RuleSig rule, ushort row, GridCol[] cols)
            => new GridRow(rule, row, cols);

        public static Index<GridRow> grows(RuleSig rule, ushort rows, byte cols, Index<GridCell> src)
        {
            var dst = alloc<GridRow>(rows);
            var k=0u;
            for(var i=z16; i<rows; i++)
            {
                seek(dst,i) = grow(rule,i, alloc<GridCol>(cols));
                ref readonly var row = ref skip(dst,i);
                for(var j=z8; j<row.ColCount; j++, k++)
                    row.Cols[j] = col(src[k]);
            }
            return dst;
        }
    }
}