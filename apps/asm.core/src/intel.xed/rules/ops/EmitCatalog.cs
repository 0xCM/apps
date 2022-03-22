//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

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
                EmitMacroData,
                EmitFields,
                EmitRuleSpecs
                );
        }


        public Index<InstDef> CalcInstDefs()
            => Data(nameof(CalcInstDefs), () => InstDefParser.parse(XedPaths.DocSource(XedDocKind.EncInstDef)));

        public Index<InstPattern> CalcInstPatterns()
            => CalcInstPatterns(CalcInstDefs());

        Index<InstPattern> CalcInstPatterns(Index<InstDef> defs)
            => Data(nameof(CalcInstPatterns), () => XedPatterns.patterns(defs));

        public void EmitRuleTables()
            => RuleTables.EmitTables(true);

        void EmitPatternData(Index<InstPattern> src)
            => exec(PllExec,
                () => EmitPatternInfo(src),
                () => EmitPatternDetails(src),
                () => EmitPatternOps(src),
                () => EmitOpCodes(src)
                );

        void EmitMacroData()
        {
            var matches = mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));
            TableEmit(@readonly(matches), MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());
            TableEmit(CalcMacroDefs().View, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());
        }

        public void EmitFields()
        {
            exec(PllExec,
                EmitFieldDefs,
                EmitReflectedFields,
                EmitSymbolicFields
                );
        }

        public void EmitRuleSpecs()
        {
            exec(true,
                () => EmitSpecs(RuleTableKind.Enc),
                () => EmitSpecs(RuleTableKind.Dec),
                () => EmitSpecs(RuleTableKind.EncDec)
                );
        }

    }
}