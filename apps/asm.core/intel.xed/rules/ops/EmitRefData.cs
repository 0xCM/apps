//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        public void EmitRefData()
        {
            exec(PllExec,
                EmitOpCodeKinds,
                EmitOpWidths,
                EmitPointerWidths
                );
        }

        void EmitOpCodeKinds()
            => TableEmit(CalcOpCodeKinds().Records, OcMapKind.RenderWidths, XedPaths.DocTarget(XedDocKind.OpCodeKinds));

        void EmitOpWidths()
            => TableEmit(XedTables.Widths.View, OpWidthInfo.RenderWidths, XedPaths.Table<OpWidthInfo>());

        void EmitPointerWidths()
            => TableEmit(CalcPointerWidths().View, PointerWidthInfo.RenderWidths,  XedPaths.DocTarget(XedDocKind.PointerWidths));
    }
}