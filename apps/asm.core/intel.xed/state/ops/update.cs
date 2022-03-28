//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedFields;
    using static XedDisasm;
    using static core;

    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedState
    {
        public static ref RuleState update(in EncodingOffsets src, AsmHexCode code, ref RuleState dst)
        {
            if(src.HasOpCode)
            {
                dst.POS_NOMINAL_OPCODE = (byte)src.OpCode;
                dst.NOMINAL_OPCODE = code[src.OpCode];
            }
            if(src.HasModRm)
            {
                dst.POS_MODRM = (byte)src.ModRm;
                dst.HAS_MODRM = bit.On;
                dst.MODRM_BYTE = code[src.ModRm];
            }
            if(src.HasSib)
            {
                dst.POS_SIB = (byte)src.Sib;
                var sib = (Sib)code[src.Sib];
                dst.SIBBASE = sib.Base;
                dst.SIBINDEX = sib.Index;
                dst.SIBSCALE = sib.Scale;
            }
            if(src.HasDisp)
            {
                dst.POS_DISP = (byte)src.Disp;
                dst.DISP = @as<Disp64>(code[src.Disp]);
            }
            if(src.HasImm0)
            {
                dst.POS_IMM = (byte)src.Imm0;
                dst.IMM0 = bit.On;
            }
            if(src.HasImm1)
            {
                dst.POS_IMM1 = (byte)src.Imm1;
                dst.IMM1 = bit.On;
            }

            return ref dst;
        }

        public static bool update(string src, FieldKind kind, ref DisasmState dstate)
            => update(src, kind, ref dstate.RuleState).IsNonEmpty;

        [Op]
        public static R.FieldValue update(string src, FieldKind kind, ref RuleState state)
        {
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
                    result = XedParsers.parse(src, out state.BASE0);
                    fieldval = value(kind, state.BASE0);
                break;

                case K.BASE1:
                    result = XedParsers.parse(src, out state.BASE1);
                    fieldval = value(kind, state.BASE1);
                break;

                case K.BCAST:
                    result = XedParsers.parse(src, out state.BCAST);
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
                    result = XedParsers.parse(src, out state.BRDISP_WIDTH);
                    fieldval = value(kind, state.BRDISP_WIDTH);
                break;

                case K.CET:
                    state.CET = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case K.CHIP:
                    result = XedParsers.parse(src, out state.CHIP);
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
                    result = XedParsers.parse(src, out state.INDEX);
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
                    result = XedParsers.parse(src, out state.OUTREG);
                    fieldval = value(kind, state.OUTREG);
                break;

                case K.REG0:
                    result = XedParsers.parse(src, out state.REG0);
                    fieldval = value(kind, state.REG0);
                break;

                case K.REG1:
                    result = XedParsers.parse(src, out state.REG1);
                    fieldval = value(kind, state.REG1);
                break;

                case K.REG2:
                    result = XedParsers.parse(src, out state.REG2);
                    fieldval = value(kind, state.REG2);
                break;

                case K.REG3:
                    result = XedParsers.parse(src, out state.REG3);
                    fieldval = value(kind, state.REG3);
                break;

                case K.REG4:
                    result = XedParsers.parse(src, out state.REG4);
                    fieldval = value(kind, state.REG4);
                break;

                case K.REG5:
                    result = XedParsers.parse(src, out state.REG5);
                    fieldval = value(kind, state.REG5);
                break;

                case K.REG6:
                    result = XedParsers.parse(src, out state.REG6);
                    fieldval = value(kind, state.REG6);
                break;

                case K.REG7:
                    result = XedParsers.parse(src, out state.REG7);
                    fieldval = value(kind, state.REG7);
                break;

                case K.REG8:
                    result = XedParsers.parse(src, out state.REG8);
                    fieldval = value(kind, state.REG8);
                break;

                case K.REG9:
                    result = XedParsers.parse(src, out state.REG9);
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
                    state.REX = bit.On;
                    state.REXB = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case K.REXR:
                    state.REX = bit.On;
                    state.REXR = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case K.REXRR:
                    state.REXRR = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case K.REXW:
                    state.REX = bit.On;
                    state.REXW = bit.On;
                    fieldval = value(kind, bit.On);
                break;

                case K.REXX:
                    state.REX = bit.On;
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
                    result = XedParsers.parse(src, out state.SEG0);
                    fieldval = value(kind, state.SEG0);
                break;

                case K.SEG1:
                    result = XedParsers.parse(src, out state.SEG1);
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


        public static Dictionary<FieldKind,R.FieldValue> update(Index<R.FieldValue> src, ref RuleState state)
        {
            update(src.View, ref state);
            return src.Map(x => (x.Field, x)).ToDictionary();
        }

        public static ref RuleState update(ReadOnlySpan<R.FieldValue> src, ref RuleState dst)
        {
            for(var i=0; i<src.Length; i++)
                update(skip(src,i), ref dst);
            return ref dst;
        }

        static ref RuleState update(in R.FieldValue src, ref RuleState dst)
        {
            var result = Outcome.Success;
            switch(src.Field)
            {
                case K.AMD3DNOW:
                    dst.AMD3DNOW = src;
                break;

                case K.ASZ:
                    dst.ASZ = src;
                break;

                case K.BASE0:
                    dst.BASE0 = src;
                break;

                case K.BASE1:
                    dst.BASE1 = src;
                break;

                case K.BCAST:
                    dst.BCAST = src;
                break;

                case K.BCRC:
                    dst.BCRC = src;
                break;

                case K.RELBR:
                    dst.RELBR = src;
                break;

                case K.BRDISP_WIDTH:
                    dst.BRDISP_WIDTH = src;
                break;

                case K.CET:
                    dst.CET = src;
                break;

                case K.CHIP:
                    dst.CHIP = src;
                break;

                case K.CLDEMOTE:
                    dst.CLDEMOTE = src;
                break;

                case K.DEFAULT_SEG:
                    dst.DEFAULT_SEG = src;
                break;

                case K.DF32:
                    dst.DF32 = src;
                break;

                case K.DF64:
                    dst.DF64 = src;
                break;

                case K.DISP:
                    dst.DISP = src;
                break;

                case K.DISP_WIDTH:
                    dst.DISP_WIDTH = src;
                break;

                case K.DUMMY:
                    dst.DUMMY = src;
                break;

                case K.EASZ:
                    dst.EASZ = src;
                break;

                case K.ELEMENT_SIZE:
                    dst.ELEMENT_SIZE = src;
                break;

                case K.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = src;
                break;

                case K.ENCODE_FORCE:
                    dst.ENCODE_FORCE = src;
                break;

                case K.EOSZ:
                    dst.EOSZ = src;
                break;

                case K.ESRC:
                    dst.ESRC = src;
                break;

                case K.FIRST_F2F3:
                    dst.FIRST_F2F3 = src;
                break;

                case K.HAS_MODRM:
                    dst.HAS_MODRM = src;
                break;

                case K.HAS_SIB:
                    dst.HAS_SIB = src;
                break;

                case K.HINT:
                    dst.HINT = src;
                break;

                case K.ICLASS:
                    dst.ICLASS = src;
                break;

                case K.ILD_F2:
                    dst.ILD_F2 = src;
                break;

                case K.ILD_F3:
                    dst.ILD_F3 = src;
                break;

                case K.ILD_SEG:
                    dst.ILD_SEG = src;
                break;

                case K.IMM0:
                    dst.IMM0 = src;
                break;

                case K.IMM0SIGNED:
                    dst.IMM0SIGNED = src;
                break;

                case K.IMM1:
                    dst.IMM1 = src;
                break;

                case K.IMM1_BYTES:
                    dst.IMM1_BYTES = src;
                break;

                case K.IMM_WIDTH:
                    dst.IMM_WIDTH = src;
                break;

                case K.INDEX:
                    dst.INDEX = src;
                break;

                case K.LAST_F2F3:
                    dst.LAST_F2F3 = src;
                break;

                case K.LLRC:
                    dst.LLRC = src;
                break;

                case K.LOCK:
                    dst.LOCK = src;
                break;

                case K.LZCNT:
                    dst.LZCNT = src;
                break;

                case K.MAP:
                    dst.MAP = src;
                break;

                case K.MASK:
                    dst.MASK = src;
                break;

                case K.MAX_BYTES:
                    dst.MAX_BYTES = src;
                break;

                case K.MEM_WIDTH:
                    dst.MEM_WIDTH = src;
                break;

                case K.MOD:
                    dst.MOD = src;
                break;

                case K.REG:
                    dst.REG = src;
                break;

                case K.MODRM_BYTE:
                    dst.MODRM_BYTE = src;
                break;

                case K.MODE:
                    dst.MODE = src;
                break;

                case K.MODEP5:
                    dst.MODEP5 = src;
                break;

                case K.MODEP55C:
                    dst.MODEP55C = src;
                break;

                case K.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = src;
                break;

                case K.MPXMODE:
                    dst.MPXMODE = src;
                break;

                case K.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = src;
                break;

                case K.NEEDREX:
                    dst.NEEDREX = src;
                break;

                case K.NEED_MEMDISP:
                    dst.NEED_MEMDISP = src;
                break;

                case K.NEED_SIB:
                    dst.NEED_SIB = src;
                break;

                case K.NELEM:
                    dst.NELEM = src;
                break;

                case K.NOMINAL_OPCODE:
                    dst.NOMINAL_OPCODE = src;
                break;

                case K.NOREX:
                    dst.NOREX = src;
                break;

                case K.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = src;
                break;

                case K.NPREFIXES:
                    dst.NPREFIXES = src;
                break;

                case K.NREXES:
                    dst.NREXES = src;
                break;

                case K.NSEG_PREFIXES:
                    dst.NSEG_PREFIXES = src;
                break;

                case K.OSZ:
                    dst.OSZ = src;
                break;

                case K.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = src;
                break;

                case K.P4:
                    dst.P4 = src;
                break;

                case K.POS_DISP:
                    dst.POS_DISP = src;;
                break;

                case K.POS_IMM:
                    dst.POS_IMM = src;
                break;

                case K.POS_IMM1:
                    dst.POS_IMM1 = src;
                break;

                case K.POS_MODRM:
                    dst.POS_MODRM = src;
                break;

                case K.POS_NOMINAL_OPCODE:
                    dst.POS_NOMINAL_OPCODE = src;
                break;

                case K.POS_SIB:
                    dst.POS_SIB = src;
                break;

                case K.PREFIX66:
                    dst.PREFIX66 = 1;
                break;

                case K.PTR:
                    dst.PTR = 1;
                break;

                case K.REALMODE:
                    dst.REALMODE = 1;
                break;

                case K.OUTREG:
                    dst.OUTREG = src;
                break;

                case K.REG0:
                    dst.REG0 = src;
                break;

                case K.REG1:
                    dst.REG1 = src;
                break;

                case K.REG2:
                    dst.REG2 = src;
                break;

                case K.REG3:
                    dst.REG3 = src;
                break;

                case K.REG4:
                    dst.REG4 = src;
                break;

                case K.REG5:
                    dst.REG5 = src;
                break;

                case K.REG6:
                    dst.REG6 = src;
                break;

                case K.REG7:
                    dst.REG7 = src;
                break;

                case K.REG8:
                    dst.REG8 = src;
                break;

                case K.REG9:
                    dst.REG9 = src;
                break;

                case K.REP:
                    dst.REP = src;
                break;

                case K.REX:
                    dst.REX = src;
                break;

                case K.REXB:
                    dst.REXB = src;
                break;

                case K.REXR:
                    dst.REXR = src;
                break;

                case K.REXRR:
                    dst.REXRR = src;
                break;

                case K.REXW:
                    dst.REXW = src;
                break;

                case K.REXX:
                    dst.REXX = src;
                break;

                case K.RM:
                    dst.RM = src;
                break;

                case K.ROUNDC:
                    dst.ROUNDC = src;
                break;

                case K.SAE:
                    dst.SAE = src;
                break;

                case K.SCALE:
                    dst.SCALE = src;
                break;

                case K.SEG0:
                    dst.SEG0 = src;
                break;

                case K.SEG1:
                    dst.SEG1 = src;
                break;

                case K.SEG_OVD:
                    dst.SEG_OVD = src;
                break;

                case K.SIBBASE:
                    dst.SIBBASE = src;
                break;

                case K.SIBINDEX:
                    dst.SIBINDEX = src;
                break;

                case K.SIBSCALE:
                    dst.SIBSCALE = src;
                break;

                case K.SMODE:
                    dst.SMODE = src;
                    break;

                case K.SRM:
                    dst.SRM = src;
                break;

                case K.TZCNT:
                    dst.TZCNT = src;
                break;

                case K.UBIT:
                    dst.UBIT = src;
                break;

                case K.UIMM0:
                    dst.UIMM0 = src;
                break;

                case K.UIMM1:
                    dst.UIMM1 = src;
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = src;
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = src;
                break;

                case K.VEXDEST210:
                    dst.VEXDEST210 = src;
                break;

                case K.VEXDEST3:
                    dst.VEXDEST3 = src;
                break;

                case K.VEXDEST4:
                    dst.VEXDEST4 = src;
                break;

                case K.VEXVALID:
                    dst.VEXVALID = src;
                break;

                case K.VEX_C4:
                    dst.VEX_C4 = src;
                break;

                case K.VEX_PREFIX:
                    dst.VEX_PREFIX = src;
                break;

                case K.VL:
                    dst.VL = src;
                break;

                case K.WBNOINVD:
                    dst.WBNOINVD = src;
                break;

                case K.ZEROING:
                    dst.ZEROING = src;
                break;

                case K.MEM0:
                    dst.MEM0 = src;
                break;

                case K.MEM1:
                    dst.MEM1 = src;
                break;

                case K.AGEN:
                    dst.AGEN = src;
                break;
            }

            return ref dst;
        }
    }
}