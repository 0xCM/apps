//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using R = XedRules;

    partial class XedDisasm
    {
        public static Index<R.FieldValue> update(in DisasmLineBlock src, ref RuleState state)
        {
            var fields = XedDisasm.fields(src);
            XedState.update(fields, ref state);
            return fields;
        }
    }
}