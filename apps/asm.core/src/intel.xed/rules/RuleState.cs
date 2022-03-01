//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;

    using K = XedModels.FieldKind;
    using N = XedModels.RuleOpName;

    partial class XedRules
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleState
        {
            public const string TableId = "xed.rules.state";

            public static ConstLookup<FieldKind,FieldInfo> fields()
            {
                var fields = typeof(RuleState).PublicInstanceFields();
                var count = fields.Length;
                var dst = dict<FieldKind,FieldInfo>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref skip(fields,i);
                    var tag = field.Tag<RuleOperandAttribute>();
                    if(tag)
                        dst.TryAdd(tag.Value.Kind, field);
                }
                return dst;
            }

            public static Index<RuleFieldSpec> specs()
            {
                var src = typeof(RuleState).PublicInstanceFields();
                var dst = alloc<RuleFieldSpec>(src.Length);
                for(var i=z16; i<src.Length; i++)
                {
                    ref readonly var field = ref skip(src,i);
                    ref var record = ref seek(dst,i);
                    record.Pos = i;
                    record.Name = field.Name;
                    record.Type = field.FieldType.IsEnum ? string.Format("enum<{0}>", field.FieldType.Name) : field.FieldType.DisplayName();
                    var tag = field.Tag<RuleOperandAttribute>();
                    if(tag)
                    {
                        record.Width = tag.Value.Width;
                        record.Kind = tag.Value.Kind;
                    }
                }
                return dst;
            }

            [RuleOperand(K.AMD3DNOW, 1)]
            public bit AMD3DNOW;

            [RuleOperand(K.ASZ, 1)]
            public bit ASZ;

            [RuleOperand(K.BCRC, 1)]
            public bit BCRC;

            [RuleOperand(K.CET, 1)]
            public bit CET;

            [RuleOperand(K.CLDEMOTE, 1)]
            public bit CLDEMOTE;

            [RuleOperand(K.DF32, 1)]
            public bit DF32;

            [RuleOperand(K.DF64, 1)]
            public bit DF64;

            [RuleOperand(K.DUMMY, 1)]
            public bit DUMMY;

            [RuleOperand(K.ENCODER_PREFERRED, 1)]
            public bit ENCODER_PREFERRED;

            [RuleOperand(K.ENCODE_FORCE, 1)]
            public bit ENCODE_FORCE;

            [RuleOperand(K.HAS_SIB, 1)]
            public bit HAS_SIB;

            /// <summary>
            /// Indicates whether a first imm operand is present"
            /// </summary>
            [RuleOperand(K.IMM0, 1)]
            public bit IMM0;

            /// <summary>
            /// Indicates whether a first imm operand is signed
            /// </summary>
            [RuleOperand(K.IMM0SIGNED, 1)]
            public bit IMM0SIGNED;

            /// <summary>
            /// Indicates whether a second imm operand is present"
            /// </summary>
            [RuleOperand(K.IMM1, 1)]
            public bit IMM1;

            [RuleOperand(K.IMM_WIDTH, 3)]
            public byte IMM_WIDTH;

            [RuleOperand(K.IMM1_BYTES, 3)]
            public byte IMM1_BYTES;

            [RuleOperand(K.UIMM0, 64)]
            public imm64 UIMM0;

            [RuleOperand(K.LOCK, 1)]
            public bit LOCK;

            [RuleOperand(K.LZCNT, 1)]
            public bit LZCNT;

            [RuleOperand(K.TZCNT, 1)]
            public bit TZCNT;

            [RuleOperand(K.MODEP5, 1)]
            public bit MODEP5;

            [RuleOperand(K.MODEP55C, 1)]
            public bit MODEP55C;

            [RuleOperand(K.MODE_FIRST_PREFIX, 1)]
            public bit MODE_FIRST_PREFIX;

            [RuleOperand(K.MODE_SHORT_UD0, 1)]
            public bit MODE_SHORT_UD0;

            [RuleOperand(K.MPXMODE, 1)]
            public bit MPXMODE;

            [RuleOperand(K.MUST_USE_EVEX, 1)]
            public bit MUST_USE_EVEX;

            [RuleOperand(K.NEEDREX, 1)]
            public bit NEEDREX;

            [RuleOperand(K.NEED_SIB, 1)]
            public bit NEED_SIB;

            [RuleOperand(K.NOREX, 1)]
            public bit NOREX;

            [RuleOperand(K.NO_SCALE_DISP8, 1)]
            public bit NO_SCALE_DISP8;

            [RuleOperand(K.OSZ, 1)]
            public bit OSZ;

            [RuleOperand(K.OUT_OF_BYTES, 1)]
            public bit OUT_OF_BYTES;

            [RuleOperand(K.P4, 1)]
            public bit P4;

            [RuleOperand(K.PREFIX66, 1)]
            public bit PREFIX66;

            [RuleOperand(K.PTR, 1)]
            public bit PTR;

            [RuleOperand(K.REALMODE, 1)]
            public bit REALMODE;

            [RuleOperand(K.RELBR,64)]
            public Disp RELBR;

            [RuleOperand(K.REX, 1)]
            public bit REX;

            [RuleOperand(K.REXB, 1)]
            public bit REXB;

            [RuleOperand(K.REXR, 1)]
            public bit REXR;

            [RuleOperand(K.REXRR, 1)]
            public bit REXRR;

            [RuleOperand(K.REXW, 1)]
            public bit REXW;

            [RuleOperand(K.REXX, 1)]
            public bit REXX;

            [RuleOperand(K.SAE, 1)]
            public bit SAE;

            [RuleOperand(K.UBIT, 1)]
            public bit UBIT;

            /// <summary>
            /// Indicates an overridden segment selector that was not the default segment selector
            /// </summary>
            [RuleOperand(K.USING_DEFAULT_SEGMENT0, 1)]
            public bit USING_DEFAULT_SEGMENT0;

            /// <summary>
            /// Indicates an overridden segment selector that was not the default segment selector
            /// </summary>
            [RuleOperand(K.USING_DEFAULT_SEGMENT1, 1)]
            public bit USING_DEFAULT_SEGMENT1;

            [RuleOperand(K.VEXDEST3, 1)]
            public bit VEXDEST3;

            [RuleOperand(K.VEXDEST4, 1)]
            public bit vexdest4;

            [RuleOperand(K.VEX_C4, 1)]
            public bit VEX_C4;

            [RuleOperand(K.VEX_PREFIX, 2)]
            public byte VEX_PREFIX;

            [RuleOperand(K.VL, 3)]
            public byte VL;

            [RuleOperand(K.WBNOINVD, 1)]
            public bit WBNOINVD;

            [RuleOperand(K.ZEROING, 1)]
            public bit ZEROING;

            [RuleOperand(K.DEFAULT_SEG, 2)]
            public byte DEFAULT_SEG;

            [RuleOperand(K.EASZ, 3)]
            public byte EASZ;

            [RuleOperand(K.EOSZ, 3)]
            public byte EOSZ;

            [RuleOperand(K.FIRST_F2F3, 2)]
            public byte FIRST_F2F3;

            /// <summary>
            /// Indicates whether a modrm byte is specified
            /// </summary>
            [RuleOperand(K.HAS_MODRM, 1)]
            public bit HAS_MODRM;

            [RuleOperand(K.LAST_F2F3, 2)]
            public byte LAST_F2F3;

            [RuleOperand(K.ILD_F2, 1)]
            public bit ILD_F2;

            [RuleOperand(K.ILD_F3, 1)]
            public bit ILD_F3;

            [RuleOperand(K.LLRC, 2)]
            public byte LLRC;

            [RuleOperand(K.MOD, 2)]
            public uint2 MOD;

            [RuleOperand(K.MODE, 2)]
            public uint2 MODE;

            [RuleOperand(K.REP, 2)]
            public uint2 REP;

            [RuleOperand(K.SIBSCALE, 2)]
            public uint2 SIBSCALE;

            [RuleOperand(K.SMODE, 2)]
            public byte SMODE;

            [RuleOperand(K.HINT, 3)]
            public byte HINT;

            [RuleOperand(K.MASK, 3)]
            public uint3 MASK;

            [RuleOperand(K.REG, 3)]
            public uint3 REG;

            [RuleOperand(K.RM, 3)]
            public uint3 RM;

            [RuleOperand(K.ROUNDC, 3)]
            public uint3 ROUNDC;

            [RuleOperand(K.SEG_OVD, 3)]
            public uint3 SEG_OVD;

            [RuleOperand(K.SIBBASE, 3)]
            public uint3 SIBBASE;

            [RuleOperand(K.SIBINDEX, 3)]
            public uint3 SIBINDEX;

            /// <summary>
            /// Specifies partial-byte opcodes that capture an RM-like field.
            /// </summary>
            [RuleOperand(K.SRM, 3)]
            public byte SRM;

            [RuleOperand(K.VEXDEST210, 3)]
            public uint3 VEXDEST210;

            [RuleOperand(K.VEXDEST4, 1)]
            public bit VEXDEST4;

            [RuleOperand(K.VEXVALID, 3)]
            public byte VEXVALID;

            [RuleOperand(K.ERROR, 1)]
            public ErrorKind ERROR;

            [RuleOperand(K.ESRC, 4)]
            public uint4 ESRC;

            [RuleOperand(K.MAP, 4)]
            public byte MAP;

            [RuleOperand(K.NELEM, 4)]
            public byte NELEM;

            [RuleOperand(K.BCAST,5)]
            public BCastKind BCAST;

            [RuleOperand(K.NEED_MEMDISP, 1)]
            public bit NEED_MEMDISP;

            [RuleOperand(K.CHIP, 8)]
            public ChipCode CHIP;

            [RuleOperand(K.BRDISP_WIDTH)]
            public byte BRDISP_WIDTH;

            [RuleOperand(K.DISP_WIDTH)]
            public byte DISP_WIDTH;

            [RuleOperand(K.ILD_SEG)]
            public byte ILD_SEG;

            [RuleOperand(FieldKind.MAX_BYTES)]
            public byte MAX_BYTES;

            [RuleOperand(K.MODRM_BYTE, 8)]
            public Hex8 MODRM_BYTE;

            [RuleOperand(K.NOMINAL_OPCODE, 8)]
            public Hex8 NOMINAL_OPCODE;

            [RuleOperand(K.NPREFIXES, 8)]
            public byte NPREFIXES;

            [RuleOperand(K.NREXES, 8)]
            public byte NREXES;

            [RuleOperand(K.NSEG_PREFIXES, 8)]
            public byte NSEG_PREFIXES;

            [RuleOperand(K.POS_DISP, 4)]
            public byte POS_DISP;

            [RuleOperand(K.POS_IMM, 4)]
            public byte POS_IMM;

            [RuleOperand(K.POS_IMM1, 4)]
            public byte POS_IMM1;

            [RuleOperand(K.POS_MODRM, 4)]
            public byte POS_MODRM;

            [RuleOperand(K.POS_NOMINAL_OPCODE, 4)]
            public byte POS_NOMINAL_OPCODE;

            [RuleOperand(K.POS_SIB, 4)]
            public byte POS_SIB;

            [RuleOperand(K.UIMM1, 8)]
            public imm8 UIMM1;

            [RuleOperand(K.BASE0, 9)]
            public XedRegId BASE0;

            [RuleOperand(K.BASE1, 9)]
            public XedRegId BASE1;

            [RuleOperand(K.ELEMENT_SIZE, 9)]
            public ushort ELEMENT_SIZE;

            [RuleOperand(K.INDEX, 9)]
            public XedRegId INDEX;

            [RuleOperand(K.SCALE)]
            public byte SCALE;

            [RuleOperand(K.OUTREG, 9)]
            public XedRegId OUTREG;

            [RuleOperand(K.REG0, 9)]
            public XedRegId REG0;

            [RuleOperand(K.REG1, 9)]
            public XedRegId REG1;

            [RuleOperand(K.REG2, 9)]
            public XedRegId REG2;

            [RuleOperand(K.REG3, 9)]
            public XedRegId REG3;

            [RuleOperand(K.REG4, 9)]
            public XedRegId REG4;

            [RuleOperand(K.REG5, 9)]
            public XedRegId REG5;

            [RuleOperand(K.REG6, 9)]
            public XedRegId REG6;

            [RuleOperand(K.REG7, 9)]
            public XedRegId REG7;

            [RuleOperand(K.REG8, 9)]
            public XedRegId REG8;

            [RuleOperand(K.REG9, 9)]
            public XedRegId REG9;

            [RuleOperand(K.SEG0, 9)]
            public XedRegId SEG0;

            [RuleOperand(K.SEG1, 9)]
            public XedRegId SEG1;

            [RuleOperand(K.ICLASS, 16)]
            public IClass ICLASS;

            [RuleOperand(K.MEM_WIDTH, 16)]
            public ushort MEM_WIDTH;

            [RuleOperand(K.DISP, 64)]
            public Disp64 DISP;

            [RuleOperand(K.NO_RETURN, 1)]
            public bit NO_RETURN;

            [RuleOperand(K.AGEN, 32)]
            public text31 AGEN;

            [RuleOperand(K.MEM0, 32)]
            public text31 MEM0;

            [RuleOperand(K.MEM1, 32)]
            public text31 MEM1;

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

                if(BASE0 != 0)
                    _ops.Add(new RuleOperand(N.BASE0, BASE0));

                if(BASE1 != 0)
                    _ops.Add(new RuleOperand(N.BASE1, BASE1));

                if(SCALE != 0)
                    _ops.Add(new RuleOperand(N.SCALE, SCALE));

                if(INDEX != 0)
                    _ops.Add(new RuleOperand(N.INDEX, INDEX));

                if(REG0 != 0)
                    _ops.Add(new RuleOperand(N.REG0, REG0));

                if(REG1 != 0)
                    _ops.Add(new RuleOperand(N.REG1, REG1));

                if(REG2 != 0)
                    _ops.Add(new RuleOperand(N.REG2, REG2));

                if(REG3 != 0)
                    _ops.Add(new RuleOperand(N.REG3, REG3));

                if(REG4 != 0)
                    _ops.Add(new RuleOperand(N.REG4, REG4));

                if(REG5 != 0)
                    _ops.Add(new RuleOperand(N.REG5, REG5));

                if(REG6 != 0)
                    _ops.Add(new RuleOperand(N.REG6, REG6));

                if(REG7 != 0)
                    _ops.Add(new RuleOperand(N.REG7, REG7));

                if(REG8 != 0)
                    _ops.Add(new RuleOperand(N.REG8, REG8));

                if(REG9 != 0)
                    _ops.Add(new RuleOperand(N.REG9, REG9));

                if(MEM0.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.MEM0, MEM0));

                if(MEM1.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.MEM1, MEM1));

                if(AGEN.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.AGEN, AGEN));

                return map(_ops, o => (o.Name, o)).ToDictionary();
            }

            public ConstLookup<FieldKind,object> Values()
            {
                var dst = dict<FieldKind,object>();
                var kinds = new FieldLookup();
                var fields = kinds.RightValues;
                foreach(var f in fields)
                    dst.Add(kinds[f], f.GetValue(this));
                return dst;
            }

            public static RuleState Empty => default;
        }
    }
}