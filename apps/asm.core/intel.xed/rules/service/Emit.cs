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
                () => Emit(patterns),
                () => Emit(rules)
            );

            EmitDocs(patterns,rules);
        }

        public void EmitDocs(Index<InstPattern> patterns, RuleTables rules)
        {
            exec(PllExec,
                () => Docs.EmitDocs(patterns),
                () => Docs.EmitDocs(rules)
            );
        }

        public void Emit(RuleTables src)
        {
            exec(PllExec,
                () => EmitCellDetail(CalcRuleCells(src)),
                () => EmitTableDefReport(src),
                EmitSeq,
                () => EmitTableDefs(src)
            );
        }

        public void Emit(OpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
            => TableEmit(src, InstGroupSeq.RenderWidths, XedPaths.Table<InstGroupSeq>(@class.ToString().ToLower()));

        public void EmitSeq()
        {
            exec(PllExec,
                () => Emit(CellParser.ruleseq()),
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

            FileEmit(dst.Emit(), controls.Count + defs.Count, XedPaths.RuleTarget("seq.reflected", FS.Txt), TextEncodingKind.Asci);
        }

        public void Emit(Index<RuleSeq> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.RuleTarget("seq", FS.Txt), TextEncodingKind.Asci);
        }

        public void Emit(ReadOnlySpan<MacroMatch> src)
            => TableEmit(src, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        public void Emit(ReadOnlySpan<FieldDef> src)
            => TableEmit(src, FieldDef.RenderWidths, XedPaths.Table<FieldDef>());

        public void Emit(ReadOnlySpan<RuleCellRecord> src)
            => TableEmit(src, RuleCellRecord.RenderWidths, XedPaths.RuleTable<RuleCellRecord>());

        public void Emit(ReadOnlySpan<MacroDef> src)
            => TableEmit(src, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        public void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => TableEmit(src, PointerWidthInfo.RenderWidths, XedPaths.Table<PointerWidthInfo>());

        public void Emit(ReadOnlySpan<PatternOpCode> src)
            => TableEmit(src, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());

        public void Emit(Index<InstOpDetail> src)
        {
            exec(PllExec,
            () => Emit(CalcInstOpRows(src)),
            () => Emit(CalcOpClasses(src))
            );
        }

        public void Emit(ReadOnlySpan<InstFieldRow> src)
            => TableEmit(src, InstFieldRow.RenderWidths, XedPaths.Table<InstFieldRow>());

        public void Emit(ReadOnlySpan<InstPatternRecord> src)
            => TableEmit(src, InstPatternRecord.RenderWidths, XedPaths.Table<InstPatternRecord>());

        public void Emit(ReadOnlySpan<InstOperandRow> src)
            => TableEmit(src, InstOperandRow.RenderWidths, XedPaths.Table<InstOperandRow>());

        public void Emit(ReadOnlySpan<InstOpClass> src)
            => TableEmit(src, InstOpClass.RenderWidths, XedPaths.Table<InstOpClass>());

        public void Emit(ReadOnlySpan<InstLayoutRecord> src)
            => TableEmit(src, InstLayoutRecord.RenderWidths, XedPaths.Table<InstLayoutRecord>());

        public void Emit(ReadOnlySpan<XedFieldDef> src)
            => TableEmit(src, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        public void Emit(ReadOnlySpan<OpWidthInfo> src)
            => TableEmit(src, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());
    }
}