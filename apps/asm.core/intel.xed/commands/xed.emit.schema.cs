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
        // void EmitRuleSchema(RuleCells src)
        // {
        //     const string RulePattern = "{0:D2} | {1,-12} | {2,-8} | {3,-32} | ";
        //     const string FieldPattern = "{0,-12} {1,-24}";
        //     var dst = text.emitter();
        //     var grids = XedGrids.grids(src);
        //     var stats = alloc<TableStats>(grids.TableCount);
        //     for(var i=0u; i<grids.TableCount; i++)
        //     {
        //         var rows = grids.Rows(i);
        //         ref readonly var rule = ref grids[i].Rule;

        //         dst.AppendLine();
        //         dst.AppendLineFormat("# {0}", grids[i].TablePath);
        //         var pw = 0u;
        //         var aw = 0u;
        //         var mpw = 0u;
        //         var maw = 0u;
        //         var mcc = 0u;

        //         var widths = rows.Storage.Select(x => x.Size());

        //         for(var j=z16; j<rows.Count; j++)
        //         {
        //             ref readonly var row = ref rows[j];
        //             var cols = row.Cols.Where(c => c.Field != 0);
        //             var count = cols.Count;
        //             ref readonly var width = ref skip(widths,j);

        //             if(count > mcc)
        //                 mcc = count;
        //             if(width.Packed > mpw)
        //                 mpw = width.Packed;
        //             if(width.Aligned> maw)
        //                 maw = width.Aligned;

        //             pw += width.Packed;
        //             aw += width.Aligned;

        //             dst.AppendFormat(RulePattern, j, (new DataSize(pw, aw)).Format(3,3,true), row.Size().Format(2,2,true), rule);
        //             for(var k=0; k<count; k++)
        //             {
        //                 ref readonly var col = ref cols[k];
        //                 dst.AppendFormat(FieldPattern, col.Size.Format(2,2,true), col.Field);
        //                 if(k != count - 1)
        //                     dst.Append(" | ");
        //             }

        //             dst.Append(Eol);
        //         }

        //         ref var ts = ref seek(stats,i);
        //         ts = new TableStats(i, rule, (ushort)rows.Count, new DataSize(pw, aw), new DataSize(mpw,maw),(byte)mcc);

        //         dst.AppendLine(RP.PageBreak180);
        //         dst.AppendLineFormat("TableSize:{0} MaxRowSize:{1} MaxColCount:{2}",
        //             ts.TableSize.Format(3,3,true),
        //             ts.MaxRowSize.Format(2,2,true),
        //             ts.MaxCols
        //             );
        //         dst.Append(Eol);
        //     }

        //     FileEmit(dst.Emit(), src.TableCount, XedDb.TargetPath("rules.tables", FileKind.Txt));
        //     TableEmit(@readonly(stats), TableStats.RenderWidths, XedDb.Table<TableStats>());
        // }
    }
}