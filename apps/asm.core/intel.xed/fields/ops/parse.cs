//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;

    using K = XedRules.FieldKind;
    using R = XedRules;

    partial class XedFields
    {
        [Op]
        public static bool parse2(string src, FieldKind kind, out R.FieldValue dst)
        {
            var result = true;
            dst = R.FieldValue.Empty;
            switch(kind)
            {
                case K.AMD3DNOW:
                case K.DUMMY:
                case K.ENCODE_FORCE:
                case K.ENCODER_PREFERRED:
                case K.BCRC:
                case K.RELBR:
                case K.ASZ:
                case K.CLDEMOTE:
                case K.DF32:
                case K.DF64:
                    dst = value(kind, bit.On);
                break;
                case K.BASE1:
                case K.BASE0:
                {
                    result = XedParsers.parse(src, out XedRegId x);
                    dst = value(kind, x);
                }
                break;

                case K.BCAST:
                {
                    result = XedParsers.parse(src, out BCastKind x);
                    dst = value(kind, x);
                }
                break;

                case K.DEFAULT_SEG:
                case K.BRDISP_WIDTH:
                {
                    result = XedParsers.parse(src, out byte x);
                    dst = value(kind, x);
                }
                break;

                case K.CET:
                    dst = value(kind, bit.On);
                break;

                case K.CHIP:
                {
                    result = XedParsers.parse(src, out ChipCode x);
                    dst = value(kind, x);
                }
                break;


                case K.DISP:
                {
                    result = XedParsers.parse(src, out Disp64 x);
                    dst = value(kind, x);
                }

                break;
            }

            //     case K.DISP_WIDTH:
            //         result = DataParser.parse(src, out state.DISP_WIDTH);
            //         dst = value(kind, state.DISP_WIDTH);
            //     break;

            //         state.DUMMY = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.EASZ:
            //         result = DataParser.parse(src, out state.EASZ);
            //         dst = value(kind, state.EASZ);
            //     break;

            //     case K.ELEMENT_SIZE:
            //         result = DataParser.parse(src, out state.ELEMENT_SIZE);
            //         dst = value(kind, state.ELEMENT_SIZE);
            //     break;

            //         state.ENCODER_PREFERRED = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //         state.ENCODE_FORCE = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.EOSZ:
            //         result = DataParser.parse(src, out state.EOSZ);
            //         dst = value(kind, state.EOSZ);
            //     break;

            //     case K.ESRC:
            //         result = DataParser.parse(src, out state.ESRC);
            //         dst = value(kind, state.ESRC);
            //     break;

            //     case K.FIRST_F2F3:
            //         result = DataParser.parse(src, out state.FIRST_F2F3);
            //         dst = value(kind, state.FIRST_F2F3);
            //     break;

            //     case K.HAS_MODRM:
            //         state.HAS_MODRM = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.HAS_SIB:
            //         state.HAS_SIB = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.HINT:
            //         result = DataParser.parse(src, out state.HINT);
            //         dst = value(kind, state.HINT);
            //     break;

            //     case K.ICLASS:
            //         result = DataParser.eparse(src, out state.ICLASS);
            //         dst = value(kind, state.ICLASS);
            //     break;

            //     case K.ILD_F2:
            //         state.ILD_F2 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.ILD_F3:
            //         state.ILD_F3 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.ILD_SEG:
            //         result = DataParser.parse(src, out state.ILD_SEG);
            //         dst = value(kind, state.ILD_SEG);
            //     break;

            //     case K.IMM0:
            //         state.IMM0 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.IMM0SIGNED:
            //         state.IMM0SIGNED = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.IMM1:
            //         state.IMM1 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.IMM1_BYTES:
            //         result = DataParser.parse(src, out state.IMM1_BYTES);
            //         dst = value(kind, state.IMM1_BYTES);
            //     break;

            //     case K.IMM_WIDTH:
            //         result = DataParser.parse(src, out state.IMM_WIDTH);
            //         dst = value(kind, state.IMM_WIDTH);
            //     break;

            //     case K.INDEX:
            //         result = XedParsers.parse(src, out state.INDEX);
            //         dst = value(kind, state.INDEX);
            //     break;

            //     case K.LAST_F2F3:
            //         result = DataParser.parse(src, out state.LAST_F2F3);
            //         dst = value(kind, state.LAST_F2F3);
            //     break;

            //     case K.LLRC:
            //         result = DataParser.parse(src, out state.LLRC);
            //         dst = value(kind, state.LLRC);
            //     break;

            //     case K.LOCK:
            //         state.LOCK = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.LZCNT:
            //         state.LZCNT = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.MAP:
            //         result = DataParser.parse(src, out state.MAP);
            //         dst = value(kind, state.MAP);
            //     break;

            //     case K.MASK:
            //         result = DataParser.parse(src, out state.MASK);
            //         dst = value(kind, state.MASK);
            //     break;

            //     case K.MAX_BYTES:
            //         result = DataParser.parse(src, out state.MAX_BYTES);
            //         dst = value(kind, state.MAX_BYTES);
            //     break;

            //     case K.MEM_WIDTH:
            //         result = DataParser.parse(src, out state.MEM_WIDTH);
            //         dst = value(kind, state.MEM_WIDTH);
            //     break;

            //     case K.MEM0:
            //         dst = value(kind, resolver(src));
            //     break;

            //     case K.MEM1:
            //         dst = value(kind, resolver(src));
            //     break;

            //     case K.MOD:
            //         result = DataParser.parse(src, out state.MOD);
            //         dst = value(kind, state.MOD);
            //     break;

            //     case K.REG:
            //         result = DataParser.parse(src, out state.REG);
            //         dst = value(kind, state.REG);
            //     break;

            //     case K.MODRM_BYTE:
            //         result = DataParser.parse(src, out byte modrm);
            //         state.MODRM_BYTE = modrm;
            //         dst = value(kind, state.MODRM_BYTE);
            //     break;

            //     case K.MODE:
            //         result = DataParser.parse(src, out state.MODE);
            //         dst = value(kind, state.MODE);
            //     break;

            //     case K.MODEP5:
            //         state.MODEP5 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.MODEP55C:
            //         state.MODEP55C = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.MODE_FIRST_PREFIX:
            //         state.MODE_FIRST_PREFIX = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.MPXMODE:
            //         state.MPXMODE = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.MUST_USE_EVEX:
            //         state.MUST_USE_EVEX = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.NEEDREX:
            //         state.NEEDREX = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.NEED_MEMDISP:
            //         state.NEED_MEMDISP = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.NEED_SIB:
            //         state.NEED_SIB = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.NELEM:
            //         result = DataParser.parse(src, out state.NELEM);
            //         dst = value(kind, state.NELEM);
            //     break;

            //     case K.NOMINAL_OPCODE:
            //         result = DataParser.parse(src, out byte opcode);
            //         state.NOMINAL_OPCODE = opcode;
            //         dst = value(kind, state.NOMINAL_OPCODE);
            //     break;

            //     case K.NOREX:
            //         state.NOREX = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.NO_SCALE_DISP8:
            //         state.NO_SCALE_DISP8 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.NPREFIXES:
            //         result = DataParser.parse(src, out state.NPREFIXES);
            //         dst = value(kind, state.NPREFIXES);
            //     break;

            //     case K.NREXES:
            //         result = DataParser.parse(src, out state.NREXES);
            //         dst = value(kind, state.NREXES);
            //     break;

            //     case K.NSEG_PREFIXES:
            //         result = DataParser.parse(src, out state.NSEG_PREFIXES);
            //         dst = value(kind, state.NSEG_PREFIXES);
            //     break;

            //     case K.OSZ:
            //         state.OSZ = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.OUT_OF_BYTES:
            //         state.OUT_OF_BYTES = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.P4:
            //         state.P4 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.POS_DISP:
            //         result = DataParser.parse(src, out state.POS_DISP);
            //         dst = value(kind, state.POS_DISP);
            //     break;

            //     case K.POS_IMM:
            //         result = DataParser.parse(src, out state.POS_IMM);
            //         dst = value(kind, state.POS_IMM);
            //     break;

            //     case K.POS_IMM1:
            //         result = DataParser.parse(src, out state.POS_IMM1);
            //         dst = value(kind, state.POS_IMM1);
            //     break;

            //     case K.POS_MODRM:
            //         result = DataParser.parse(src, out state.POS_MODRM);
            //         dst = value(kind, state.POS_MODRM);
            //     break;

            //     case K.POS_NOMINAL_OPCODE:
            //         result = DataParser.parse(src, out state.POS_NOMINAL_OPCODE);
            //         dst = value(kind, state.POS_NOMINAL_OPCODE);
            //     break;

            //     case K.POS_SIB:
            //         result = DataParser.parse(src, out state.POS_SIB);
            //         dst = value(kind, state.POS_SIB);
            //     break;

            //     case K.PREFIX66:
            //         state.PREFIX66 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.PTR:
            //         state.PTR = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.REALMODE:
            //         state.REALMODE = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.OUTREG:
            //         result = XedParsers.parse(src, out state.OUTREG);
            //         dst = value(kind, state.OUTREG);
            //     break;

            //     case K.REG0:
            //         result = XedParsers.parse(src, out state.REG0);
            //         dst = value(kind, state.REG0);
            //     break;

            //     case K.REG1:
            //         result = XedParsers.parse(src, out state.REG1);
            //         dst = value(kind, state.REG1);
            //     break;

            //     case K.REG2:
            //         result = XedParsers.parse(src, out state.REG2);
            //         dst = value(kind, state.REG2);
            //     break;

            //     case K.REG3:
            //         result = XedParsers.parse(src, out state.REG3);
            //         dst = value(kind, state.REG3);
            //     break;

            //     case K.REG4:
            //         result = XedParsers.parse(src, out state.REG4);
            //         dst = value(kind, state.REG4);
            //     break;

            //     case K.REG5:
            //         result = XedParsers.parse(src, out state.REG5);
            //         dst = value(kind, state.REG5);
            //     break;

            //     case K.REG6:
            //         result = XedParsers.parse(src, out state.REG6);
            //         dst = value(kind, state.REG6);
            //     break;

            //     case K.REG7:
            //         result = XedParsers.parse(src, out state.REG7);
            //         dst = value(kind, state.REG7);
            //     break;

            //     case K.REG8:
            //         result = XedParsers.parse(src, out state.REG8);
            //         dst = value(kind, state.REG8);
            //     break;

            //     case K.REG9:
            //         result = XedParsers.parse(src, out state.REG9);
            //         dst = value(kind, state.REG9);
            //     break;

            //     case K.REP:
            //         result = DataParser.parse(src, out state.REP);
            //         dst = value(kind, state.REP);
            //     break;

            //     case K.REX:
            //         state.REX = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.REXB:
            //         state.REXB = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.REXR:
            //         state.REXR = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.REXRR:
            //         state.REXRR = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.REXW:
            //         state.REXW = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.REXX:
            //         state.REXX = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.RM:
            //         result = DataParser.parse(src, out state.RM);
            //         dst = value(kind, state.RM);
            //     break;

            //     case K.ROUNDC:
            //         result = DataParser.parse(src, out state.ROUNDC);
            //         dst = value(kind, state.ROUNDC);
            //     break;

            //     case K.SAE:
            //         state.SAE = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.SCALE:
            //         result = DataParser.parse(src, out state.SCALE);
            //         dst = value(kind, state.SCALE);
            //     break;

            //     case K.SEG0:
            //         result = XedParsers.parse(src, out state.SEG0);
            //         dst = value(kind, state.SEG0);
            //     break;

            //     case K.SEG1:
            //         result = XedParsers.parse(src, out state.SEG1);
            //         dst = value(kind, state.SEG1);
            //     break;

            //     case K.SEG_OVD:
            //         result = DataParser.parse(src, out state.SEG_OVD);
            //         dst = value(kind, state.SEG_OVD);
            //     break;

            //     case K.SIBBASE:
            //         result = DataParser.parse(src, out state.SIBBASE);
            //         dst = value(kind, state.SIBBASE);
            //     break;

            //     case K.SIBINDEX:
            //         result = DataParser.parse(src, out state.SIBINDEX);
            //         dst = value(kind, state.SIBINDEX);
            //     break;

            //     case K.SIBSCALE:
            //         result = DataParser.parse(src, out state.SIBSCALE);
            //         dst = value(kind, state.SIBSCALE);
            //     break;

            //     case K.SMODE:
            //         result = DataParser.parse(src, out state.SMODE);
            //         dst = value(kind, state.SMODE);
            //         break;

            //     case K.SRM:
            //         result = DataParser.parse(src, out state.SRM);
            //         dst = value(kind, state.SRM);
            //     break;

            //     case K.TZCNT:
            //         state.TZCNT = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.UBIT:
            //         state.UBIT = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.UIMM0:
            //         result = imm64.parse(src, out state.UIMM0);
            //         dst = value(kind, state.UIMM0);
            //     break;

            //     case K.UIMM1:
            //         result = imm8.parse(src, out state.UIMM1);
            //         dst = value(kind, state.UIMM1);
            //     break;

            //     case K.USING_DEFAULT_SEGMENT0:
            //         state.USING_DEFAULT_SEGMENT0 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.USING_DEFAULT_SEGMENT1:
            //         state.USING_DEFAULT_SEGMENT1 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.VEXDEST210:
            //         result = DataParser.parse(src, out state.VEXDEST210);
            //         dst = value(kind, state.VEXDEST210);
            //     break;

            //     case K.VEXDEST3:
            //         state.VEXDEST3 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.VEXDEST4:
            //         state.VEXDEST4 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.VEXVALID:
            //         result = DataParser.parse(src, out state.VEXVALID);
            //         dst = value(kind, state.VEXVALID);
            //     break;

            //     case K.VEX_C4:
            //         state.VEX_C4 = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.VEX_PREFIX:
            //         result = DataParser.parse(src, out state.VEX_PREFIX);
            //         dst = value(kind, state.VEX_PREFIX);
            //     break;

            //     case K.VL:
            //         result = DataParser.parse(src, out state.VL);
            //         dst = value(kind, state.VL);
            //     break;

            //     case K.WBNOINVD:
            //         state.WBNOINVD = bit.On;
            //         dst = value(kind, bit.On);
            //     break;

            //     case K.ZEROING:
            //         state.ZEROING = bit.On;
            //         dst = value(kind, bit.On);
            //     break;
            // }

             return result;

       }


        public static bool parse(FieldKind field, string value, out R.FieldValue dst)
        {
            var result = true;
            dst = R.FieldValue.Empty;
            switch(field)
            {
                case K.AGEN:
                case K.AMD3DNOW:
                case K.ASZ:
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
                case K.NEED_SIB:
                case K.NOREX:
                case K.NO_RETURN:
                case K.NO_SCALE_DISP8:
                case K.REX:
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
                case K.VEXDEST3:
                case K.VEXDEST4:
                case K.WBNOINVD:
                case K.REXRR:
                case K.SAE:
                case K.BCRC:
                case K.ZEROING:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new(field, b);
                        result = true;
                    }
                }
                break;

                case K.REXW:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'w')
                    {
                        dst = new (new BitfieldSeg(field, value[0], false));
                        result = true;
                    }
                }
                break;
                case K.REXR:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'r')
                    {
                        dst = new (new BitfieldSeg(field, value[0], false));
                        result = true;
                    }
                }
                break;
                case K.REXX:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'x')
                    {
                        dst = new (new BitfieldSeg(field, value[0], false));
                        result = true;
                    }
                }
                break;
                case K.REXB:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'b')
                    {
                        dst = new (new BitfieldSeg(field, value[0], false));
                        result = true;
                    }
                }
                break;

                case K.ELEMENT_SIZE:
                case K.MEM_WIDTH:
                {
                    if(ushort.TryParse(value, out ushort b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                }
                break;

                case K.SIBBASE:
                case K.HINT:
                case K.ROUNDC:
                case K.SEG_OVD:
                case K.VEXVALID:
                case K.MOD:
                case K.SIBSCALE:
                case K.EASZ:
                case K.EOSZ:
                case K.FIRST_F2F3:
                case K.LAST_F2F3:
                case K.DEFAULT_SEG:
                case K.MODE:
                case K.REP:
                case K.SMODE:
                case K.VEX_PREFIX:
                case K.VL:
                case K.LLRC:
                case K.MAP:
                case K.NELEM:
                case K.SCALE:
                case K.BRDISP_WIDTH:
                case K.DISP_WIDTH:
                case K.ILD_SEG:
                case K.IMM1_BYTES:
                case K.IMM_WIDTH:
                case K.MAX_BYTES:
                case K.MODRM_BYTE:
                case K.NPREFIXES:
                case K.NREXES:
                case K.NSEG_PREFIXES:
                case K.POS_DISP:
                case K.POS_IMM:
                case K.POS_IMM1:
                case K.POS_MODRM:
                case K.POS_NOMINAL_OPCODE:
                case K.POS_SIB:
                case K.NEED_MEMDISP:
                case K.RM:
                case K.SIBINDEX:
                case K.REG:
                case K.VEXDEST210:
                case K.MASK:
                case K.SRM:
                {
                    if(XedParsers.parse(value, out byte b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                }
                break;

                case K.ESRC:
                {
                    if(DataParser.parse(value, out Hex4 x))
                    {
                        dst = new (field,x);
                        result = true;
                    }
                }
                break;


                case K.NOMINAL_OPCODE:
                {
                    if(DataParser.parse(value, out Hex8 x))
                    {
                        dst = new (field,x);
                        result = true;
                    }
                }
                break;

                case K.DISP:
                {
                    result = byte.TryParse(value, out byte b);
                    if(result)
                        dst = new (field, b);
                    else
                    {
                        result = XedParsers.parse(value, out DispFieldSpec disp);
                        if(result)
                            dst = new (field,disp);
                    }
                }
                break;

                case K.UIMM1:
                case K.UIMM0:
                {
                    result = XedParsers.parse(value, out ImmFieldSpec imm);
                    dst = new (field,imm);
                }
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
                    if(XedParsers.reg(field, value, out dst))
                        result = true;
                }
                break;
                case K.CHIP:
                {
                    if(XedParsers.parse(value, out ChipCode x))
                    {
                        dst = new (field, (ushort)x);
                        result = true;
                    }
                }
                break;

                case K.ERROR:
                {
                    if(XedParsers.parse(value, out ErrorKind x))
                    {
                        dst = new (field, (ushort)x);
                        result = true;
                    }
                }
                break;

                case K.ICLASS:
                {
                    if(XedParsers.parse(value, out IClass x))
                    {
                        dst = new (field, (ushort)x);
                        result = true;
                    }
                }
                break;

                case K.BCAST:
                {
                    if(XedParsers.parse(value, out BCastKind kind))
                    {
                        dst = new (field, (byte)kind);
                    }
                }
                break;
            }

            return result;
        }
    }
}