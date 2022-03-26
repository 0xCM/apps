//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedDisasm
    {
        public static Dictionary<FieldKind,R.FieldValue> update(Index<R.FieldValue> src, ref RuleState state)
        {
            XedFields.update(src, ref state);
            return src.Map(x => (x.Field, x)).ToDictionary();
        }

        public static Index<R.FieldValue> update(in DisasmLineBlock src, ref RuleState state)
        {
            var fields = XedDisasm.fields(src);
            XedFields.update(fields, ref state);
            return fields;
        }

        static Outcome update(string src, FieldKind kind, ref DisasmState dstate)
        {
            return XedFields.update(src, kind, ref dstate.RuleState).IsNonEmpty;
        }
    }
}