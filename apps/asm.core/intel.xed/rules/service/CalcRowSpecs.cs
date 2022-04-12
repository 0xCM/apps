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
        public static SortedLookup<ushort,Index<RowSpec>> CalcRowSpecs(Index<TableCriteria> src)
        {
            var dst = dict<ushort,Index<RowSpec>>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var table = ref src[i];
                var tid = (ushort)table.TableId;
                var tk = table.TableKind;
                var rows = alloc<RowSpec>(table.RowCount);
                for(ushort j=0; j<table.RowCount; j++)
                {
                    ref readonly var row = ref table[j];
                    ref readonly var a = ref row.Antecedant;
                    ref readonly var c = ref row.Consequent;
                    var count = a.Count + 1 + c.Count;
                    var keys = alloc<CellKey>(count);
                    var cells = alloc<CellSpec>(count);
                    var m=z8;
                    for(var k=0; k<a.Count; k++,m++)
                    {
                        seek(keys, m) = new CellKey(tk, tid, j, LogicKind.Antecedant, m);
                        seek(cells, m) = a[k];
                    }

                    {
                        seek(keys, m) = new CellKey(tk, tid, j, LogicKind.Antecedant, m);
                        seek(cells, m) = new XedRules.CellSpec(OperatorKind.Impl);
                        m++;
                    }

                    for(var k=0; k<c.Count; k++,m++)
                    {
                        seek(keys, m) = new CellKey(tk, tid, j, LogicKind.Consequent, m);
                        seek(cells, m) = c[k];
                    }
                    seek(rows,j) = new RowSpec(tk, tid, j, keys, cells);

                }
                dst.Add(tid, rows);
            }

            return dst;
        }
    }
}