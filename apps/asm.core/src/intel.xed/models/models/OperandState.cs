//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using Asm;

    using static XedModels.OperandKind;
    using static core;

    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct OperandState
        {
            public const string TableId = "xed.operand.state";

            [OperandKind(AGEN)]
            public string agen;

            [OperandKind(AMD3DNOW)]
            public bit amd3dnow;

            [OperandKind(ASZ)]
            public bit asz;

            [OperandKind(BCRC)]
            public bit bcrc;

            [OperandKind(CET)]
            public bit cet;

            [OperandKind(CLDEMOTE)]
            public bit cldemote;

            [OperandKind(DF32)]
            public bit df32;

            [OperandKind(DF64)]
            public bit df64;

            [OperandKind(DUMMY)]
            public bit dummy;

            [OperandKind(ENCODER_PREFERRED)]
            public bit encoder_preferred;

            [OperandKind(ENCODE_FORCE)]
            public bit encode_force;

            [OperandKind(HAS_SIB)]
            public bit has_sib;

            [OperandKind(ILD_F2)]
            public bit ild_f2;

            [OperandKind(ILD_F3)]
            public bit ild_f3;

            [OperandKind(IMM0, "Indicates whether a first imm operand is present")]
            public bit imm0;

            [OperandKind(IMM0SIGNED, "Indicates whether a first imm operand is signed")]
            public bit imm0signed;

            [OperandKind(IMM1, "Indicates whether a second imm operand is present")]
            public bit imm1;

            [OperandKind(LOCK)]
            public bit @lock;

            [OperandKind(LZCNT)]
            public bit lzcnt;

            [OperandKind(MEM0)]
            public string mem0;

            [OperandKind(MEM1)]
            public string mem1;

            [OperandKind(MODEP5)]
            public bit modep5;

            [OperandKind(MODEP55C)]
            public bit modep55c;

            [OperandKind(MODE_FIRST_PREFIX)]
            public bit mode_first_prefix;

            public bit mode_short_ud0;

            [OperandKind(MPXMODE)]
            public bit mpxmode;

            [OperandKind(MUST_USE_EVEX)]
            public bit must_use_evex;

            [OperandKind(NEEDREX)]
            public bit needrex;

            [OperandKind(NEED_SIB)]
            public bit need_sib;

            [OperandKind(NOREX)]
            public bit norex;

            [OperandKind(NO_SCALE_DISP8)]
            public bit no_scale_disp8;

            [OperandKind(OSZ)]
            public bit osz;

            [OperandKind(OUT_OF_BYTES)]
            public bit out_of_bytes;

            [OperandKind(P4)]
            public bit p4;

            [OperandKind(PREFIX66)]
            public bit prefix66;

            [OperandKind(PTR)]
            public bit ptr;

            [OperandKind(REALMODE)]
            public bit realmode;

            [OperandKind(RELBR)]
            public bit relbr;

            [OperandKind(REX)]
            public bit rex;

            [OperandKind(REXB)]
            public bit rexb;

            [OperandKind(REXR)]
            public bit rexr;

            [OperandKind(REXRR)]
            public bit rexrr;

            [OperandKind(REXW)]
            public bit rexw;

            [OperandKind(REXX)]
            public bit rexx;

            [OperandKind(SAE)]
            public bit sae;

            [OperandKind(TZCNT)]
            public bit tzcnt;

            [OperandKind(UBIT)]
            public bit ubit;

            [OperandKind(USING_DEFAULT_SEGMENT0)]
            public bit using_default_segment0;

            [OperandKind(USING_DEFAULT_SEGMENT1)]
            public bit using_default_segment1;

            [OperandKind(VEXDEST3)]
            public bit vexdest3;

            [OperandKind(VEXDEST4)]
            public bit vexdest4;

            [OperandKind(VEX_C4)]
            public bit vex_c4;

            [OperandKind(WBNOINVD)]
            public bit wbnoinvd;

            [OperandKind(ZEROING)]
            public bit zeroing;

            [OperandKind(DEFAULT_SEG)]
            public uint2 default_seg;

            [OperandKind(OperandKind.EASZ)]
            public EASZ easz;

            [OperandKind(OperandKind.EOSZ)]
            public EOSZ eosz;

            [OperandKind(FIRST_F2F3)]
            public uint2 first_f2f3;

            [OperandKind(HAS_MODRM, "Indicates whether a modrm byte is specified")]
            public bit has_modrm;

            [OperandKind(LAST_F2F3)]
            public uint2 last_f2f3;

            [OperandKind(LLRC)]
            public uint2 llrc;

            [OperandKind(MOD)]
            public uint2 mod;

            [OperandKind(MODE)]
            public Mode mode;

            [OperandKind(REP)]
            public uint2 rep;

            [OperandKind(SIBSCALE)]
            public uint2 sibscale;

            [OperandKind(SMODE)]
            public SMode smode;

            [OperandKind(VEX_PREFIX)]
            public uint2 vex_prefix;

            [OperandKind(VL)]
            public uint2 vl;

            [OperandKind(HINT)]
            public HintKind hint;

            [OperandKind(MASK)]
            public uint3 mask;

            [OperandKind(REG)]
            public uint3 reg;

            [OperandKind(RM)]
            public uint3 rm;

            [OperandKind(ROUNDC)]
            public uint3 roundc;

            [OperandKind(SEG_OVD)]
            public uint3 seg_ovd;

            [OperandKind(SIBBASE)]
            public uint3 sibbase;

            [OperandKind(SIBINDEX)]
            public uint3 sibindex;

            [OperandKind(SRM)]
            public uint3 srm;

            [OperandKind(VEXDEST210)]
            public uint3 vexdest210;

            [OperandKind(VEXVALID)]
            public VexValidityKind vexvalid;

            [OperandKind(ERROR)]
            public ErrorKind error;

            [OperandKind(ESRC)]
            public uint4 esrc;

            [OperandKind(MAP)]
            public byte map;

            [OperandKind(NELEM)]
            public uint4 nelem;

            [OperandKind(SCALE)]
            public uint4 scale;

            [OperandKind(BCAST)]
            public uint5 bcast;

            [OperandKind(NEED_MEMDISP)]
            public byte need_memdisp;

            [OperandKind(CHIP)]
            public ChipCode chip;

            [OperandKind(BRDISP_WIDTH)]
            public byte brdisp_width;

            [OperandKind(DISP_WIDTH)]
            public byte disp_width;

            [OperandKind(ILD_SEG)]
            public byte ild_seg;

            [OperandKind(IMM1_BYTES)]
            public byte imm1_bytes;

            [OperandKind(OperandKind.IMM_WIDTH)]
            public byte imm_width;

            [OperandKind(OperandKind.MAX_BYTES)]
            public byte max_bytes;

            [OperandKind(MODRM_BYTE)]
            public Hex8 modrm_byte;

            [OperandKind(NOMINAL_OPCODE)]
            public Hex8 nominal_opcode;

            [OperandKind(NPREFIXES)]
            public byte nprefixes;

            [OperandKind(NREXES)]
            public byte nrexes;

            [OperandKind(NSEG_PREFIXES)]
            public byte nseg_prefixes;

            [OperandKind(POS_DISP)]
            public byte pos_disp;

            [OperandKind(POS_IMM)]
            public byte pos_imm;

            [OperandKind(POS_IMM1)]
            public byte pos_imm1;

            [OperandKind(POS_MODRM)]
            public byte pos_modrm;

            [OperandKind(POS_NOMINAL_OPCODE)]
            public byte pos_nominal_opcode;

            [OperandKind(POS_SIB)]
            public byte pos_sib;

            [OperandKind(UIMM1)]
            public imm8 uimm1;

            [OperandKind(BASE0)]
            public Register base0;

            [OperandKind(BASE1)]
            public Register base1;

            [OperandKind(ELEMENT_SIZE)]
            public ushort element_size;

            [OperandKind(INDEX)]
            public Register index;

            [OperandKind(OUTREG)]
            public Register outreg;

            [OperandKind(REG0)]
            public Register reg0;

            [OperandKind(REG1)]
            public Register reg1;

            [OperandKind(REG2)]
            public Register reg2;

            [OperandKind(REG3)]
            public Register reg3;

            [OperandKind(REG4)]
            public Register reg4;

            [OperandKind(REG5)]
            public Register reg5;

            [OperandKind(REG6)]
            public Register reg6;

            [OperandKind(REG7)]
            public Register reg7;

            [OperandKind(REG8)]
            public Register reg8;

            [OperandKind(REG9)]
            public Register reg9;

            [OperandKind(SEG0)]
            public Register seg0;

            [OperandKind(SEG1)]
            public Register seg1;

            [OperandKind(ICLASS)]
            public IClass iclass;

            [OperandKind(MEM_WIDTH)]
            public ushort mem_width;

            [OperandKind(DISP)]
            public Disp64 disp;

            [OperandKind(UIMM0)]
            public imm64 uimm0;

            public static OperandState Empty => default;

            public ConstLookup<OperandKind,object> ToLookup()
            {
                var dst = dict<OperandKind,object>();
                var fields = typeof(OperandState).DeclaredInstanceFields().Tagged<OperandKindAttribute>();
                var count = fields.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref skip(fields,i);
                    var kind = field.Tag<OperandKindAttribute>().Require().Kind;
                    var result = dst.TryAdd(kind, field.GetValue(this));
                    if(!result)
                        Errors.Throw(string.Format("Duplicate kind {0} for {1}", kind, field.Name));

                }
                return dst;
            }
        }
    }
}