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
            var patterns = EmitPatterns();
            EmitOpCodes(patterns);
            var actions = new Action[]{
                EmitEncPatternDetails,
                EmitDecPatternDetails,
                EmitRuleTables,
                EmitFieldDefs,
                EmitRuleSeq,
                EmitOperandWidths,
                EmitPointerWidths,
                EmitOpCodeKinds,
                EmitMacroAssignments,
                EmitFieldSpecs};

            iter(actions, a => a(), false);
        }

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.FieldDefsTarget());

        void EmitDecPatternDetails()
            => EmitPatternDetails(CalcDecInstDefs(), AppDb.XedPath("xed.rules.dec.detail", FileKind.Txt), AppDb.XedPath("xed.rules.dec.ops", FileKind.Csv));

        void EmitEncPatternDetails()
            => EmitPatternDetails(CalcEncInstDefs(), AppDb.XedPath("xed.rules.enc.detail", FileKind.Txt), AppDb.XedPath("xed.rules.enc.ops", FileKind.Csv));

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitMacroAssignments()
            => TableEmit(CalcMacroAssignments().View, MacroAssignment.RenderWidths, XedPaths.DocTarget(XedDocKind.MacroAssignments));

        void EmitFieldSpecs()
            => TableEmit(CalcFieldSpecs().View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());

        void EmitOpCodes(Index<RulePatternInfo> patterns)
            => TableEmit(CalcOpCodes(patterns).View, XedOpCode.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodes));

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