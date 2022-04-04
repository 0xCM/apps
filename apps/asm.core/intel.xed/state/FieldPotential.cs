//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    //using Asm;

    using static XedModels;
    using static XedFields;
    using static DataStores;

    using K = XedRules.FieldKind;
    using X = XedModels;

    partial class XedRules
    {
        public unsafe class FieldPotential
        {
            public static FieldPotential create()
                => new FieldPotential();

            [MethodImpl(Inline)]
            static S2<bit> b01()
            {
                var dst = alloc<bit>(n2,2);
                dst[0] = bit.On;
                dst[1] = bit.Off;
                return dst;
            }

            //FieldSet Fields;

            //AttributeVector Attribs;

            public FieldPotential()
            {
                Data.ASZ = b01();
                Data.OSZ = b01();
                Data.DF32 = b01();
                Data.DF64 = b01();
                Data.NO_SCALE_DISP8 = b01();
                Data.AMD3DNOW = b01();
                Data.BCRC = b01();
                Data.CET = b01();
                Data.CLDEMOTE = b01();
                Data.DUMMY = b01();
                Data.ENCODER_PREFERRED = b01();
                Data.ENCODE_FORCE = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                Data.DF64 = b01();
                var kinds = Symbols.index<XedRegId>().Kinds;
                var data = core.first(core.recover<XedRegId,S568>(kinds));
                RegData = new(kinds.Length,data);
            }

            Potentials Data;

            S568<XedRegId> RegData;

            public ref readonly S568<XedRegId> Regs
            {
                [MethodImpl(Inline)]
                get => ref RegData;
            }

            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public struct Potentials
            {
                [RuleField(K.ASZ)]
                public S2<bit> ASZ;

                [RuleField(K.OSZ)]
                public S2<bit> OSZ;

                [RuleField(K.DF32)]
                public S2<bit> DF32;

                [RuleField(K.DF64)]
                public S2<bit> DF64;

                [RuleField(K.NO_SCALE_DISP8)]
                public S2<bit> NO_SCALE_DISP8;

                [RuleField(K.AMD3DNOW)]
                public S2<bit> AMD3DNOW;

                [RuleField(K.BCRC)]
                public S2<bit> BCRC;

                [RuleField(K.CET)]
                public S2<bit> CET;

                [RuleField(K.CLDEMOTE)]
                public S2<bit> CLDEMOTE;

                [RuleField(K.DUMMY)]
                public S2<bit> DUMMY;

                [RuleField(K.ENCODER_PREFERRED)]
                public S2<bit> ENCODER_PREFERRED;

                [RuleField(K.ENCODE_FORCE)]
                public S2<bit> ENCODE_FORCE;

                [RuleField(K.IMM0)]
                public S2<bit> IMM0;

                [RuleField(K.IMM0SIGNED)]
                public S2<bit> IMM0SIGNED;

                [RuleField(K.IMM1)]
                public S2<bit> IMM1;

                [RuleField(K.LZCNT)]
                public S2<bit> LZCNT;

                [RuleField(K.TZCNT)]
                public S2<bit> TZCNT;

                [RuleField(K.MODEP5)]
                public S2<bit> MODEP5;

                [RuleField(K.MODEP55C)]
                public S2<bit> MODEP55C;

                [RuleField(K.MODE_FIRST_PREFIX)]
                public S2<bit> MODE_FIRST_PREFIX;

                [RuleField(K.MODE_SHORT_UD0)]
                public S2<bit> MODE_SHORT_UD0;

                [RuleField(K.MPXMODE)]
                public S2<bit> MPXMODE;

                [RuleField(K.OUT_OF_BYTES)]
                public S2<bit> OUT_OF_BYTES;

                [RuleField(K.P4)]
                public S2<bit> P4;

                [RuleField(K.PTR)]
                public S2<bit> PTR;

                [RuleField(K.AGEN)]
                public S2<bit> AGEN;

                [RuleField(K.MEM0)]
                public S2<bit> MEM0;

                [RuleField(K.MEM1)]
                public S2<bit> MEM1;

                [RuleField(K.LOCK)]
                public S2<bit> LOCK;

                [RuleField(K.PREFIX66)]
                public S2<bit> PREFIX66;

                [RuleField(K.HAS_MODRM)]
                public S2<bit> HAS_MODRM;

                [RuleField(K.HAS_SIB)]
                public S2<bit> HAS_SIB;

                [RuleField(K.NEED_SIB)]
                public S2<bit> NEED_SIB;

                [RuleField(K.NEEDREX)]
                public S2<bit> NEEDREX;

                [RuleField(K.NOREX)]
                public S2<bit> NOREX;

                [RuleField(K.REX)]
                public S2<bit> REX;

                [RuleField(K.VEX_C4)]
                public S2<bit> VEX_C4;

                [RuleField(K.MUST_USE_EVEX)]
                public S2<bit> MUST_USE_EVEX;

                [RuleField(K.ZEROING)]
                public S2<bit> ZEROING;

                [RuleField(K.SAE)]
                public S2<bit> SAE;

                [RuleField(K.REALMODE)]
                public S2<bit> REALMODE;

                [RuleField(K.UBIT)]
                public S2<bit> UBIT;

                [RuleField(K.WBNOINVD)]
                public S2<bit> WBNOINVD;

                [RuleField(K.ILD_F2)]
                public S2<bit> ILD_F2;

                [RuleField(K.ILD_F3)]
                public S2<bit> ILD_F3;

                [RuleField(K.NEED_MEMDISP)]
                public S2<bit> NEED_MEMDISP;

                [RuleField(K.NO_RETURN)]
                public S2<bit> NO_RETURN;

                [RuleField(K.USING_DEFAULT_SEGMENT0)]
                public S2<bit> USING_DEFAULT_SEGMENT0;

                [RuleField(K.USING_DEFAULT_SEGMENT1)]
                public S2<bit> USING_DEFAULT_SEGMENT1;

                [RuleField(K.RELBR)]
                public S2<bit> RELBR;

                [RuleField(K.POS_NOMINAL_OPCODE)]
                public S16<byte> POS_NOMINAL_OPCODE;

                [RuleField(K.POS_MODRM)]
                public S16<byte> POS_MODRM;

                [RuleField(K.POS_SIB)]
                public S16<byte> POS_SIB;

                [RuleField(K.POS_IMM)]
                public S16<byte> POS_IMM;

                [RuleField(K.POS_IMM1)]
                public S16<byte> POS_IMM1;

                [RuleField(K.POS_DISP)]
                public S16<byte> POS_DISP;

                [RuleField(K.MODE)]
                public S5<MachineMode> MODE;

                [RuleField(K.SMODE)]
                public S3<SMode> SMODE;

                [RuleField(K.EASZ)]
                public S5<EASZ> EASZ;

                [RuleField(K.EOSZ)]
                public S6<EOSZ> EOSZ;

                [RuleField(K.NOMINAL_OPCODE)]
                public S256<Hex8> NOMINAL_OPCODE;

                [RuleField(K.NPREFIXES)]
                public S4<byte> NPREFIXES;

                [RuleField(K.NREXES)]
                public S4<byte> NREXES;

                [RuleField(K.NSEG_PREFIXES)]
                public S4<byte> NSEG_PREFIXES;

                [RuleField(K.REP)]
                public S4<RepPrefix> REP;

                [RuleField(K.SEG_OVD)]
                public S7<SegPrefixKind> SEG_OVD;

                [RuleField(K.HINT)]
                public S5<HintKind> HINT;

                [RuleField(K.MOD)]
                public S4<uint2> MOD;

                [RuleField(K.REG)]
                public S8<uint3> REG;

                [RuleField(K.RM)]
                public S8<uint3> RM;

                [RuleField(K.MODRM_BYTE)]
                public Hex8 MODRM_BYTE;

                [RuleField(K.SIBSCALE)]
                public S4<uint2> SIBSCALE;

                [RuleField(K.SIBBASE)]
                public S8<uint3> SIBBASE;

                [RuleField(K.SIBINDEX)]
                public S8<uint3> SIBINDEX;

                [RuleField(K.REXW)]
                public S2<bit> REXW;

                [RuleField(K.REXR)]
                public S2<bit> REXR;

                [RuleField(K.REXX)]
                public S2<bit> REXX;

                [RuleField(K.REXB)]
                public S2<bit> REXB;

                [RuleField(K.VEXVALID)]
                public S5<VexClass> VEXVALID;

                [RuleField(K.VEX_PREFIX)]
                public S4<VexKind> VEX_PREFIX;

                [RuleField(K.VL)]
                public S3<VexLengthKind> VL;

                [RuleField(K.REXRR)]
                public S2<bit> REXRR;

                [RuleField(K.VEXDEST4)]
                public S2<bit> VEXDEST4;

                [RuleField(K.VEXDEST3)]
                public S2<bit> VEXDEST3;

                [RuleField(K.VEXDEST210)]
                public S8<uint3> VEXDEST210;

                [RuleField(K.MASK)]
                public S8<MASK> MASK;

                [RuleField(K.ROUNDC)]
                public S5<ROUNDC> ROUNDC;

                [RuleField(K.BCAST)]
                public S32<BCastKind> BCAST;

                [RuleField(K.BASE0, 9, typeof(XedRegId))]
                public XedRegId BASE0;

                [RuleField(K.BASE1, 9, typeof(XedRegId))]
                public XedRegId BASE1;

                [RuleField(K.INDEX)]
                public XedRegId INDEX;

                [RuleField(K.SCALE)]
                public byte SCALE;

                [RuleField(K.IMM_WIDTH)]
                public byte IMM_WIDTH;

                [RuleField(K.IMM1_BYTES)]
                public byte IMM1_BYTES;

                [RuleField(K.DEFAULT_SEG)]
                public byte DEFAULT_SEG;

                [RuleField(K.FIRST_F2F3)]
                public byte FIRST_F2F3;

                [RuleField(K.LAST_F2F3)]
                public byte LAST_F2F3;

                [RuleField(K.LLRC)]
                public S4<LLRC> LLRC;

                [RuleField(K.SRM)]
                public byte SRM;

                [RuleField(K.ESRC)]
                public S16<ESRC> ESRC;

                [RuleField(K.MAP)]
                public S16<byte> MAP;

                [RuleField(K.BRDISP_WIDTH)]
                public S4<BrDispWidth> BRDISP_WIDTH;

                [RuleField(K.ILD_SEG)]
                public byte ILD_SEG;

                [RuleField(FieldKind.MAX_BYTES)]
                public S16<byte> MAX_BYTES;

                [RuleField(K.NELEM, 4, typeof(byte))]
                public byte NELEM;

                [RuleField(K.ELEMENT_SIZE, 9, typeof(ushort))]
                public ushort ELEMENT_SIZE;

                [RuleField(K.MEM_WIDTH, 16, typeof(ushort))]
                public ushort MEM_WIDTH;

                [RuleField(K.UIMM0, 64, typeof(imm64))]
                public imm64 UIMM0;

                [RuleField(K.UIMM1, 8, typeof(Asm.imm8))]
                public Asm.imm8 UIMM1;

                [RuleField(K.ICLASS, 16, typeof(IClass))]
                public IClass ICLASS;

                [RuleField(K.CHIP, 8, typeof(ChipCode))]
                public ChipCode CHIP;

                [RuleField(K.OUTREG, 9, typeof(XedRegId))]
                public XedRegId OUTREG;

                [RuleField(K.REG0)]
                public XedRegId REG0;

                [RuleField(K.REG1)]
                public XedRegId REG1;

                [RuleField(K.REG2)]
                public XedRegId REG2;

                [RuleField(K.REG3)]
                public XedRegId REG3;

                [RuleField(K.REG4)]
                public XedRegId REG4;

                [RuleField(K.REG5)]
                public XedRegId REG5;

                [RuleField(K.REG6)]
                public XedRegId REG6;

                [RuleField(K.REG7)]
                public XedRegId REG7;

                [RuleField(K.REG8)]
                public XedRegId REG8;

                [RuleField(K.REG9)]
                public XedRegId REG9;

                [RuleField(K.SEG0)]
                public XedRegId SEG0;

                [RuleField(K.SEG1)]
                public XedRegId SEG1;

                [RuleField(K.ERROR)]
                public ErrorKind ERROR;

                [RuleField(K.DISP_WIDTH)]
                public byte DISP_WIDTH;
            }
        }
    }
}