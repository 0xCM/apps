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
        bool PllWf {get;} = true;

        public static void exec(params Action[] src)
            => iter(src, a => a(), true);

        public static void exec(bool pll, params Action[] src)
            => iter(src, a => a(), pll);

        public void EmitCatalog()
        {
            var defs = CalcInstDefs();
            var patterns = CalcInstPatterns(defs);
            exec(PllWf,
                () => EmitPatternData(patterns),
                EmitRuleTables,
                EmitFieldDefs,
                EmitRuleSeq,
                EmitOperandWidths,
                EmitPointerWidths,
                EmitOpCodeKinds,
                EmitMacroAssignments,
                EmitReflectedFields);
        }

        void EmitRuleTables()
            => RuleTables.create(Wf).EmitTables();

        void EmitPatternData(Index<InstPattern> src)
            => exec(PllWf,
                () => EmitPatternInfo(src),
                () => EmitPatternDetails(src),
                () => EmitPatternOps(src)
                );

        void EmitPatternInfo(Index<InstPattern> patterns)
            => TableEmit(CalcPatternInfo(patterns));

        void EmitPatternOps(Index<InstPattern> patterns)
            => TableEmit(CalcPatternOps(patterns));

        void EmitRuleSeq()
        {
            var src = CalcRuleSeq();
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format()));
            FileEmit(dst.Emit(), src.Count, XedPaths.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
        }

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs());

        void TableEmit(Index<PatternInfo> src)
            => TableEmit(src.View, PatternInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodes));

        void TableEmit(Index<XedFieldDef> src)
            => TableEmit(src.View, XedFieldDef.RenderWidths, XedPaths.FieldDefsTarget());

        void EmitPatternDetails(Index<InstPattern> src)
            => EmitPatternDetails(src, AppDb.XedPath("xed.rules.detail", FileKind.Txt));

        void TableEmit(Index<PatternOpDetail> src)
            => TableEmit(src.View, PatternOpDetail.RenderWidths, AppDb.XedTable<PatternOpDetail>());

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitMacroAssignments()
            => TableEmit(CalcMacroAssignments().View, MacroAssignment.RenderWidths, XedPaths.DocTarget(XedDocKind.MacroAssignments));

        void EmitReflectedFields()
            => TableEmit(XedFields.Specs.View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());

        void EmitOperandWidths()
            => TableEmit(CalcOperandWidths().View, AppDb.XedTable<OpWidth>());

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}