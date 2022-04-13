//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;

    using K = XedRules.FieldKind;

    partial class XedDisasm
    {
        internal class FieldParser
        {
            DisasmState State;

            List<FieldKind> _ParsedFields;

            List<Facet<string>> _UnknownFields;

            Dictionary<FieldKind, string> _Failures;

            byte DispWidth;

            public FieldParser()
            {
                State = DisasmState.Empty;
                _ParsedFields = new();
                _UnknownFields = new();
                _Failures = new();
                DispWidth = 32;
            }

            void Clear()
            {
                State = DisasmState.Empty;
                _ParsedFields.Clear();
                _UnknownFields.Clear();
                _Failures.Clear();
                DispWidth = 32;
            }

            public DisasmState Parse(DisasmProps src)
            {
                Clear();
                var count = src.Count;
                var dispwidth = (byte)32;
                var relbranch = Disp.Empty;
                var dst = DisasmState.Empty;
                var result = Outcome.Success;
                var names = src.Keys.Array();
                for(var i=0; i<count; i++)
                {
                    ref readonly var name = ref skip(names,i);
                    var kind = FieldKind.INVALID;
                    if(XedParsers.parse(name, out kind))
                    {
                        var value = src[name];
                        Parse(kind, value, ref dst);
                    }
                }
                dst.RuleState = State.RuleState;
                return dst;
            }

            void Parse(FieldKind kind, string value, ref DisasmState dst)
            {
                var result = Outcome.Success;

                switch(kind)
                {
                    case K.RELBR:
                        result = Disp.parse(value, Sizes.native(DispWidth), out dst.RELBRVal);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.BRDISP_WIDTH:
                        result = DataParser.parse(value, out DispWidth);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.AGEN:
                        result = DataParser.parse(value, out dst.AGENVal);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.MEM0:
                        result = DataParser.parse(value, out dst.MEM0Val);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    case K.MEM1:
                        result = DataParser.parse(value, out dst.MEM1Val);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;

                    default:
                        result = update(value, kind, ref State);
                        if(result)
                            _ParsedFields.Add(kind);
                    break;
                }

                if(result.Fail)
                    _Failures.Add(kind,value);
            }

            public DisasmState Parse(ReadOnlySpan<Facet<string>> src)
            {
                Clear();
                var count = src.Length;
                var relbranch = Disp.Empty;
                var dst = DisasmState.Empty;
                var result = Outcome.Success;
                for(var i=0; i<count; i++)
                {
                    ref readonly var name = ref skip(src,i);
                    var kind = FieldKind.INVALID;
                    if(XedParsers.parse(name.Key, out kind))
                    {
                        var value = text.trim(name.Value);

                        switch(kind)
                        {
                            case K.RELBR:
                                result = Disp.parse(value, Sizes.native(DispWidth), out dst.RELBRVal);
                                if(result)
                                    _ParsedFields.Add(kind);
                            break;

                            case K.BRDISP_WIDTH:
                                result = DataParser.parse(value, out DispWidth);
                                if(result)
                                    _ParsedFields.Add(kind);
                            break;

                            case K.AGEN:
                                result = DataParser.parse(value, out dst.AGENVal);
                                if(result)
                                    _ParsedFields.Add(kind);
                            break;

                            case K.MEM0:
                                result = DataParser.parse(value, out dst.MEM0Val);
                                if(result)
                                    _ParsedFields.Add(kind);
                            break;

                            case K.MEM1:
                                result = DataParser.parse(value, out dst.MEM1Val);
                                if(result)
                                    _ParsedFields.Add(kind);
                            break;

                            default:
                                result = update(value, kind, ref State);
                                if(result)
                                    _ParsedFields.Add(kind);
                            break;
                        }

                        if(result.Fail)
                            _Failures.Add(kind,value);
                    }
                    else
                        _UnknownFields.Add(name);
                }

                dst.RuleState = State.RuleState;
                return dst;
            }
       }
    }
}