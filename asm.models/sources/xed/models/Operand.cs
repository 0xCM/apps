//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct XedModels
    {
        /// <summary>
        /// Defines the content of an Xed operand; adapted from 'xed-operand-storage.h'
        /// </summary>

        [StructLayout(LayoutKind.Sequential)]
        public struct Operand
        {
            public byte agen;

            public byte amd3dnow;

            public byte asz;

            public byte bcrc;

            public byte cet;

            public byte cldemote;

            public byte df32;

            public byte df64;

            public byte dummy;

            public byte encoder_preferred;

            public byte encode_force;

            public byte has_sib;

            public byte ild_f2;

            public byte ild_f3;

            public byte imm0;

            public byte imm0signed;

            public byte imm1;

            public byte @lock;

            public byte lzcnt;

            public byte mem0;

            public byte mem1;

            public byte modep5;

            public byte modep55c;

            public byte mode_first_prefix;

            public byte mpxmode;

            public byte must_use_evex;

            public byte needrex;

            public byte need_sib;

            public byte norex;

            public byte no_scale_disp8;

            public byte osz;

            public byte out_of_bytes;

            public byte p4;

            public byte prefix66;

            public byte ptr;

            public byte realmode;

            public byte relbr;

            public byte rex;

            public byte rexb;

            public byte rexr;

            public byte rexrr;

            public byte rexw;

            public byte rexx;

            public byte sae;

            public byte tzcnt;

            public byte ubit;

            public byte using_default_segment0;

            public byte using_default_segment1;

            public byte vexdest3;

            public byte vexdest4;

            public byte vex_c4;

            public byte wbnoinvd;

            public byte zeroing;

            public byte default_seg;

            /// <summary>
            /// Effective address width id
            /// </summary>
            public EASZ easz;

            /// <summary>
            /// Effective operand width id
            /// </summary>
            public EOSZ eosz;

            public byte first_f2f3;

            public byte has_modrm;

            public byte last_f2f3;

            public byte llrc;

            public byte mod;

            public byte mode;

            public byte rep;

            public byte sibscale;

            public byte smode;

            public byte vex_prefix;

            public byte vl;

            public byte hint;

            public byte mask;

            public byte reg;

            public byte rm;

            public byte roundc;

            public byte seg_ovd;

            public byte sibbase;

            public byte sibindex;

            public byte srm;

            public byte vexdest210;

            public byte vexvalid;

            public byte error;

            public byte esrc;

            public byte map;

            public byte nelem;

            public byte scale;

            public byte bcast;

            public byte need_memdisp;

            public byte chip;

            public byte brdisp_width;

            public byte disp_width;

            public byte ild_seg;

            public byte imm1_bytes;

            public byte imm_width;

            public byte max_bytes;

            public byte modrm_byte;

            public byte nominal_opcode;

            public byte nprefixes;

            public byte nrexes;

            public byte nseg_prefixes;

            public byte pos_disp;

            public byte pos_imm;

            public byte pos_imm1;

            public byte pos_modrm;

            public byte pos_nominal_opcode;

            public byte pos_sib;

            public byte uimm1;

            public ushort base0;

            public ushort base1;

            public ushort element_size;

            public ushort index;

            public ushort outreg;

            public ushort reg0;

            public ushort reg1;

            public ushort reg2;

            public ushort reg3;

            public ushort reg4;

            public ushort reg5;

            public ushort reg6;

            public ushort reg7;

            public ushort reg8;

            public ushort reg9;

            public ushort seg0;

            public ushort seg1;

            public IClass iclass;

            public ushort mem_width;

            public ulong disp;

            public ulong uimm0;
        }
    }
}