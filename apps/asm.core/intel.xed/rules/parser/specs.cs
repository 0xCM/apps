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
        partial struct CellParser
        {
            public static TableSpecs specs(Index<TableCriteria> src)
            {
                var dst = dict<RuleSig,TableSpec>();
                var specs = alloc<TableSpec>(src.Count);
                var seq = z16;
                for(var i=z16; i<src.Count; i++)
                {
                    ref readonly var table = ref src[i];
                    var tix = i;
                    var tk = table.TableKind;
                    ref readonly var sig = ref table.Sig;
                    var rows = alloc<RowSpec>(table.RowCount);
                    for(ushort j=0; j<table.RowCount; j++)
                    {
                        var rix = j;
                        ref readonly var row = ref table[j];
                        var left = row.Antecedant.Select(x => cellinfo(x.Type, LogicKind.Antecedant, x.Data));
                        var right = row.Consequent.Select(x => cellinfo(x.Type, LogicKind.Consequent, x.Data));
                        var count = left.Count + 1 + right.Count;
                        var keys = alloc<CellKey>(count);
                        var cells = alloc<CellInfo>(count);
                        var m=z8;
                        for(var k=0; k<left.Count; k++,m++)
                        {
                            seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Antecedant, left[k].Kind, tk, sig.TableName, left[k].Field);
                            seek(cells, m) = left[k];
                        }

                        {
                            seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Operator, RuleCellKind.Operator, tk, sig.TableName, FieldKind.INVALID);
                            seek(cells, m) = cellinfo(OperatorKind.Impl);
                            m++;
                        }

                        for(var k=0; k<right.Count; k++,m++)
                        {
                            seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Consequent, right[k].Kind, tk, sig.TableName, right[k].Field);
                            seek(cells, m) = right[k];
                        }
                        seek(rows,j) = new RowSpec(sig, tix, rix, keys, cells);
                    }

                    var spec = new TableSpec(tix, sig, rows);
                    seek(specs,i) = spec;
                    dst.Add(sig, spec);
                }
                return specs.Select(x => (x.Sig,x)).ToDictionary();
            }
        }
    }
}