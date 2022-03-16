//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    using K = XedRules.FieldKind;

    using static XedRules;

    partial class XedDisasm
    {
        public class DisasmFieldParser
        {
            Symbols<FieldKind> FieldKinds;

            DisasmState State;

            DataList<FieldKind> _ParsedFields;

            DataList<Facet<string>> _UnknownFields;

            Dictionary<FieldKind, string> _Failures;

            public DisasmFieldParser()
            {
                FieldKinds = Symbols.index<FieldKind>();
                State = DisasmState.Empty;
                _ParsedFields = new();
                _UnknownFields = new();
                _Failures = new();
            }

            void Clear()
            {
                State = DisasmState.Empty;
                _ParsedFields.Clear();
                _UnknownFields.Clear();
                _Failures.Clear();
            }

            public void ParseState(ReadOnlySpan<Facet<string>> src, out DisasmState dst)
            {
                Clear();
                var count = src.Length;
                var dispwidth = 0u;
                var relbranch = Disp.Empty;
                dst = DisasmState.Empty;
                for(var i=0; i<count; i++)
                {
                    ref readonly var facet = ref skip(src,i);

                    if(FieldKinds.Lookup(facet.Key, out var k))
                    {
                        var value = text.trim(facet.Value);
                        var kind = k.Kind;
                        var result = update(value, kind, ref State);
                        if(result.Fail)
                            _Failures[kind] = value;
                        else
                            _ParsedFields.Add(kind);
                    }
                    else
                        _UnknownFields.Add(facet);
                }

                dst.RuleState = State.RuleState;
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
}