//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        void EmitMacroDefs()
            => TableEmit(CalcMacroAssignments().View, MacroAssignment.RenderWidths, XedPaths.DocTarget(XedDocKind.MacroDefs));
    }
}