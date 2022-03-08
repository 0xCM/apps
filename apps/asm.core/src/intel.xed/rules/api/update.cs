//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    using K = XedRules.FieldKind;
    using P = XedRules.RuleParser;

    partial class XedRules
    {
        [Op]
        public static FieldValue update(string src, FieldKind kind, ref RuleState state)
        {
            var result = true;
            var fieldval = FieldValue.Empty;
            var type = datatype(kind);
            switch(kind)
            {
                case K.AMD3DNOW:
                    state.AMD3DNOW = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.ASZ:
                    state.ASZ = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.BASE0:
                    result = P.xedreg(src, out state.BASE0);
                    fieldval = value(kind, type, state.BASE0);
                break;

                case K.BASE1:
                    result = P.xedreg(src, out state.BASE1);
                    fieldval = value(kind, type, state.BASE1);
                break;

                case K.BCAST:
                    result = DataParser.eparse(src, out state.BCAST);
                    fieldval = value(kind, type, state.BCAST);
                break;

                case K.BCRC:
                    state.BCRC = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.RELBR:
                    state.RELBR = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.BRDISP_WIDTH:
                    result = DataParser.parse(src, out state.BRDISP_WIDTH);
                    fieldval = value(kind, type, state.BRDISP_WIDTH);
                break;

                case K.CET:
                    state.CET = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.CHIP:
                    result = DataParser.eparse(src, out state.CHIP);
                    fieldval = value(kind, type, state.CHIP);
                break;

                case K.CLDEMOTE:
                    state.CLDEMOTE = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.DEFAULT_SEG:
                    result = DataParser.parse(src, out state.DEFAULT_SEG);
                    fieldval = value(kind, type, state.DEFAULT_SEG);
                break;

                case K.DF32:
                    state.DF32 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.DF64:
                    state.DF64 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.DISP:
                    result = Disp64.parse(src, out state.DISP);
                    fieldval = value(kind, type, state.DISP);
                break;

                case K.DISP_WIDTH:
                    result = DataParser.parse(src, out state.DISP_WIDTH);
                    fieldval = value(kind, type, state.DISP_WIDTH);
                break;

                case K.DUMMY:
                    state.DUMMY = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.EASZ:
                    result = DataParser.parse(src, out state.EASZ);
                    fieldval = value(kind, type, state.EASZ);
                break;

                case K.ELEMENT_SIZE:
                    result = DataParser.parse(src, out state.ELEMENT_SIZE);
                    fieldval = value(kind, type, state.ELEMENT_SIZE);
                break;

                case K.ENCODER_PREFERRED:
                    state.ENCODER_PREFERRED = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.ENCODE_FORCE:
                    state.ENCODE_FORCE = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.EOSZ:
                    result = DataParser.parse(src, out state.EOSZ);
                    fieldval = value(kind, type, state.EOSZ);
                break;

                case K.ESRC:
                    result = DataParser.parse(src, out state.ESRC);
                    fieldval = value(kind, type, state.ESRC);
                break;

                case K.FIRST_F2F3:
                    result = DataParser.parse(src, out state.FIRST_F2F3);
                    fieldval = value(kind, type, state.FIRST_F2F3);
                break;

                case K.HAS_MODRM:
                    state.HAS_MODRM = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.HAS_SIB:
                    state.HAS_SIB = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.HINT:
                    result = DataParser.parse(src, out state.HINT);
                    fieldval = value(kind, type, state.HINT);
                break;

                case K.ICLASS:
                    result = DataParser.eparse(src, out state.ICLASS);
                    fieldval = value(kind, type, state.ICLASS);
                break;

                case K.ILD_F2:
                    state.ILD_F2 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.ILD_F3:
                    state.ILD_F3 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.ILD_SEG:
                    result = DataParser.parse(src, out state.ILD_SEG);
                    fieldval = value(kind, type, state.ILD_SEG);
                break;

                case K.IMM0:
                    state.IMM0 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.IMM0SIGNED:
                    state.IMM0SIGNED = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.IMM1:
                    state.IMM1 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.IMM1_BYTES:
                    result = DataParser.parse(src, out state.IMM1_BYTES);
                    fieldval = value(kind, type, state.IMM1_BYTES);
                break;

                case K.IMM_WIDTH:
                    result = DataParser.parse(src, out state.IMM_WIDTH);
                    fieldval = value(kind, type, state.IMM_WIDTH);
                break;

                case K.INDEX:
                    result = P.xedreg(src, out state.INDEX);
                    fieldval = value(kind, type, state.INDEX);
                break;

                case K.LAST_F2F3:
                    result = DataParser.parse(src, out state.LAST_F2F3);
                    fieldval = value(kind, type, state.LAST_F2F3);
                break;

                case K.LLRC:
                    result = DataParser.parse(src, out state.LLRC);
                    fieldval = value(kind, type, state.LLRC);
                break;

                case K.LOCK:
                    state.LOCK = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.LZCNT:
                    state.LZCNT = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.MAP:
                    result = DataParser.parse(src, out state.MAP);
                    fieldval = value(kind, type, state.MAP);
                break;

                case K.MASK:
                    result = DataParser.parse(src, out state.MASK);
                    fieldval = value(kind, type, state.MASK);
                break;

                case K.MAX_BYTES:
                    result = DataParser.parse(src, out state.MAX_BYTES);
                    fieldval = value(kind, type, state.MAX_BYTES);
                break;

                case K.MEM_WIDTH:
                    result = DataParser.parse(src, out state.MEM_WIDTH);
                    fieldval = value(kind, type, state.MEM_WIDTH);
                break;

                case K.MEM0:
                    fieldval = value(kind, resolver(src));
                break;

                case K.MEM1:
                    fieldval = value(kind, resolver(src));
                break;

                case K.MOD:
                    result = DataParser.parse(src, out state.MOD);
                    fieldval = value(kind, type, state.MOD);
                break;

                case K.REG:
                    result = DataParser.parse(src, out state.REG);
                    fieldval = value(kind, type, state.REG);
                break;

                case K.MODRM_BYTE:
                    result = DataParser.parse(src, out byte modrm);
                    state.MODRM_BYTE = modrm;
                    fieldval = value(kind, type, state.MODRM_BYTE);
                break;

                case K.MODE:
                    result = DataParser.parse(src, out state.MODE);
                    fieldval = value(kind, type, state.MODE);
                break;

                case K.MODEP5:
                    state.MODEP5 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.MODEP55C:
                    state.MODEP55C = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.MODE_FIRST_PREFIX:
                    state.MODE_FIRST_PREFIX = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.MPXMODE:
                    state.MPXMODE = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.MUST_USE_EVEX:
                    state.MUST_USE_EVEX = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.NEEDREX:
                    state.NEEDREX = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.NEED_MEMDISP:
                    state.NEED_MEMDISP = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.NEED_SIB:
                    state.NEED_SIB = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.NELEM:
                    result = DataParser.parse(src, out state.NELEM);
                    fieldval = value(kind, type, state.NELEM);
                break;

                case K.NOMINAL_OPCODE:
                    result = DataParser.parse(src, out byte opcode);
                    state.NOMINAL_OPCODE = opcode;
                    fieldval = value(kind, type, state.NOMINAL_OPCODE);
                break;

                case K.NOREX:
                    state.NOREX = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.NO_SCALE_DISP8:
                    state.NO_SCALE_DISP8 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.NPREFIXES:
                    result = DataParser.parse(src, out state.NPREFIXES);
                    fieldval = value(kind, type, state.NPREFIXES);
                break;

                case K.NREXES:
                    result = DataParser.parse(src, out state.NREXES);
                    fieldval = value(kind, type, state.NREXES);
                break;

                case K.NSEG_PREFIXES:
                    result = DataParser.parse(src, out state.NSEG_PREFIXES);
                    fieldval = value(kind, type, state.NSEG_PREFIXES);
                break;

                case K.OSZ:
                    state.OSZ = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.OUT_OF_BYTES:
                    state.OUT_OF_BYTES = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.P4:
                    state.P4 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.POS_DISP:
                    result = DataParser.parse(src, out state.POS_DISP);
                    fieldval = value(kind, type, state.POS_DISP);
                break;

                case K.POS_IMM:
                    result = DataParser.parse(src, out state.POS_IMM);
                    fieldval = value(kind, type, state.POS_IMM);
                break;

                case K.POS_IMM1:
                    result = DataParser.parse(src, out state.POS_IMM1);
                    fieldval = value(kind, type, state.POS_IMM1);
                break;

                case K.POS_MODRM:
                    result = DataParser.parse(src, out state.POS_MODRM);
                    fieldval = value(kind, type, state.POS_MODRM);
                break;

                case K.POS_NOMINAL_OPCODE:
                    result = DataParser.parse(src, out state.POS_NOMINAL_OPCODE);
                    fieldval = value(kind, type, state.POS_NOMINAL_OPCODE);
                break;

                case K.POS_SIB:
                    result = DataParser.parse(src, out state.POS_SIB);
                    fieldval = value(kind, type, state.POS_SIB);
                break;

                case K.PREFIX66:
                    state.PREFIX66 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.PTR:
                    state.PTR = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.REALMODE:
                    state.REALMODE = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.OUTREG:
                    result = P.xedreg(src, out state.OUTREG);
                    fieldval = value(kind, type, state.OUTREG);
                break;

                case K.REG0:
                    result = P.xedreg(src, out state.REG0);
                    fieldval = value(kind, type, state.REG0);
                break;

                case K.REG1:
                    result = P.xedreg(src, out state.REG1);
                    fieldval = value(kind, type, state.REG1);
                break;

                case K.REG2:
                    result = P.xedreg(src, out state.REG2);
                    fieldval = value(kind, type, state.REG2);
                break;

                case K.REG3:
                    result = P.xedreg(src, out state.REG3);
                    fieldval = value(kind, type, state.REG3);
                break;

                case K.REG4:
                    result = P.xedreg(src, out state.REG4);
                    fieldval = value(kind, type, state.REG4);
                break;

                case K.REG5:
                    result = P.xedreg(src, out state.REG5);
                    fieldval = value(kind, type, state.REG5);
                break;

                case K.REG6:
                    result = P.xedreg(src, out state.REG6);
                    fieldval = value(kind, type, state.REG6);
                break;

                case K.REG7:
                    result = P.xedreg(src, out state.REG7);
                    fieldval = value(kind, type, state.REG7);
                break;

                case K.REG8:
                    result = P.xedreg(src, out state.REG8);
                    fieldval = value(kind, type, state.REG8);
                break;

                case K.REG9:
                    result = P.xedreg(src, out state.REG9);
                    fieldval = value(kind, type, state.REG9);
                break;

                case K.REP:
                    result = DataParser.parse(src, out state.REP);
                    fieldval = value(kind, type, state.REP);
                break;

                case K.REX:
                    state.REX = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.REXB:
                    state.REXB = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.REXR:
                    state.REXR = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.REXRR:
                    state.REXRR = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.REXW:
                    state.REXW = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.REXX:
                    state.REXX = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.RM:
                    result = DataParser.parse(src, out state.RM);
                    fieldval = value(kind, type, state.RM);
                break;

                case K.ROUNDC:
                    result = DataParser.parse(src, out state.ROUNDC);
                    fieldval = value(kind, type, state.ROUNDC);
                break;

                case K.SAE:
                    state.SAE = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.SCALE:
                    result = DataParser.parse(src, out state.SCALE);
                    fieldval = value(kind, type, state.SCALE);
                break;

                case K.SEG0:
                    result = P.xedreg(src, out state.SEG0);
                    fieldval = value(kind, type, state.SEG0);
                break;

                case K.SEG1:
                    result = P.xedreg(src, out state.SEG1);
                    fieldval = value(kind, type, state.SEG1);
                break;

                case K.SEG_OVD:
                    result = DataParser.parse(src, out state.SEG_OVD);
                    fieldval = value(kind, type, state.SEG_OVD);
                break;

                case K.SIBBASE:
                    result = DataParser.parse(src, out state.SIBBASE);
                    fieldval = value(kind, type, state.SIBBASE);
                break;

                case K.SIBINDEX:
                    result = DataParser.parse(src, out state.SIBINDEX);
                    fieldval = value(kind, type, state.SIBINDEX);
                break;

                case K.SIBSCALE:
                    result = DataParser.parse(src, out state.SIBSCALE);
                    fieldval = value(kind, type, state.SIBSCALE);
                break;

                case K.SMODE:
                    result = DataParser.parse(src, out state.SMODE);
                    fieldval = value(kind, type, state.SMODE);
                    break;

                case K.SRM:
                    result = DataParser.parse(src, out state.SRM);
                    fieldval = value(kind, type, state.SRM);
                break;

                case K.TZCNT:
                    state.TZCNT = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.UBIT:
                    state.UBIT = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.UIMM0:
                    result = imm64.parse(src, out state.UIMM0);
                    fieldval = value(kind, type, state.UIMM0);
                break;

                case K.UIMM1:
                    result = imm8.parse(src, out state.UIMM1);
                    fieldval = value(kind, type, state.UIMM1);
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    state.USING_DEFAULT_SEGMENT0 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    state.USING_DEFAULT_SEGMENT1 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.VEXDEST210:
                    result = DataParser.parse(src, out state.VEXDEST210);
                    fieldval = value(kind, type, state.VEXDEST210);
                break;

                case K.VEXDEST3:
                    state.VEXDEST3 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.VEXDEST4:
                    state.VEXDEST4 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.VEXVALID:
                    result = DataParser.parse(src, out state.VEXVALID);
                    fieldval = value(kind, type, state.VEXVALID);
                break;

                case K.VEX_C4:
                    state.VEX_C4 = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.VEX_PREFIX:
                    result = DataParser.parse(src, out state.VEX_PREFIX);
                    fieldval = value(kind, type, state.VEX_PREFIX);
                break;

                case K.VL:
                    result = DataParser.parse(src, out state.VL);
                    fieldval = value(kind, type, state.VL);
                break;

                case K.WBNOINVD:
                    state.WBNOINVD = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;

                case K.ZEROING:
                    state.ZEROING = bit.On;
                    fieldval = value(kind, type, bit.On);
                break;
            }

            return fieldval;
        }

        public static ref RuleState update(in FieldAssign src, ref RuleState dst)
        {
            var kind = src.Field;
            var result = Outcome.Success;
            switch(kind)
            {
                case K.AMD3DNOW:
                    dst.AMD3DNOW = (bit)src.Value;
                break;

                case K.ASZ:
                    dst.ASZ = (bit)src.Value;
                break;

                case K.BASE0:
                    dst.BASE0 = (XedRegId)src.Value;
                break;

                case K.BASE1:
                    dst.BASE1 = (XedRegId)src.Value;
                break;

                case K.BCAST:
                    dst.BCAST = (BCastKind)src.Value;
                break;

                case K.BCRC:
                    dst.BCRC = (bit)src.Value;
                break;

                case K.RELBR:
                    dst.RELBR = (bit)src.Value;
                break;

                case K.BRDISP_WIDTH:
                    dst.BRDISP_WIDTH = (byte)src.Value;
                break;

                case K.CET:
                    dst.CET = (bit)src.Value;
                break;

                case K.CHIP:
                    dst.CHIP = (ChipCode)src.Value;
                break;

                case K.CLDEMOTE:
                    dst.CLDEMOTE = (bit)src.Value;
                break;

                case K.DEFAULT_SEG:
                    dst.DEFAULT_SEG = (byte)src.Value;
                break;

                case K.DF32:
                    dst.DF32 = (bit)src.Value;
                break;

                case K.DF64:
                    dst.DF64 = (bit)src.Value;
                break;

                case K.DISP:
                    dst.DISP =  src.Value;
                break;

                case K.DISP_WIDTH:
                    dst.DISP_WIDTH = (byte)src.Value;
                break;

                case K.DUMMY:
                    dst.DUMMY = (bit)src.Value;
                break;

                case K.EASZ:
                    dst.EASZ = (byte)src.Value;
                break;

                case K.ELEMENT_SIZE:
                    dst.ELEMENT_SIZE = (ushort)src.Value;
                break;

                case K.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = (bit)src.Value;
                break;

                case K.ENCODE_FORCE:
                    dst.ENCODE_FORCE = (bit)src.Value;
                break;

                case K.EOSZ:
                    dst.EOSZ = (byte)src.Value;
                break;

                case K.ESRC:
                    dst.ESRC = (uint4)src.Value;
                break;

                case K.FIRST_F2F3:
                    dst.FIRST_F2F3 = (byte)src.Value;
                break;

                case K.HAS_MODRM:
                    dst.HAS_MODRM = (bit)src.Value;
                break;

                case K.HAS_SIB:
                    dst.HAS_SIB = (bit)src.Value;
                break;

                case K.HINT:
                    dst.HINT = (byte)src.Value;
                break;

                case K.ICLASS:
                    dst.ICLASS = (IClass)src.Value;
                break;

                case K.ILD_F2:
                    dst.ILD_F2 = (bit)src.Value;
                break;

                case K.ILD_F3:
                    dst.ILD_F3 = (bit)src.Value;
                break;

                case K.ILD_SEG:
                    dst.ILD_SEG = (byte)src.Value;
                break;

                case K.IMM0:
                    dst.IMM0 = (bit)src.Value;
                break;

                case K.IMM0SIGNED:
                    dst.IMM0SIGNED = (bit)src.Value;
                break;

                case K.IMM1:
                    dst.IMM1 = (bit)src.Value;
                break;

                case K.IMM1_BYTES:
                    dst.IMM1_BYTES = (byte)src.Value;
                break;

                case K.IMM_WIDTH:
                    dst.IMM_WIDTH = (byte)src.Value;
                break;

                case K.INDEX:
                    dst.INDEX = (XedRegId)src.Value;
                break;

                case K.LAST_F2F3:
                    dst.LAST_F2F3 = (byte)src.Value;
                break;

                case K.LLRC:
                    dst.LLRC = (byte)src.Value;
                break;

                case K.LOCK:
                    dst.LOCK = (bit)src.Value;
                break;

                case K.LZCNT:
                    dst.LZCNT = (bit)src.Value;
                break;

                case K.MAP:
                    dst.MAP = (byte)src.Value;
                break;

                case K.MASK:
                    dst.MASK = (byte)src.Value;
                break;

                case K.MAX_BYTES:
                    dst.MAX_BYTES = (byte)src.Value;
                break;

                case K.MEM_WIDTH:
                    dst.MEM_WIDTH = (ushort)src.Value;
                break;

                case K.MOD:
                    dst.MOD = (byte)src.Value;
                break;

                case K.REG:
                    dst.REG = (byte)src.Value;
                break;

                case K.MODRM_BYTE:
                    dst.MODRM_BYTE = (byte)src.Value;
                break;

                case K.MODE:
                    dst.MODE = (byte)src.Value;
                break;

                case K.MODEP5:
                    dst.MODEP5 = (bit)src.Value;
                break;

                case K.MODEP55C:
                    dst.MODEP55C = (bit)src.Value;
                break;

                case K.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = (bit)src.Value;
                break;

                case K.MPXMODE:
                    dst.MPXMODE = (bit)src.Value;
                break;

                case K.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = (bit)src.Value;
                break;

                case K.NEEDREX:
                    dst.NEEDREX = (bit)src.Value;
                break;

                case K.NEED_MEMDISP:
                    dst.NEED_MEMDISP = (bit)src.Value;
                break;

                case K.NEED_SIB:
                    dst.NEED_SIB = (bit)src.Value;
                break;

                case K.NELEM:
                    dst.NELEM = (byte)src.Value;
                break;

                case K.NOMINAL_OPCODE:
                    dst.NOMINAL_OPCODE = (byte)src.Value;
                break;

                case K.NOREX:
                    dst.NOREX = (bit)src.Value;
                break;

                case K.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = (bit)src.Value;
                break;

                case K.NPREFIXES:
                    dst.NPREFIXES = (byte)src.Value;
                break;

                case K.NREXES:
                    dst.NREXES = (byte)src.Value;
                break;

                case K.NSEG_PREFIXES:
                    dst.NSEG_PREFIXES = (byte)src.Value;
                break;

                case K.OSZ:
                    dst.OSZ = (bit)src.Value;
                break;

                case K.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = (bit)src.Value;
                break;

                case K.P4:
                    dst.P4 = (bit)src.Value;
                break;

                case K.POS_DISP:
                    dst.POS_DISP = (byte)src.Value;;
                break;

                case K.POS_IMM:
                    dst.POS_IMM = (byte)src.Value;
                break;

                case K.POS_IMM1:
                    dst.POS_IMM1 = (byte)src.Value;
                break;

                case K.POS_MODRM:
                    dst.POS_MODRM = (byte)src.Value;
                break;

                case K.POS_NOMINAL_OPCODE:
                    dst.POS_NOMINAL_OPCODE = (byte)src.Value;
                break;

                case K.POS_SIB:
                    dst.POS_SIB = (byte)src.Value;
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
                    dst.OUTREG = (XedRegId)src.Value;
                break;

                case K.REG0:
                    dst.REG0 = (XedRegId)src.Value;
                break;

                case K.REG1:
                    dst.REG1 = (XedRegId)src.Value;
                break;

                case K.REG2:
                    dst.REG2 = (XedRegId)src.Value;
                break;

                case K.REG3:
                    dst.REG3 = (XedRegId)src.Value;
                break;

                case K.REG4:
                    dst.REG4 = (XedRegId)src.Value;
                break;

                case K.REG5:
                    dst.REG5 = (XedRegId)src.Value;
                break;

                case K.REG6:
                    dst.REG6 = (XedRegId)src.Value;
                break;

                case K.REG7:
                    dst.REG7 = (XedRegId)src.Value;
                break;

                case K.REG8:
                    dst.REG8 = (XedRegId)src.Value;
                break;

                case K.REG9:
                    dst.REG9 = (XedRegId)src.Value;
                break;

                case K.REP:
                    dst.REP = (byte)src.Value;
                break;

                case K.REX:
                    dst.REX = (bit)src.Value;
                break;

                case K.REXB:
                    dst.REXB = (bit)src.Value;
                break;

                case K.REXR:
                    dst.REXR = (bit)src.Value;
                break;

                case K.REXRR:
                    dst.REXRR = (bit)src.Value;
                break;

                case K.REXW:
                    dst.REXW = (bit)src.Value;
                break;

                case K.REXX:
                    dst.REXX = (bit)src.Value;
                break;

                case K.RM:
                    dst.RM = (byte)src.Value;
                break;

                case K.ROUNDC:
                    dst.ROUNDC = (byte)src.Value;
                break;

                case K.SAE:
                    dst.SAE = (bit)src.Value;
                break;

                case K.SCALE:
                    dst.SCALE = (byte)src.Value;
                break;

                case K.SEG0:
                    dst.SEG0 = (XedRegId)src.Value;
                break;

                case K.SEG1:
                    dst.SEG1 = (XedRegId)src.Value;
                break;

                case K.SEG_OVD:
                    dst.SEG_OVD = (byte)src.Value;
                break;

                case K.SIBBASE:
                    dst.SIBBASE = (byte)src.Value;
                break;

                case K.SIBINDEX:
                    dst.SIBINDEX = (byte)src.Value;
                break;

                case K.SIBSCALE:
                    dst.SIBSCALE = (byte)src.Value;
                break;

                case K.SMODE:
                    dst.SMODE = (byte)src.Value;
                    break;

                case K.SRM:
                    dst.SRM = (byte)src.Value;
                break;

                case K.TZCNT:
                    dst.TZCNT = (bit)src.Value;
                break;

                case K.UBIT:
                    dst.UBIT = (bit)src.Value;
                break;

                case K.UIMM0:
                    dst.UIMM0 = src.Value;
                break;

                case K.UIMM1:
                    dst.UIMM1 = (byte)src.Value;
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = (bit)src.Value;
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = (bit)src.Value;
                break;

                case K.VEXDEST210:
                    dst.VEXDEST210 = (byte)src.Value;
                break;

                case K.VEXDEST3:
                    dst.VEXDEST3 = (bit)src.Value;
                break;

                case K.VEXDEST4:
                    dst.VEXDEST4 = (bit)src.Value;
                break;

                case K.VEXVALID:
                    dst.VEXVALID = (byte)src.Value;
                break;

                case K.VEX_C4:
                    dst.VEX_C4 = (bit)src.Value;
                break;

                case K.VEX_PREFIX:
                    dst.VEX_PREFIX = (byte)src.Value;
                break;

                case K.VL:
                    dst.VL = (byte)src.Value;
                break;

                case K.WBNOINVD:
                    dst.WBNOINVD = (bit)src.Value;
                break;

                case K.ZEROING:
                    dst.ZEROING = (bit)src.Value;
                break;

                case K.MEM0:
                    dst.MEM0 = (bit)src.Value;
                break;

                case K.MEM1:
                    dst.MEM1 = (bit)src.Value;
                break;

                case K.AGEN:
                    dst.AGEN = (bit)src.Value;
                break;
            }

            return ref dst;
        }
    }
}