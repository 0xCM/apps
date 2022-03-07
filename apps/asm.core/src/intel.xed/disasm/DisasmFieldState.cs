//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.FieldKind;

    using static XedRules;
    using static XedModels;

    partial class XedDisasmSvc
    {
        // NOP NOP_MEMv_GPRv_0F1F DISP_WIDTH:32, EASZ:3, EOSZ:1, HAS_MODRM:1, HAS_SIB, HINT:1, LZCNT, MAP:1, MAX_BYTES:15, MEM0:ptr [RAX+RAX*1], MOD:2, MODE:2, MODRM_BYTE:132, NEED_MEMDISP:32, NOMINAL_OPCODE:31, NPREFIXES:3, NSEG_PREFIXES:1, OSZ, OUTREG:AX, P4, POS_DISP:7, POS_MODRM:5, POS_NOMINAL_OPCODE:4, POS_SIB:6, PREFIX66, REG0:AX, RM:4, SMODE:2, SRM:7, TZCNT, USING_DEFAULT_SEGMENT0
        // VMOVAPD VMOVAPD_YMMqq_MEMqq EASZ:3, EOSZ:2, HAS_MODRM:1, LZCNT, MAP:1, MAX_BYTES:15, MEM0:ptr [RCX], MODE:2, MODRM_BYTE:1, NOMINAL_OPCODE:40, OUTREG:YMM0, P4, POS_MODRM:3, POS_NOMINAL_OPCODE:2, REG0:YMM0, RM:1, SMODE:2, TZCNT, USING_DEFAULT_SEGMENT0, VEXDEST210:7, VEXDEST3, VEXVALID:1, VEX_PREFIX:1, VL:1
        // VPMOVM2Q VPMOVM2Q_YMMu64_MASKmskw_AVX512 EASZ:3, EOSZ:3, HAS_MODRM:1, LLRC:1, LZCNT, MAP:2, MAX_BYTES:15, MOD:3, MODE:2, MODRM_BYTE:192, NOMINAL_OPCODE:56, OUTREG:K0, P4, POS_MODRM:5, POS_NOMINAL_OPCODE:4, REG0:YMM0, REG1:K0, REXW, SMODE:2, TZCNT, UBIT, VEXDEST210:7, VEXDEST3, VEXVALID:2, VEX_PREFIX:3, VL:1
        // RET_NEAR RET_NEAR DF64, EASZ:3, EOSZ:3, LZCNT, MAX_BYTES:15, MEM0:ptr [RSP], MODE:2, NOMINAL_OPCODE:195, P4, REG0:STACKPOP, REG1:RIP, SMODE:2, SRM:3, TZCNT, USING_DEFAULT_SEGMENT0

        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct DisasmFieldState
        {
            [RuleField(K.HAS_MODRM, 1)]
            public bit HAS_MODRM;

            [RuleField(K.HAS_SIB, 1)]
            public bit HAS_SIB;

            [RuleField(K.LZCNT, 1)]
            public bit LZCNT;

            [RuleField(K.TZCNT, 1)]
            public bit TZCNT;

            [RuleField(K.IMM0, 1)]
            public bit IMM0;

            [RuleField(K.IMM0SIGNED, 1)]
            public bit IMM0SIGNED;

            [RuleField(K.IMM1, 1)]
            public bit IMM1;

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

            [RuleField(K.NPREFIXES, 3)]
            public byte NPREFIXES;

            [RuleField(K.NREXES, 3)]
            public byte NREXES;

            [RuleField(K.NSEG_PREFIXES, 3)]
            public byte NSEG_PREFIXES;

            [RuleField(K.MODE, 2)]
            public byte MODE;

            [RuleField(K.SRM, 3)]
            public byte SRM;

            [RuleField(K.IMM_WIDTH, 3)]
            public byte IMM_WIDTH;

            [RuleField(K.IMM1_BYTES, 3)]
            public byte IMM1_BYTES;

            [RuleField(FieldKind.MAX_BYTES, 4)]
            public byte MAX_BYTES;

            [RuleField(K.ELEMENT_SIZE, 9)]
            public ushort ELEMENT_SIZE;

            [RuleField(K.MEM_WIDTH, 16)]
            public ushort MEM_WIDTH;

            [RuleField(K.EASZ, 3)]
            public byte EASZ;

            [RuleField(K.EOSZ, 3)]
            public byte EOSZ;

            [RuleField(K.SMODE, 2)]
            public byte SMODE;

            [RuleField(K.MAP, 4)]
            public byte MAP;

            [RuleField(K.MODRM_BYTE, 8)]
            public byte MODRM_BYTE;

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

            [RuleField(K.MOD, 2)]
            public byte MOD;

            [RuleField(K.REG, 3)]
            public byte REG;

            [RuleField(K.RM, 3)]
            public byte RM;

            [RuleField(K.SIBSCALE, 2)]
            public byte SIBSCALE;

            [RuleField(K.SIBINDEX, 3)]
            public byte SIBINDEX;

            [RuleField(K.SIBBASE, 3)]
            public byte SIBBASE;

            [RuleField(K.MASK, 3)]
            public byte MASK;

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

            [RuleField(K.ICLASS, 16)]
            public IClass ICLASS;
        }
    }
}