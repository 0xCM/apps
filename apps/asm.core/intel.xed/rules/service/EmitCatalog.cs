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
            var rules = RuleTables.Empty;
            var patterns = Index<InstPattern>.Empty;
            exec(PllExec,
                () => TableEmit(OpCodeKinds.Instance.Records, OcMapKind.RenderWidths, XedPaths.Table<OcMapKind>()),
                EmitOpWidths,
                () => Emit(CalcPointerWidths().View),
                () => Emit(mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i))),
                () => Emit(CalcMacroDefs().View),
                () => Emit(XedFields.Defs.Positioned),
                EmitSymbolicFields,
                () => Emit(ImportFieldDefs()),
                () => rules = CalcRuleTables(),
                () => patterns = CalcPatterns()
            );

            Emit(patterns,rules);
        }

        void EmitSymbolicFields()
            => ApiMetadataService.create(Wf).EmitTokenSet(XedFields.EffectiveFields.create(), AppDb.XedPath("xed.fields.symbolic", FileKind.Csv));

        public void EmitOpWidths()
            => Emit(XedOperands.Views.OpWidths);

        Index<PointerWidthInfo> CalcPointerWidths()
            => Data(nameof(CalcPointerWidths), () => mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i)));
    }
}