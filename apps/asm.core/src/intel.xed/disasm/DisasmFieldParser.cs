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
    using R = XedRules;

    using static XedRules;
    using static XedModels;
    using static XedFields;

    partial class XedDisasm
    {
        public class DisasmFieldParser
        {
            public static Index<R.FieldValue> fields(in DisasmLineBlock src)
            {
                var data = props(src);
                var count = data.Count;
                var dst = alloc<R.FieldValue>(count);
                var state = RuleState.Empty;
                for(var i=0; i<count; i++)
                {
                    ref readonly var prop = ref data[i];
                    if(Parsers.Parse(prop.Key, out FieldKind kind))
                        seek(dst,i) = update(prop.Value, kind, ref state);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), prop.Key));
                }

                return dst;
            }

            [Op]
            public static R.FieldValue update(string src, FieldKind kind, ref RuleState state)
            {
                static Outcome xedreg(string src, out XedRegId dst)
                {
                    var result = XedParsers.parse(src, out XedRegId reg);
                    if(result)
                        dst = reg;
                    else
                    {
                        if(src == "MM0")
                        {
                            dst = XedRegId.MMX0;
                            result = true;
                        }
                        else if(src == "MM1")
                        {
                            dst = XedRegId.MMX1;
                            result = true;
                        }
                        else if(src == "MM2")
                        {
                            dst = XedRegId.MMX2;
                            result = true;
                        }

                        dst = default;
                    }
                    return result;
                }

                var result = true;
                var fieldval = R.FieldValue.Empty;
                switch(kind)
                {
                    case K.AMD3DNOW:
                        state.AMD3DNOW = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ASZ:
                        state.ASZ = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.BASE0:
                        result = xedreg(src, out state.BASE0);
                        fieldval = value(kind, state.BASE0);
                    break;

                    case K.BASE1:
                        result = xedreg(src, out state.BASE1);
                        fieldval = value(kind, state.BASE1);
                    break;

                    case K.BCAST:
                        result = DataParser.eparse(src, out state.BCAST);
                        fieldval = value(kind, state.BCAST);
                    break;

                    case K.BCRC:
                        state.BCRC = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.RELBR:
                        state.RELBR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.BRDISP_WIDTH:
                        result = DataParser.parse(src, out state.BRDISP_WIDTH);
                        fieldval = value(kind, state.BRDISP_WIDTH);
                    break;

                    case K.CET:
                        state.CET = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.CHIP:
                        result = DataParser.eparse(src, out state.CHIP);
                        fieldval = value(kind, state.CHIP);
                    break;

                    case K.CLDEMOTE:
                        state.CLDEMOTE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.DEFAULT_SEG:
                        result = DataParser.parse(src, out state.DEFAULT_SEG);
                        fieldval = value(kind, state.DEFAULT_SEG);
                    break;

                    case K.DF32:
                        state.DF32 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.DF64:
                        state.DF64 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.DISP:
                        result = Disp64.parse(src, out state.DISP);
                        fieldval = value(kind, state.DISP);
                    break;

                    case K.DISP_WIDTH:
                        result = DataParser.parse(src, out state.DISP_WIDTH);
                        fieldval = value(kind, state.DISP_WIDTH);
                    break;

                    case K.DUMMY:
                        state.DUMMY = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.EASZ:
                        result = DataParser.parse(src, out state.EASZ);
                        fieldval = value(kind, state.EASZ);
                    break;

                    case K.ELEMENT_SIZE:
                        result = DataParser.parse(src, out state.ELEMENT_SIZE);
                        fieldval = value(kind, state.ELEMENT_SIZE);
                    break;

                    case K.ENCODER_PREFERRED:
                        state.ENCODER_PREFERRED = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ENCODE_FORCE:
                        state.ENCODE_FORCE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.EOSZ:
                        result = DataParser.parse(src, out state.EOSZ);
                        fieldval = value(kind, state.EOSZ);
                    break;

                    case K.ESRC:
                        result = DataParser.parse(src, out state.ESRC);
                        fieldval = value(kind, state.ESRC);
                    break;

                    case K.FIRST_F2F3:
                        result = DataParser.parse(src, out state.FIRST_F2F3);
                        fieldval = value(kind, state.FIRST_F2F3);
                    break;

                    case K.HAS_MODRM:
                        state.HAS_MODRM = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.HAS_SIB:
                        state.HAS_SIB = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.HINT:
                        result = DataParser.parse(src, out state.HINT);
                        fieldval = value(kind, state.HINT);
                    break;

                    case K.ICLASS:
                        result = DataParser.eparse(src, out state.ICLASS);
                        fieldval = value(kind, state.ICLASS);
                    break;

                    case K.ILD_F2:
                        state.ILD_F2 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ILD_F3:
                        state.ILD_F3 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ILD_SEG:
                        result = DataParser.parse(src, out state.ILD_SEG);
                        fieldval = value(kind, state.ILD_SEG);
                    break;

                    case K.IMM0:
                        state.IMM0 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.IMM0SIGNED:
                        state.IMM0SIGNED = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.IMM1:
                        state.IMM1 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.IMM1_BYTES:
                        result = DataParser.parse(src, out state.IMM1_BYTES);
                        fieldval = value(kind, state.IMM1_BYTES);
                    break;

                    case K.IMM_WIDTH:
                        result = DataParser.parse(src, out state.IMM_WIDTH);
                        fieldval = value(kind, state.IMM_WIDTH);
                    break;

                    case K.INDEX:
                        result = xedreg(src, out state.INDEX);
                        fieldval = value(kind, state.INDEX);
                    break;

                    case K.LAST_F2F3:
                        result = DataParser.parse(src, out state.LAST_F2F3);
                        fieldval = value(kind, state.LAST_F2F3);
                    break;

                    case K.LLRC:
                        result = DataParser.parse(src, out state.LLRC);
                        fieldval = value(kind, state.LLRC);
                    break;

                    case K.LOCK:
                        state.LOCK = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.LZCNT:
                        state.LZCNT = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MAP:
                        result = DataParser.parse(src, out state.MAP);
                        fieldval = value(kind, state.MAP);
                    break;

                    case K.MASK:
                        result = DataParser.parse(src, out state.MASK);
                        fieldval = value(kind, state.MASK);
                    break;

                    case K.MAX_BYTES:
                        result = DataParser.parse(src, out state.MAX_BYTES);
                        fieldval = value(kind, state.MAX_BYTES);
                    break;

                    case K.MEM_WIDTH:
                        result = DataParser.parse(src, out state.MEM_WIDTH);
                        fieldval = value(kind, state.MEM_WIDTH);
                    break;

                    case K.MEM0:
                        fieldval = value(kind, resolver(src));
                    break;

                    case K.MEM1:
                        fieldval = value(kind, resolver(src));
                    break;

                    case K.MOD:
                        result = DataParser.parse(src, out state.MOD);
                        fieldval = value(kind, state.MOD);
                    break;

                    case K.REG:
                        result = DataParser.parse(src, out state.REG);
                        fieldval = value(kind, state.REG);
                    break;

                    case K.MODRM_BYTE:
                        result = DataParser.parse(src, out byte modrm);
                        state.MODRM_BYTE = modrm;
                        fieldval = value(kind, state.MODRM_BYTE);
                    break;

                    case K.MODE:
                        result = DataParser.parse(src, out state.MODE);
                        fieldval = value(kind, state.MODE);
                    break;

                    case K.MODEP5:
                        state.MODEP5 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MODEP55C:
                        state.MODEP55C = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MODE_FIRST_PREFIX:
                        state.MODE_FIRST_PREFIX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MPXMODE:
                        state.MPXMODE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.MUST_USE_EVEX:
                        state.MUST_USE_EVEX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NEEDREX:
                        state.NEEDREX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NEED_MEMDISP:
                        state.NEED_MEMDISP = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NEED_SIB:
                        state.NEED_SIB = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NELEM:
                        result = DataParser.parse(src, out state.NELEM);
                        fieldval = value(kind, state.NELEM);
                    break;

                    case K.NOMINAL_OPCODE:
                        result = DataParser.parse(src, out byte opcode);
                        state.NOMINAL_OPCODE = opcode;
                        fieldval = value(kind, state.NOMINAL_OPCODE);
                    break;

                    case K.NOREX:
                        state.NOREX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NO_SCALE_DISP8:
                        state.NO_SCALE_DISP8 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.NPREFIXES:
                        result = DataParser.parse(src, out state.NPREFIXES);
                        fieldval = value(kind, state.NPREFIXES);
                    break;

                    case K.NREXES:
                        result = DataParser.parse(src, out state.NREXES);
                        fieldval = value(kind, state.NREXES);
                    break;

                    case K.NSEG_PREFIXES:
                        result = DataParser.parse(src, out state.NSEG_PREFIXES);
                        fieldval = value(kind, state.NSEG_PREFIXES);
                    break;

                    case K.OSZ:
                        state.OSZ = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.OUT_OF_BYTES:
                        state.OUT_OF_BYTES = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.P4:
                        state.P4 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.POS_DISP:
                        result = DataParser.parse(src, out state.POS_DISP);
                        fieldval = value(kind, state.POS_DISP);
                    break;

                    case K.POS_IMM:
                        result = DataParser.parse(src, out state.POS_IMM);
                        fieldval = value(kind, state.POS_IMM);
                    break;

                    case K.POS_IMM1:
                        result = DataParser.parse(src, out state.POS_IMM1);
                        fieldval = value(kind, state.POS_IMM1);
                    break;

                    case K.POS_MODRM:
                        result = DataParser.parse(src, out state.POS_MODRM);
                        fieldval = value(kind, state.POS_MODRM);
                    break;

                    case K.POS_NOMINAL_OPCODE:
                        result = DataParser.parse(src, out state.POS_NOMINAL_OPCODE);
                        fieldval = value(kind, state.POS_NOMINAL_OPCODE);
                    break;

                    case K.POS_SIB:
                        result = DataParser.parse(src, out state.POS_SIB);
                        fieldval = value(kind, state.POS_SIB);
                    break;

                    case K.PREFIX66:
                        state.PREFIX66 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.PTR:
                        state.PTR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REALMODE:
                        state.REALMODE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.OUTREG:
                        result = xedreg(src, out state.OUTREG);
                        fieldval = value(kind, state.OUTREG);
                    break;

                    case K.REG0:
                        result = xedreg(src, out state.REG0);
                        fieldval = value(kind, state.REG0);
                    break;

                    case K.REG1:
                        result = xedreg(src, out state.REG1);
                        fieldval = value(kind, state.REG1);
                    break;

                    case K.REG2:
                        result = xedreg(src, out state.REG2);
                        fieldval = value(kind, state.REG2);
                    break;

                    case K.REG3:
                        result = xedreg(src, out state.REG3);
                        fieldval = value(kind, state.REG3);
                    break;

                    case K.REG4:
                        result = xedreg(src, out state.REG4);
                        fieldval = value(kind, state.REG4);
                    break;

                    case K.REG5:
                        result = xedreg(src, out state.REG5);
                        fieldval = value(kind, state.REG5);
                    break;

                    case K.REG6:
                        result = xedreg(src, out state.REG6);
                        fieldval = value(kind, state.REG6);
                    break;

                    case K.REG7:
                        result = xedreg(src, out state.REG7);
                        fieldval = value(kind, state.REG7);
                    break;

                    case K.REG8:
                        result = xedreg(src, out state.REG8);
                        fieldval = value(kind, state.REG8);
                    break;

                    case K.REG9:
                        result = xedreg(src, out state.REG9);
                        fieldval = value(kind, state.REG9);
                    break;

                    case K.REP:
                        result = DataParser.parse(src, out state.REP);
                        fieldval = value(kind, state.REP);
                    break;

                    case K.REX:
                        state.REX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXB:
                        state.REXB = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXR:
                        state.REXR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXRR:
                        state.REXRR = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXW:
                        state.REXW = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.REXX:
                        state.REXX = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.RM:
                        result = DataParser.parse(src, out state.RM);
                        fieldval = value(kind, state.RM);
                    break;

                    case K.ROUNDC:
                        result = DataParser.parse(src, out state.ROUNDC);
                        fieldval = value(kind, state.ROUNDC);
                    break;

                    case K.SAE:
                        state.SAE = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.SCALE:
                        result = DataParser.parse(src, out state.SCALE);
                        fieldval = value(kind, state.SCALE);
                    break;

                    case K.SEG0:
                        result = xedreg(src, out state.SEG0);
                        fieldval = value(kind, state.SEG0);
                    break;

                    case K.SEG1:
                        result = xedreg(src, out state.SEG1);
                        fieldval = value(kind, state.SEG1);
                    break;

                    case K.SEG_OVD:
                        result = DataParser.parse(src, out state.SEG_OVD);
                        fieldval = value(kind, state.SEG_OVD);
                    break;

                    case K.SIBBASE:
                        result = DataParser.parse(src, out state.SIBBASE);
                        fieldval = value(kind, state.SIBBASE);
                    break;

                    case K.SIBINDEX:
                        result = DataParser.parse(src, out state.SIBINDEX);
                        fieldval = value(kind, state.SIBINDEX);
                    break;

                    case K.SIBSCALE:
                        result = DataParser.parse(src, out state.SIBSCALE);
                        fieldval = value(kind, state.SIBSCALE);
                    break;

                    case K.SMODE:
                        result = DataParser.parse(src, out state.SMODE);
                        fieldval = value(kind, state.SMODE);
                        break;

                    case K.SRM:
                        result = DataParser.parse(src, out state.SRM);
                        fieldval = value(kind, state.SRM);
                    break;

                    case K.TZCNT:
                        state.TZCNT = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.UBIT:
                        state.UBIT = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.UIMM0:
                        result = imm64.parse(src, out state.UIMM0);
                        fieldval = value(kind, state.UIMM0);
                    break;

                    case K.UIMM1:
                        result = imm8.parse(src, out state.UIMM1);
                        fieldval = value(kind, state.UIMM1);
                    break;

                    case K.USING_DEFAULT_SEGMENT0:
                        state.USING_DEFAULT_SEGMENT0 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.USING_DEFAULT_SEGMENT1:
                        state.USING_DEFAULT_SEGMENT1 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEXDEST210:
                        result = DataParser.parse(src, out state.VEXDEST210);
                        fieldval = value(kind, state.VEXDEST210);
                    break;

                    case K.VEXDEST3:
                        state.VEXDEST3 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEXDEST4:
                        state.VEXDEST4 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEXVALID:
                        result = DataParser.parse(src, out state.VEXVALID);
                        fieldval = value(kind, state.VEXVALID);
                    break;

                    case K.VEX_C4:
                        state.VEX_C4 = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.VEX_PREFIX:
                        result = DataParser.parse(src, out state.VEX_PREFIX);
                        fieldval = value(kind, state.VEX_PREFIX);
                    break;

                    case K.VL:
                        result = DataParser.parse(src, out state.VL);
                        fieldval = value(kind, state.VL);
                    break;

                    case K.WBNOINVD:
                        state.WBNOINVD = bit.On;
                        fieldval = value(kind, bit.On);
                    break;

                    case K.ZEROING:
                        state.ZEROING = bit.On;
                        fieldval = value(kind, bit.On);
                    break;
                }

                return fieldval;
            }

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
                var fieldval = update(src, kind, ref rules);
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