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
            ref var rules = ref dstate.RuleState;
            var fieldval = XedFields.update(src, kind, ref rules);
            var result = fieldval.IsNonEmpty;
            switch(kind)
            {
                case K.RELBR:
                    result = Disp.parse(src, Sizes.native(rules.BRDISP_WIDTH), out dstate.RELBRVal);
                    dstate.RuleState.RELBRVal = dstate.RELBRVal;
                break;

                case K.AGEN:
                    result = DataParser.parse(src, out dstate.AGENVal);
                    dstate.RuleState.AGENVal = dstate.AGENVal;
                break;

                case K.MEM0:
                    result = DataParser.parse(src, out dstate.MEM0Val);
                    dstate.RuleState.MEM0Val = dstate.MEM0Val;
                break;

                case K.MEM1:
                    result = DataParser.parse(src, out dstate.MEM1Val);
                    dstate.RuleState.MEM1Val = dstate.MEM1Val;
                break;
            }
            return result;
        }
    }
}