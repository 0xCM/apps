//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using Asm;

    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct OperandState
        {
            public const string TableId = "xed.operand.state";

            public bit agen;

            public bit amd3dnow;

            public bit asz;

            public bit bcrc;

            public bit cet;

            public bit cldemote;

            public bit df32;

            public bit df64;

            public bit dummy;

            public bit encoder_preferred;

            public bit encode_force;

            public bit has_sib;

            public bit ild_f2;

            public bit ild_f3;

            public bit imm0;

            public bit imm0signed;

            public bit imm1;

            public bit @lock;

            public bit lzcnt;

            public bit mem0;

            public bit mem1;

            public bit modep5;

            public bit modep55c;

            public bit mode_first_prefix;

            public bit mode_short_ud0;

            public bit mpxmode;

            public bit must_use_evex;

            public bit needrex;

            public bit need_sib;

            public bit norex;

            public bit no_scale_disp8;

            public bit osz;

            public bit out_of_bytes;

            public bit p4;

            public bit prefix66;

            public bit ptr;

            public bit realmode;

            public bit relbr;

            public bit rex;

            public bit rexb;

            public bit rexr;

            public bit rexrr;

            public bit rexw;

            public bit rexx;

            public bit sae;

            public bit tzcnt;

            public bit ubit;

            public bit using_default_segment0;

            public bit using_default_segment1;

            public bit vexdest3;

            public bit vexdest4;

            public bit vex_c4;

            public bit wbnoinvd;

            public bit zeroing;

            public uint2 default_seg;

            public EASZ easz;

            public EOSZ eosz;

            public uint2 first_f2f3;

            public uint2 has_modrm;

            public uint2 last_f2f3;

            public uint2 llrc;

            [Field("MOD")]
            public uint3 mod;

            [Field("MODE",2)]
            public Mode mode;

            public uint2 rep;

            [Field("SIBSCALE")]
            public uint2 sibscale;

            public uint2 smode;

            public uint2 vex_prefix;

            public uint2 vl;

            public HintKind hint;

            public uint3 mask;

            public uint3 reg;

            public uint3 rm;

            public uint3 roundc;

            public uint3 seg_ovd;

            public uint3 sibbase;

            public uint3 sibindex;

            public uint3 srm;

            public uint3 vexdest210;

            public uint3 vexvalid;

            public ErrorKind error;

            public uint4 esrc;

            public OpCodeMap map;

            public uint4 nelem;

            [Field("SCALE")]
            public uint4 scale;

            public uint5 bcast;

            [Field("NEED_MEMDISP")]
            public bit need_memdisp;

            public ChipCode chip;

            public byte brdisp_width;

            [Field("DISP_WIDTH")]
            public byte disp_width;

            public byte ild_seg;

            public byte imm1_bytes;

            public byte imm_width;

            public byte max_bytes;

            public byte modrm_byte;

            public OpCode nominal_opcode;

            public byte nprefixes;

            public byte nrexes;

            public byte nseg_prefixes;

            public byte pos_disp;

            public byte pos_imm;

            public byte pos_imm1;

            public byte pos_modrm;

            public byte pos_nominal_opcode;

            public byte pos_sib;

            public imm8 uimm1;

            [Field("BASE0")]
            public Register base0;

            public Register base1;

            public ushort element_size;

            public Register index;

            public Register outreg;

            public Register reg0;

            public Register reg1;

            public Register reg2;

            public Register reg3;

            public Register reg4;

            public Register reg5;

            public Register reg6;

            public Register reg7;

            public Register reg8;

            public Register reg9;

            public Register seg0;

            public Register seg1;

            public IClass iclass;

            public ushort mem_width;

            public Disp64 disp;

            public imm64 uimm0;
        }
    }
}