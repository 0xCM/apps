//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using K = XedRules.FieldKind;

    partial class XedRules
    {
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