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
            var dst = list<LocatedField>();
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
                        dst.Add(new (cell.Location, cell.Field));
                    }
                }
            }

            return dst.ToIndex().Sort();
        }
    }
}