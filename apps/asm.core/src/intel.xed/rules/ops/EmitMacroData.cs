//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        void EmitMacroData()
        {
            var matches = mapi(RuleMacros.matches().Values.ToArray().Sort(), (i,m) => m.WithSeq((uint)i));
            TableEmit(@readonly(matches), MacroMatch.RenderWidths, XedPaths.RuleTable<MacroMatch>());
            TableEmit(CalcMacroDefs().View, MacroDef.RenderWidths, XedPaths.RuleTable<MacroDef>());
        }
    }
}