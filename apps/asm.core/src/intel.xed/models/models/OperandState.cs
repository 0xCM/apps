//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Collections.Generic;

    using Asm;

    using static XedModels.OperandKind;
    using static Asm.AsmPrefixCodes;
    using static core;

    using K = XedModels.OperandKind;

    partial struct XedModels
    {
        public class RuleOperands
        {
            readonly Dictionary<RuleOpName,RuleOperand> Data;

            public RuleOperands(Dictionary<RuleOpName,RuleOperand> src)
            {
                Data = src;
            }

            public bool TryGetValue(RuleOpName key, out RuleOperand value)
                => Data.TryGetValue(key, out value);

            public ICollection<RuleOpName> Keys
                => Data.Keys;

            public ICollection<RuleOperand> Values
                => Data.Values;

            public RuleOperand this[RuleOpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator RuleOperands(Dictionary<RuleOpName,RuleOperand> src)
                => new RuleOperands(src);
        }

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

            [OperandKind(IMM0, "Indicates whether a first imm operand is present")]
            public bit imm0;

            [OperandKind(IMM0SIGNED, "Indicates whether a first imm operand is signed")]
            public bit imm0signed;

            [OperandKind(IMM1, "Indicates whether a second imm operand is present")]
            public bit imm1;

            [OperandKind(OperandKind.IMM_WIDTH)]
            public byte imm_width;

            [OperandKind(IMM1_BYTES)]
            public byte imm1_bytes;

            [OperandKind(UIMM0)]
            public imm64 uimm0;

            [OperandKind(LOCK)]
            public bit @lock;

            [OperandKind(LZCNT, "F3+BSR")]
            public bit lzcnt;

            [OperandKind(TZCNT, "F3+BSF")]
            public bit tzcnt;

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
            public Hex64 relbr;

            public Disp _relbr;

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

            [OperandKind(UBIT)]
            public bit ubit;

            [OperandKind(USING_DEFAULT_SEGMENT0, "Indicates an overridden segment selector that was not the default segment selector")]
            public bit using_default_segment0;

            [OperandKind(USING_DEFAULT_SEGMENT1, "Indicates an overridden segment selector that was not the default segment selector")]
            public bit using_default_segment1;

            [OperandKind(VEXDEST3)]
            public bit vexdest3;

            [OperandKind(VEXDEST4)]
            public bit vexdest4;

            [OperandKind(VEX_C4)]
            public bit vex_c4;

            [OperandKind(VEX_PREFIX)]
            public VexPrefixKind vex_prefix;

            [OperandKind(VL)]
            public VectorWidthCode vl;

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

            [OperandKind(ILD_F2)]
            public bit ild_f2;

            [OperandKind(ILD_F3)]
            public bit ild_f3;

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

            [OperandKind(SRM, "Specifies partial-byte opcodes that capture an RM-like field.")]
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
            public byte nelem;

            [OperandKind(BCAST)]
            public BCastKind bcast;

            [OperandKind(NEED_MEMDISP)]
            public bit need_memdisp;

            [OperandKind(CHIP)]
            public ChipCode chip;

            [OperandKind(BRDISP_WIDTH)]
            public byte brdisp_width;

            [OperandKind(DISP_WIDTH)]
            public byte disp_width;

            [OperandKind(ILD_SEG)]
            public byte ild_seg;

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

            [OperandKind(SCALE)]
            public uint4 scale;

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

            public static OperandState Empty => default;

            public EncodingOffsets Offsets()
            {
                var offsets = EncodingOffsets.init();
                offsets.OpCode = (sbyte)(pos_nominal_opcode);
                if(has_modrm)
                    offsets.ModRm = (sbyte)pos_modrm;
                if(pos_sib != 0)
                    offsets.Sib = (sbyte)pos_sib;
                if(pos_disp != 0)
                    offsets.Disp = (sbyte)pos_disp;
                if(imm0)
                    offsets.Imm0 = (sbyte)pos_imm;
                return offsets;
            }

            public Index<K> Flags()
            {
                var flags = list<K>();
                if(need_memdisp)
                    flags.Add(K.NEED_MEMDISP);
                if(p4)
                    flags.Add(K.P4);
                if(using_default_segment0)
                    flags.Add(K.USING_DEFAULT_SEGMENT0);
                if(using_default_segment1)
                    flags.Add(K.USING_DEFAULT_SEGMENT1);
                if(lzcnt)
                    flags.Add(K.LZCNT);
                if(tzcnt)
                    flags.Add(K.TZCNT);
                if(df32)
                    flags.Add(K.DF32);
                if(df64)
                    flags.Add(K.DF64);
                if(must_use_evex)
                    flags.Add(K.MUST_USE_EVEX);
                if(rexrr)
                    flags.Add(K.REXRR);
                return flags.ToArray();
            }

            public RuleOperands RuleOperands(in AsmHexCode code)
            {
                var _ops = list<RuleOperand>();
                if(disp_width != 0)
                    _ops.Add(new RuleOperand(RuleOpName.DISP, disp(this, code), disp_width));

                if(imm0)
                    _ops.Add(new RuleOperand(RuleOpName.IMM0, imm(this, code)));

                if(_relbr != 0)
                    _ops.Add(new RuleOperand(RuleOpName.RELBR, relbr));

                if(base0.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.BASE0, base0));

                if(base1.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.BASE1, base1));

                if(scale != 0)
                    _ops.Add(new RuleOperand(RuleOpName.SCALE, scale));

                if(index.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.INDEX, index));

                if(reg0.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG0, reg0));

                if(reg1.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG1, reg1));

                if(reg2.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG2, reg2));

                if(reg3.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG3, reg3));

                if(reg4.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG4, reg4));

                if(reg5.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG5, reg5));

                if(reg6.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG6, reg6));

                if(reg7.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG7, reg7));

                if(reg8.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG8, reg8));

                if(reg9.IsNonEmpty)
                    _ops.Add(new RuleOperand(RuleOpName.REG9, reg9));

                if(nonempty(mem0))
                    _ops.Add(new RuleOperand(RuleOpName.MEM0, mem0));

                if(nonempty(mem1))
                    _ops.Add(new RuleOperand(RuleOpName.MEM1, mem1));

                if(nonempty(agen))
                    _ops.Add(new RuleOperand(RuleOpName.AGEN, agen));

                return map(_ops, o => (o.Name, o)).ToDictionary();
            }
        }
    }
}