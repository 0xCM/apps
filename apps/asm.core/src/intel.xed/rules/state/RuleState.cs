//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels.RuleStateCalcs;
    using static Asm.AsmPrefixCodes;
    using static Asm.AsmPrefixCodes.VectorWidthCode;
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.SMode;
    using static XedModels.SegPrefixKind;
    using static XedModels.VexMapKind;
    using static core;

    using K = XedModels.FieldKind;
    using N = XedModels.RuleOpName;
    using P = XedModels.RepPrefix;
    using D = XedModels.SegDefaultKind;
    using B = XedModels.BCastKind;
    using V = XedModels.VexPrefixKind;
    using M = XedModels.RuleMacroName;

    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleState
        {
            public const string TableId = "xed.rules.state";

            [RuleOperand(K.AGEN)]
            public text31 AGEN;

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

            [RuleOperand(K.IMM_WIDTH)]
            public byte IMM_WIDTH;

            [RuleOperand(K.IMM1_BYTES)]
            public byte IMM1_BYTES;

            [RuleOperand(K.UIMM0, 64)]
            public imm64 UIMM0;

            [RuleOperand(K.LOCK, 1)]
            public bit LOCK;

            [RuleOperand(K.LZCNT, 1)]
            public bit LZCNT;

            [RuleOperand(K.TZCNT, 1)]
            public bit TZCNT;

            [RuleOperand(K.MEM0)]
            public text31 MEM0;

            [RuleOperand(K.MEM1)]
            public text31 MEM1;

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

            [RuleOperand(K.RELBR)]
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

            [RuleOperand(K.VEX_PREFIX)]
            public VexPrefixKind VEX_PREFIX;

            [RuleOperand(K.VL)]
            public VectorWidthCode VL;

            [RuleOperand(K.WBNOINVD, 1)]
            public bit WBNOINVD;

            [RuleOperand(K.ZEROING, 1)]
            public bit ZEROING;

            [RuleOperand(K.DEFAULT_SEG, 2)]
            public uint2 DEFAULT_SEG;

            [RuleOperand(K.EASZ, 3)]
            public EASZ EASZ;

            [RuleOperand(K.EOSZ, 3)]
            public EOSZ EOSZ;

            [RuleOperand(K.FIRST_F2F3, 2)]
            public uint2 FIRST_F2F3;

            /// <summary>
            /// Indicates whether a modrm byte is specified
            /// </summary>
            [RuleOperand(K.HAS_MODRM, 1)]
            public bit HAS_MODRM;

            [RuleOperand(K.LAST_F2F3, 2)]
            public uint2 LAST_F2F3;

            [RuleOperand(K.ILD_F2, 1)]
            public bit ILD_F2;

            [RuleOperand(K.ILD_F3, 1)]
            public bit ILD_F3;

            [RuleOperand(K.LLRC, 2)]
            public uint2 LLRC;

            [RuleOperand(K.MOD, 2)]
            public uint2 MOD;

            [RuleOperand(K.MODE, 2)]
            public ModeKind MODE;

            [RuleOperand(K.REP, 2)]
            public uint2 REP;

            [RuleOperand(K.SIBSCALE, 2)]
            public uint2 SIBSCALE;

            [RuleOperand(K.SMODE, 2)]
            public SMode SMODE;

            [RuleOperand(K.HINT, 3)]
            public HintKind HINT;

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
            public uint3 SRM;

            [RuleOperand(K.VEXDEST210, 3)]
            public uint3 VEXDEST210;

            [RuleOperand(K.VEXDEST4, 1)]
            public bit VEXDEST4;

            [RuleOperand(K.VEXVALID)]
            public VexKind VEXVALID;

            [RuleOperand(K.ERROR)]
            public ErrorKind ERROR;

            [RuleOperand(K.ESRC, 4)]
            public uint4 ESRC;

            [RuleOperand(K.MAP)]
            public byte MAP;

            [RuleOperand(K.NELEM)]
            public byte NELEM;

            [RuleOperand(K.BCAST)]
            public BCastKind BCAST;

            [RuleOperand(K.NEED_MEMDISP, 1)]
            public bit NEED_MEMDISP;

            [RuleOperand(K.CHIP)]
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

            [RuleOperand(K.NPREFIXES)]
            public byte NPREFIXES;

            [RuleOperand(K.NREXES)]
            public byte NREXES;

            [RuleOperand(K.NSEG_PREFIXES)]
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

            [RuleOperand(K.BASE0)]
            public XedRegId BASE0;

            [RuleOperand(K.BASE1)]
            public XedRegId BASE1;

            [RuleOperand(K.ELEMENT_SIZE)]
            public ushort ELEMENT_SIZE;

            [RuleOperand(K.INDEX)]
            public XedRegId INDEX;

            [RuleOperand(K.SCALE)]
            public byte SCALE;

            [RuleOperand(K.OUTREG)]
            public XedRegId OUTREG;

            [RuleOperand(K.REG0)]
            public XedRegId REG0;

            [RuleOperand(K.REG1)]
            public XedRegId REG1;

            [RuleOperand(K.REG2)]
            public XedRegId REG2;

            [RuleOperand(K.REG3)]
            public XedRegId REG3;

            [RuleOperand(K.REG4)]
            public XedRegId REG4;

            [RuleOperand(K.REG5)]
            public XedRegId REG5;

            [RuleOperand(K.REG6)]
            public XedRegId REG6;

            [RuleOperand(K.REG7)]
            public XedRegId REG7;

            [RuleOperand(K.REG8)]
            public XedRegId REG8;

            [RuleOperand(K.REG9)]
            public XedRegId REG9;

            [RuleOperand(K.SEG0)]
            public XedRegId SEG0;

            [RuleOperand(K.SEG1)]
            public XedRegId SEG1;

            [RuleOperand(K.ICLASS)]
            public IClass ICLASS;

            [RuleOperand(K.MEM_WIDTH)]
            public ushort MEM_WIDTH;

            [RuleOperand(K.DISP)]
            public Disp64 DISP;

            [RuleOperand(K.NO_RETURN, 1)]
            public bit NO_RETURN;

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

            [MethodImpl(Inline), RuleMacro(M.mod0)]
            public void mod0()
            {
                MOD = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.mod1)]
            public void mod1()
            {
                MOD = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.mod2)]
            public void mod2()
            {
                MOD = 2;
            }

            [MethodImpl(Inline), RuleMacro(M.mod3)]
            public void mod3()
            {
                MOD = 3;
            }

            [MethodImpl(Inline), RuleMacro(M.not64)]
            public void not64()
            {
                MODE = ModeKind.Not64;
            }

            [MethodImpl(Inline), RuleMacro(M.mode64)]
            public void mode64()
            {
                MODE = ModeKind.Mode64;
            }

            [MethodImpl(Inline), RuleMacro(M.mode32)]
            public void mode32()
            {
                MODE = ModeKind.Mode32;
            }

            [MethodImpl(Inline), RuleMacro(M.mode16)]
            public void mode16()
            {
                MODE = ModeKind.Mode16;
            }

            [MethodImpl(Inline), RuleMacro(M.eanot16)]
            public void eanot16()
            {
                EASZ = EASZNot16;
            }

            [MethodImpl(Inline), RuleMacro(M.eamode16)]
            public void eamode16()
            {
                EASZ = EASZ16;
            }

            [MethodImpl(Inline), RuleMacro(M.eamode32)]
            public void eamode32()
            {
                EASZ = EASZ32;
            }

            [MethodImpl(Inline), RuleMacro(M.eamode64)]
            public void eamode64()
            {
                EASZ = EASZ64;
            }

            [MethodImpl(Inline), RuleMacro(M.smode16)]
            public void smode16()
            {
                SMODE = SMode16;
            }

            [MethodImpl(Inline), RuleMacro(M.smode32)]
            public void smode32()
            {
                SMODE = SMode32;
            }

            [MethodImpl(Inline), RuleMacro(M.smode64)]
            public void smode64()
            {
                SMODE = SMode64;
            }

            [MethodImpl(Inline), RuleMacro(M.eosz8)]
            public void eosz8()
            {
                EOSZ = EOSZ8;
            }

            [MethodImpl(Inline), RuleMacro(M.eosz16)]
            public void eosz16()
            {
                EOSZ = EOSZ16;
            }

            [MethodImpl(Inline), RuleMacro(M.eosz32)]
            public void eosz32()
            {
                EOSZ = EOSZ32;
            }

            [MethodImpl(Inline), RuleMacro(M.eosz64)]
            public void eosz64()
            {
                EOSZ = EOSZ64;
            }

            [MethodImpl(Inline), RuleMacro(M.not_eosz16)]
            public void not_eosz16()
            {
                EOSZ = EOSZNot16;
            }

            [MethodImpl(Inline), RuleMacro(M.eosznot64)]
            public void eosznot64()
            {
                EOSZ = EOSZNot64;
            }

            [MethodImpl(Inline), RuleMacro(M.rex_reqd)]
            public void rex_reqd()
            {
                REX = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.no_rex)]
            public void no_rex()
            {
                REX = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.reset_rex)]
            public void reset_rex()
            {
                REX = 0;
                REXW = 0;
                REXB = 0;
                REXR = 0;
                REXX = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.rexb_prefix)]
            public void rexb_prefix()
            {
                REXB = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.norexb_prefix)]
            public void norexb_prefix()
            {
                REXB = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.rexx_prefix)]
            public void rexx_prefix()
            {
                REXX = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.norexx_prefix)]
            public void norexx_prefix()
            {
                REXX = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.rexr_prefix)]
            public void rexr_prefix()
            {
                REXR = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.norexr_prefix)]
            public void norexr_prefix()
            {
                REXR = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.rexw_prefix)]
            public void rexw_prefix()
            {
                REXW = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.norexw_prefix)]
            public void norexw_prefix()
            {
                REXW = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.W0)]
            public void W0()
            {
                REXW = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.W1)]
            public void W1()
            {
                REXW = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.f2_prefix)]
            public void f2_prefix()
            {
                REP = (byte)P.REPF2;
            }

            [MethodImpl(Inline), RuleMacro(M.f3_prefix)]
            public void f3_prefix()
            {
                REP = (byte)P.REPF3;
            }

            [MethodImpl(Inline), RuleMacro(M.repne)]
            public void repne()
            {
                REP = (byte)P.REPF2;
            }

            [MethodImpl(Inline), RuleMacro(M.repe)]
            public void repe()
            {
                REP = (byte)P.REPF3;
            }

            [MethodImpl(Inline), RuleMacro(M.norep)]
            public void norep()
            {
                REP = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.x66_prefix)]
            public void x66_prefix()
            {
                EOSZ = EOSZ.EOSZ16;
            }

            [MethodImpl(Inline), RuleMacro(M.nof3_prefix)]
            public void nof3_prefix()
            {
                REP = (byte)P.NOF3;
            }

            [MethodImpl(Inline), RuleMacro(M.no66_prefix)]
            public void no66_prefix()
            {
                EOSZ = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.not_refining)]
            public void not_refining()
            {
                REP = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.refining_f2)]
            public void refining_f2()
            {
                REP = (byte)P.REPF2;
            }

            [MethodImpl(Inline), RuleMacro(M.refining_f3)]
            public void refining_f3()
            {
                REP = (byte)P.REPF3;
            }

            [MethodImpl(Inline), RuleMacro(M.not_refining_f3)]
            public void not_refining_f3()
            {
                REP = (byte)P.NOF3;
            }

            [MethodImpl(Inline), RuleMacro(M.no_refining_prefix)]
            public void no_refining_prefix()
            {
                REP = 0;
                EOSZ = EOSZ.EOSZ16;
            }

            [MethodImpl(Inline), RuleMacro(M.osz_refining_prefix)]
            public void osz_refining_prefix()
            {
                REP = 0;
                EOSZ = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.f2_refining_prefix)]
            public void f2_refining_prefix()
            {
                REP = (byte)P.REPF2;
            }

            [MethodImpl(Inline), RuleMacro(M.f3_refining_prefix)]
            public void f3_refining_prefix()
            {
                REP = (byte)P.REPF3;
            }

            [MethodImpl(Inline), RuleMacro(M.no67_prefix)]
            public void no67_prefix()
            {
                ASZ = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.x67_prefix)]
            public void x67_prefix()
            {
                ASZ = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.lock_prefix)]
            public void lock_prefix()
            {
                LOCK = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.no_lock_prefix)]
            public void nolock_prefix()
            {
                LOCK = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.default_ds)]
            public void default_ds()
            {
                DEFAULT_SEG = (byte)D.DefaultDS;
            }

            [MethodImpl(Inline), RuleMacro(M.default_ss)]
            public void default_ss()
            {
                DEFAULT_SEG = (byte)D.DefaultSS;
            }

            [MethodImpl(Inline), RuleMacro(M.default_es)]
            public void default_es()
            {
                DEFAULT_SEG = (byte)D.DefaultES;
            }

            [MethodImpl(Inline), RuleMacro(M.no_seg_prefix)]
            public void no_seg_prefix()
            {
                SEG_OVD = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.cs_prefix)]
            public void cs_prefix()
            {
                SEG_OVD = (byte)CS;
            }

            [MethodImpl(Inline), RuleMacro(M.ds_prefix)]
            public void ds_prefix()
            {
                SEG_OVD = (byte)DS;
            }

            [MethodImpl(Inline), RuleMacro(M.es_prefix)]
            public void es_prefix()
            {
                SEG_OVD = (byte)ES;
            }

            [MethodImpl(Inline), RuleMacro(M.fs_prefix)]
            public void fs_prefix()
            {
                SEG_OVD = (byte)SegPrefixKind.FS;
            }

            [MethodImpl(Inline), RuleMacro(M.gs_prefix)]
            public void gs_prefix()
            {
                SEG_OVD = (byte)GS;
            }

            [MethodImpl(Inline), RuleMacro(M.ss_prefix)]
            public void ss_prefix()
            {
                SEG_OVD = (byte)SS;
            }

            [MethodImpl(Inline), RuleMacro(M.nrmw)]
            public void nrmw()
            {
                DF64 = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.df64)]
            public void df64()
            {
                DF64 = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.enc)]
            public void enc()
            {
                ENCODER_PREFERRED = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.no_return)]
            public void no_return()
            {
                NO_RETURN = 1;
            }

            [MethodImpl(Inline), RuleMacro(M.error)]
            public void error()
            {
                ERROR = ErrorKind.GENERAL_ERROR;
            }

            [MethodImpl(Inline), RuleMacro(M.@true)]
            public void @true()
            {
                DUMMY = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.XMAP8)]
            public void XMAP8()
            {
                MAP = 8;
            }

            [MethodImpl(Inline), RuleMacro(M.XMAP9)]
            public void XMAP9()
            {
                MAP = 9;
            }

            [MethodImpl(Inline), RuleMacro(M.XMAPA)]
            public void XMAPA()
            {
                MAP = 10;
            }

            [MethodImpl(Inline), RuleMacro(M.XOPV)]
            public void XOPV()
            {
                VEXVALID = VexKind.XOPV;
            }

            [MethodImpl(Inline), RuleMacro(M.VL128)]
            public void VL128()
            {
                VL = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.VL256)]
            public void VL256()
            {
                VL = V256;
            }

            [MethodImpl(Inline), RuleMacro(M.VL512)]
            public void VL512()
            {
                VL = V512;
            }

            [MethodImpl(Inline), RuleMacro(M.VV1)]
            public void VV1()
            {
                VEXVALID = VexKind.VV1;
            }

            [MethodImpl(Inline), RuleMacro(M.VV0)]
            public void VV0()
            {
                VEXVALID = VexKind.VV0;
            }

            [MethodImpl(Inline), RuleMacro(M.VMAP0)]
            public void VMAP0()
            {
                MAP = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.V0F)]
            public void V0F()
            {
                MAP = (byte)VEX_MAP_0F38;
            }

            [MethodImpl(Inline), RuleMacro(M.V0F38)]
            public void V0F38()
            {
                MAP = (byte)VEX_MAP_0F38;
            }

            [MethodImpl(Inline), RuleMacro(M.V0F3A)]
            public void V0F3A()
            {
                MAP = (byte)VEX_MAP_0F3A;
            }

            [MethodImpl(Inline), RuleMacro(M.VNP)]
            public void VNP()
            {
                VEX_PREFIX = V.VNP;
            }

            [MethodImpl(Inline), RuleMacro(M.V66)]
            public void V66()
            {
                VEX_PREFIX = V.V66;
            }

            [MethodImpl(Inline), RuleMacro(M.VF2)]
            public void VF2()
            {
                VEX_PREFIX = V.VF2;
            }

            [MethodImpl(Inline), RuleMacro(M.VF3)]
            public void VF3()
            {
                VEX_PREFIX = V.VF3;
            }

            [MethodImpl(Inline), RuleMacro(M.NOVSR)]
            public void NOVSR()
            {
                VEXDEST3=1;
                VEXDEST210=0b111;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_32)]
            public void EMX_BROADCAST_1TO4_32()
            {
                BCAST = B.BCast_1TO4_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_64)]
            public void EMX_BROADCAST_1TO4_64()
            {
                BCAST = B.BCast_1TO4_64;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_32)]
            public void EMX_BROADCAST_1TO8_32()
            {
               BCAST = B.BCast_1TO8_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO4_64)]
            public void EMX_BROADCAST_2TO4_64()
            {
               BCAST = B.BCast_2TO4_64;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_64)]
            public void EMX_BROADCAST_1TO2_64()
            {
               BCAST = B.BCast_1TO2_64;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_16)]
            public void EMX_BROADCAST_1TO8_16()
            {
               BCAST = B.BCast_1TO8_16;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO16_16)]
            public void EMX_BROADCAST_1TO16_16()
            {
               BCAST = B.BCast_1TO16_16;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO16_8)]
            public void EMX_BROADCAST_1TO16_8()
            {
               BCAST = B.BCast_1TO16_8;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO32_8)]
            public void EMX_BROADCAST_1TO32_8()
            {
               BCAST = B.BCast_1TO32_8;
            }

            [MethodImpl(Inline), RuleMacro(M.VLBAD)]
            public void VLBAD()
            {
                VL = VectorWidthCode.INVALID;
            }

            [MethodImpl(Inline), RuleMacro(M.KVV)]
            public void KVV()
            {
                VEXVALID = VexKind.KVV;
            }

            [MethodImpl(Inline), RuleMacro(M.NOEVSR)]
            public void NOEVSR()
            {
                VEXDEST3=1;
                VEXDEST210=0b111;
                VEXDEST4=0;
            }

            [MethodImpl(Inline), RuleMacro(M.NO_SPARSE_EVSR)]
            public void NO_SPARSE_EVSR()
            {
                VEXDEST3=1;
                VEXDEST210=0b111;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO16_32)]
            public void EMX_BROADCAST_1TO16_32()
            {
               BCAST = B.BCast_1TO16_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_4TO16_32)]
            public void EMX_BROADCAST_4TO16_32()
            {
               BCAST = B.BCast_4TO16_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_64)]
            public void EMX_BROADCAST_1TO8_64()
            {
               BCAST = B.BCast_1TO8_64;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_4TO8_64)]
            public void EMX_BROADCAST_4TO8_64()
            {
               BCAST = B.BCast_4TO8_64;
            }

            [MethodImpl(Inline), RuleMacro(M.EVV)]
            public void EVV()
            {
                VEXVALID = VexKind.EVV;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO16_32)]
            public void EMX_BROADCAST_2TO16_32()
            {
               BCAST = B.BCast_2TO16_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO8_64)]
            public void EMX_BROADCAST_2TO8_64()
            {
               BCAST = B.BCast_2TO8_64;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_8TO16_32)]
            public void EMX_BROADCAST_8TO16_32()
            {
               BCAST = B.BCast_8TO16_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO32_16)]
            public void EMX_BROADCAST_1TO32_16()
            {
               BCAST = B.BCast_1TO32_16;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO64_8)]
            public void EMX_BROADCAST_1TO64_8()
            {
               BCAST = B.BCast_1TO64_8;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_4TO8_32)]
            public void EMX_BROADCAST_4TO8_32()
            {
               BCAST = B.BCast_4TO8_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO4_32)]
            public void EMX_BROADCAST_2TO4_32()
            {
               BCAST = B.BCast_2TO4_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO8_32)]
            public void EMX_BROADCAST_2TO8_32()
            {
               BCAST = B.BCast_2TO8_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_32)]
            public void EMX_BROADCAST_1TO2_32()
            {
               BCAST = B.BCast_1TO2_32;
            }

            [MethodImpl(Inline), RuleMacro(M.EVEXRR_ONE)]
            public void EVEXRR_ONE()
            {
                REXRR = 0;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_8)]
            public void EMX_BROADCAST_1TO2_8()
            {
               BCAST = B.BCast_1TO2_8;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_8)]
            public void EMX_BROADCAST_1TO4_8()
            {
               BCAST = B.BCast_1TO4_8;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_8)]
            public void EMX_BROADCAST_1TO8_8()
            {
               BCAST = B.BCast_1TO8_8;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_16)]
            public void EMX_BROADCAST_1TO2_16()
            {
               BCAST = B.BCast_1TO2_16;
            }

            [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_16)]
            public void EMX_BROADCAST_1TO4_16()
            {
               BCAST = B.BCast_1TO4_16;
            }

            public static RuleState Empty => default;
        }
    }
}