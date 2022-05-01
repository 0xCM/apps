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
            public static RuleGrid grid(in CellTable src)
            {
                var cols = (byte)src.Rows.Select(row => cells(row).Count).Storage.Max();
                var dst = alloc<GridCell>(cols*src.RowCount);
                var k=z8;
                for(var i=0; i<src.RowCount; i++)
                {
                    var _cells = cells(src[i]);
                    for(var j=0; j<_cells.Count; j++, k++)
                        seek(dst, k) = _cells[j];
                    for(var j=k; j<cols; j++, k++)
                        seek(dst, k) = GridCell.Empty;
                }
                return new RuleGrid(src.Sig, (ushort)src.RowCount, cols, dst);
            }
        }
    }
}