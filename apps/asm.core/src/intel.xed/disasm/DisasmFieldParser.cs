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

    using P = XedRules.RuleParser;

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

        // NOP NOP_MEMv_GPRv_0F1F DISP_WIDTH:32, EASZ:3, EOSZ:1, HAS_MODRM:1, HAS_SIB, HINT:1, LZCNT, MAP:1, MAX_BYTES:15, MEM0:ptr [RAX+RAX*1], MOD:2, MODE:2, MODRM_BYTE:132, NEED_MEMDISP:32, NOMINAL_OPCODE:31, NPREFIXES:3, NSEG_PREFIXES:1, OSZ, OUTREG:AX, P4, POS_DISP:7, POS_MODRM:5, POS_NOMINAL_OPCODE:4, POS_SIB:6, PREFIX66, REG0:AX, RM:4, SMODE:2, SRM:7, TZCNT, USING_DEFAULT_SEGMENT0
        // VMOVAPD VMOVAPD_YMMqq_MEMqq EASZ:3, EOSZ:2, HAS_MODRM:1, LZCNT, MAP:1, MAX_BYTES:15, MEM0:ptr [RCX], MODE:2, MODRM_BYTE:1, NOMINAL_OPCODE:40, OUTREG:YMM0, P4, POS_MODRM:3, POS_NOMINAL_OPCODE:2, REG0:YMM0, RM:1, SMODE:2, TZCNT, USING_DEFAULT_SEGMENT0, VEXDEST210:7, VEXDEST3, VEXVALID:1, VEX_PREFIX:1, VL:1
        // VPMOVM2Q VPMOVM2Q_YMMu64_MASKmskw_AVX512 EASZ:3, EOSZ:3, HAS_MODRM:1, LLRC:1, LZCNT, MAP:2, MAX_BYTES:15, MOD:3, MODE:2, MODRM_BYTE:192, NOMINAL_OPCODE:56, OUTREG:K0, P4, POS_MODRM:5, POS_NOMINAL_OPCODE:4, REG0:YMM0, REG1:K0, REXW, SMODE:2, TZCNT, UBIT, VEXDEST210:7, VEXDEST3, VEXVALID:2, VEX_PREFIX:3, VL:1
        // RET_NEAR RET_NEAR DF64, EASZ:3, EOSZ:3, LZCNT, MAX_BYTES:15, MEM0:ptr [RSP], MODE:2, NOMINAL_OPCODE:195, P4, REG0:STACKPOP, REG1:RIP, SMODE:2, SRM:3, TZCNT, USING_DEFAULT_SEGMENT0

            static bool state(string src, FieldKind kind, ref RuleState state)
            {
                var result = true;
                switch(kind)
                {
                    case K.AMD3DNOW:
                        state.AMD3DNOW = bit.On;
                    break;

                    case K.ASZ:
                        state.ASZ = bit.On;
                    break;

                    case K.BASE0:
                        result = P.xedreg(src, out state.BASE0);
                    break;

                    case K.BASE1:
                        result = P.xedreg(src, out state.BASE1);
                    break;

                    case K.BCAST:
                        result = DataParser.eparse(src, out state.BCAST);
                    break;

                    case K.BCRC:
                        state.BCRC = bit.On;
                    break;

                    case K.RELBR:
                        state.RELBR = bit.On;
                        result = Disp.parse(src, Sizes.native(state.BRDISP_WIDTH), out state.RELBRVal);
                    break;

                    case K.BRDISP_WIDTH:
                        result = DataParser.parse(src, out state.BRDISP_WIDTH);
                    break;

                    case K.CET:
                        state.CET = bit.On;
                    break;

                    case K.CHIP:
                        result = DataParser.eparse(src, out state.CHIP);
                    break;

                    case K.CLDEMOTE:
                        state.CLDEMOTE = bit.On;
                    break;

                    case K.DEFAULT_SEG:
                        result = DataParser.parse(src, out state.DEFAULT_SEG);
                    break;

                    case K.DF32:
                        state.DF32 = bit.On;
                    break;

                    case K.DF64:
                        state.DF64 = bit.On;
                    break;

                    case K.DISP:
                        result = Disp64.parse(src, out state.DISP);
                    break;

                    case K.DISP_WIDTH:
                        result = DataParser.parse(src, out state.DISP_WIDTH);
                    break;

                    case K.DUMMY:
                        state.DUMMY = bit.On;
                    break;

                    case K.EASZ:
                        result = DataParser.parse(src, out state.EASZ);
                    break;

                    case K.ELEMENT_SIZE:
                        result = DataParser.parse(src, out state.ELEMENT_SIZE);
                    break;

                    case K.ENCODER_PREFERRED:
                        state.ENCODER_PREFERRED = bit.On;
                    break;

                    case K.ENCODE_FORCE:
                        state.ENCODE_FORCE = bit.On;
                    break;

                    case K.EOSZ:
                        result = DataParser.parse(src, out state.EOSZ);
                    break;

                    case K.ESRC:
                        result = DataParser.parse(src, out state.ESRC);
                    break;

                    case K.FIRST_F2F3:
                        result = DataParser.parse(src, out state.FIRST_F2F3);
                    break;

                    case K.HAS_MODRM:
                        state.HAS_MODRM = bit.On;
                    break;

                    case K.HAS_SIB:
                        state.HAS_SIB = bit.On;
                    break;

                    case K.HINT:
                        result = DataParser.parse(src, out state.HINT);
                    break;

                    case K.ICLASS:
                        result = DataParser.eparse(src, out state.ICLASS);
                    break;

                    case K.ILD_F2:
                        state.ILD_F2 = bit.On;
                    break;

                    case K.ILD_F3:
                        state.ILD_F3 = bit.On;
                    break;

                    case K.ILD_SEG:
                        result = DataParser.parse(src, out state.ILD_SEG);
                    break;

                    case K.IMM0:
                        state.IMM0 = bit.On;
                    break;

                    case K.IMM0SIGNED:
                        state.IMM0SIGNED = bit.On;
                    break;

                    case K.IMM1:
                        state.IMM1 = bit.On;
                    break;

                    case K.IMM1_BYTES:
                        result = DataParser.parse(src, out state.IMM1_BYTES);
                    break;

                    case K.IMM_WIDTH:
                        result = DataParser.parse(src, out state.IMM_WIDTH);
                    break;

                    case K.INDEX:
                        result = P.xedreg(src, out state.INDEX);
                    break;

                    case K.LAST_F2F3:
                        result = DataParser.parse(src, out state.LAST_F2F3);
                    break;

                    case K.LLRC:
                        result = DataParser.parse(src, out state.LLRC);
                    break;

                    case K.LOCK:
                        state.LOCK = bit.On;
                    break;

                    case K.LZCNT:
                        state.LZCNT = bit.On;
                    break;

                    case K.MAP:
                        result = DataParser.parse(src, out state.MAP);
                    break;

                    case K.MASK:
                        result = DataParser.parse(src, out state.MASK);
                    break;

                    case K.MAX_BYTES:
                        result = DataParser.parse(src, out state.MAX_BYTES);
                    break;

                    case K.MEM_WIDTH:
                        result = DataParser.parse(src, out state.MEM_WIDTH);
                    break;

                    case K.MOD:
                        result = DataParser.parse(src, out state.MOD);
                    break;

                    case K.REG:
                        result = DataParser.parse(src, out state.REG);
                    break;

                    case K.MODRM_BYTE:
                        result = DataParser.parse(src, out byte modrm);
                        if(result)
                            state.MODRM_BYTE = modrm;
                    break;

                    case K.MODE:
                        result = DataParser.parse(src, out state.MODE);
                    break;

                    case K.MODEP5:
                        state.MODEP5 = bit.On;
                    break;

                    case K.MODEP55C:
                        state.MODEP55C = bit.On;
                    break;

                    case K.MODE_FIRST_PREFIX:
                        state.MODE_FIRST_PREFIX = bit.On;
                    break;

                    case K.MPXMODE:
                        state.MPXMODE = bit.On;
                    break;

                    case K.MUST_USE_EVEX:
                        state.MUST_USE_EVEX = bit.On;
                    break;

                    case K.NEEDREX:
                        state.NEEDREX = bit.On;
                    break;

                    case K.NEED_MEMDISP:
                        state.NEED_MEMDISP = bit.On;
                    break;

                    case K.NEED_SIB:
                        state.NEED_SIB = bit.On;
                    break;

                    case K.NELEM:
                        result = DataParser.parse(src, out state.NELEM);
                    break;

                    case K.NOMINAL_OPCODE:
                        result = DataParser.parse(src, out byte opcode);
                        if(result)
                            state.NOMINAL_OPCODE = opcode;
                    break;

                    case K.NOREX:
                        state.NOREX = bit.On;
                    break;

                    case K.NO_SCALE_DISP8:
                        state.NO_SCALE_DISP8 = bit.On;
                    break;

                    case K.NPREFIXES:
                        result = DataParser.parse(src, out state.NPREFIXES);
                    break;

                    case K.NREXES:
                        result = DataParser.parse(src, out state.NREXES);
                    break;

                    case K.NSEG_PREFIXES:
                        result = DataParser.parse(src, out state.NSEG_PREFIXES);
                    break;

                    case K.OSZ:
                        state.OSZ = bit.On;
                    break;

                    case K.OUT_OF_BYTES:
                        state.OUT_OF_BYTES = bit.On;
                    break;

                    case K.P4:
                        state.P4 = bit.On;
                    break;

                    case K.POS_DISP:
                        result = DataParser.parse(src, out state.POS_DISP);
                    break;

                    case K.POS_IMM:
                        result = DataParser.parse(src, out state.POS_IMM);
                    break;

                    case K.POS_IMM1:
                        result = DataParser.parse(src, out state.POS_IMM1);
                    break;

                    case K.POS_MODRM:
                        result = DataParser.parse(src, out state.POS_MODRM);
                    break;

                    case K.POS_NOMINAL_OPCODE:
                        result = DataParser.parse(src, out state.POS_NOMINAL_OPCODE);
                    break;

                    case K.POS_SIB:
                        result = DataParser.parse(src, out state.POS_SIB);
                    break;

                    case K.PREFIX66:
                        state.PREFIX66 = 1;
                    break;

                    case K.PTR:
                        state.PTR = 1;
                    break;

                    case K.REALMODE:
                        state.REALMODE = 1;
                    break;

                    case K.OUTREG:
                        result = P.xedreg(src, out state.OUTREG);
                    break;

                    case K.REG0:
                        result = P.xedreg(src, out state.REG0);
                    break;

                    case K.REG1:
                        result = P.xedreg(src, out state.REG1);
                    break;

                    case K.REG2:
                        result = P.xedreg(src, out state.REG2);
                    break;

                    case K.REG3:
                        result = P.xedreg(src, out state.REG3);
                    break;

                    case K.REG4:
                        result = P.xedreg(src, out state.REG4);
                    break;

                    case K.REG5:
                        result = P.xedreg(src, out state.REG5);
                    break;

                    case K.REG6:
                        result = P.xedreg(src, out state.REG6);
                    break;

                    case K.REG7:
                        result = P.xedreg(src, out state.REG7);
                    break;

                    case K.REG8:
                        result = P.xedreg(src, out state.REG8);
                    break;

                    case K.REG9:
                        result = P.xedreg(src, out state.REG9);
                    break;

                    case K.REP:
                        result = DataParser.parse(src, out state.REP);
                    break;

                    case K.REX:
                        state.REX = bit.On;
                    break;

                    case K.REXB:
                        state.REXB = 1;
                    break;

                    case K.REXR:
                        state.REXR = 1;
                    break;

                    case K.REXRR:
                        state.REXRR = 1;
                    break;

                    case K.REXW:
                        state.REXW = 1;
                    break;

                    case K.REXX:
                        state.REXX = 1;
                    break;

                    case K.RM:
                        result = DataParser.parse(src, out state.RM);
                    break;

                    case K.ROUNDC:
                        result = DataParser.parse(src, out state.ROUNDC);
                    break;

                    case K.SAE:
                        state.SAE = bit.On;
                    break;

                    case K.SCALE:
                        result = DataParser.parse(src, out state.SCALE);
                    break;

                    case K.SEG0:
                        result = P.xedreg(src, out state.SEG0);
                    break;

                    case K.SEG1:
                        result = P.xedreg(src, out state.SEG1);
                    break;

                    case K.SEG_OVD:
                        result = DataParser.parse(src, out state.SEG_OVD);
                    break;

                    case K.SIBBASE:
                        result = DataParser.parse(src, out state.SIBBASE);
                    break;

                    case K.SIBINDEX:
                        result = DataParser.parse(src, out state.SIBINDEX);
                    break;

                    case K.SIBSCALE:
                        result = DataParser.parse(src, out state.SIBSCALE);
                    break;

                    case K.SMODE:
                        result = DataParser.parse(src, out state.SMODE);
                        break;

                    case K.SRM:
                        result = DataParser.parse(src, out state.SRM);
                    break;

                    case K.TZCNT:
                        state.TZCNT = bit.On;
                    break;

                    case K.UBIT:
                        state.UBIT = bit.On;
                    break;

                    case K.UIMM0:
                        result = imm64.parse(src, out state.UIMM0);
                    break;

                    case K.UIMM1:
                        result = imm8.parse(src, out state.UIMM1);
                    break;

                    case K.USING_DEFAULT_SEGMENT0:
                        state.USING_DEFAULT_SEGMENT0 = bit.On;
                    break;

                    case K.USING_DEFAULT_SEGMENT1:
                        state.USING_DEFAULT_SEGMENT1 = bit.On;
                    break;

                    case K.VEXDEST210:
                        result = DataParser.parse(src, out state.VEXDEST210);
                    break;

                    case K.VEXDEST3:
                        state.VEXDEST3 = bit.On;
                    break;

                    case K.VEXDEST4:
                        state.VEXDEST4 = bit.On;
                    break;

                    case K.VEXVALID:
                        result = DataParser.parse(src, out state.VEXVALID);
                    break;

                    case K.VEX_C4:
                        state.VEX_C4 = bit.On;
                    break;

                    case K.VEX_PREFIX:
                        result = DataParser.parse(src, out state.VEX_PREFIX);
                    break;

                    case K.VL:
                        result = DataParser.parse(src, out state.VL);
                    break;

                    case K.WBNOINVD:
                        state.WBNOINVD = bit.On;
                    break;

                    case K.ZEROING:
                        state.ZEROING = bit.On;
                    break;
                }

                return result;
            }

            static Outcome update(string src, FieldKind kind, ref DisasmState dstate)
            {
                ref var rules = ref dstate.RuleState;
                var result = state(src, kind, ref rules);

                switch(kind)
                {
                    case K.RELBR:
                        dstate.RELBRVal = rules.RELBRVal;
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