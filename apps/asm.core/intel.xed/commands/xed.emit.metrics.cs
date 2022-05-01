//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/metrics")]
        Outcome EmitMetrics(CmdArgs args)
        {
            EmitRuleMetrics(CalcRuleCells());
            return true;
        }

        string CalcTableMetrics(in CellTable table)
        {
            var dst = text.emitter();
            dst.AppendLine(string.Format("{0:D3} {1,-32} {2}", table.TableIndex,  table.Sig.Format(), XedPaths.CheckedTableDef(table.Sig)));
            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine();
            for(var i=0; i<table.RowCount; i++)
            {
                ref readonly var row = ref table[i];

                if(i != 0)
                    dst.AppendLine();

                dst.AppendLineFormat("{0:D3} {1:D3}", table.TableIndex, row.RowIndex);
                dst.AppendLine(RP.PageBreak80);
                for(var j=0; j<row.CellCount; j++)
                {
                    ref readonly var cell = ref row[j];
                    ref readonly var key = ref cell.Key;
                    var descriptor = string.Format("{0:D3} {1:D3} {2:D3} {3}", table.TableIndex, row.RowIndex, key.Col, key.FormatSemantic());
                    dst.AppendLineFormat("{0} {1,-12} | {2}", descriptor, XedRender.format(cell.Field), cell);
                }

                dst.AppendLine(row.Expression);
            }

            dst.AppendLine(RP.PageBreak80);

            dst.Append(table.Grid().Format());

            return dst.Emit();
        }

        void EmitRuleMetrics(RuleCells src)
        {
            var dst = text.emitter();
            for(var i=0; i<src.TableCount; i++)
                dst.AppendLine(CalcTableMetrics(src[i]));
            FileEmit(dst.Emit(), src.TableCount, XedPaths.RuleTargets() + FS.file("xed.rules.metrics", FS.Txt));
        }
    }
}