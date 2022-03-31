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
    using X = XedModels;

    partial class XedRules
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleState
        {
            public const string TableId = "xed.rules.state";

            [RuleField(K.ASZ, 1, typeof(bit), "Specifies whether the 0x67 prefix is applicable")]
            public bit ASZ;

            [RuleField(K.OSZ, 1, typeof(bit), "Specifies whether the 0x66 prefix is applicable")]
            public bit OSZ;

            [RuleField(K.DF32, 1, typeof(bit))]
            public bit DF32;

            [RuleField(K.DF64, 1, typeof(X.DF64), "Specifies whether, in 64-bit mode, to default to 64 bit-width")]
            public bit DF64;

            [RuleField(K.NO_SCALE_DISP8, 1, typeof(bit))]
            public bit NO_SCALE_DISP8;

            [RuleField(K.AMD3DNOW, 1, typeof(bit))]
            public bit AMD3DNOW;

            [RuleField(K.BCRC, 1, typeof(bit))]
            public bit BCRC;

            [RuleField(K.CET, 1, typeof(bit))]
            public bit CET;

            [RuleField(K.CLDEMOTE, 1, typeof(bit))]
            public bit CLDEMOTE;

            [RuleField(K.DUMMY, 1, typeof(bit))]
            public bit DUMMY;

            [RuleField(K.ENCODER_PREFERRED, 1, typeof(bit))]
            public bit ENCODER_PREFERRED;

            [RuleField(K.ENCODE_FORCE, 1, typeof(bit))]
            public bit ENCODE_FORCE;

            [RuleField(K.IMM0, 1, typeof(bit))]
            public bit IMM0;

            [RuleField(K.IMM0SIGNED, 1, typeof(bit))]
            public bit IMM0SIGNED;

            [RuleField(K.IMM1, 1, typeof(bit))]
            public bit IMM1;

            [RuleField(K.LZCNT, 1, typeof(bit))]
            public bit LZCNT;

            [RuleField(K.TZCNT, 1, typeof(bit))]
            public bit TZCNT;

            [RuleField(K.MODEP5, 1, typeof(bit))]
            public bit MODEP5;

            [RuleField(K.MODEP55C, 1, typeof(bit))]
            public bit MODEP55C;

            [RuleField(K.MODE_FIRST_PREFIX, 1, typeof(bit))]
            public bit MODE_FIRST_PREFIX;

            [RuleField(K.MODE_SHORT_UD0, 1, typeof(bit))]
            public bit MODE_SHORT_UD0;

            [RuleField(K.MPXMODE, 1, typeof(bit))]
            public bit MPXMODE;

            [RuleField(K.OUT_OF_BYTES, 1, typeof(bit))]
            public bit OUT_OF_BYTES;

            [RuleField(K.P4, 1, typeof(bit))]
            public bit P4;

            [RuleField(K.PTR, 1, typeof(bit))]
            public bit PTR;

            [RuleField(K.AGEN, 1, typeof(bit))]
            public bit AGEN;

            [RuleField(K.MEM0, 1, typeof(bit))]
            public bit MEM0;

            [RuleField(K.MEM1, 1, typeof(bit))]
            public bit MEM1;

            [RuleField(K.LOCK, 1, typeof(bit))]
            public bit LOCK;

            [RuleField(K.PREFIX66, 1, typeof(bit))]
            public bit PREFIX66;

            [RuleField(K.HAS_MODRM, 1, typeof(bit))]
            public bit HAS_MODRM;

            [RuleField(K.HAS_SIB, 1, typeof(bit))]
            public bit HAS_SIB;

            [RuleField(K.NEED_SIB, 1, typeof(bit))]
            public bit NEED_SIB;

            [RuleField(K.NEEDREX, 1, typeof(bit))]
            public bit NEEDREX;

            [RuleField(K.NOREX, 1, typeof(bit))]
            public bit NOREX;

            [RuleField(K.REX, 1, typeof(bit))]
            public bit REX;

            [RuleField(K.VEX_C4, 1, typeof(bit))]
            public bit VEX_C4;

            [RuleField(K.MUST_USE_EVEX, 1, typeof(bit))]
            public bit MUST_USE_EVEX;

            [RuleField(K.ZEROING, 1, typeof(ZEROING), "Specifies whether zero-masking is enabled, if applicable")]
            public bit ZEROING;

            [RuleField(K.SAE, 1, typeof(bit))]
            public bit SAE;

            [RuleField(K.REALMODE, 1, typeof(bit))]
            public bit REALMODE;

            [RuleField(K.UBIT, 1, typeof(bit))]
            public bit UBIT;

            [RuleField(K.WBNOINVD, 1, typeof(bit))]
            public bit WBNOINVD;

            [RuleField(K.ILD_F2, 1, typeof(bit))]
            public bit ILD_F2;

            [RuleField(K.ILD_F3, 1, typeof(bit))]
            public bit ILD_F3;

            [RuleField(K.NEED_MEMDISP, 1, typeof(bit))]
            public bit NEED_MEMDISP;

            [RuleField(K.NO_RETURN, 1, typeof(bit))]
            public bit NO_RETURN;

            [RuleField(K.USING_DEFAULT_SEGMENT0, 1, typeof(bit))]
            public bit USING_DEFAULT_SEGMENT0;

            [RuleField(K.USING_DEFAULT_SEGMENT1, 1, typeof(bit))]
            public bit USING_DEFAULT_SEGMENT1;

            [RuleField(K.RELBR, 1, typeof(bit))]
            public bit RELBR;

            [RuleField(K.POS_NOMINAL_OPCODE, 4, typeof(byte), "Specifies the 0-based index of the NOMINAL_OPCODE field, if applicable")]
            public byte POS_NOMINAL_OPCODE;

            [RuleField(K.POS_MODRM, 4, typeof(byte), "Specifies the 0-based index of the encoded MODRM field, if applicable")]
            public byte POS_MODRM;

            [RuleField(K.POS_SIB, 4, typeof(byte), "Specifies the 0-based index of the encoded SIB field, if applicable")]
            public byte POS_SIB;

            [RuleField(K.POS_IMM, 4, typeof(byte), "Specifies the 0-based index of the encoded IMM field, if applicable")]
            public byte POS_IMM;

            [RuleField(K.POS_IMM1, 4, typeof(byte), "Specifies the 0-based index of the encoded IMM1 field, if applicable")]
            public byte POS_IMM1;

            [RuleField(K.POS_DISP, 4, typeof(byte), "Specifies the 0-based index of the encoded DISP field, if applicable")]
            public byte POS_DISP;

            [RuleField(K.MODE, 2, typeof(X.ModeKind), "Specifies one of {Mode16,Mode32,Mode64,Not64} if applicable")]
            public byte MODE;

            [RuleField(K.SMODE, 2, typeof(X.SMode), "Specifies one of {SMode16,SMode32,SMode64} if applicable")]
            public byte SMODE;

            [RuleField(K.EASZ, 3, typeof(X.EASZ), "Specifies one of {EASZ16,EASZ32,EASZ64,EASZNot16} if applicable")]
            public byte EASZ;

            [RuleField(K.EOSZ, 3, typeof(X.EOSZ), "Specifies one of {EOSZ8,EOSZ16,EOSZ32,EOSZ64,EASZNot64} if applicable")]
            public byte EOSZ;

            [RuleField(K.NOMINAL_OPCODE, 8, typeof(Hex8), "Specifies the nominal opcode value")]
            public Hex8 NOMINAL_OPCODE;

            [RuleField(K.NPREFIXES, 3, typeof(byte))]
            public byte NPREFIXES;

            [RuleField(K.NREXES, 3, typeof(byte))]
            public byte NREXES;

            [RuleField(K.NSEG_PREFIXES, 3, typeof(byte))]
            public byte NSEG_PREFIXES;

            [RuleField(K.REP, 2, typeof(X.RepPrefix), "Defines the value of the REP prefix, if any")]
            public byte REP;

            [RuleField(K.SEG_OVD, 3, typeof(X.SegPrefixKind), "Defines the value of the seg override prefix, if any")]
            public byte SEG_OVD;

            [RuleField(K.HINT, 3, typeof(X.HintKind))]
            public byte HINT;

            [RuleField(K.MOD, 2, typeof(uint2), "Specifies the value of the MOD segment of the ModRM bitfield, if applicable")]
            public byte MOD;

            [RuleField(K.REG, 3, typeof(uint3), "Specifies the value of the REG segment of the ModRM bitfield, if applicable")]
            public byte REG;

            [RuleField(K.RM, 3, typeof(uint3), "Specifies the value of the RM segment of the ModRM bitfield, if applicable")]
            public byte RM;

            [RuleField(K.MODRM_BYTE, 8, typeof(Hex8))]
            public Hex8 MODRM_BYTE;

            [RuleField(K.SIBSCALE, 2, typeof(uint2))]
            public byte SIBSCALE;

            [RuleField(K.SIBBASE, 3, typeof(uint3))]
            public byte SIBBASE;

            [RuleField(K.SIBINDEX, 3, typeof(uint3))]
            public byte SIBINDEX;

            [RuleField(K.REXW, 1, typeof(bit), "Specifies the 'W' bit of the REX prefix, if applicable")]
            public bit REXW;

            [RuleField(K.REXR, 1, typeof(bit), "Specifies the 'R' bit of the REX prefix, if applicable")]
            public bit REXR;

            [RuleField(K.REXX, 1, typeof(bit), "Specifies the 'X' bit of the REX prefix, if applicable")]
            public bit REXX;

            [RuleField(K.REXB, 1, typeof(bit), "Specifies the 'B' bit of the REX prefix, if applicable")]
            public bit REXB;

            [RuleField(K.VEXVALID, 3, typeof(X.VexClass), "Specifies one of {VV0,VV1,EVV,XOPV,KVV}, if applicable")]
            public byte VEXVALID;

            [RuleField(K.VEX_PREFIX, 2, typeof(X.VexKind), "Specifies one of {VNP,V66,VF2,VF3}, if applicable")]
            public byte VEX_PREFIX;

            [RuleField(K.VL, 3, typeof(X.VexLengthKind), "Specifies one of {V128,V256,V512}, if applicable")]
            public byte VL;

            [RuleField(K.REXRR, 1, typeof(bit))]
            public bit REXRR;

            [RuleField(K.VEXDEST4, 1, typeof(bit))]
            public bit VEXDEST4;

            [RuleField(K.VEXDEST3, 1, typeof(bit))]
            public bit VEXDEST3;

            [RuleField(K.VEXDEST210, 3, typeof(uint3))]
            public byte VEXDEST210;

            [RuleField(K.MASK, 3, typeof(MASK))]
            public byte MASK;

            [RuleField(K.ROUNDC, 3, typeof(X.ROUNDC))]
            public byte ROUNDC;

            [RuleField(K.BCAST,5, typeof(X.BCastKind))]
            public BCastKind BCAST;

            [RuleField(K.BASE0, 9, typeof(XedRegId))]
            public XedRegId BASE0;

            [RuleField(K.BASE1, 9, typeof(XedRegId))]
            public XedRegId BASE1;

            [RuleField(K.INDEX, 9, typeof(XedRegId), "Specifies an index register, if applicable")]
            public XedRegId INDEX;

            [RuleField(K.SCALE, 4, typeof(ScaleFactor), "Specifies the scaling factor applied to an index register, if applicable")]
            public byte SCALE;

            [RuleField(K.IMM_WIDTH, 3, typeof(NativeSizeCode), "Specifies the native size code of the IMM field, if applicable")]
            public byte IMM_WIDTH;

            [RuleField(K.IMM1_BYTES, 3, typeof(byte))]
            public byte IMM1_BYTES;

            [RuleField(K.DEFAULT_SEG, 2, typeof(byte))]
            public byte DEFAULT_SEG;

            [RuleField(K.FIRST_F2F3, 2, typeof(byte))]
            public byte FIRST_F2F3;

            [RuleField(K.LAST_F2F3, 2, typeof(byte))]
            public byte LAST_F2F3;

            [RuleField(K.LLRC, 2, typeof(LLRC))]
            public byte LLRC;

            [RuleField(K.SRM, 3, typeof(uint3))]
            public byte SRM;

            [RuleField(K.ESRC, 4, typeof(ESRC))]
            public byte ESRC;

            [RuleField(K.MAP, 4, typeof(byte))]
            public byte MAP;

            [RuleField(K.BRDISP_WIDTH, 8, typeof(X.BrDispWidth), "Specifies the bit-width of a branch displacement, if applicable")]
            public byte BRDISP_WIDTH;

            [RuleField(K.ILD_SEG, 8, typeof(byte))]
            public byte ILD_SEG;

            [RuleField(FieldKind.MAX_BYTES, 4, typeof(byte))]
            public byte MAX_BYTES;

            [RuleField(K.NELEM, 4, typeof(byte))]
            public byte NELEM;

            [RuleField(K.ELEMENT_SIZE, 9, typeof(ushort))]
            public ushort ELEMENT_SIZE;

            [RuleField(K.MEM_WIDTH, 16, typeof(ushort))]
            public ushort MEM_WIDTH;

            [RuleField(K.UIMM0, 64, typeof(imm64))]
            public imm64 UIMM0;

            [RuleField(K.UIMM1, 8, typeof(imm8))]
            public imm8 UIMM1;

            [RuleField(K.ICLASS, 16, typeof(IClass))]
            public IClass ICLASS;

            [RuleField(K.CHIP, 8, typeof(ChipCode))]
            public ChipCode CHIP;

            [RuleField(K.OUTREG, 9, typeof(XedRegId))]
            public XedRegId OUTREG;

            [RuleField(K.REG0, 9, typeof(XedRegId), "Specifies the value of a first register operand, if applicable")]
            public XedRegId REG0;

            [RuleField(K.REG1, 9, typeof(XedRegId), "Specifies the value of a second register operand, if applicable")]
            public XedRegId REG1;

            [RuleField(K.REG2, 9, typeof(XedRegId), "Specifies the value of a third register operand, if applicable")]
            public XedRegId REG2;

            [RuleField(K.REG3, 9, typeof(XedRegId), "Specifies the value of a fourth register operand, if applicable")]
            public XedRegId REG3;

            [RuleField(K.REG4, 9, typeof(XedRegId), "Specifies the value of a fifth register operand, if applicable")]
            public XedRegId REG4;

            [RuleField(K.REG5, 9, typeof(XedRegId), "Specifies the value of a sixth register operand, if applicable")]
            public XedRegId REG5;

            [RuleField(K.REG6, 9, typeof(XedRegId), "Specifies the value of a seventh register operand, if applicable")]
            public XedRegId REG6;

            [RuleField(K.REG7, 9, typeof(XedRegId), "Specifies the value of an eighth register operand, if applicable")]
            public XedRegId REG7;

            [RuleField(K.REG8, 9, typeof(XedRegId), "Specifies the value of a ningth register operand, if applicable")]
            public XedRegId REG8;

            [RuleField(K.REG9, 9, typeof(XedRegId), "Specifies the value of a tenth register operand, if applicable")]
            public XedRegId REG9;

            [RuleField(K.SEG0, 9, typeof(XedRegId))]
            public XedRegId SEG0;

            [RuleField(K.SEG1, 9, typeof(XedRegId))]
            public XedRegId SEG1;

            [RuleField(K.ERROR, 1, typeof(X.ErrorKind))]
            public ErrorKind ERROR;

            [RuleField(K.DISP_WIDTH, 8, typeof(byte))]
            public byte DISP_WIDTH;

            [RuleField(K.DISP, 64, typeof(Disp64))]
            public Disp64 DISP;

            public static RuleState Empty => default;
        }
    }
}