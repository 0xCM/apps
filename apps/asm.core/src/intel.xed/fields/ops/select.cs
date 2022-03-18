//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedFields
    {
        [Op]
        public static R.FieldValue select(in RuleState src, FieldKind kind)
        {
            var result = Outcome.Success;
            var dst = new R.FieldValue(kind,0ul);
            switch(kind)
            {
                case K.AMD3DNOW:
                    dst = dst.WithValue(src.AMD3DNOW);
                break;

                case K.ASZ:
                    dst = dst.WithValue(src.ASZ);
                break;

                case K.BASE0:
                    dst = dst.WithValue(src.BASE0);
                break;

                case K.BASE1:
                    dst = dst.WithValue(src.BASE1);
                break;

                case K.BCAST:
                    dst = dst.WithValue(src.BCAST);
                break;

                case K.BCRC:
                    dst = dst.WithValue(src.BCRC);
                break;

                case K.RELBR:
                    dst = dst.WithValue(src.RELBR);
                break;

                case K.BRDISP_WIDTH:
                    dst = dst.WithValue(src.BRDISP_WIDTH);
                break;

                case K.CET:
                    dst = dst.WithValue(src.CET);
                break;

                case K.CHIP:
                    dst = dst.WithValue(src.CHIP);
                break;

                case K.CLDEMOTE:
                    dst = dst.WithValue(src.CLDEMOTE);
                break;

                case K.DEFAULT_SEG:
                    dst = dst.WithValue(src.DEFAULT_SEG);
                break;

                case K.DF32:
                    dst = dst.WithValue(src.DF32);
                break;

                case K.DF64:
                    dst = dst.WithValue(src.DF64);
                break;

                case K.DISP:
                    dst = dst.WithValue(src.DISP);
                break;

                case K.DISP_WIDTH:
                    dst = dst.WithValue(src.DISP_WIDTH);
                break;

                case K.DUMMY:
                    dst = dst.WithValue(src.DUMMY);
                break;

                case K.EASZ:
                    dst = dst.WithValue(src.EASZ);
                break;

                case K.ELEMENT_SIZE:
                    dst = dst.WithValue(src.ELEMENT_SIZE);
                break;

                case K.ENCODER_PREFERRED:
                    dst = dst.WithValue(src.ENCODER_PREFERRED);
                break;

                case K.ENCODE_FORCE:
                    dst = dst.WithValue(src.ENCODE_FORCE);
                break;

                case K.EOSZ:
                    dst = dst.WithValue(src.EOSZ);
                break;

                case K.ESRC:
                    dst = dst.WithValue(src.ESRC);
                break;

                case K.FIRST_F2F3:
                    dst = dst.WithValue(src.FIRST_F2F3);
                break;

                case K.HAS_MODRM:
                    dst = dst.WithValue(src.HAS_MODRM);
                break;

                case K.HAS_SIB:
                    dst = dst.WithValue(src.HAS_SIB);
                break;

                case K.HINT:
                    dst = dst.WithValue(src.HINT);
                break;

                case K.ICLASS:
                    dst = dst.WithValue(src.ICLASS);
                break;

                case K.ILD_F2:
                    dst = dst.WithValue(src.ILD_F2);
                break;

                case K.ILD_F3:
                    dst = dst.WithValue(src.ILD_F3);
                break;

                case K.ILD_SEG:
                    dst = dst.WithValue(src.ILD_SEG);
                break;

                case K.IMM0:
                    dst = dst.WithValue(src.IMM0);
                break;

                case K.IMM0SIGNED:
                    dst = dst.WithValue(src.IMM0SIGNED);
                break;

                case K.IMM1:
                    dst = dst.WithValue(src.IMM1);
                break;

                case K.IMM1_BYTES:
                    dst = dst.WithValue(src.IMM1_BYTES);
                break;

                case K.IMM_WIDTH:
                    dst = dst.WithValue(src.IMM_WIDTH);
                break;

                case K.INDEX:
                    dst = dst.WithValue(src.INDEX);
                break;

                case K.LAST_F2F3:
                    dst = dst.WithValue(src.LAST_F2F3);
                break;

                case K.LLRC:
                    dst = dst.WithValue(src.LLRC);
                break;

                case K.LOCK:
                    dst = dst.WithValue(src.LOCK);
                break;

                case K.LZCNT:
                    dst = dst.WithValue(src.LZCNT);
                break;

                case K.MAP:
                    dst = dst.WithValue(src.MAP);
                break;

                case K.MASK:
                    dst = dst.WithValue(src.MASK);
                break;

                case K.MAX_BYTES:
                    dst = dst.WithValue(src.MAX_BYTES);
                break;

                case K.MEM_WIDTH:
                    dst = dst.WithValue(src.MEM_WIDTH);
                break;

                case K.MOD:
                    dst = dst.WithValue(src.MOD);
                break;

                case K.REG:
                    dst = dst.WithValue(src.REG);
                break;

                case K.MODRM_BYTE:
                    dst = dst.WithValue(src.MODRM_BYTE);
                break;

                case K.MODE:
                    dst = dst.WithValue(src.MODE);
                break;

                case K.MODEP5:
                    dst = dst.WithValue(src.MODEP5);
                break;

                case K.MODEP55C:
                    dst = dst.WithValue(src.MODEP55C);
                break;

                case K.MODE_FIRST_PREFIX:
                    dst = dst.WithValue(src.MODE_FIRST_PREFIX);
                break;

                case K.MPXMODE:
                    dst = dst.WithValue(src.MPXMODE);
                break;

                case K.MUST_USE_EVEX:
                    dst = dst.WithValue(src.MUST_USE_EVEX);
                break;

                case K.NEEDREX:
                    dst = dst.WithValue(src.NEEDREX);
                break;

                case K.NEED_MEMDISP:
                    dst = dst.WithValue(src.NEED_MEMDISP);
                break;

                case K.NEED_SIB:
                    dst = dst.WithValue(src.NEED_SIB);
                break;

                case K.NELEM:
                    dst = dst.WithValue(src.NELEM);
                break;

                case K.NOMINAL_OPCODE:
                    dst = dst.WithValue(src.NOMINAL_OPCODE);
                break;

                case K.NOREX:
                    dst = dst.WithValue(src.NOREX);
                break;

                case K.NO_SCALE_DISP8:
                    dst = dst.WithValue(src.NO_SCALE_DISP8);
                break;

                case K.NPREFIXES:
                    dst = dst.WithValue(src.NPREFIXES);
                break;

                case K.NREXES:
                    dst = dst.WithValue(src.NREXES);
                break;

                case K.NSEG_PREFIXES:
                    dst = dst.WithValue(src.NSEG_PREFIXES);
                break;

                case K.OSZ:
                    dst = dst.WithValue(src.OSZ);
                break;

                case K.OUT_OF_BYTES:
                    dst = dst.WithValue(src.OUT_OF_BYTES);
                break;

                case K.P4:
                    dst = dst.WithValue(src.P4);
                break;

                case K.POS_DISP:
                    dst = dst.WithValue(src.POS_DISP);
                break;

                case K.POS_IMM:
                    dst = dst.WithValue(src.POS_IMM);
                break;

                case K.POS_IMM1:
                    dst = dst.WithValue(src.POS_IMM1);
                break;

                case K.POS_MODRM:
                    dst = dst.WithValue(src.POS_MODRM);
                break;

                case K.POS_NOMINAL_OPCODE:
                    dst = dst.WithValue(src.POS_NOMINAL_OPCODE);
                break;

                case K.POS_SIB:
                    dst = dst.WithValue(src.POS_SIB);
                break;

                case K.PREFIX66:
                    dst = dst.WithValue(src.PREFIX66);
                break;

                case K.PTR:
                    dst = dst.WithValue(src.PTR);
                break;

                case K.REALMODE:
                    dst = dst.WithValue(src.REALMODE);
                break;

                case K.OUTREG:
                    dst = dst.WithValue(src.OUTREG);
                break;

                case K.REG0:
                    dst = dst.WithValue(src.REG0);
                break;

                case K.REG1:
                    dst = dst.WithValue(src.REG1);
                break;

                case K.REG2:
                    dst = dst.WithValue(src.REG2);
                break;

                case K.REG3:
                    dst = dst.WithValue(src.REG3);
                break;

                case K.REG4:
                    dst = dst.WithValue(src.REG4);
                break;

                case K.REG5:
                    dst = dst.WithValue(src.REG5);
                break;

                case K.REG6:
                    dst = dst.WithValue(src.REG6);
                break;

                case K.REG7:
                    dst = dst.WithValue(src.REG7);
                break;

                case K.REG8:
                    dst = dst.WithValue(src.REG8);
                break;

                case K.REG9:
                    dst = dst.WithValue(src.REG9);
                break;

                case K.REP:
                    dst = dst.WithValue(src.REP);
                break;

                case K.REX:
                    dst = dst.WithValue(src.REX);
                break;

                case K.REXB:
                    dst = dst.WithValue(src.REXB);
                break;

                case K.REXR:
                    dst = dst.WithValue(src.REXR);
                break;

                case K.REXRR:
                    dst = dst.WithValue(src.REXRR);
                break;

                case K.REXW:
                    dst = dst.WithValue(src.REXW);
                break;

                case K.REXX:
                    dst = dst.WithValue(src.REXX);
                break;

                case K.RM:
                    dst = dst.WithValue(src.RM);
                break;

                case K.ROUNDC:
                    dst = dst.WithValue(src.ROUNDC);
                break;

                case K.SAE:
                    dst = dst.WithValue(src.SAE);
                break;

                case K.SCALE:
                    dst = dst.WithValue(src.SCALE);
                break;

                case K.SEG0:
                    dst = dst.WithValue(src.SEG0);
                break;

                case K.SEG1:
                    dst = dst.WithValue(src.SEG1);
                break;

                case K.SEG_OVD:
                    dst = dst.WithValue(src.SEG_OVD);
                break;

                case K.SIBBASE:
                    dst = dst.WithValue(src.SIBBASE);
                break;

                case K.SIBINDEX:
                    dst = dst.WithValue(src.SIBINDEX);
                break;

                case K.SIBSCALE:
                    dst = dst.WithValue(src.SIBSCALE);
                break;

                case K.SMODE:
                    dst = dst.WithValue(src.SMODE);
                    break;

                case K.SRM:
                    dst = dst.WithValue(src.SRM);
                break;

                case K.TZCNT:
                    dst = dst.WithValue(src.TZCNT);
                break;

                case K.UBIT:
                    dst = dst.WithValue(src.UBIT);
                break;

                case K.UIMM0:
                    dst = dst.WithValue(src.UIMM0);
                break;

                case K.UIMM1:
                    dst = dst.WithValue(src.UIMM1);
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    dst = dst.WithValue(src.USING_DEFAULT_SEGMENT0);
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    dst = dst.WithValue(src.USING_DEFAULT_SEGMENT1);
                break;

                case K.VEXDEST210:
                    dst = dst.WithValue(src.VEXDEST210);
                break;

                case K.VEXDEST3:
                    dst = dst.WithValue(src.VEXDEST3);
                break;

                case K.VEXDEST4:
                    dst = dst.WithValue(src.VEXDEST4);
                break;

                case K.VEXVALID:
                    dst = dst.WithValue(src.VEXVALID);
                break;

                case K.VEX_C4:
                    dst = dst.WithValue(src.VEX_C4);
                break;

                case K.VEX_PREFIX:
                    dst = dst.WithValue(src.VEX_PREFIX);
                break;

                case K.VL:
                    dst = dst.WithValue(src.VL);
                break;

                case K.WBNOINVD:
                    dst = dst.WithValue(src.WBNOINVD);
                break;

                case K.ZEROING:
                    dst = dst.WithValue(src.ZEROING);
                break;

                case K.MEM0:
                    dst = dst.WithValue(src.MEM0);
                break;

                case K.MEM1:
                    dst = dst.WithValue(src.MEM1);
                break;

                case K.AGEN:
                    dst = dst.WithValue(src.AGEN);
                break;
            }

            return dst;
        }
    }
}