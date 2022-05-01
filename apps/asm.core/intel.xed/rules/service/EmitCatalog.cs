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
            exec(PllExec,
                EmitOpCodeKinds,
                EmitOpWidths,
                EmitPointerWidths,
                () => Emit(CalcMacroMatches()),
                EmitMacroDefs,
                () => Emit(XedFields.ByPosition.Valid),
                EmitSymbolicFields,
                () => Emit(ImportFieldDefs()),
                () => Emit(CalcRuleTables()),
                () => EmitPatterns(CalcPatterns())
            );
        }

        Index<MacroMatch> CalcMacroMatches()
            => mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));

        void EmitMacroDefs()
            => Emit(CalcMacroDefs().View);

        void EmitSymbolicFields()
            => ApiMetadataService.create(Wf).EmitTokenSet(XedFields.EffectiveFields.create(), AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));

        void EmitOpCodeKinds()
            => TableEmit(OpCodeKinds.Instance.Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitOpWidths()
            => TableEmit(XedWidths.Records.View, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());

        Index<PointerWidthInfo> CalcPointerWidths()
            => Data(nameof(CalcPointerWidths), () => mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i)));

        void EmitPointerWidths()
            => Emit(CalcPointerWidths().View);
    }
}