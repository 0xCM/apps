//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;
    using static XedModels;

    partial class XedRules
    {
        public void EmitCatalog()
        {
            var patterns = CalcInstPatterns(CalcInstDefs());
            var tables = RuleTables.Empty;
            exec(PllExec,
                () => EmitPatternInfo(patterns),
                () => EmitOpCodes(patterns),
                () => EmitInstFields(patterns),
                () => EmitFlagEffects(patterns),
                EmitOpCodeKinds,
                EmitOpWidths,
                EmitPointerWidths,
                EmitMacroMatches,
                EmitMacroDefs,
                EmitReflectedFields,
                EmitSymbolicFields,
                EmitFieldDefs,
                () => tables = CalcRules()
                );

            exec(PllExec,
                () => EmitRuleTables(tables, patterns),
                () => EmitPatternDetails(tables, patterns),
                () => EmitIsaPages(tables,patterns),
                () => Docs.EmitDocs(tables,patterns)
                );
        }

        Index<InstDef> CalcInstDefs()
            => Data(nameof(InstDef), () => Patterns.ParseInstDefs(XedPaths.DocSource(XedDocKind.EncInstDef)));

        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<MacroMatch> CalcMacroMatches()
            => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
            => Data(nameof(InstPattern), () => XedPatterns.patterns(defs));

        void EmitSymbolicFields()
            => ApiMetadataService.create(Wf).EmitTokenSet(XedFields.SymbolicFields.create(), AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        void EmitReflectedFields()
            => TableEmit(XedFields.Specs.View, RuleFieldSpec.RenderWidths, XedPaths.Table<RuleFieldSpec>());

        void EmitOpCodes(Index<InstPattern> src)
            => TableEmit(XedPatterns.poc(src).View, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());

        void EmitInstFields(Index<InstPattern> src)
            => TableEmit(XedPatterns.fieldrows(src).View, InstFieldRow.RenderWidths, XedPaths.Table<InstFieldRow>());

        void EmitPatternInfo(Index<InstPattern> src)
            => TableEmit(XedPatterns.describe(src).View, InstPatternRecord.RenderWidths, XedPaths.Table<InstPatternRecord>());

        void EmitPatternDetails(RuleTables tables, Index<InstPattern> src)
            => EmitPatternDetails(tables, src, XedPaths.DocTarget(XedDocKind.PatternDetail));

        void EmitPatternOps(RuleTables tables, Index<InstPattern> src)
            => TableEmit(CalcOpRecords(tables, src).View, PatternOpRow.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));

        void EmitMacroDefs()
            => TableEmit(CalcMacroDefs().View, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        void EmitMacroMatches()
            => TableEmit(CalcMacroMatches().View, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitOpWidths()
            => TableEmit(XedTables.WidthRecords.View, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}