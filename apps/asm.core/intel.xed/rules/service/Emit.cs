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

        public Index<InstGroup> EmitInstGroups(Index<InstPattern> src)
        {
            var dst = CalcInstGroups(src);
            EmitInstGroups(dst);
            return dst;
        }

        public Index<PatternOpCode> EmitPoc(Index<InstPattern> src)
        {
            var data = CalcPoc(src);
            Emit(data);
            return data;
        }

        public Index<InstFieldRow> EmitInstFields(Index<InstPattern> src)
        {
            var data = CalcInstFields(src);
            TableEmit(data.View, InstFieldRow.RenderWidths, XedPaths.InstTable<InstFieldRow>());
            return data;
        }

        public Index<InstPatternRecord> EmitPatternRecords(Index<InstPattern> src)
        {
            var data = CalcPatternRecords(src);
            TableEmit(data.View, InstPatternRecord.RenderWidths, XedPaths.InstTable<InstPatternRecord>());
            return data;
        }

        public Index<InstOpDetail> EmitOpDetails(Index<InstPattern> src)
        {
            var data = CalcInstOpDetails(src);
            Emit(data);
            return data;
        }

        public Index<InstPattern> EmitPatternData(Index<InstPattern> src)
        {
            exec(PllExec,
                () => EmitPatternRecords(src),
                () => EmitFlagEffects(src),
                () => EmitInstAttribs(src),
                () => EmitInstFields(src),
                () => EmitInstGroups(src),
                () => EmitOpDetails(src),
                () => EmitPoc(src)
                );
            return src;
        }

        public void EmitRuleData(RuleTables src)
        {
            exec(PllExec,
                () => Emit(CalcRuleCells(src)),
                () => EmitTableDefReport(src),
                EmitSeq,
                () => EmitRulePages(src)
            );
        }

        void Emit(OpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
            => TableEmit(src, InstGroupSeq.RenderWidths, XedPaths.InstTable<InstGroupSeq>(@class.ToString().ToLower()));

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

            FileEmit(dst.Emit(), controls.Count + defs.Count, XedPaths.RuleTarget("seq.reflected", FS.Txt), TextEncodingKind.Asci);
        }

        void EmitSeq(Index<RuleSeq> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.RuleTarget("seq", FS.Txt), TextEncodingKind.Asci);
        }

        public void Emit(Index<InstOpDetail> src)
        {
            exec(PllExec,
            () => Emit(CalcInstOpRows(src)),
            () => Emit(CalcOpClasses(src))
            );
        }

        public void Emit(RuleCells src)
        {
            exec(PllExec,
                () => EmitRaw(src),
                () => Emit(src.Records.View)
                );
        }

        void EmitRaw(RuleCells src)
        {
            var dst = text.emitter();
            var count = CellRender.Tables.render(src.Values, dst);
            var data = Require.equal(dst.Emit(), src.Description);
            FileEmit(data, count, XedPaths.RuleTarget("cells.raw", FS.Csv), TextEncodingKind.Asci);
        }

        void Emit(ReadOnlySpan<MacroMatch> src)
            => TableEmit(src, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        void Emit(ReadOnlySpan<FieldDef> src)
            => TableEmit(src, FieldDef.RenderWidths, XedPaths.Table<FieldDef>());

        void Emit(ReadOnlySpan<RuleCellRecord> src)
            => TableEmit(src, RuleCellRecord.RenderWidths, XedPaths.RuleTable<RuleCellRecord>());

        void Emit(ReadOnlySpan<MacroDef> src)
            => TableEmit(src, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => TableEmit(src, PointerWidthInfo.RenderWidths, XedPaths.Table<PointerWidthInfo>());

        void Emit(ReadOnlySpan<PatternOpCode> src)
            => TableEmit(src, PatternOpCode.RenderWidths, XedPaths.InstTable<PatternOpCode>());

        void Emit(ReadOnlySpan<InstOperandRow> src)
            => TableEmit(src, InstOperandRow.RenderWidths, XedPaths.InstTable<InstOperandRow>());

        void Emit(ReadOnlySpan<InstOpClass> src)
            => TableEmit(src, InstOpClass.RenderWidths, XedPaths.Table<InstOpClass>());

        void Emit(ReadOnlySpan<XedFieldDef> src)
            => TableEmit(src, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        void Emit(ReadOnlySpan<OpWidthInfo> src)
            => TableEmit(src, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());
    }
}