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
            XedState.update(fields, ref state);
            return fields;
        }
    }
}