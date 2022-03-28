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
            exec(PllExec,
                () => EmitPatternInfo(patterns),
                () => EmitPatternDetails(patterns),
                () => EmitPatternOps(patterns),
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
                EmitFieldDefs
                );

            EmitRuleTables(CalcTableSet(), patterns);
        }

        void EmitIsaPages(RuleTableSet tables, Index<InstPattern> src)
            => Patterns.EmitIsaPages(tables, src);

        public Index<InstDef> CalcInstDefs()
            => Data(nameof(InstDef), () => Patterns.ParseInstDefs(XedPaths.DocSource(XedDocKind.EncInstDef)));

        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<MacroMatch> CalcMacroMatches()
            => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
            => Data(nameof(InstPattern), () => Patterns.CalcPatterns(defs));

        void EmitSymbolicFields()
            => ApiMetadataService.create(Wf).EmitTokenSet(XedFields.SymbolicFields.create(), AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));

        void EmitFieldDefs()
            => TableEmit(CalcFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        void EmitReflectedFields()
            => TableEmit(XedFields.Specs.View, RuleFieldSpec.RenderWidths, XedPaths.Table<RuleFieldSpec>());

        void EmitOpCodes(Index<InstPattern> src)
            => TableEmit(CalcOpCodeDetails(src).View, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());

        void EmitInstFields(Index<InstPattern> src)
            => TableEmit(Patterns.CalcInstFields(src).View, InstFieldInfo.RenderWidths, XedPaths.Table<InstFieldInfo>());

        void EmitPatternInfo(Index<InstPattern> src)
            => TableEmit(XedPatterns.describe(src).View, InstPatternInfo.RenderWidths, XedPaths.Table<InstPatternInfo>());

        void EmitPatternDetails(Index<InstPattern> src)
            => EmitPatternDetails(src, XedPaths.DocTarget(XedDocKind.PatternDetail));

        void EmitPatternOps(Index<InstPattern> src)
            => TableEmit(CalcOpRecords(src).View, PatternOpInfo.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));


        void EmitMacroDefs()
            => TableEmit(CalcMacroDefs().View, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        void EmitMacroMatches()
            => TableEmit(CalcMacroMatches().View, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitOpWidths()
            => TableEmit(XedTables.Widths.View, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}