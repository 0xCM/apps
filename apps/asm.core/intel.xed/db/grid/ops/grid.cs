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
                var kCol = (byte)src.Rows.Select(row => cells(row).Count).Storage.Max();
                var kRow = src.RowCount;
                var dst = alloc<GridCell>(kCol*kRow);
                var k=z8;
                for(var i=0; i<kRow; i++)
                {
                    var cells = RuleGrids.cells(src[i]);

                    for(var j=0; j<cells.Count; j++, k++)
                        seek(dst, k) = cells[j];

                    for(var j=k; j<kCol; j++, k++)
                        seek(dst, k) = GridCell.Empty;
                }
                return new RuleGrid(src.Sig, (ushort)src.RowCount, kCol, dst);
            }
        }
    }
}