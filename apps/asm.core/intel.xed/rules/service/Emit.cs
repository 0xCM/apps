//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public void Emit(Index<InstPattern> patterns, RuleTables rules)
        {
            exec(PllExec,
                () => EmitPatternData(patterns),
                () => EmitRuleData(rules)
            );
        }

        public void Emit(Index<IsaImport> src)
            => AppSvc.TableEmit(src, XedPaths.RefTable<IsaImport>());

        public void Emit(Index<CpuIdImport> src)
            => AppSvc.TableEmit(src, XedPaths.RefTable<CpuIdImport>());

        public void EmitInstGroups(Index<InstPattern> src)
            => EmitInstGroups(CalcInstGroups(src));

        public void EmitOpcodes(Index<InstPattern> src)
            => Emit(Xed.Views.OpCodes);

        public void EmitInstFields(Index<InstPattern> src)
            => AppSvc.TableEmit(Xed.Views.InstFields, XedPaths.InstTable<InstFieldRow>());

        public void EmitPatternRecords(Index<InstPattern> src)
            => AppSvc.TableEmit(CalcPatternRecords(src), XedPaths.InstTable<InstPatternRecord>());

        public void EmitOpDetails(Index<InstPattern> src)
            => Emit(CalcInstOpDetails(src));

        public Index<InstPattern> EmitPatternData(Index<InstPattern> src)
        {
            exec(PllExec,
                () => EmitPatternRecords(src),
                () => EmitFlagEffects(src),
                () => EmitInstAttribs(src),
                () => EmitInstFields(src),
                () => EmitInstGroups(src),
                () => EmitOpDetails(src),
                () => EmitOpcodes(src)
                );
            return src;
        }

        public void EmitRuleData(RuleTables src)
        {
            exec(PllExec,
                () => Emit(Xed.Views.CellDatasets),
                () => EmitRuleExpr(Xed.Views.CellTables),
                () => Emit(RuleTables.records(Xed.Views.CellTables)),
                () => EmitTableSpecs(Xed.Views.RuleTables),
                EmitSeq,
                () => EmitRulePages(Xed.Views.RuleTables)
            );
        }

        void Emit(OpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
            => TableEmit(src, XedPaths.InstTable<InstGroupSeq>(@class.ToString().ToLower()));

        public void EmitSeq()
        {
            exec(PllExec,
                () => EmitSeq(CellParser.ruleseq()),
                () => Emit(XedSeq.controls(), XedSeq.defs())
                );
        }

        public void Emit(Index<SeqControl> controls, Index<SeqDef> defs)
        {
            var dst = text.emitter();
            for(var i=0; i<controls.Count; i++)
            {
                if(i != 1)
                    dst.AppendLine();

                dst.AppendLine(controls[i].Format());
            }

            for(var i=0; i<defs.Count; i++)
            {
                dst.AppendLine();
                dst.AppendLine(defs[i].Format());
            }

            AppSvc.FileEmit(dst.Emit(), controls.Count + defs.Count, XedPaths.RuleTarget("seq.reflected", FS.Txt));
        }

        void EmitSeq(Index<RuleSeq> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            AppSvc.FileEmit(dst.Emit(), src.Count, XedPaths.RuleTarget("seq", FS.Txt));
        }

        public void Emit(Index<InstOpDetail> src)
        {
            exec(PllExec,
            () => Emit(CalcInstOpRows(src)),
            () => Emit(CalcOpClasses(src))
            );
        }

        public void Emit(CellDatasets src)
        {
            exec(PllExec,
                () => EmitRaw(src)

                );
        }

        void EmitRaw(CellDatasets src)
        {
            var dst = text.emitter();
            var count = CellRender.Tables.render(Xed.Views.CellTables.Cells(), dst);
            var data = Require.equal(dst.Emit(), src.RawFormat);
            AppSvc.FileEmit(data, src.TableCount, XedPaths.RuleTarget("cells.raw", FS.Csv));
        }

        public void Emit(ReadOnlySpan<MacroMatch> src)
            => AppSvc.TableEmit(src, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        public void Emit(ReadOnlySpan<FieldDef> src)
            => AppSvc.TableEmit(src, XedPaths.Table<FieldDef>());

        public void Emit(ReadOnlySpan<RuleCellRecord> src)
            => AppSvc.TableEmit(src, XedPaths.RuleTable<RuleCellRecord>());

        public void Emit(ReadOnlySpan<MacroDef> src)
            => AppSvc.TableEmit(src, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        public void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => AppSvc.TableEmit(src, PointerWidthInfo.RenderWidths, XedPaths.Table<PointerWidthInfo>());

        public void Emit(ReadOnlySpan<InstOpCode> src)
            => AppSvc.TableEmit(src, XedPaths.InstTable<InstOpCode>());

        public void Emit(ReadOnlySpan<InstOperandRow> src)
            => AppSvc.TableEmit(src, XedPaths.InstTable<InstOperandRow>());

        public void Emit(ReadOnlySpan<InstOpClass> src)
            => AppSvc.TableEmit(src, XedPaths.Table<InstOpClass>());

        public void Emit(ReadOnlySpan<XedFieldDef> src)
            => AppSvc.TableEmit(src, XedPaths.RefTable<XedFieldDef>());

        public void Emit(ReadOnlySpan<OpWidthRecord> src)
            => AppSvc.TableEmit(src, XedPaths.RefTable<OpWidthRecord>());

        public void Emit(ReadOnlySpan<RuleExpr> src)
            => AppSvc.TableEmit(src, XedPaths.RuleTable<RuleExpr>());
    }
}