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
                () => EmitInstGroups(patterns),
                EmitFieldSpecs,
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
                () => EmitRules(tables, patterns),
                () => EmitCellSpecs(tables),
                () => EmitPatternDetails(tables, patterns),
                () => EmitIsaPages(tables,patterns),
                () => EmitInstLayouts(patterns),
                () => Docs.EmitDocs(tables,patterns)
                );
        }

        void EmitPatternDetails(RuleTables tables, Index<InstPattern> src, FS.FilePath dst)
        {
            src.Sort();
            var formatter = InstPageFormatter.create(tables);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
                writer.Write(formatter.Format(src[j]));

            EmittedFile(emitting, src.Count);
        }

        void EmitIsaPages(RuleTables tables, Index<InstPattern> src)
        {
            XedPaths.InstIsaRoot().Delete();
            var groups = InstPageFormatter.FormatGroups(tables, src);
            iter(groups, EmitIsaGroup, PllExec);
        }

        void EmitIsaGroup(InstIsaFormat src)
        {
            var dst = XedPaths.InstIsaPath(src.Isa);
            Require.invariant(!dst.Exists);
            FileEmit(src.Content, src.LineCount, dst, TextEncodingKind.Asci);
        }

        Index<MacroMatch> CalcMacroMatches()
            => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

        void EmitSymbolicFields()
            => ApiMetadataService.create(Wf).EmitTokenSet(XedFields.EffectiveFields.create(), AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));

        void EmitFieldDefs()
            => TableEmit(ImportFieldDefs().View, XedFieldDef.RenderWidths, XedPaths.Table<XedFieldDef>());

        void EmitReflectedFields()
            => TableEmit(XedFields.Reflected.View, ReflectedField.RenderWidths, XedPaths.Table<ReflectedField>());

        void EmitOpCodes(Index<InstPattern> src)
            => TableEmit(XedOpCodes.poc(src).View, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());

        void EmitInstFields(Index<InstPattern> src)
            => TableEmit(XedPatterns.fieldrows(src).View, InstPatternFields.RenderWidths, XedPaths.Table<InstPatternFields>());

        void EmitPatternInfo(Index<InstPattern> src)
            => TableEmit(XedPatterns.describe(src).View, InstPatternRecord.RenderWidths, XedPaths.Table<InstPatternRecord>());

        void EmitPatternDetails(RuleTables tables, Index<InstPattern> src)
            => EmitPatternDetails(tables, src, XedPaths.DocTarget(XedDocKind.PatternDetail));

        void EmitOperandRows(RuleTables tables, Index<InstPattern> src)
            => TableEmit(CalcOperandRows(tables, src).View, InstOperandRow.RenderWidths, XedPaths.DocTarget(XedDocKind.PatternOps));

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