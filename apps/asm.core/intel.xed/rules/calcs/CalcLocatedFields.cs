//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedRules
    {
        public static Index<LocatedField> CalcLocatedFields(RuleCells src)
        {
            var dst = dict<Coordinate,FieldKind>();
            var tables = src.Tables;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref src[i];
                var rows = table.Rows;
                for(var j=0; j<rows.Count; j++)
                {
                    ref readonly var row = ref table[j];
                    var cells = row.Cells;
                    for(var k=0; k<cells.Count; k++)
                    {
                        ref readonly var cell = ref cells[k];
                        dst.Add(cell.Location, cell.Field);
                    }
                }
            }

            var pairs = dst.Pairings();
            var count = pairs.Count;
            var located = alloc<LocatedField>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var pair = ref pairs[i];
                ref readonly var c = ref pair.Left;
                ref readonly var f = ref pair.Right;
                seek(located, i) = pair;
            }
            return located;
        }
    }
}