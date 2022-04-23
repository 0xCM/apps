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
        static Dictionary<RuleSig,TableSpec> lookup(Index<TableCriteria> src)
        {
            var dst = dict<RuleSig,TableSpec>();
            var specs = alloc<TableSpec>(src.Count);
            for(var i=z16; i<src.Count; i++)
            {
                ref readonly var table = ref src[i];
                var tid = i;
                var tk = table.TableKind;
                ref readonly var sig = ref table.Sig;
                var rows = alloc<RowSpec>(table.RowCount);
                for(ushort j=0; j<table.RowCount; j++)
                {
                    var rid = j;
                    ref readonly var row = ref table[j];
                    var left = row.Antecedant.Select(x => cellinfo(x.Type, LogicKind.Antecedant, x.Data));
                    var right = row.Consequent.Select(x => cellinfo(x.Type, LogicKind.Consequent, x.Data));
                    var count = left.Count + 1 + right.Count;
                    var keys = alloc<CellKey>(count);
                    var cells = alloc<CellInfo>(count);
                    var m=z8;
                    for(var k=0; k<left.Count; k++,m++)
                    {
                        seek(keys, m) = new CellKey(sig, tid, rid, LogicKind.Antecedant, m);
                        seek(cells, m) = left[k];
                    }

                    {
                        seek(keys, m) = new CellKey(sig, tid, rid, LogicKind.Operator, m);
                        seek(cells, m) = cellinfo(OperatorKind.Impl);
                        m++;
                    }

                    for(var k=0; k<right.Count; k++,m++)
                    {
                        seek(keys, m) = new CellKey(sig, tid, rid, LogicKind.Consequent, m);
                        seek(cells, m) = right[k];
                    }
                    seek(rows,j) = new RowSpec(sig, tid, rid, keys, cells);
                }

                var spec = new TableSpec(tid, sig, rows);
                seek(specs,i) = spec;
                dst.Add(sig, spec);
            }
            return specs.Select(x => (x.Sig,x)).ToDictionary();
        }
    }
}