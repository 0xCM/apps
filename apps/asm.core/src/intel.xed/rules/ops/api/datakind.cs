//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.FieldKind;

    using F = XedRules.FieldDataKind;
    using K = XedRules.FieldKind;

    partial class XedRules
    {
        [Op]
        public static FieldDataKind datakind(FieldKind field)
        {
            var dst = F.None;
            switch(field)
            {
                case AGEN:
                case AMD3DNOW:
                case ASZ:
                case BCRC:
                case CET:
                case CLDEMOTE:
                case DF32:
                case DF64:
                case DUMMY:
                case ENCODER_PREFERRED:
                case ENCODE_FORCE:
                case HAS_MODRM:
                case HAS_SIB:
                case ILD_F2:
                case ILD_F3:
                case IMM0:
                case IMM0SIGNED:
                case IMM1:
                case LOCK:
                case LZCNT:
                case MEM0:
                case MEM1:
                case MODE_FIRST_PREFIX:
                case MODE_SHORT_UD0:
                case MODEP5:
                case MODEP55C:
                case MPXMODE:
                case MUST_USE_EVEX:
                case NEEDREX:
                case NEED_MEMDISP:
                case NEED_SIB:
                case NOREX:
                case NO_RETURN:
                case NO_SCALE_DISP8:
                case REX:
                case REXW:
                case REXR:
                case REXX:
                case REXB:
                case OSZ:
                case OUT_OF_BYTES:
                case P4:
                case PREFIX66:
                case PTR:
                case REALMODE:
                case RELBR:
                case TZCNT:
                case UBIT:
                case USING_DEFAULT_SEGMENT0:
                case USING_DEFAULT_SEGMENT1:
                case VEX_C4:
                case VEXDEST3:
                case VEXDEST4:
                case ZEROING:
                case WBNOINVD:
                case REXRR:
                case SAE:
                    dst = F.B1;
                break;

                case MOD:
                case SIBSCALE:
                case K.EASZ:
                case K.EOSZ:
                case FIRST_F2F3:
                case LAST_F2F3:
                case LLRC:
                case DEFAULT_SEG:
                case MODE:
                case REP:
                case SMODE:
                case VEX_PREFIX:
                case VL:
                {
                    dst = F.U2;
                }
                break;

                case REG:
                case RM:
                case SIBBASE:
                case SIBINDEX:
                case VEXDEST210:
                case SRM:
                case HINT:
                case MASK:
                case ROUNDC:
                case SEG_OVD:
                case VEXVALID:
                {
                    dst = F.U3;
                }
                break;

                case MAP:
                case ESRC:
                case NELEM:
                case SCALE:
                {
                    dst = F.U4;
                }
                break;

                case BCAST:
                {
                    dst = F.U5;
                }
                break;

                case BRDISP_WIDTH:
                case DISP_WIDTH:
                case ILD_SEG:
                case IMM1_BYTES:
                case IMM_WIDTH:
                case MAX_BYTES:
                case MODRM_BYTE:
                case NPREFIXES:
                case NREXES:
                case NSEG_PREFIXES:
                case POS_DISP:
                case POS_IMM:
                case POS_IMM1:
                case POS_MODRM:
                case POS_NOMINAL_OPCODE:
                case POS_SIB:
                case UIMM1:
                {
                    dst = F.U8;
                }
                break;

                case ELEMENT_SIZE:
                case MEM_WIDTH:
                {
                    dst = F.U16;
                }
                break;

                case NOMINAL_OPCODE:
                {
                    dst = F.Hex8;
                }
                break;

                case DISP:
                {
                    dst = F.Disp;
                }
                break;

                case UIMM0:
                {
                    dst = F.U64;
                }
                break;

                case BASE0:
                case BASE1:
                case INDEX:
                case OUTREG:
                case SEG0:
                case SEG1:
                case REG0:
                case REG1:
                case REG2:
                case REG3:
                case REG4:
                case REG5:
                case REG6:
                case REG7:
                case REG8:
                case REG9:
                {
                    dst = F.Reg;
                }
                break;
                case CHIP:
                {
                    dst = F.Chip;
                }
                break;

                case ERROR:
                {
                    dst = F.Error;
                }
                break;

                case ICLASS:
                {
                    dst = F.InstClass;
                }
                break;

                default:
                    break;
            }

            return dst;
        }
    }
}