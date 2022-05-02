//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        string CalcTableMetrics(in CellTable table)
        {
            var dst = text.emitter();
            dst.AppendLine(string.Format("{0,-32} {1}", table.Sig.Format(), XedPaths.CheckedTableDef(table.Sig)));
            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine();
            for(var i=0; i<table.RowCount; i++)
            {
                ref readonly var row = ref table[i];

                if(i != 0)
                    dst.AppendLine();

                dst.AppendLineFormat("{0:D3}", row.RowIndex);
                dst.AppendLine(RP.PageBreak80);
                for(var j=0; j<row.CellCount; j++)
                {
                    ref readonly var cell = ref row[j];
                    ref readonly var key = ref cell.Key;
                    dst.AppendLineFormat("{0} {1,-12} | {2}",
                        string.Format("{0:D3} {1:D3} {2}", row.RowIndex, key.Col, key.FormatSemantic()),
                        XedRender.format(cell.Field),
                        cell);
                }

                dst.AppendLine(row.Expression);
            }

            dst.AppendLine(RP.PageBreak80);
            dst.Append(XedGrids.grid(table).Format());

            return dst.Emit();
        }
    }
}