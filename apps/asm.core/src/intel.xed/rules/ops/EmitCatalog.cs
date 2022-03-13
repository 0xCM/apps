//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public void EmitCatalog()
        {
            var defs = CalcInstDefs();
            var patterns = CalcInstPatterns(defs);
            var actions = new Action[]{
                () => TableEmit(CalcPatternInfo(patterns)),
                () => EmitPatternDetails(defs),
                () => TableEmit(CalcPatternOps(defs)),
                EmitRuleTables,
                EmitFieldDefs,
                EmitRuleSeq,
                EmitOperandWidths,
                EmitPointerWidths,
                EmitOpCodeKinds,
                EmitMacroAssignments,
                EmitFieldSpecs};

            iter(actions, a => a(), true);
        }

        void TableEmit(Index<PatternInfo> src)
            => TableEmit(src.View, PatternInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodes));

        void EmitRuleSeq()
        {
            var src = CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.FieldDefsTarget());

        void EmitPatternDetails(Index<InstDef> src)
            => EmitPatternDetails(src, AppDb.XedPath("xed.rules.detail", FileKind.Txt));

        void TableEmit(Index<PatternOpDetail> src)
            => TableEmit(src.View, PatternOpDetail.RenderWidths, AppDb.XedTable<PatternOpDetail>());

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitMacroAssignments()
            => TableEmit(CalcMacroAssignments().View, MacroAssignment.RenderWidths, XedPaths.DocTarget(XedDocKind.MacroAssignments));

        void EmitFieldSpecs()
            => TableEmit(CalcFieldSpecs().View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());

        void EmitRuleTables()
        {
            var tables = CalcRuleTables();
            var sigs = tables.Keys.ToArray().Sort();
            var path = AppDb.XedPath("xed.rules.tables", FileKind.Txt);
            var emitting = EmittingFile(path);
            using var writer = path.AsciWriter();
            for(var i=0; i<sigs.Length; i++)
                writer.WriteLine(tables[skip(sigs,i)].Format());

            EmittedFile(emitting, sigs.Length);
        }

        void EmitOperandWidths()
            => TableEmit(CalcOperandWidths().View, AppDb.XedTable<OpWidth>());

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}