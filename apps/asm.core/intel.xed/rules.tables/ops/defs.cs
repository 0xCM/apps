//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        partial struct TableCalcs
        {
            // public static Index<TableDef> defs(RuleTables rules)
            // {
            //     var src = rules.TableSpecs();
            //     var count = src.Count;
            //     var dst = alloc<TableDef>(count);
            //     defs(src, dst);
            //     return dst;
            // }

            // public static void defs(Index<TableSpec> src, Span<TableDef> dst)
            // {
            //     for(var i=0; i<src.Count; i++)
            //         seek(dst,i) = def(src[i]);
            // }

            // public static TableDef def(in TableSpec src)
            // {
            //     ref readonly var sig = ref src.Sig;
            //     var table = (ushort)src.TableId;
            //     var rows = alloc<RowDef>(src.RowCount);
            //     for(var i=z16; i<src.RowCount; i++)
            //     {
            //         ref readonly var spec = ref src[i];
            //         ref readonly var a = ref spec.Antecedant;
            //         ref readonly var c = ref spec.Consequent;
            //         var count =  a.Count + c.Count;
            //         if(a.Count != 0 && c.Count !=0)
            //             count++;

            //         var cells = alloc<CellDef>(count);
            //         var k = z8;
            //         var counter = z8;

            //         counter += celldefs(src, spec.Antecedant, LogicKind.Antecedant, i, ref k, cells);

            //         if(a.Count != 0 && c.Count !=0)
            //         {
            //             seek(cells,k) = new (new CellKey(sig.TableKind, table, i, LogicKind.Operator, k), RuleOperator.Impl);
            //             k++;
            //             counter++;
            //         }

            //         counter += celldefs(src, spec.Consequent, LogicKind.Consequent, i, ref k, cells);

            //         seek(rows,i) = new RowDef(table, i, cells);
            //     }

            //     return new TableDef(table, sig, rows);
            // }
        }
    }
}