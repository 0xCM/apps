//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public void EmitRefData()
        {
            exec(PllWf,
                EmitOpCodeKinds,
                EmitOperandWidths,
                EmitPointerWidths
                );
        }

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitOperandWidths()
            => TableEmit(CalcOperandWidths().View, AppDb.XedTable<OpWidth>());

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}