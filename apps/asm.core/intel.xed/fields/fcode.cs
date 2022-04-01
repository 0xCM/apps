//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using C = XedRules.FormatCode;
    using K = XedRules.FieldKind;

    partial class XedFields
    {
        [Op]
        public static FormatCode fcode(FieldKind src)
        {
            var dst = C.None;
            switch(src)
            {
                case K.AGEN:
                case K.AMD3DNOW:
                case K.ASZ:
                case K.BCRC:
                case K.CET:
                case K.CLDEMOTE:
                case K.DF32:
                case K.DF64:
                case K.DUMMY:
                case K.ENCODER_PREFERRED:
                case K.ENCODE_FORCE:
                case K.HAS_MODRM:
                case K.HAS_SIB:
                case K.ILD_F2:
                case K.ILD_F3:
                case K.IMM0:
                case K.IMM0SIGNED:
                case K.IMM1:
                case K.LOCK:
                case K.LZCNT:
                case K.MEM0:
                case K.MEM1:
                case K.MODE_FIRST_PREFIX:
                case K.MODE_SHORT_UD0:
                case K.MODEP5:
                case K.MODEP55C:
                case K.MPXMODE:
                case K.MUST_USE_EVEX:
                case K.NEEDREX:
                case K.NEED_MEMDISP:
                case K.NEED_SIB:
                case K.NOREX:
                case K.NO_RETURN:
                case K.NO_SCALE_DISP8:
                case K.REX:
                case K.REXW:
                case K.REXR:
                case K.REXX:
                case K.REXB:
                case K.OSZ:
                case K.OUT_OF_BYTES:
                case K.P4:
                case K.PREFIX66:
                case K.PTR:
                case K.REALMODE:
                case K.RELBR:
                case K.TZCNT:
                case K.UBIT:
                case K.USING_DEFAULT_SEGMENT0:
                case K.USING_DEFAULT_SEGMENT1:
                case K.VEX_C4:
                case K.ZEROING:
                case K.WBNOINVD:
                case K.REXRR:
                case K.SAE:
                case K.VEXDEST3:
                case K.VEXDEST4:
                    dst = C.Bit;
                break;

                case K.SIBSCALE:
                    dst = C.B2;
                break;

                // case K.VEXDEST3:
                // case K.VEXDEST4:
                //     dst = C.B1;
                // break;

                // case K.REG:
                // case K.RM:
                // case K.SRM:
                // case K.SIBBASE:
                // case K.SIBINDEX:
                // case K.VEXDEST210:
                //     dst = C.B3;
                // break;

                case K.FIRST_F2F3:
                case K.LAST_F2F3:
                case K.LLRC:
                case K.DEFAULT_SEG:
                case K.REP:
                case K.VL:
                {
                    dst = C.U2;
                }
                break;

                case K.HINT:
                case K.ROUNDC:
                case K.SEG_OVD:
                    dst = C.U3;
                break;

                case K.ESRC:
                    dst = C.X4;
                break;

                case K.MAP:
                case K.NELEM:
                case K.SCALE:
                    dst = C.U4;
                break;

                case K.BCAST:
                    dst = C.U5;
                break;

                case K.MOD:
                case K.BRDISP_WIDTH:
                case K.DISP_WIDTH:
                case K.ILD_SEG:
                case K.IMM1_BYTES:
                case K.IMM_WIDTH:
                case K.MAX_BYTES:
                case K.NPREFIXES:
                case K.NREXES:
                case K.NSEG_PREFIXES:
                case K.POS_DISP:
                case K.POS_IMM:
                case K.POS_IMM1:
                case K.POS_MODRM:
                case K.POS_NOMINAL_OPCODE:
                case K.POS_SIB:
                case K.UIMM1:
                case K.REG:
                case K.RM:
                case K.SRM:
                case K.SIBBASE:
                case K.SIBINDEX:
                case K.VEXDEST210:
                {
                    dst = C.U8;
                }
                break;

                case K.ELEMENT_SIZE:
                case K.MEM_WIDTH:
                {
                    dst = C.U16;
                }
                break;

                case K.MODRM_BYTE:
                case K.NOMINAL_OPCODE:
                {
                    dst = C.X8;
                }
                break;

                case K.DISP:
                    dst = C.Disp;
                break;

                case K.UIMM0:
                    dst = C.U64;
                break;

                case K.BASE0:
                case K.BASE1:
                case K.INDEX:
                case K.OUTREG:
                case K.SEG0:
                case K.SEG1:
                case K.REG0:
                case K.REG1:
                case K.REG2:
                case K.REG3:
                case K.REG4:
                case K.REG5:
                case K.REG6:
                case K.REG7:
                case K.REG8:
                case K.REG9:
                {
                    dst = C.Reg;
                }
                break;
                case K.CHIP:
                {
                    dst = C.Chip;
                }
                break;

                case K.ERROR:
                {
                    dst = C.Error;
                }
                break;

                case K.ICLASS:
                    dst = C.InstClass;
                break;

                case K.MASK:
                case K.VEX_PREFIX:
                case K.VEXVALID:
                    dst = C.UInt;
                break;

                case K.SMODE:
                case K.MODE:
                    dst = C.UInt;
                break;

                case K.EASZ:
                case K.EOSZ:
                    dst = C.UInt;
                break;

                default:
                    break;
            }

            return dst;
        }
    }
}
