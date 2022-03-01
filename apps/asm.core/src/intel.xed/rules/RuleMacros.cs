//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules.MacroSpec;
    using static Asm.AsmPrefixCodes;
    using static Asm.AsmPrefixCodes.VectorWidthCode;
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.SMode;
    using static XedModels.SegPrefixKind;
    using static XedModels.VexMapKind;

    using K = XedModels.FieldKind;
    using M = XedModels.RuleMacroName;

    partial class XedRules
    {
        [ApiHost("xed.rules.macros")]
        public readonly struct RuleMacros
        {
            [MethodImpl(Inline), Op]
            public static MacroSpec mod0()
                => assign(M.mod0, K.MOD, 0);

            [MethodImpl(Inline), Op]
            public static MacroSpec mod1()
                => assign(M.mod1, K.MOD, 1);

            [MethodImpl(Inline), Op]
            public static MacroSpec mod2()
                => assign(M.mod2, K.MOD, 2);

            [MethodImpl(Inline), Op]
            public static MacroSpec mod3()
                => assign(M.mod3, K.MOD, 2);

            [MethodImpl(Inline), Op]
            public static MacroSpec not64()
                => assign(M.not64, K.MODE, ModeKind.Not64);

            [MethodImpl(Inline), Op]
            public static MacroSpec mode64()
                => assign(M.mode64, K.MODE, ModeKind.Mode64);

            [MethodImpl(Inline), Op]
            public static MacroSpec mode32()
                => assign(M.mode32, K.MODE, ModeKind.Mode32);

            [MethodImpl(Inline), Op]
            public static MacroSpec mode16()
                => assign(M.mode16, K.MODE, ModeKind.Mode16);

            [MethodImpl(Inline), Op]
            public static MacroSpec eanot16()
                => assign(M.eanot16, K.MODE, EASZNot16);

            [MethodImpl(Inline), Op]
            public static MacroSpec eamode16()
                => assign(M.eamode16, K.MODE, EASZ16);

            [MethodImpl(Inline), Op]
            public static MacroSpec eamode32()
                => assign(M.eamode32, K.MODE, EASZ32);

            [MethodImpl(Inline), Op]
            public static MacroSpec eamode64()
                => assign(M.eamode64, K.MODE, EASZ64);

            [MethodImpl(Inline), Op]
            public static MacroSpec smode16()
                => assign(M.smode16, K.SMODE, SMode16);

            [MethodImpl(Inline), Op]
            public static MacroSpec smode32()
                => assign(M.smode32, K.SMODE, SMode32);

            [MethodImpl(Inline), Op]
            public static MacroSpec smode64()
                => assign(M.smode64, K.SMODE, SMode64);

            [MethodImpl(Inline), Op]
            public static MacroSpec eosz8()
                => assign(M.eosz8, K.EOSZ, EOSZ8);

            [MethodImpl(Inline), Op]
            public static MacroSpec eosz16()
                => assign(M.eosz16, K.EOSZ, EOSZ16);

            [MethodImpl(Inline), Op]
            public static MacroSpec eosz32()
                => assign(M.eosz32, K.EOSZ, EOSZ32);

            [MethodImpl(Inline), Op]
            public static MacroSpec eosz64()
                => assign(M.eosz64, K.EOSZ, EOSZ64);

            [MethodImpl(Inline), Op]
            public static MacroSpec not_eosz16()
                => assign(M.not_eosz16, K.EOSZ, EOSZNot16);

            [MethodImpl(Inline), Op]
            public static MacroSpec eosznot64()
                => assign(M.eosznot64, K.EOSZ, EOSZNot64);

            // [MethodImpl(Inline), RuleMacro(M.rex_reqd)]
            // public static AssignmentRule rex_reqd()
            // {
            //     REX = 1;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no_rex)]
            // public static AssignmentRule no_rex()
            // {
            //     REX = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.reset_rex)]
            // public static AssignmentRule reset_rex()
            // {
            //     REX = 0;
            //     REXW = 0;
            //     REXB = 0;
            //     REXR = 0;
            //     REXX = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.rexb_prefix)]
            // public static AssignmentRule rexb_prefix()
            // {
            //     REXB = 1;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.norexb_prefix)]
            // public static AssignmentRule norexb_prefix()
            // {
            //     REXB = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.rexx_prefix)]
            // public static AssignmentRule rexx_prefix()
            // {
            //     REXX = 1;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.norexx_prefix)]
            // public static AssignmentRule norexx_prefix()
            // {
            //     REXX = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.rexr_prefix)]
            // public static AssignmentRule rexr_prefix()
            // {
            //     REXR = 1;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.norexr_prefix)]
            // public static AssignmentRule norexr_prefix()
            // {
            //     REXR = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.rexw_prefix)]
            // public static AssignmentRule rexw_prefix()
            // {
            //     REXW = 1;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.norexw_prefix)]
            // public static AssignmentRule norexw_prefix()
            // {
            //     REXW = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.W0)]
            // public static AssignmentRule W0()
            // {
            //     REXW = 0;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.W1)]
            // public static AssignmentRule W1()
            // {
            //     REXW = 1;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.f2_prefix)]
            // public static AssignmentRule f2_prefix()
            // {
            //     REP = (byte)P.REPF2;
            //     return Empty;
            // }

            // [MethodImpl(Inline), RuleMacro(M.f3_prefix)]
            // public static AssignmentRule f3_prefix()
            // {
            //     REP = (byte)P.REPF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.repne)]
            // public static AssignmentRule repne()
            // {
            //     REP = (byte)P.REPF2;
            // }

            // [MethodImpl(Inline), RuleMacro(M.repe)]
            // public static AssignmentRule repe()
            // {
            //     REP = (byte)P.REPF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.norep)]
            // public static AssignmentRule norep()
            // {
            //     REP = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.x66_prefix)]
            // public static AssignmentRule x66_prefix()
            // {
            //     OSZ = (byte)EOSZ16;
            // }

            // [MethodImpl(Inline), RuleMacro(M.nof3_prefix)]
            // public static AssignmentRule nof3_prefix()
            // {
            //     REP = (byte)P.NOF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no66_prefix)]
            // public static AssignmentRule no66_prefix()
            // {
            //     EOSZ = (byte)EOSZ8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.not_refining)]
            // public static AssignmentRule not_refining()
            // {
            //     REP = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.refining_f2)]
            // public static AssignmentRule refining_f2()
            // {
            //     REP = (byte)P.REPF2;
            // }

            // [MethodImpl(Inline), RuleMacro(M.refining_f3)]
            // public static AssignmentRule refining_f3()
            // {
            //     REP = (byte)P.REPF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.not_refining_f3)]
            // public static AssignmentRule not_refining_f3()
            // {
            //     REP = (byte)P.NOF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no_refining_prefix)]
            // public static AssignmentRule no_refining_prefix()
            // {
            //     REP = 0;
            //     EOSZ = (byte)EOSZ16;
            // }

            // [MethodImpl(Inline), RuleMacro(M.osz_refining_prefix)]
            // public static AssignmentRule osz_refining_prefix()
            // {
            //     REP = 0;
            //     EOSZ = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.f2_refining_prefix)]
            // public static AssignmentRule f2_refining_prefix()
            // {
            //     REP = (byte)P.REPF2;
            // }

            // [MethodImpl(Inline), RuleMacro(M.f3_refining_prefix)]
            // public static AssignmentRule f3_refining_prefix()
            // {
            //     REP = (byte)P.REPF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no67_prefix)]
            // public static AssignmentRule no67_prefix()
            // {
            //     ASZ = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.x67_prefix)]
            // public static AssignmentRule x67_prefix()
            // {
            //     ASZ = 1;
            // }

            // [MethodImpl(Inline), RuleMacro(M.lock_prefix)]
            // public static AssignmentRule lock_prefix()
            // {
            //     LOCK = 1;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no_lock_prefix)]
            // public static AssignmentRule nolock_prefix()
            // {
            //     LOCK = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.default_ds)]
            // public static AssignmentRule default_ds()
            // {
            //     DEFAULT_SEG = (byte)D.DefaultDS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.default_ss)]
            // public static AssignmentRule default_ss()
            // {
            //     DEFAULT_SEG = (byte)D.DefaultSS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.default_es)]
            // public static AssignmentRule default_es()
            // {
            //     DEFAULT_SEG = (byte)D.DefaultES;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no_seg_prefix)]
            // public static AssignmentRule no_seg_prefix()
            // {
            //     SEG_OVD = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.cs_prefix)]
            // public static AssignmentRule cs_prefix()
            // {
            //     SEG_OVD = (byte)CS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.ds_prefix)]
            // public static AssignmentRule ds_prefix()
            // {
            //     SEG_OVD = (byte)DS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.es_prefix)]
            // public static AssignmentRule es_prefix()
            // {
            //     SEG_OVD = (byte)ES;
            // }

            // [MethodImpl(Inline), RuleMacro(M.fs_prefix)]
            // public static AssignmentRule fs_prefix()
            // {
            //     SEG_OVD = (byte)SegPrefixKind.FS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.gs_prefix)]
            // public static AssignmentRule gs_prefix()
            // {
            //     SEG_OVD = (byte)GS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.ss_prefix)]
            // public static AssignmentRule ss_prefix()
            // {
            //     SEG_OVD = (byte)SS;
            // }

            // [MethodImpl(Inline), RuleMacro(M.nrmw)]
            // public static AssignmentRule nrmw()
            // {
            //     DF64 = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.df64)]
            // public static AssignmentRule df64()
            // {
            //     DF64 = 1;
            // }

            // [MethodImpl(Inline), RuleMacro(M.enc)]
            // public static AssignmentRule enc()
            // {
            //     ENCODER_PREFERRED = 1;
            // }

            // [MethodImpl(Inline), RuleMacro(M.no_return)]
            // public static AssignmentRule no_return()
            // {
            //     NO_RETURN = 1;
            // }

            // [MethodImpl(Inline), RuleMacro(M.error)]
            // public static AssignmentRule error()
            // {
            //     ERROR = ErrorKind.GENERAL_ERROR;
            // }

            // [MethodImpl(Inline), RuleMacro(M.@true)]
            // public static AssignmentRule @true()
            // {
            //     DUMMY = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.XMAP8)]
            // public static AssignmentRule XMAP8()
            // {
            //     MAP = 8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.XMAP9)]
            // public static AssignmentRule XMAP9()
            // {
            //     MAP = 9;
            // }

            // [MethodImpl(Inline), RuleMacro(M.XMAPA)]
            // public static AssignmentRule XMAPA()
            // {
            //     MAP = 10;
            // }

            // [MethodImpl(Inline), RuleMacro(M.XOPV)]
            // public static AssignmentRule XOPV()
            // {
            //     VEXVALID = (byte)VexKind.XOPV;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VL128)]
            // public static AssignmentRule VL128()
            // {
            //     VL = (byte)V128;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VL256)]
            // public static AssignmentRule VL256()
            // {
            //     VL = (byte)V256;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VL512)]
            // public static AssignmentRule VL512()
            // {
            //     VL = (byte)V512;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VV1)]
            // public static AssignmentRule VV1()
            // {
            //     VEXVALID = (byte)VexKind.VV1;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VV0)]
            // public static AssignmentRule VV0()
            // {
            //     VEXVALID = (byte)VexKind.VV0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VMAP0)]
            // public static AssignmentRule VMAP0()
            // {
            //     MAP = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.V0F)]
            // public static AssignmentRule V0F()
            // {
            //     MAP = (byte)VEX_MAP_0F38;
            // }

            // [MethodImpl(Inline), RuleMacro(M.V0F38)]
            // public static AssignmentRule V0F38()
            // {
            //     MAP = (byte)VEX_MAP_0F38;
            // }

            // [MethodImpl(Inline), RuleMacro(M.V0F3A)]
            // public static AssignmentRule V0F3A()
            // {
            //     MAP = (byte)VEX_MAP_0F3A;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VNP)]
            // public static AssignmentRule VNP()
            // {
            //     VEX_PREFIX = (byte)V.VNP;
            // }

            // [MethodImpl(Inline), RuleMacro(M.V66)]
            // public static AssignmentRule V66()
            // {
            //     VEX_PREFIX = (byte)V.V66;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VF2)]
            // public static AssignmentRule VF2()
            // {
            //     VEX_PREFIX = (byte)V.VF2;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VF3)]
            // public static AssignmentRule VF3()
            // {
            //     VEX_PREFIX = (byte)V.VF3;
            // }

            // [MethodImpl(Inline), RuleMacro(M.NOVSR)]
            // public static AssignmentRule NOVSR()
            // {
            //     VEXDEST3=1;
            //     VEXDEST210=0b111;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_32)]
            // public static AssignmentRule EMX_BROADCAST_1TO4_32()
            // {
            //     BCAST = B.BCast_1TO4_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_64)]
            // public static AssignmentRule EMX_BROADCAST_1TO4_64()
            // {
            //     BCAST = B.BCast_1TO4_64;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_32)]
            // public static AssignmentRule EMX_BROADCAST_1TO8_32()
            // {
            //    BCAST = B.BCast_1TO8_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO4_64)]
            // public static AssignmentRule EMX_BROADCAST_2TO4_64()
            // {
            //    BCAST = B.BCast_2TO4_64;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_64)]
            // public static AssignmentRule EMX_BROADCAST_1TO2_64()
            // {
            //    BCAST = B.BCast_1TO2_64;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_16)]
            // public static AssignmentRule EMX_BROADCAST_1TO8_16()
            // {
            //    BCAST = B.BCast_1TO8_16;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO16_16)]
            // public static AssignmentRule EMX_BROADCAST_1TO16_16()
            // {
            //    BCAST = B.BCast_1TO16_16;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO16_8)]
            // public static AssignmentRule EMX_BROADCAST_1TO16_8()
            // {
            //    BCAST = B.BCast_1TO16_8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO32_8)]
            // public static AssignmentRule EMX_BROADCAST_1TO32_8()
            // {
            //    BCAST = B.BCast_1TO32_8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.VLBAD)]
            // public static AssignmentRule VLBAD()
            // {
            //     VL = (byte)VectorWidthCode.INVALID;
            // }

            // [MethodImpl(Inline), RuleMacro(M.KVV)]
            // public static AssignmentRule KVV()
            // {
            //     VEXVALID = (byte)VexKind.KVV;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EVV)]
            // public static AssignmentRule EVV()
            // {
            //     VEXVALID = (byte)VexKind.EVV;
            // }

            // [MethodImpl(Inline), RuleMacro(M.NOEVSR)]
            // public static AssignmentRule NOEVSR()
            // {
            //     VEXDEST3=1;
            //     VEXDEST210=0b111;
            //     VEXDEST4=0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.NO_SPARSE_EVSR)]
            // public static AssignmentRule NO_SPARSE_EVSR()
            // {
            //     VEXDEST3=1;
            //     VEXDEST210=0b111;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO16_32)]
            // public static AssignmentRule EMX_BROADCAST_1TO16_32()
            // {
            //    BCAST = B.BCast_1TO16_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_4TO16_32)]
            // public static AssignmentRule EMX_BROADCAST_4TO16_32()
            // {
            //    BCAST = B.BCast_4TO16_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_64)]
            // public static AssignmentRule EMX_BROADCAST_1TO8_64()
            // {
            //    BCAST = B.BCast_1TO8_64;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_4TO8_64)]
            // public static AssignmentRule EMX_BROADCAST_4TO8_64()
            // {
            //    BCAST = B.BCast_4TO8_64;
            // }


            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO16_32)]
            // public static AssignmentRule EMX_BROADCAST_2TO16_32()
            // {
            //    BCAST = B.BCast_2TO16_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO8_64)]
            // public static AssignmentRule EMX_BROADCAST_2TO8_64()
            // {
            //    BCAST = B.BCast_2TO8_64;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_8TO16_32)]
            // public static AssignmentRule EMX_BROADCAST_8TO16_32()
            // {
            //    BCAST = B.BCast_8TO16_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO32_16)]
            // public static AssignmentRule EMX_BROADCAST_1TO32_16()
            // {
            //    BCAST = B.BCast_1TO32_16;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO64_8)]
            // public static AssignmentRule EMX_BROADCAST_1TO64_8()
            // {
            //    BCAST = B.BCast_1TO64_8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_4TO8_32)]
            // public static AssignmentRule EMX_BROADCAST_4TO8_32()
            // {
            //    BCAST = B.BCast_4TO8_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO4_32)]
            // public static AssignmentRule EMX_BROADCAST_2TO4_32()
            // {
            //    BCAST = B.BCast_2TO4_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_2TO8_32)]
            // public static AssignmentRule EMX_BROADCAST_2TO8_32()
            // {
            //    BCAST = B.BCast_2TO8_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_32)]
            // public static AssignmentRule EMX_BROADCAST_1TO2_32()
            // {
            //    BCAST = B.BCast_1TO2_32;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EVEXRR_ONE)]
            // public static AssignmentRule EVEXRR_ONE()
            // {
            //     REXRR = 0;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_8)]
            // public static AssignmentRule EMX_BROADCAST_1TO2_8()
            // {
            //    BCAST = B.BCast_1TO2_8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_8)]
            // public static AssignmentRule EMX_BROADCAST_1TO4_8()
            // {
            //    BCAST = B.BCast_1TO4_8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO8_8)]
            // public static AssignmentRule EMX_BROADCAST_1TO8_8()
            // {
            //    BCAST = B.BCast_1TO8_8;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO2_16)]
            // public static AssignmentRule EMX_BROADCAST_1TO2_16()
            // {
            //    BCAST = B.BCast_1TO2_16;
            // }

            // [MethodImpl(Inline), RuleMacro(M.EMX_BROADCAST_1TO4_16)]
            // public static AssignmentRule EMX_BROADCAST_1TO4_16()
            // {
            //    BCAST = B.BCast_1TO4_16;
            // }

            [MethodImpl(Inline), Op, Closures(Closure)]
            static FieldAssignment assign<T>(FieldKind field, T value)
                where T : unmanaged
                    => new FieldAssignment(field, core.bw64(value));

            [MethodImpl(Inline), Op, Closures(Closure)]
            static MacroSpec assign<T>(RuleMacroName name, FieldKind field, T value)
                where T : unmanaged
                    => new MacroSpec(name,assign(field,value));

            [MethodImpl(Inline), Op]
            static MacroSpec assign(RuleMacroName name, in FieldAssignment a0)
                => new MacroSpec(name, a0);

            [MethodImpl(Inline), Op]
            static MacroSpec assign(RuleMacroName name, FieldAssignment a0, FieldAssignment a1)
                => new MacroSpec(name, a0, a1);

            [MethodImpl(Inline), Op]
            static MacroSpec assign(RuleMacroName name, FieldAssignment a0, FieldAssignment a1, FieldAssignment a2)
                => new MacroSpec(name, a0, a1, a2);

            [MethodImpl(Inline), Op]
            static MacroSpec assign(RuleMacroName name, FieldAssignment a0, FieldAssignment a1, FieldAssignment a2, FieldAssignment a3)
                => new MacroSpec(name, a0, a1, a2, a3);

            [MethodImpl(Inline), Op]
            static MacroSpec assign(RuleMacroName name, FieldAssignment a0, FieldAssignment a1, FieldAssignment a2, FieldAssignment a3, FieldAssignment a4)
                => new MacroSpec(name, a0, a1, a2, a3);
        }
    }
}