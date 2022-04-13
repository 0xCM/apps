//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasm
    {
        public static Index<CellValue> update(in DisasmLineBlock src, ref RuleState state)
        {
            var fields = XedDisasm.values(src);
            XedState.Edit.update(fields, ref state);
            return fields;
        }

        public static bool update(string src, FieldKind kind, ref DisasmState dstate)
            => XedState.Edit.field(src, kind, ref dstate.RuleState).IsNonEmpty;
    }
}