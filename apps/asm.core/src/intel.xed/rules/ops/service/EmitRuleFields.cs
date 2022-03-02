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
        public void EmitRuleFields()
            => TableEmit(CalcFieldSpecs().View, RuleFieldSpec.RenderWidths, AppDb.XedTable<RuleFieldSpec>());

        void EmitMacroAssignments()
            => TableEmit(CalcMacroAssignments().View, MacroAssignment.RenderWidths, AppDb.XedPath("xed.rules.macros", FileKind.Csv));
    }
}