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
        public void EmitCatalog()
        {
            var patterns = Index<InstPattern>.Empty;
            var tables = RuleTables.Empty;
            exec(PllExec,
                EmitFieldSpecs,
                EmitOpCodeKinds,
                EmitOpWidths,
                EmitPointerWidths,
                EmitMacroMatches,
                EmitMacroDefs,
                EmitReflectedFields,
                EmitSymbolicFields,
                EmitFieldImports,
                () => tables = EmitRules(CalcRules()),
                () => patterns = EmitPatterns(CalcPatterns())
            );

            Docs.EmitInstDocs(patterns);
        }

        Index<MacroMatch> CalcMacroMatches()
            => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

        void EmitMacroDefs()
            => TableEmit(CalcMacroDefs().View, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());

        void EmitMacroMatches()
            => TableEmit(CalcMacroMatches().View, MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());

        void EmitSymbolicFields()
            => ApiMetadataService.create(Wf).EmitTokenSet(XedFields.EffectiveFields.create(), AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));

        void EmitFieldImports()
            => TableEmit(ImportFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        void EmitReflectedFields()
            => TableEmit(XedFields.ByPosition.Valid, ReflectedField.RenderWidths, XedPaths.Table<ReflectedField>());

        void EmitOpCodeKinds()
            => TableEmit(OpCodeKinds.Instance.Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitOpWidths()
            => TableEmit(XedWidths.Records.View, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());

        Index<PointerWidthInfo> CalcPointerWidths()
            => Data(nameof(CalcPointerWidths), () => mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i)));

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}