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

    partial class XedRules
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleState
        {
            public const string TableId = "xed.rules.state";

            [RuleField(K.AMD3DNOW, 1)]
            public bit AMD3DNOW;

            [RuleField(K.ASZ, 1)]
            public bit ASZ;

            [RuleField(K.BCRC, 1)]
            public bit BCRC;

            [RuleField(K.CET, 1)]
            public bit CET;

            [RuleField(K.CLDEMOTE, 1)]
            public bit CLDEMOTE;

            [RuleField(K.DF32, 1)]
            public bit DF32;

            [RuleField(K.DF64, 1)]
            public bit DF64;

            [RuleField(K.DUMMY, 1)]
            public bit DUMMY;

            [RuleField(K.ENCODER_PREFERRED, 1)]
            public bit ENCODER_PREFERRED;

            [RuleField(K.ENCODE_FORCE, 1)]
            public bit ENCODE_FORCE;

            [RuleField(K.HAS_MODRM, 1)]
            public bit HAS_MODRM;

            [RuleField(K.HAS_SIB, 1)]
            public bit HAS_SIB;

            [RuleField(K.IMM0, 1)]
            public bit IMM0;

            [RuleField(K.IMM0SIGNED, 1)]
            public bit IMM0SIGNED;

            [RuleField(K.IMM1, 1)]
            public bit IMM1;

            [RuleField(K.LOCK, 1)]
            public bit LOCK;

            [RuleField(K.LZCNT, 1)]
            public bit LZCNT;

            [RuleField(K.TZCNT, 1)]
            public bit TZCNT;

            [RuleField(K.MODEP5, 1)]
            public bit MODEP5;

            [RuleField(K.MODEP55C, 1)]
            public bit MODEP55C;

            [RuleField(K.MODE_FIRST_PREFIX, 1)]
            public bit MODE_FIRST_PREFIX;

            [RuleField(K.MODE_SHORT_UD0, 1)]
            public bit MODE_SHORT_UD0;

            [RuleField(K.MPXMODE, 1)]
            public bit MPXMODE;

            [RuleField(K.MUST_USE_EVEX, 1)]
            public bit MUST_USE_EVEX;

            [RuleField(K.NEEDREX, 1)]
            public bit NEEDREX;

            [RuleField(K.NEED_SIB, 1)]
            public bit NEED_SIB;

            [RuleField(K.NOREX, 1)]
            public bit NOREX;

            [RuleField(K.NO_SCALE_DISP8, 1)]
            public bit NO_SCALE_DISP8;

            [RuleField(K.OSZ, 1)]
            public bit OSZ;

            [RuleField(K.OUT_OF_BYTES, 1)]
            public bit OUT_OF_BYTES;

            [RuleField(K.P4, 1)]
            public bit P4;

            [RuleField(K.PREFIX66, 1)]
            public bit PREFIX66;

            [RuleField(K.PTR, 1)]
            public bit PTR;

            [RuleField(K.REALMODE, 1)]
            public bit REALMODE;

            [RuleField(K.REX, 1)]
            public bit REX;

            [RuleField(K.REXB, 1)]
            public bit REXB;

            [RuleField(K.REXR, 1)]
            public bit REXR;

            [RuleField(K.REXRR, 1)]
            public bit REXRR;

            [RuleField(K.REXW, 1)]
            public bit REXW;

            [RuleField(K.REXX, 1)]
            public bit REXX;

            [RuleField(K.SAE, 1)]
            public bit SAE;

            [RuleField(K.UBIT, 1)]
            public bit UBIT;

            [RuleField(K.WBNOINVD, 1)]
            public bit WBNOINVD;

            [RuleField(K.ZEROING, 1)]
            public bit ZEROING;

            [RuleField(K.ILD_F2, 1)]
            public bit ILD_F2;

            [RuleField(K.ILD_F3, 1)]
            public bit ILD_F3;

            [RuleField(K.NEED_MEMDISP, 1)]
            public bit NEED_MEMDISP;

            [RuleField(K.NO_RETURN, 1)]
            public bit NO_RETURN;

            [RuleField(K.AGEN, 1)]
            public bit AGEN;

            [RuleField(K.MEM0, 1)]
            public bit MEM0;

            [RuleField(K.MEM1, 1)]
            public bit MEM1;

            [RuleField(K.USING_DEFAULT_SEGMENT0, 1)]
            public bit USING_DEFAULT_SEGMENT0;

            [RuleField(K.USING_DEFAULT_SEGMENT1, 1)]
            public bit USING_DEFAULT_SEGMENT1;

            [RuleField(K.VEXDEST3, 1)]
            public bit VEXDEST3;

            [RuleField(K.VEXDEST4, 1)]
            public bit VEXDEST4;

            [RuleField(K.VEX_C4, 1)]
            public bit VEX_C4;

            [RuleField(K.RELBR, 1)]
            public bit RELBR;

            [RuleField(K.IMM_WIDTH, 3)]
            public byte IMM_WIDTH;

            [RuleField(K.IMM1_BYTES, 3)]
            public byte IMM1_BYTES;

            [RuleField(K.VEX_PREFIX, 2)]
            public byte VEX_PREFIX;

            [RuleField(K.VL, 3)]
            public byte VL;

            [RuleField(K.DEFAULT_SEG, 2)]
            public byte DEFAULT_SEG;

            [RuleField(K.EASZ, 3)]
            public byte EASZ;

            [RuleField(K.EOSZ, 3)]
            public byte EOSZ;

            [RuleField(K.FIRST_F2F3, 2)]
            public byte FIRST_F2F3;

            [RuleField(K.LAST_F2F3, 2)]
            public byte LAST_F2F3;

            [RuleField(K.LLRC, 2)]
            public byte LLRC;

            [RuleField(K.MOD, 2)]
            public byte MOD;

            [RuleField(K.REG, 3)]
            public byte REG;

            [RuleField(K.RM, 3)]
            public byte RM;

            [RuleField(K.MODE, 2)]
            public byte MODE;

            [RuleField(K.REP, 2)]
            public byte REP;

            [RuleField(K.SIBSCALE, 2)]
            public byte SIBSCALE;

            [RuleField(K.SMODE, 2)]
            public byte SMODE;

            [RuleField(K.HINT, 3)]
            public byte HINT;

            [RuleField(K.MASK, 3)]
            public byte MASK;

            [RuleField(K.ROUNDC, 3)]
            public byte ROUNDC;

            [RuleField(K.SEG_OVD, 3)]
            public byte SEG_OVD;

            [RuleField(K.SIBBASE, 3)]
            public byte SIBBASE;

            [RuleField(K.SIBINDEX, 3)]
            public byte SIBINDEX;

            [RuleField(K.SRM, 3)]
            public byte SRM;

            [RuleField(K.VEXDEST210, 3)]
            public byte VEXDEST210;

            [RuleField(K.VEXVALID, 3)]
            public byte VEXVALID;

            [RuleField(K.ESRC, 4)]
            public uint4 ESRC;

            [RuleField(K.MAP, 4)]
            public byte MAP;

            [RuleField(K.NELEM, 4)]
            public byte NELEM;

            [RuleField(K.BRDISP_WIDTH, 8)]
            public byte BRDISP_WIDTH;

            [RuleField(K.DISP_WIDTH, 8)]
            public byte DISP_WIDTH;

            [RuleField(K.ILD_SEG, 8)]
            public byte ILD_SEG;

            [RuleField(FieldKind.MAX_BYTES, 4)]
            public byte MAX_BYTES;

            [RuleField(K.MODRM_BYTE, 8)]
            public Hex8 MODRM_BYTE;

            [RuleField(K.NOMINAL_OPCODE, 8)]
            public Hex8 NOMINAL_OPCODE;

            [RuleField(K.NPREFIXES, 3)]
            public byte NPREFIXES;

            [RuleField(K.NREXES, 3)]
            public byte NREXES;

            [RuleField(K.NSEG_PREFIXES, 3)]
            public byte NSEG_PREFIXES;

            [RuleField(K.POS_DISP, 4)]
            public byte POS_DISP;

            [RuleField(K.POS_IMM, 4)]
            public byte POS_IMM;

            [RuleField(K.POS_IMM1, 4)]
            public byte POS_IMM1;

            [RuleField(K.POS_MODRM, 4)]
            public byte POS_MODRM;

            [RuleField(K.POS_NOMINAL_OPCODE, 4)]
            public byte POS_NOMINAL_OPCODE;

            [RuleField(K.POS_SIB, 4)]
            public byte POS_SIB;

            [RuleField(K.ELEMENT_SIZE, 9)]
            public ushort ELEMENT_SIZE;

            [RuleField(K.MEM_WIDTH, 16)]
            public ushort MEM_WIDTH;

            [RuleField(K.SCALE, 4)]
            public byte SCALE;

            [RuleField(K.IMM0, 64)]
            public imm64 UIMM0;

            [RuleField(K.UIMM1, 8)]
            public imm8 UIMM1;

            [RuleField(K.ICLASS, 16)]
            public IClass ICLASS;

            [RuleField(K.CHIP, 8)]
            public ChipCode CHIP;

            [RuleField(K.BCAST,5)]
            public BCastKind BCAST;

            [RuleField(K.BASE0, 9)]
            public XedRegId BASE0;

            [RuleField(K.BASE1, 9)]
            public XedRegId BASE1;

            [RuleField(K.INDEX, 9)]
            public XedRegId INDEX;

            [RuleField(K.OUTREG, 9)]
            public XedRegId OUTREG;

            [RuleField(K.REG0, 9)]
            public XedRegId REG0;

            [RuleField(K.REG1, 9)]
            public XedRegId REG1;

            [RuleField(K.REG2, 9)]
            public XedRegId REG2;

            [RuleField(K.REG3, 9)]
            public XedRegId REG3;

            [RuleField(K.REG4, 9)]
            public XedRegId REG4;

            [RuleField(K.REG5, 9)]
            public XedRegId REG5;

            [RuleField(K.REG6, 9)]
            public XedRegId REG6;

            [RuleField(K.REG7, 9)]
            public XedRegId REG7;

            [RuleField(K.REG8, 9)]
            public XedRegId REG8;

            [RuleField(K.REG9, 9)]
            public XedRegId REG9;

            [RuleField(K.SEG0, 9)]
            public XedRegId SEG0;

            [RuleField(K.SEG1, 9)]
            public XedRegId SEG1;

            [RuleField(K.ERROR, 1)]
            public ErrorKind ERROR;

            [RuleField(K.DISP, 64)]
            public Disp64 DISP;

            public Disp RELBRVal;

            public text31 AGENVal;

            public text31 MEM0Val;

            public text31 MEM1Val;

            public static RuleState Empty => default;
        }
    }
}