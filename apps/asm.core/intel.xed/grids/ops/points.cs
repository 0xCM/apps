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
        public static ushort points(CellTables src, Span<Coordinate> dst)
        {
            var m = z16;
            for(var i=z16; i<src.TableCount; i++)
            {
                for(var j=z8; j<src[i].RowCount; j++)
                {
                    for(var k=z8; k<src[i][j].CellCount; k++,m++)
                    {
                        ref readonly var cell = ref src[i][j][k];
                        seek(dst,m) = new (m,i,j,k, cell.TableKind, cell.Rule.TableName);
                    }
                }
            }
            return m;
        }
    }
}