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

        void EmitRuleSchema(RuleCells src)
        {
            const string RulePattern = "{0:D2} | {1,-8} | {2,-8} | {3,-32} | ";
            const string FieldPattern = "{0,-8} {1,-24}";
            var dst = text.emitter();
            var grids = XedGrids.grids(src);
            for(var i=0; i<grids.TableCount; i++)
            {
                var rows = grids.Rows(i);
                ref readonly var rule = ref grids[i].Rule;

                dst.AppendLine();
                dst.AppendLineFormat("# {0}", grids[i].TablePath);
                var pw = 0u;
                var aw = 0u;
                var mpw = 0u;
                var maw = 0u;
                var mcc = 0u;

                var widths = rows.Storage.Select(x => x.Size());


                for(var j=z16; j<rows.Count; j++)
                {
                    ref readonly var row = ref rows[j];
                    var cols = row.Cols.Where(c => c.Field != 0);
                    var count = cols.Count;
                    ref readonly var width = ref skip(widths,j);

                    if(count > mcc)
                        mcc = count;
                    if(width.Packed > mpw)
                        mpw = width.Packed;
                    if(width.Aligned> maw)
                        maw = width.Aligned;

                    pw += width.Packed;
                    aw += width.Aligned;

                    dst.AppendFormat(RulePattern, j, (new DataSize(pw, aw)).Format(3,3,true), row.Size().Format(2,2,true), rule);
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var col = ref cols[k];
                        dst.AppendFormat(FieldPattern, col.Size.Format(2,2,true), col.Field);
                        if(k != count - 1)
                            dst.Append(" | ");
                    }

                    dst.Append(Eol);
                }

                dst.AppendLine(RP.PageBreak180);
                dst.AppendLineFormat("TableSize:{0} MaxRowSize:{1} MaxColCount:{2}",
                    (new DataSize(pw, aw)).Format(3,3,true),
                    new DataSize(mpw,maw).Format(2,2,true),
                    mcc
                    );
                dst.Append(Eol);
            }

            FileEmit(dst.Emit(), src.TableCount, XedDb.TargetPath("rules.tables", FileKind.Txt));
        }
    }
}