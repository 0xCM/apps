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

    partial class XedDisasmSvc
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
                for(var i=0; i<count; i++)
                {
                    ref readonly var facet = ref skip(src,i);
                    var kind = K.INVALID;
                    if(FieldKinds.Lookup(facet.Key, out var k))
                    {
                        var value = text.trim(facet.Value);
                        kind = k.Kind;
                        var result = XedRules.RuleParser.state(value, kind, ref State.RuleState);
                        if(result.Fail)
                            _Failures[kind] = value;
                        else
                            _ParsedFields.Add(kind);
                    }
                    else
                        _UnknownFields.Add(facet);

                }
                dst = DisasmState.Empty;
                dst.RuleState = State.RuleState;
            }
        }
    }
}