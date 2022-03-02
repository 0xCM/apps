//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using N = XedRules.RuleOpName;
    using K = XedModels.FieldKind;
    using static XedModels.FieldKind;
    using Asm;

    partial class XedRules
    {
        public static Outcome spec(in RuleCriterion src, out CriterionSpec dst)
        {
            var result = Outcome.Failure;
            var kind = src.Field;
            var op = src.Operator;
            var input = src.Value;
            dst = default;
            switch(src.Field)
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
                {
                    if(bit.parse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Bit, 1));
                        result = true;
                    }
                }
                break;

                case MOD:
                case SIBSCALE:
                {
                    if(DataParser.parse(input, out uint2 x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Bits, 2));
                        result = true;
                    }
                }
                break;

                case REG:
                case RM:
                case SIBBASE:
                case SIBINDEX:
                case VEXDEST210:
                case SRM:
                {
                    if(DataParser.parse(input, out uint3 x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Bits, 3));
                        result = true;
                    }
                }
                break;

                case REX:
                {
                    if(DataParser.parse(input, out uint4 x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Bits, 4));
                        result = true;
                    }
                }
                break;

                case K.EASZ:
                case K.EOSZ:
                {
                    if(byte.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Byte, 2));
                        result = true;
                    }
                }
                break;

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
                    if(byte.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Byte, 2));
                        result = true;
                    }
                }
                break;

                case HINT:
                case MASK:
                case ROUNDC:
                case SEG_OVD:
                case VEXVALID:
                {
                    if(byte.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Byte, 3));
                        result = true;
                    }
                }
                break;

                case MAP:
                case ESRC:
                case NELEM:
                case SCALE:
                {
                    if(byte.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Byte, 4));
                        result = true;
                    }
                }
                break;

                case BCAST:
                {
                    if(byte.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Byte, 5));
                        result = true;
                    }
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
                    if(byte.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Byte, 8));
                        result = true;
                    }
                }
                break;

                case NOMINAL_OPCODE:
                {
                    if(DataParser.parse(input, out Hex8 x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Hex8, 8));
                        result = true;
                    }
                }
                break;

                case DISP:
                {
                    if(Disp64.parse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Disp, 64));
                        result = true;
                    }
                }
                break;

                case UIMM0:
                {
                    if(ulong.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.U64, 64));
                        result = true;
                    }
                }
                break;

                case ELEMENT_SIZE:
                case MEM_WIDTH:
                {
                    if(ushort.TryParse(input, out var x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.U16, 16));
                        result = true;
                    }
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
                    if(DataParser.eparse(input, out XedRegId x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Reg, 16));
                        result = true;
                    }
                }
                break;
                case CHIP:
                {
                    if(DataParser.eparse(input, out ChipCode x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Chip, 16));
                        result = true;
                    }
                }
                break;

                case ERROR:
                {
                    if(DataParser.eparse(input, out ErrorKind x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.Error, 1));
                        result = true;
                    }
                }
                break;

                case ICLASS:
                {
                    if(DataParser.eparse(input, out IClass x))
                    {
                        dst = convert(criterion(kind, op, x), datatype(FieldDataKind.InstClass, 16));
                        result = true;
                    }
                }
                break;

                default:
                    break;
            }
            return result;
        }
    }
}