//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.SMode;
    using static XedModels.RepPrefix;
    using static XedModels.SegPrefixKind;

    using RPX = XedModels.RepPrefix;

    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential), ApiComplete("xed.machinestate")]
        public struct MachineState
        {
            public Mode MODE;

            public EASZ EASZ;

            public EOSZ EOSZ;

            public SMode SMODE;

            public bit REX;

            public bit REXW;

            public bit REXB;

            public bit REXR;

            public bit REXX;

            public RPX REP;

            public bit ASZ;

            public bit LOCK;

            public SegPrefixKind SEG_OVD;

            public bit DF64;

            public XedBCastKind BCAST;

            public VexValidityKind VEXVALID;

            public byte VL;

            public VexPrefixKind VEX_PREFIX;

            public uint4 MAP;

            public uint3 VEXDEST210;

            public bit VEXDEST3;

            public bit VEXDEST4;

            public bit REXRR;

            public uint2 MOD;

            public SegDefaultKind DEFAULT_SEG;

            public bit NO_RETURN;

            public ErrorKind ERROR;

            public bit DUMMY;

            public bit ENC;

            bit RepNeq3;

            bit SegPrefixNeq0;

            [MethodImpl(Inline)]
            public void not64()
            {
                MODE = Mode.Not64;
            }

            [MethodImpl(Inline)]
            public void mode64()
            {
                MODE = Mode.Mode64;
            }

            [MethodImpl(Inline)]
            public void mode32()
            {
                MODE = Mode.Mode32;
            }

            [MethodImpl(Inline)]
            public void mode16()
            {
                MODE = Mode.Mode16;
            }

            [MethodImpl(Inline)]
            public void eanot16()
            {
                EASZ = EASZNot16;
            }

            [MethodImpl(Inline)]
            public void eamode16()
            {
                EASZ = EASZ16;
            }

            [MethodImpl(Inline)]
            public void eamode32()
            {
                EASZ = EASZ32;
            }

            [MethodImpl(Inline)]
            public void eamode64()
            {
                EASZ = EASZ64;
            }

            [MethodImpl(Inline)]
            public void smode16()
            {
                SMODE = SMode16;
            }

            [MethodImpl(Inline)]
            public void smode32()
            {
                SMODE = SMode32;
            }

            [MethodImpl(Inline)]
            public void smode64()
            {
                SMODE = SMode64;
            }

            [MethodImpl(Inline)]
            public void eosz8()
            {
                EOSZ = EOSZ8;
            }

            [MethodImpl(Inline)]
            public void eosz16()
            {
                EOSZ = EOSZ16;
            }

            [MethodImpl(Inline)]
            public void eosz32()
            {
                EOSZ = EOSZ32;
            }

            [MethodImpl(Inline)]
            public void eosz64()
            {
                EOSZ = EOSZ64;
            }

            [MethodImpl(Inline)]
            public void not_eosz16()
            {
                EOSZ = EOSZNot16;
            }

            [MethodImpl(Inline)]
            public void eosznot64()
            {
                EOSZ = EOSZNot64;
            }

            [MethodImpl(Inline)]
            public void rex_reqd()
            {
                REX = 1;
            }

            [MethodImpl(Inline)]
            public void no_rex()
            {
                REX = 0;
            }

            [MethodImpl(Inline)]
            public void reset_rex()
            {
                REX = 0;
                REXW = 0;
                REXB = 0;
                REXR = 0;
                REXX = 0;
            }

            [MethodImpl(Inline)]
            public void rexb_prefix()
            {
                REXB = 1;
            }

            [MethodImpl(Inline)]
            public void norexb_prefix()
            {
                REXB = 0;
            }

            [MethodImpl(Inline)]
            public void rexx_prefix()
            {
                REXX = 1;
            }

            [MethodImpl(Inline)]
            public void norexx_prefix()
            {
                REXX = 0;
            }

            [MethodImpl(Inline)]
            public void rexr_prefix()
            {
                REXR = 1;
            }

            [MethodImpl(Inline)]
            public void norexr_prefix()
            {
                REXR = 0;
            }

            [MethodImpl(Inline)]
            public void rexw_prefix()
            {
                REXW = 1;
            }

            [MethodImpl(Inline)]
            public void norexw_prefix()
            {
                REXW = 0;
            }

            [MethodImpl(Inline)]
            public void W0()
            {
                REXW = 0;
            }

            [MethodImpl(Inline)]
            public void W1()
            {
                REXW = 1;
            }

            [MethodImpl(Inline)]
            public void f2_prefix()
            {
                REP = REPF2;
            }

            [MethodImpl(Inline)]
            public void f3_prefix()
            {
                REP = REPF3;
            }

            [MethodImpl(Inline)]
            public void repne()
            {
                REP = REPF2;
            }

            [MethodImpl(Inline)]
            public void repe()
            {
                REP = REPF3;
            }

            [MethodImpl(Inline)]
            public void norep()
            {
                REP = 0;
            }

            [MethodImpl(Inline), Name("66_prefix")]
            public void x66_prefix()
            {
                EOSZ = EOSZ.EOSZ16;
            }

            [MethodImpl(Inline)]
            public void nof3_prefix()
            {
                RepNeq3 = true;
            }

            [MethodImpl(Inline)]
            public void no66_prefix()
            {
                EOSZ = 0;
            }

            [MethodImpl(Inline)]
            public void not_refining()
            {
                REP = 0;
            }

            [MethodImpl(Inline)]
            public void refining_f2()
            {
                REP = RPX.REPF2;
            }

            [MethodImpl(Inline)]
            public void refining_f3()
            {
                REP = RPX.REPF3;
            }

            [MethodImpl(Inline)]
            public void not_refining_f3()
            {
                RepNeq3 = true;
            }

            [MethodImpl(Inline)]
            public void no_refining_prefix()
            {
                REP = 0;
                EOSZ = EOSZ.EOSZ16;
            }

            [MethodImpl(Inline)]
            public void osz_refining_prefix()
            {
                REP = 0;
                EOSZ = 0;
            }

            [MethodImpl(Inline)]
            public void f2_refining_prefix()
            {
                REP = RPX.REPF2;
            }

            [MethodImpl(Inline)]
            public void f3_refining_prefix()
            {
                REP = RPX.REPF3;
            }

            [MethodImpl(Inline)]
            public void no67_prefix()
            {
                ASZ = 0;
            }

            [MethodImpl(Inline), Name("67_prefix")]
            public void x67_prefix()
            {
                ASZ = 1;
            }

            [MethodImpl(Inline)]
            public void lock_prefix()
            {
                LOCK = 1;
            }

            [MethodImpl(Inline)]
            public void nolock_prefix()
            {
                LOCK = 0;
            }

            [MethodImpl(Inline)]
            public void default_ds()
            {
                DEFAULT_SEG = SegDefaultKind.DefaultDS;
            }

            [MethodImpl(Inline)]
            public void default_ss()
            {
                DEFAULT_SEG = SegDefaultKind.DefaultSS;
            }

            [MethodImpl(Inline)]
            public void default_es()
            {
                DEFAULT_SEG = SegDefaultKind.DefaultES;
            }

            [MethodImpl(Inline)]
            public void no_seg_prefix()
            {
                SEG_OVD = 0;
            }

            [MethodImpl(Inline)]
            public void some_seg_prefix()
            {
                SegPrefixNeq0 = true;
            }

            [MethodImpl(Inline)]
            public void cs_prefix()
            {
                SEG_OVD = CS;
            }

            [MethodImpl(Inline)]
            public void ds_prefix()
            {
                SEG_OVD = DS;
            }

            [MethodImpl(Inline)]
            public void es_prefix()
            {
                SEG_OVD = ES;
            }

            [MethodImpl(Inline)]
            public void fs_prefix()
            {
                SEG_OVD = SegPrefixKind.FS;
            }

            [MethodImpl(Inline)]
            public void gs_prefix()
            {
                SEG_OVD = GS;
            }

            [MethodImpl(Inline)]
            public void ss_prefix()
            {
                SEG_OVD = SS;
            }

            [MethodImpl(Inline)]
            public void nrmw()
            {
                DF64 = 0;
            }

            [MethodImpl(Inline)]
            public void df64()
            {
                DF64 = 1;
            }

            [MethodImpl(Inline)]
            public void enc()
            {

            }

            [MethodImpl(Inline)]
            public void no_return()
            {
                NO_RETURN = 1;
            }

            [MethodImpl(Inline)]
            public void error()
            {
                ERROR = ErrorKind.GENERAL_ERROR;
            }

            [MethodImpl(Inline), Name("true")]
            public void @true()
            {
                DUMMY = 0;
            }

            [MethodImpl(Inline)]
            public void XMAP8()
            {
                MAP = 8;
            }

            [MethodImpl(Inline)]
            public void XMAP9()
            {
                MAP = 9;
            }

            [MethodImpl(Inline)]
            public void XMAPA()
            {
                MAP = 10;
            }

            [MethodImpl(Inline)]
            public void XOPV()
            {
                VEXVALID = VexValidityKind.XOPV;
            }

            [MethodImpl(Inline)]
            public void VL128()
            {
                VL = 0;
            }

            [MethodImpl(Inline)]
            public void VL256()
            {
                VL = 1;
            }

            [MethodImpl(Inline)]
            public void VV1()
            {
                VEXVALID = VexValidityKind.VV1;
            }

            [MethodImpl(Inline)]
            public void VV0()
            {
                VEXVALID = VexValidityKind.VV0;
            }

            [MethodImpl(Inline)]
            public void VMAP0()
            {
                MAP = 0;
            }

            [MethodImpl(Inline)]
            public void V0F()
            {
                MAP = (byte)VexMapKind.VEX_MAP_0F38;
            }

            [MethodImpl(Inline)]
            public void V0F38()
            {
                MAP = (byte)VexMapKind.VEX_MAP_0F38;
            }

            [MethodImpl(Inline)]
            public void V0F3A()
            {
                MAP = (byte)VexMapKind.VEX_MAP_0F3A;
            }

            [MethodImpl(Inline)]
            public void VNP()
            {
                VEX_PREFIX = VexPrefixKind.VNP;
            }

            [MethodImpl(Inline)]
            public void V66()
            {
                VEX_PREFIX = VexPrefixKind.V66;
            }

            [MethodImpl(Inline)]
            public void VF2()
            {
                VEX_PREFIX = VexPrefixKind.VF2;
            }

            [MethodImpl(Inline)]
            public void VF3()
            {
                VEX_PREFIX = VexPrefixKind.VF3;
            }

            [MethodImpl(Inline)]
            public void NOVSR()
            {
                VEXDEST3=1;
                VEXDEST210=0b111;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO4_32()
            {
                BCAST = XedBCastKind.BCast_1TO4_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO4_64()
            {
                BCAST = XedBCastKind.BCast_1TO4_64;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO8_32()
            {
               BCAST = XedBCastKind.BCast_1TO8_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_2TO4_64()
            {
               BCAST = XedBCastKind.BCast_2TO4_64;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO2_64()
            {
               BCAST = XedBCastKind.BCast_1TO2_64;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO8_16()
            {
               BCAST = XedBCastKind.BCast_1TO8_16;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO16_16()
            {
               BCAST = XedBCastKind.BCast_1TO16_16;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO16_8()
            {
               BCAST = XedBCastKind.BCast_1TO16_8;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO32_8()
            {
               BCAST = XedBCastKind.BCast_1TO32_8;
            }

            [MethodImpl(Inline)]
            public void VL512()
            {
                VL = 2;
            }

            [MethodImpl(Inline)]
            public void VLBAD()
            {
                VL = 3;
            }

            [MethodImpl(Inline)]
            public void KVV()
            {
                VEXVALID = VexValidityKind.KVV;
            }

            [MethodImpl(Inline)]
            public void NOEVSR()
            {
                VEXDEST3=1;
                VEXDEST210=0b111;
                VEXDEST4=0;
            }

            [MethodImpl(Inline)]
            public void NO_SPARSE_EVSR()
            {
                VEXDEST3=1;
                VEXDEST210=0b111;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO16_32()
            {
               BCAST = XedBCastKind.BCast_1TO16_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_4TO16_32()
            {
               BCAST = XedBCastKind.BCast_4TO16_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO8_64()
            {
               BCAST = XedBCastKind.BCast_1TO8_64;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_4TO8_64()
            {
               BCAST = XedBCastKind.BCast_4TO8_64;
            }

            [MethodImpl(Inline)]
            public void EVV()
            {
                VEXVALID = VexValidityKind.EVV;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_2TO16_32()
            {
               BCAST = XedBCastKind.BCast_2TO16_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_2TO8_64()
            {
               BCAST = XedBCastKind.BCast_2TO8_64;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_8TO16_32()
            {
               BCAST = XedBCastKind.BCast_8TO16_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO32_16()
            {
               BCAST = XedBCastKind.BCast_1TO32_16;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO64_8()
            {
               BCAST = XedBCastKind.BCast_1TO64_8;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_4TO8_32()
            {
               BCAST = XedBCastKind.BCast_4TO8_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_2TO4_32()
            {
               BCAST = XedBCastKind.BCast_2TO4_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_2TO8_32()
            {
               BCAST = XedBCastKind.BCast_2TO8_32;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO2_32()
            {
               BCAST = XedBCastKind.BCast_1TO2_32;
            }

            [MethodImpl(Inline)]
            public void EVEXRR_ONE()
            {
                REXRR = 0;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO2_8()
            {
               BCAST = XedBCastKind.BCast_1TO2_8;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO4_8()
            {
               BCAST = XedBCastKind.BCast_1TO4_8;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO8_8()
            {
               BCAST = XedBCastKind.BCast_1TO8_8;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO2_16()
            {
               BCAST = XedBCastKind.BCast_1TO2_16;
            }

            [MethodImpl(Inline)]
            public void EMX_BROADCAST_1TO4_16()
            {
               BCAST = XedBCastKind.BCast_1TO4_16;
            }
        }
    }
}