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
            var defs = CalcInstDefs();
            var patterns = CalcInstPatterns(defs);
            exec(PllExec,
                () => EmitPatternData(patterns),
                () => EmitFlagEffects(defs),
                EmitRuleTables,
                EmitRefData,
                EmitMacroMatches,
                EmitMacroDefs,
                EmitReflectedFields,
                EmitSymbolicFields,
                EmitRuleSpecs,
                EmitFieldDefs
                );
        }

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

        void EmitPatternData(Index<InstPattern> src)
            => exec(PllExec,
                () => EmitPatternInfo(src),
                () => EmitPatternDetails(src),
                () => EmitPatternOps(src),
                () => EmitOpCodes(src),
                () => EmitInstFieldDefs(src)
                );

        void EmitRuleTables()
            => RuleTables.EmitTables(true);

        void EmitMacroDefs()
            => TableEmit(CalcMacroDefs().View, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        void EmitMacroMatches()
            => TableEmit(CalcMacroMatches().View, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        void EmitRuleSpecs()
        {
            exec(PllExec,
                () => EmitSpecs(RuleTableKind.Enc),
                () => EmitSpecs(RuleTableKind.Dec),
                () => EmitSpecs(RuleTableKind.EncDec)
                );
        }
    }
}