//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/defs")]
        Outcome EmitDefs(CmdArgs args)
        {
            var rules = Xed.Rules.CalcRules();
            EmitCellDefs(rules);
            return true;
        }

        static SortedLookup<CellKey,XedRules.CellSpec> Lookup(Index<TableSpec> specs)
        {
            var dst = dict<CellKey,XedRules.CellSpec>();
            for(var i=0; i<specs.Count; i++)
            {
                ref readonly var spec = ref specs[i];
                for(ushort j=0; j<spec.RowCount; j++)
                {
                    ref readonly var row = ref spec[j];
                    ref readonly var a = ref row.Antecedant;
                    ref readonly var c = ref row.Consequent;
                    var m=z8;
                    for(var k=0; k<a.Count; k++,m++)
                        dst.Add(new CellKey(spec.TableKind, spec.TableId, j, LogicKind.Antecedant, m), a[k]);

                    dst.Add(new CellKey(spec.TableKind, spec.TableId, j, LogicKind.Antecedant, m++), new XedRules.CellSpec(OperatorKind.Impl));

                    for(var k=0; k<c.Count; k++,m++)
                        dst.Add(new CellKey(spec.TableKind, spec.TableId, j, LogicKind.Consequent, m), c[k]);
                }
            }
            return dst;
        }

        void EmitCellDefs(RuleTables rules)
        {
            var specs = rules.TableSpecs();
            var lookup = Lookup(specs);
            var idLookup = specs.Select(x => (x.TableId, x)).ToDictionary();
            const string Sep = " | ";
            var cols = new Pairings<string,byte>(new Paired<string,byte>[]{
                ("Kind", 16), ("TableName", 32), ("Row", 8),
                ("Expr", 32), ("Type",22), ("Source",32),
                });

            var count = cols.Count;
            var widths = alloc<byte>(count);
            iteri(count, i=> seek(widths,i) = cols[i].Right);
            var slots = mapi(widths, (i,w) => RP.slot((byte)i, (short)-w));
            var names = alloc<string>(count);
            iteri(count, i => names[i] = cols[i].Left);
            var RenderPattern = slots.Intersperse(" | ").Concat();
            var header = string.Format(RenderPattern, names);
            var keys = lookup.Keys;
            var dst = text.buffer();
            dst.AppendLine(header);
            for(var i=0; i<keys.Length; i++)
            {
                ref readonly var key =ref skip(keys,i);
                var cell = lookup[key];
                var type = TableCalcs.celltype(cell);

                // var value = CellValueExpr.Empty;
                // dst.AppendLineFormat(RenderPattern, key.TableKind, idLookup[key.TableId].TableName, key.RowIndex, value, type, cell.Data);
            }

            FileEmit(dst.Emit(), keys.Length, XedPaths.RuleTargets() + FS.file("xed.rules.expressions", FS.Csv), TextEncodingKind.Asci);
        }
    }
}