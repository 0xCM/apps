//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using K = XedRules.FieldKind;
    using R = XedRules.CellRole;

    partial class XedState
    {
        [Op]
        public static CellValue select(in RuleState src, FieldKind kind)
        {
            var result = Outcome.Success;
            var dst = new CellValue(kind, 0ul, R.FieldValue);
            switch(kind)
            {
                case K.AMD3DNOW:
                    dst = new (kind, src.AMD3DNOW, R.FieldValue);
                break;

                case K.ASZ:
                    dst = new (kind, src.ASZ, R.FieldValue);
                break;

                case K.BASE0:
                    dst = new (kind, src.BASE0, R.FieldValue);
                break;

                case K.BASE1:
                    dst = new (kind, src.BASE1, R.FieldValue);
                break;

                case K.BCAST:
                    dst = new (kind, src.BCAST, R.FieldValue);
                break;

                case K.BCRC:
                    dst = new (kind, src.BCRC, R.FieldValue);
                break;

                case K.RELBR:
                    dst = new (kind, src.RELBR, R.FieldValue);
                break;

                case K.BRDISP_WIDTH:
                    dst = new (kind, src.BRDISP_WIDTH, R.FieldValue);
                break;

                case K.CET:
                    dst = new (kind, src.CET, R.FieldValue);
                break;

                case K.CHIP:
                    dst = new (kind, src.CHIP, R.FieldValue);
                break;

                case K.CLDEMOTE:
                    dst = new (kind, src.CLDEMOTE, R.FieldValue);
                break;

                case K.DEFAULT_SEG:
                    dst = new (kind, src.DEFAULT_SEG, R.FieldValue);
                break;

                case K.DF32:
                    dst = new (kind, src.DF32, R.FieldValue);
                break;

                case K.DF64:
                    dst = new (kind, src.DF64, R.FieldValue);
                break;

                case K.DISP:
                    dst = new (kind, src.DISP, R.FieldValue);
                break;

                case K.DISP_WIDTH:
                    dst = new (kind, src.DISP_WIDTH, R.FieldValue);
                break;

                case K.DUMMY:
                    dst = new (kind, src.DUMMY, R.FieldValue);
                break;

                case K.EASZ:
                    dst = new (kind, src.EASZ, R.FieldValue);
                break;

                case K.ELEMENT_SIZE:
                    dst = new (kind, src.ELEMENT_SIZE, R.FieldValue);
                break;

                case K.ENCODER_PREFERRED:
                    dst = new (kind, src.ENCODER_PREFERRED, R.FieldValue);
                break;

                case K.ENCODE_FORCE:
                    dst = new (kind, src.ENCODE_FORCE, R.FieldValue);
                break;

                case K.EOSZ:
                    dst = new (kind, src.EOSZ, R.FieldValue);
                break;

                case K.ESRC:
                    dst = new (kind, src.ESRC, R.FieldValue);
                break;

                case K.FIRST_F2F3:
                    dst = new (kind, src.FIRST_F2F3, R.FieldValue);
                break;

                case K.HAS_MODRM:
                    dst = new (kind, src.HAS_MODRM, R.FieldValue);
                break;

                case K.HAS_SIB:
                    dst = new (kind, src.HAS_SIB, R.FieldValue);
                break;

                case K.HINT:
                    dst = new (kind, src.HINT, R.FieldValue);
                break;

                case K.ICLASS:
                    dst = new (kind, src.ICLASS, R.FieldValue);
                break;

                case K.ILD_F2:
                    dst = new (kind, src.ILD_F2, R.FieldValue);
                break;

                case K.ILD_F3:
                    dst = new (kind, src.ILD_F3, R.FieldValue);
                break;

                case K.ILD_SEG:
                    dst = new (kind, src.ILD_SEG, R.FieldValue);
                break;

                case K.IMM0:
                    dst = new (kind, src.IMM0, R.FieldValue);
                break;

                case K.IMM0SIGNED:
                    dst = new (kind, src.IMM0SIGNED, R.FieldValue);
                break;

                case K.IMM1:
                    dst = new (kind, src.IMM1, R.FieldValue);
                break;

                case K.IMM1_BYTES:
                    dst = new (kind, src.IMM1_BYTES, R.FieldValue);
                break;

                case K.IMM_WIDTH:
                    dst = new (kind, src.IMM_WIDTH, R.FieldValue);
                break;

                case K.INDEX:
                    dst = new (kind, src.INDEX, R.FieldValue);
                break;

                case K.LAST_F2F3:
                    dst = new (kind, src.LAST_F2F3, R.FieldValue);
                break;

                case K.LLRC:
                    dst = new (kind, src.LLRC, R.FieldValue);
                break;

                case K.LOCK:
                    dst = new (kind, src.LOCK, R.FieldValue);
                break;

                case K.LZCNT:
                    dst = new (kind, src.LZCNT, R.FieldValue);
                break;

                case K.MAP:
                    dst = new (kind, src.MAP, R.FieldValue);
                break;

                case K.MASK:
                    dst = new (kind, src.MASK, R.FieldValue);
                break;

                case K.MAX_BYTES:
                    dst = new (kind, src.MAX_BYTES, R.FieldValue);
                break;

                case K.MEM_WIDTH:
                    dst = new (kind, src.MEM_WIDTH, R.FieldValue);
                break;

                case K.MOD:
                    dst = new (kind, src.MOD, R.FieldValue);
                break;

                case K.REG:
                    dst = new (kind, src.REG, R.FieldValue);
                break;

                case K.MODRM_BYTE:
                    dst = new (kind, src.MODRM_BYTE, R.FieldValue);
                break;

                case K.MODE:
                    dst = new (kind, src.MODE, R.FieldValue);
                break;

                case K.MODEP5:
                    dst = new (kind, src.MODEP5, R.FieldValue);
                break;

                case K.MODEP55C:
                    dst = new (kind, src.MODEP55C, R.FieldValue);
                break;

                case K.MODE_FIRST_PREFIX:
                    dst = new (kind, src.MODE_FIRST_PREFIX, R.FieldValue);
                break;

                case K.MPXMODE:
                    dst = new (kind, src.MPXMODE, R.FieldValue);
                break;

                case K.MUST_USE_EVEX:
                    dst = new (kind, src.MUST_USE_EVEX, R.FieldValue);
                break;

                case K.NEEDREX:
                    dst = new (kind, src.NEEDREX, R.FieldValue);
                break;

                case K.NEED_MEMDISP:
                    dst = new (kind, src.NEED_MEMDISP, R.FieldValue);
                break;

                case K.NEED_SIB:
                    dst = new (kind, src.NEED_SIB, R.FieldValue);
                break;

                case K.NELEM:
                    dst = new (kind, src.NELEM, R.FieldValue);
                break;

                case K.NOMINAL_OPCODE:
                    dst = new (kind, src.NOMINAL_OPCODE, R.FieldValue);
                break;

                case K.NOREX:
                    dst = new (kind, src.NOREX, R.FieldValue);
                break;

                case K.NO_SCALE_DISP8:
                    dst = new (kind, src.NO_SCALE_DISP8, R.FieldValue);
                break;

                case K.NPREFIXES:
                    dst = new (kind, src.NPREFIXES, R.FieldValue);
                break;

                case K.NREXES:
                    dst = new (kind, src.NREXES, R.FieldValue);
                break;

                case K.NSEG_PREFIXES:
                    dst = new (kind, src.NSEG_PREFIXES, R.FieldValue);
                break;

                case K.OSZ:
                    dst = new (kind, src.OSZ, R.FieldValue);
                break;

                case K.OUT_OF_BYTES:
                    dst = new (kind, src.OUT_OF_BYTES, R.FieldValue);
                break;

                case K.P4:
                    dst = new (kind, src.P4, R.FieldValue);
                break;

                case K.POS_DISP:
                    dst = new (kind, src.POS_DISP, R.FieldValue);
                break;

                case K.POS_IMM:
                    dst = new (kind, src.POS_IMM, R.FieldValue);
                break;

                case K.POS_IMM1:
                    dst = new (kind, src.POS_IMM1, R.FieldValue);
                break;

                case K.POS_MODRM:
                    dst = new (kind, src.POS_MODRM, R.FieldValue);
                break;

                case K.POS_NOMINAL_OPCODE:
                    dst = new (kind, src.POS_NOMINAL_OPCODE, R.FieldValue);
                break;

                case K.POS_SIB:
                    dst = new (kind, src.POS_SIB, R.FieldValue);
                break;

                case K.PREFIX66:
                    dst = new (kind, src.PREFIX66, R.FieldValue);
                break;

                case K.PTR:
                    dst = new (kind, src.PTR, R.FieldValue);
                break;

                case K.REALMODE:
                    dst = new (kind, src.REALMODE, R.FieldValue);
                break;

                case K.OUTREG:
                    dst = new (kind, src.OUTREG, R.FieldValue);
                break;

                case K.REG0:
                    dst = new (kind, src.REG0, R.FieldValue);
                break;

                case K.REG1:
                    dst = new (kind, src.REG1, R.FieldValue);
                break;

                case K.REG2:
                    dst = new (kind, src.REG2, R.FieldValue);
                break;

                case K.REG3:
                    dst = new (kind, src.REG3, R.FieldValue);
                break;

                case K.REG4:
                    dst = new (kind, src.REG4, R.FieldValue);
                break;

                case K.REG5:
                    dst = new (kind, src.REG5, R.FieldValue);
                break;

                case K.REG6:
                    dst = new (kind, src.REG6, R.FieldValue);
                break;

                case K.REG7:
                    dst = new (kind, src.REG7, R.FieldValue);
                break;

                case K.REG8:
                    dst = new (kind, src.REG8, R.FieldValue);
                break;

                case K.REG9:
                    dst = new (kind, src.REG9, R.FieldValue);
                break;

                case K.REP:
                    dst = new (kind, src.REP, R.FieldValue);
                break;

                case K.REX:
                    dst = new (kind, src.REX, R.FieldValue);
                break;

                case K.REXB:
                    dst = new (kind, src.REXB, R.FieldValue);
                break;

                case K.REXR:
                    dst = new (kind, src.REXR, R.FieldValue);
                break;

                case K.REXRR:
                    dst = new (kind, src.REXRR, R.FieldValue);
                break;

                case K.REXW:
                    dst = new (kind, src.REXW, R.FieldValue);
                break;

                case K.REXX:
                    dst = new (kind, src.REXX, R.FieldValue);
                break;

                case K.RM:
                    dst = new (kind, src.RM, R.FieldValue);
                break;

                case K.ROUNDC:
                    dst = new (kind, src.ROUNDC, R.FieldValue);
                break;

                case K.SAE:
                    dst = new (kind, src.SAE, R.FieldValue);
                break;

                case K.SCALE:
                    dst = new (kind, src.SCALE, R.FieldValue);
                break;

                case K.SEG0:
                    dst = new (kind, src.SEG0, R.FieldValue);
                break;

                case K.SEG1:
                    dst = new (kind, src.SEG1, R.FieldValue);
                break;

                case K.SEG_OVD:
                    dst = new (kind, src.SEG_OVD, R.FieldValue);
                break;

                case K.SIBBASE:
                    dst = new (kind, src.SIBBASE, R.FieldValue);
                break;

                case K.SIBINDEX:
                    dst = new (kind, src.SIBINDEX, R.FieldValue);
                break;

                case K.SIBSCALE:
                    dst = new (kind, src.SIBSCALE, R.FieldValue);
                break;

                case K.SMODE:
                    dst = new (kind, src.SMODE, R.FieldValue);
                    break;

                case K.SRM:
                    dst = new (kind, src.SRM, R.FieldValue);
                break;

                case K.TZCNT:
                    dst = new (kind, src.TZCNT, R.FieldValue);
                break;

                case K.UBIT:
                    dst = new (kind, src.UBIT, R.FieldValue);
                break;

                case K.UIMM0:
                    dst = new (kind, src.UIMM0, R.FieldValue);
                break;

                case K.UIMM1:
                    dst = new (kind, src.UIMM1, R.FieldValue);
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    dst = new (kind, src.USING_DEFAULT_SEGMENT0, R.FieldValue);
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    dst = new (kind, src.USING_DEFAULT_SEGMENT1, R.FieldValue);
                break;

                case K.VEXDEST210:
                    dst = new (kind, src.VEXDEST210, R.FieldValue);
                break;

                case K.VEXDEST3:
                    dst = new (kind, src.VEXDEST3, R.FieldValue);
                break;

                case K.VEXDEST4:
                    dst = new (kind, src.VEXDEST4, R.FieldValue);
                break;

                case K.VEXVALID:
                    dst = new (kind, src.VEXVALID, R.FieldValue);
                break;

                case K.VEX_C4:
                    dst = new (kind, src.VEX_C4, R.FieldValue);
                break;

                case K.VEX_PREFIX:
                    dst = new (kind, src.VEX_PREFIX, R.FieldValue);
                break;

                case K.VL:
                    dst = new (kind, src.VL, R.FieldValue);
                break;

                case K.WBNOINVD:
                    dst = new (kind, src.WBNOINVD, R.FieldValue);
                break;

                case K.ZEROING:
                    dst = new (kind, src.ZEROING, R.FieldValue);
                break;

                case K.MEM0:
                    dst = new (kind, src.MEM0, R.FieldValue);
                break;

                case K.MEM1:
                    dst = new (kind, src.MEM1, R.FieldValue);
                break;

                case K.AGEN:
                    dst = new (kind, src.AGEN, R.FieldValue);
                break;
            }

            return dst;
        }
    }
}