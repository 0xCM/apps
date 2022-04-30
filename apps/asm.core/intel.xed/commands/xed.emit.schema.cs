//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static MemDb;
    using static core;

    partial class XedCmdProvider
    {
        XedDb XedDb => Service(Wf.XedDb);

        [CmdOp("xed/emit/schema")]
        Outcome EmitSchema(CmdArgs args)
        {
            var dst = text.emitter();
            var objects = XedDb.Schema.Objects;
            var render = XedDb.Render;

            dst.AppendLine(TypeTable.header());
            var count = objects.ObjectCount(ObjectKind.TypeTable);
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref objects.TypeTable(i);
                dst.Append(table.Format());
            }
            FileEmit(dst.Emit(), count, XedDb.TargetPath("typetables", FileKind.Csv), TextEncodingKind.Asci);

            EmitRuleSchema(CalcRuleCells());

            return true;
        }

        static string format(DataSize src)
            => string.Format("[{0:D2}:{1:D2}]", src.Aligned.Width, src.Packed);

        static string format(ByteSize aligned, BitWidth packed)
            => string.Format("[{0:D3}:{1:D3}]", (ulong)aligned, (ulong)packed);

        void EmitRuleSchema(RuleCells src)
        {
            const string RulePattern = "{0:D2} | {1} | {2,-6} | {3,-32} | ";
            const string FieldPattern = "{0,-6} {1,-24}";
            var dst = text.emitter();
            var grids = src.Grids();
            for(var i=0; i<grids.TableCount; i++)
            {
                var rows = grids.Rows(i);
                ref readonly var rule = ref grids[i].Rule;

                dst.AppendLine();
                dst.AppendLineFormat("# {0}", grids[i].TablePath);
                var aw = 0ul;
                var pw = 0ul;

                var widths = rows.Storage.Select(x => (aligned: x.AlignedWidth(), packed: x.PackedWidth()));

                for(var j=z16; j<rows.Count; j++)
                {
                    ref readonly var row = ref rows[j];
                    var cols = row.Cols.Where(c => c.Field != 0);
                    var count = cols.Count;
                    ref readonly var width = ref skip(widths,j);
                    aw += width.aligned;
                    pw += width.packed;

                    dst.AppendFormat(RulePattern, j, format(aw, pw), format(row.AlignedWidth(), row.PackedWidth()), rule);
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var col = ref cols[k];
                        dst.AppendFormat(FieldPattern, format(col.Size), col.Field);
                        if(k != count - 1)
                            dst.Append(" | ");
                    }
                    dst.Append(Eol);
                }
            }

            FileEmit(dst.Emit(), src.TableCount, XedDb.TargetPath("rules.tables.2", FileKind.Txt));
        }
    }
}