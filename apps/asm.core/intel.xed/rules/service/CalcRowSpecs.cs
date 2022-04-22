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
        public static Index<TableSpec> resequence(Index<TableSpec> src)
        {
            var dst = src.Where(t => t.IsNonEmpty).Sort();
            for(var i=z16; i<dst.Count; i++)
            {
                ref var table = ref dst[i];
                var sig = new RuleSig(table.Name, table.TableKind);
                var rows = table.Rows.Where(r => r.Keys.IsNonEmpty && r.Cells.IsNonEmpty).Sort();
                for(var j=z16; j<rows.Count; j++)
                {
                    ref var row = ref rows[j];
                    var count = Require.equal(row.Cells.Count, row.Keys.Count);
                    var kL = row.Keys.Where(k => k.Logic == LogicKind.Antecedant).Sort();
                    var kO = row.Keys.Where(k => k.Logic == LogicKind.Operator).Sort();
                    var kR = row.Keys.Where(k => k.Logic == LogicKind.Consequent).Sort();
                    Require.equal(count, kL.Count + kO.Count + kR.Count);

                    var n = z16;
                    var keySource = kL;
                    var lookup = alloc<Tripled<ushort,CellKey,CellInfo>>(count);
                    for(var k=0; k<count; k++)
                    {
                        keySource = kL;
                        for(var q=z8; k<keySource.Count; q++, n++)
                            seek(lookup,n) = (n, row.Keys[n], row.Cells[n]);

                        keySource = kO;
                        for(var q=z8; k<keySource.Count; q++, n++)
                            seek(lookup,n) = (n, row.Keys[n], row.Cells[n]);

                        keySource = kR;
                        for(var q=z8; k<keySource.Count; q++, n++)
                            seek(lookup,n) = (n, row.Keys[n], row.Cells[n]);
                    }

                    var keys = alloc<CellKey>(count);
                    var cells = alloc<CellInfo>(count);
                    var logic = LogicKind.Antecedant;
                    var m=z8;
                    keySource = kL;
                    for(var k=z8; k<keySource.Length; k++, m++)
                    {
                        ref readonly var triple = ref lookup[m];
                        seek(cells,m) = triple.Third;
                        seek(keys,m) = new CellKey(table.Sig, i, j, logic, m);
                    }

                    logic = LogicKind.Operator;
                    keySource = kO;
                    for(var k=z8; k<keySource.Length; k++, m++)
                    {
                        ref readonly var triple = ref lookup[m];
                        seek(cells, m) = triple.Third;
                        seek(keys, m) = new CellKey(table.Sig, i, j, logic, m);
                    }

                    logic = LogicKind.Consequent;
                    keySource = kR;
                    for(var k=z8; k<keySource.Length; k++, m++)
                    {
                        ref readonly var triple = ref lookup[m];
                        seek(cells, m) = triple.Third;
                        seek(keys, m) = new CellKey(table.Sig, i, j, logic, m);
                    }

                    row = new RowSpec(sig, i, j, keys, cells);
                }

                table = new TableSpec(table.Sig, rows);
            }
            return dst;
        }

        static Dictionary<RuleSig,TableSpec> lookup(Index<TableCriteria> src)
        {
            var dst = dict<RuleSig,TableSpec>();
            var specs = alloc<TableSpec>(src.Count);
            for(var i=z16; i<src.Count; i++)
            {

                ref readonly var table = ref src[i];
                //var tid = (ushort)table.TableId;
                var tid = i;
                var tk = table.TableKind;
                ref readonly var sig = ref table.Sig;
                var rows = alloc<RowSpec>(table.RowCount);
                for(ushort j=0; j<table.RowCount; j++)
                {
                    var rid = j;
                    ref readonly var row = ref table[j];
                    ref readonly var a = ref row.Antecedant;
                    ref readonly var c = ref row.Consequent;
                    var count = a.Count + 1 + c.Count;
                    var keys = alloc<CellKey>(count);
                    var cells = alloc<CellInfo>(count);
                    var m=z8;
                    for(var k=0; k<a.Count; k++,m++)
                    {
                        seek(keys, m) = new CellKey(sig, tid, rid, LogicKind.Antecedant, m);
                        seek(cells, m) = a[k];
                    }

                    {
                        seek(keys, m) = new CellKey(sig, tid, rid, LogicKind.Operator, m);
                        seek(cells, m) = new XedRules.CellInfo(OperatorKind.Impl);
                        m++;
                    }

                    for(var k=0; k<c.Count; k++,m++)
                    {
                        seek(keys, m) = new CellKey(sig, tid, rid, LogicKind.Consequent, m);
                        seek(cells, m) = c[k];
                    }
                    seek(rows,j) = new RowSpec(sig, tid, rid, keys, cells);
                }

                var spec = new TableSpec(sig, rows);
                seek(specs,i) = spec;
                dst.Add(sig, spec);
            }
            //var result = resequence(specs).Select(s => (s.Sig,s)).ToDictionary();
            var result = specs.Select(x => (x.Sig,x)).ToDictionary();
            return result;
        }
    }
}