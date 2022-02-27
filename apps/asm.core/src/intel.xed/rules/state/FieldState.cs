//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels.FieldKind;
    using static XedModels.RuleStateCalcs;
    using static Asm.AsmPrefixCodes;
    using static core;

    using K = XedModels.FieldKind;
    using N = XedModels.RuleOpName;

    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FieldState
        {
            public const string TableId = "xed.operand.state";

            [OperandKind(K.AGEN)]
            public text31 AGEN;

            [OperandKind(K.AMD3DNOW)]
            public bit AMD3DNOW;

            [OperandKind(K.ASZ)]
            public bit ASZ;

            [OperandKind(K.BCRC)]
            public bit BCRC;

            [OperandKind(K.CET)]
            public bit CET;

            [OperandKind(K.CLDEMOTE)]
            public bit CLDEMOTE;

            [OperandKind(K.DF32)]
            public bit DF32;

            [OperandKind(K.DF64)]
            public bit DF64;

            [OperandKind(K.DUMMY)]
            public bit DUMMY;

            [OperandKind(K.ENCODER_PREFERRED)]
            public bit ENCODER_PREFERRED;

            [OperandKind(K.ENCODE_FORCE)]
            public bit ENCODE_FORCE;

            [OperandKind(K.HAS_SIB)]
            public bit HAS_SIB;

            [OperandKind(K.IMM0, "Indicates whether a first imm operand is present")]
            public bit IMM0;

            [OperandKind(K.IMM0SIGNED, "Indicates whether a first imm operand is signed")]
            public bit IMM0SIGNED;

            [OperandKind(K.IMM1, "Indicates whether a second imm operand is present")]
            public bit IMM1;

            [OperandKind(K.IMM_WIDTH)]
            public byte IMM_WIDTH;

            [OperandKind(K.IMM1_BYTES)]
            public byte IMM1_BYTES;

            [OperandKind(K.UIMM0)]
            public imm64 UIMM0;

            [OperandKind(K.LOCK)]
            public bit LOCK;

            [OperandKind(K.LZCNT, "F3+BSR")]
            public bit LZCNT;

            [OperandKind(K.TZCNT, "F3+BSF")]
            public bit TZCNT;

            [OperandKind(K.MEM0)]
            public string MEM0;

            [OperandKind(K.MEM1)]
            public string MEM1;

            [OperandKind(K.MODEP5)]
            public bit MODEP5;

            [OperandKind(K.MODEP55C)]
            public bit MODEP55C;

            [OperandKind(K.MODE_FIRST_PREFIX)]
            public bit MODE_FIRST_PREFIX;

            [OperandKind(K.MODE_SHORT_UD0)]
            public bit MODE_SHORT_UD0;

            [OperandKind(K.MPXMODE)]
            public bit MPXMODE;

            [OperandKind(K.MUST_USE_EVEX)]
            public bit MUST_USE_EVEX;

            [OperandKind(K.NEEDREX)]
            public bit NEEDREX;

            [OperandKind(K.NEED_SIB)]
            public bit NEED_SIB;

            [OperandKind(K.NOREX)]
            public bit NOREX;

            [OperandKind(K.NO_SCALE_DISP8)]
            public bit NO_SCALE_DISP8;

            [OperandKind(K.OSZ)]
            public bit OSZ;

            [OperandKind(K.OUT_OF_BYTES)]
            public bit OUT_OF_BYTES;

            [OperandKind(K.P4)]
            public bit P4;

            [OperandKind(K.PREFIX66)]
            public bit PREFIX66;

            [OperandKind(K.PTR)]
            public bit PTR;

            [OperandKind(K.REALMODE)]
            public bit REALMODE;

            [OperandKind(K.RELBR)]
            public Disp RELBR;

            [OperandKind(K.REX)]
            public bit REX;

            [OperandKind(K.REXB)]
            public bit REXB;

            [OperandKind(K.REXR)]
            public bit REXR;

            [OperandKind(K.REXRR)]
            public bit REXRR;

            [OperandKind(K.REXW)]
            public bit REXW;

            [OperandKind(K.REXX)]
            public bit REXX;

            [OperandKind(K.SAE)]
            public bit SAE;

            [OperandKind(K.UBIT)]
            public bit UBIT;

            [OperandKind(K.USING_DEFAULT_SEGMENT0, "Indicates an overridden segment selector that was not the default segment selector")]
            public bit USING_DEFAULT_SEGMENT0;

            [OperandKind(K.USING_DEFAULT_SEGMENT1, "Indicates an overridden segment selector that was not the default segment selector")]
            public bit USING_DEFAULT_SEGMENT1;

            [OperandKind(K.VEXDEST3)]
            public bit VEXDEST3;

            [OperandKind(VEXDEST4)]
            public bit vexdest4;

            [OperandKind(K.VEX_C4)]
            public bit VEX_C4;

            [OperandKind(K.VEX_PREFIX)]
            public VexPrefixKind VEX_PREFIX;

            [OperandKind(K.VL)]
            public VectorWidthCode VL;

            [OperandKind(K.WBNOINVD)]
            public bit WBNOINVD;

            [OperandKind(K.ZEROING)]
            public bit ZEROING;

            [OperandKind(K.DEFAULT_SEG)]
            public uint2 DEFAULT_SEG;

            [OperandKind(K.EASZ)]
            public EASZ EASZ;

            [OperandKind(K.EOSZ)]
            public EOSZ EOSZ;

            [OperandKind(K.FIRST_F2F3)]
            public uint2 FIRST_F2F3;

            [OperandKind(K.HAS_MODRM, "Indicates whether a modrm byte is specified")]
            public bit HAS_MODRM;

            [OperandKind(K.LAST_F2F3)]
            public uint2 LAST_F2F3;

            [OperandKind(K.ILD_F2)]
            public bit ILD_F2;

            [OperandKind(K.ILD_F3)]
            public bit ILD_F3;

            [OperandKind(K.LLRC)]
            public uint2 LLRC;

            [OperandKind(K.MOD)]
            public uint2 MOD;

            [OperandKind(K.MODE)]
            public Mode MODE;

            [OperandKind(K.REP)]
            public uint2 REP;

            [OperandKind(K.SIBSCALE)]
            public uint2 SIBSCALE;

            [OperandKind(K.SMODE)]
            public SMode SMODE;

            [OperandKind(K.HINT)]
            public HintKind HINT;

            [OperandKind(K.MASK)]
            public uint3 MASK;

            [OperandKind(K.REG)]
            public uint3 REG;

            [OperandKind(K.RM)]
            public uint3 RM;

            [OperandKind(K.ROUNDC)]
            public uint3 ROUNDC;

            [OperandKind(K.SEG_OVD)]
            public uint3 SEG_OVD;

            [OperandKind(K.SIBBASE)]
            public uint3 SIBBASE;

            [OperandKind(K.SIBINDEX)]
            public uint3 SIBINDEX;

            [OperandKind(K.SRM, "Specifies partial-byte opcodes that capture an RM-like field.")]
            public uint3 SRM;

            [OperandKind(K.VEXDEST210)]
            public uint3 VEXDEST210;

            [OperandKind(K.VEXVALID)]
            public VexKind VEXVALID;

            [OperandKind(K.ERROR)]
            public ErrorKind ERROR;

            [OperandKind(K.ESRC)]
            public uint4 ESRC;

            [OperandKind(K.MAP)]
            public byte MAP;

            [OperandKind(K.NELEM)]
            public byte NELEM;

            [OperandKind(K.BCAST)]
            public XedBCastKind BCAST;

            [OperandKind(K.NEED_MEMDISP)]
            public bit NEED_MEMDISP;

            [OperandKind(K.CHIP)]
            public ChipCode CHIP;

            [OperandKind(K.BRDISP_WIDTH)]
            public byte BRDISP_WIDTH;

            [OperandKind(K.DISP_WIDTH)]
            public byte DISP_WIDTH;

            [OperandKind(K.ILD_SEG)]
            public byte ILD_SEG;

            [OperandKind(FieldKind.MAX_BYTES)]
            public byte MAX_BYTES;

            [OperandKind(K.MODRM_BYTE)]
            public Hex8 MODRM_BYTE;

            [OperandKind(K.NOMINAL_OPCODE)]
            public Hex8 NOMINAL_OPCODE;

            [OperandKind(K.NPREFIXES)]
            public byte NPREFIXES;

            [OperandKind(K.NREXES)]
            public byte NREXES;

            [OperandKind(K.NSEG_PREFIXES)]
            public byte NSEG_PREFIXES;

            [OperandKind(K.POS_DISP)]
            public byte POS_DISP;

            [OperandKind(K.POS_IMM)]
            public byte POS_IMM;

            [OperandKind(K.POS_IMM1)]
            public byte POS_IMM1;

            [OperandKind(K.POS_MODRM)]
            public byte POS_MODRM;

            [OperandKind(K.POS_NOMINAL_OPCODE)]
            public byte POS_NOMINAL_OPCODE;

            [OperandKind(K.POS_SIB)]
            public byte POS_SIB;

            [OperandKind(K.UIMM1)]
            public imm8 UIMM1;

            [OperandKind(K.BASE0)]
            public Register BASE0;

            [OperandKind(K.BASE1)]
            public Register BASE1;

            [OperandKind(K.ELEMENT_SIZE)]
            public ushort ELEMENT_SIZE;

            [OperandKind(K.INDEX)]
            public Register INDEX;

            [OperandKind(K.SCALE)]
            public uint4 SCALE;

            [OperandKind(K.OUTREG)]
            public Register OUTREG;

            [OperandKind(K.REG0)]
            public Register REG0;

            [OperandKind(K.REG1)]
            public Register REG1;

            [OperandKind(K.REG2)]
            public Register REG2;

            [OperandKind(K.REG3)]
            public Register REG3;

            [OperandKind(K.REG4)]
            public Register REG4;

            [OperandKind(K.REG5)]
            public Register REG5;

            [OperandKind(K.REG6)]
            public Register REG6;

            [OperandKind(K.REG7)]
            public Register REG7;

            [OperandKind(K.REG8)]
            public Register REG8;

            [OperandKind(K.REG9)]
            public Register REG9;

            [OperandKind(K.SEG0)]
            public Register SEG0;

            [OperandKind(K.SEG1)]
            public Register SEG1;

            [OperandKind(K.ICLASS)]
            public IClass ICLASS;

            [OperandKind(K.MEM_WIDTH)]
            public ushort MEM_WIDTH;

            [OperandKind(DISP)]
            public Disp64 disp;

            public ConstLookup<FieldKind,object> FieldValues()
            {
                var dst = dict<FieldKind,object>();
                var kinds = new FieldKinds();
                var fields = kinds.RightValues;
                foreach(var f in fields)
                    dst.Add(kinds[f], f.GetValue(this));
                return dst;
            }

            public EncodingOffsets Offsets()
            {
                var offsets = EncodingOffsets.init();
                offsets.OpCode = (sbyte)(POS_NOMINAL_OPCODE);
                if(HAS_MODRM)
                    offsets.ModRm = (sbyte)POS_MODRM;
                if(POS_SIB != 0)
                    offsets.Sib = (sbyte)POS_SIB;
                if(POS_DISP != 0)
                    offsets.Disp = (sbyte)POS_DISP;
                if(IMM0)
                    offsets.Imm0 = (sbyte)POS_IMM;
                return offsets;
            }

            public Index<K> Flags()
            {
                var flags = list<K>();
                if(NEED_MEMDISP)
                    flags.Add(K.NEED_MEMDISP);
                if(P4)
                    flags.Add(K.P4);
                if(USING_DEFAULT_SEGMENT0)
                    flags.Add(K.USING_DEFAULT_SEGMENT0);
                if(USING_DEFAULT_SEGMENT1)
                    flags.Add(K.USING_DEFAULT_SEGMENT1);
                if(LZCNT)
                    flags.Add(K.LZCNT);
                if(TZCNT)
                    flags.Add(K.TZCNT);
                if(DF32)
                    flags.Add(K.DF32);
                if(DF64)
                    flags.Add(K.DF64);
                if(MUST_USE_EVEX)
                    flags.Add(K.MUST_USE_EVEX);
                if(REXRR)
                    flags.Add(K.REXRR);
                return flags.ToArray();
            }

            public RuleOperands RuleOperands(in AsmHexCode code)
            {
                var _ops = list<RuleOperand>();
                if(DISP_WIDTH != 0)
                    _ops.Add(new RuleOperand(N.DISP, disp(this, code)));

                if(IMM0)
                    _ops.Add(new RuleOperand(N.IMM0, imm(this, code)));

                if(RELBR.IsNonZero)
                    _ops.Add(new RuleOperand(N.RELBR, RELBR));

                if(BASE0.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.BASE0, BASE0));

                if(BASE1.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.BASE1, BASE1));

                if(SCALE != 0)
                    _ops.Add(new RuleOperand(N.SCALE, SCALE));

                if(INDEX.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.INDEX, INDEX));

                if(REG0.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG0, REG0));

                if(REG1.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG1, REG1));

                if(REG2.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG2, REG2));

                if(REG3.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG3, REG3));

                if(REG4.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG4, REG4));

                if(REG5.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG5, REG5));

                if(REG6.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG6, REG6));

                if(REG7.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG7, REG7));

                if(REG8.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG8, REG8));

                if(REG9.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.REG9, REG9));

                if(nonempty(MEM0))
                    _ops.Add(new RuleOperand(N.MEM0, MEM0));

                if(nonempty(MEM1))
                    _ops.Add(new RuleOperand(N.MEM1, MEM1));

                if(AGEN.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.AGEN, AGEN));

                return map(_ops, o => (o.Name, o)).ToDictionary();
            }

            public static FieldState Empty => default;
        }
    }
}