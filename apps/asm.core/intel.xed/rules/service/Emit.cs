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
                () => Emit(CellParser.ruleseq()),
                () => EmitTableDefs(src)
            );
        }

        public void Emit(OpCodeClass @class, ReadOnlySpan<InstGroupSeq> src)
            => TableEmit(src, InstGroupSeq.RenderWidths, XedPaths.Table<InstGroupSeq>(@class.ToString().ToLower()));

        public void Emit(Index<RuleSeq> src)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.Service.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        public void Emit(ReadOnlySpan<MacroMatch> src)
            => TableEmit(src, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        public void Emit(ReadOnlySpan<ReflectedField> src)
            => TableEmit(src, ReflectedField.RenderWidths, XedPaths.Table<ReflectedField>());

        public void Emit(ReadOnlySpan<RuleCellRecord> src)
            => TableEmit(src, RuleCellRecord.RenderWidths, XedPaths.RuleTable<RuleCellRecord>());

        public void Emit(ReadOnlySpan<MacroDef> src)
            => TableEmit(src, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        public void Emit(ReadOnlySpan<PointerWidthInfo> src)
            => TableEmit(src, PointerWidthInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.PointerWidths));

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
            => TableEmit(src, InstOperandRow.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));

        public void Emit(ReadOnlySpan<InstOpClass> src)
            => TableEmit(src, InstOpClass.RenderWidths, XedPaths.Table<InstOpClass>());

        public void Emit(ReadOnlySpan<InstLayout> src)
            => TableEmit(src, InstLayout.RenderWidths, XedPaths.Table<InstLayout>());

        public void Emit(ReadOnlySpan<XedFieldDef> src)
            => TableEmit(src, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());
    }
}