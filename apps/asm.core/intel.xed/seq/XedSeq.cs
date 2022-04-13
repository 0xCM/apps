//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.SeqKind;

    using NT = XedModels.NontermKind;
    public unsafe partial class XedSeq
    {
        [MethodImpl(Inline), Op]
        public static SeqStep bind(SeqKind kind)
            => new SeqStep(kind,SeqEffect.BIND);

        [MethodImpl(Inline), Op]
        public static SeqStep bind(NontermKind kind)
            => new SeqStep(kind,SeqEffect.BIND);

        [MethodImpl(Inline), Op]
        public static SeqStep emit(SeqKind kind)
            => new SeqStep(kind,SeqEffect.EMIT);

        [MethodImpl(Inline), Op]
        public static SeqStep emit(NontermKind kind)
            => new SeqStep(kind,SeqEffect.EMIT);

        /*
        SEQUENCE ISA_BINDINGS
            FIXUP_EOSZ_ENC_BIND()   | FIXUP_EOSZ_ENC
            FIXUP_EASZ_ENC_BIND()   | FIXUP_EASZ_ENC
            ASZ_NONTERM_BIND()      | ASZ_NONTERM
            INSTRUCTIONS_BIND()     | *select encoding function*
            OSZ_NONTERM_ENC_BIND()  | OSZ_NONTERM_ENC
            PREFIX_ENC_BIND()       | PREFIX_ENC
            REX_PREFIX_ENC_BIND()   | REX_PREFIX_ENC

        */
        static SeqDef ISA_BINDINGS => new SeqStep[]{
                bind(NT.FIXUP_EOSZ_ENC),
                bind(NT.FIXUP_EASZ_ENC),
                bind(NT.ASZ_NONTERM),
                bind(INSTRUCTIONS),
                bind(NT.OSZ_NONTERM_ENC),
                bind(NT.PREFIX_ENC),
                bind(NT.VEXED_REX),
        };

        /*
        SEQUENCE ISA_EMIT
            PREFIX_ENC_EMIT()
            REX_PREFIX_ENC_EMIT() | VEXED_REX_EMIT()
            INSTRUCTIONS_EMIT()
        */
        static SeqDef ISA_EMIT => new SeqStep[]{
            emit(NT.PREFIX_ENC),
            emit(NT.VEXED_REX),
            emit(INSTRUCTIONS)
        };

        /*
        SEQUENCE ISA_ENCODE
            ISA_BINDINGS    | ISA_BINDINGS()
            ISA_EMIT        | ISA_EMIT
        */
        static SeqDef ISA_ENCODE
            => ISA_BINDINGS.Steps.Append(ISA_EMIT.Steps);

        /*
        SEQUENCE MODRM_BIND
            SIB_REQUIRED_ENCODE_BIND()
            SIBSCALE_ENCODE_BIND()
            SIBINDEX_ENCODE_BIND()
            SIBBASE_ENCODE_BIND()
            MODRM_RM_ENCODE_BIND()
            MODRM_MOD_ENCODE_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            SIB_NT_BIND()
            DISP_NT_BIND()
        */
        static SeqDef MODRM_BIND => new SeqStep[]{
            bind(NT.SIB_REQUIRED_ENCODE),
            bind(NT.SIBSCALE_ENCODE),
            bind(NT.SIBINDEX_ENCODE),
            bind(NT.SIBBASE_ENCODE),
            bind(NT.MODRM_RM_ENCODE),
            bind(NT.MODRM_MOD_ENCODE),
            bind(NT.SEGMENT_DEFAULT_ENCODE),
            bind(NT.SEGMENT_ENCODE),
            bind(NT.SIB_NT),
            bind(NT.DISP_NT)
        };

        /*
        SEQUENCE MODRM_EMIT
            SIB_NT_EMIT()
            DISP_NT_EMIT()
        */
        static SeqDef MODRM_EMIT => new SeqStep[]{
            emit(NT.SIB_NT),
            emit(NT.DISP_NT),
        };

        /*
        SEQUENCE NEWVEX3_ENC_BIND
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND

        */
        static SeqDef NEWVEX3_ENC_BIND => new SeqStep[]{
            bind(NT.VEX_TYPE_ENC),
            bind(NT.VEX_REXR_ENC),
            bind(NT.VEX_REXXB_ENC),
            bind(NT.VEX_MAP_ENC),
            bind(NT.VEX_REG_ENC),
            bind(NT.VEX_ESCVL_ENC),
        };

        public static Index<SeqDef> Defs()
            => new SeqDef[]{
                ISA_ENCODE,
                MODRM_BIND,
                MODRM_EMIT,
        };

        /*
        SEQUENCE XOP_ENC_BIND
            XOP_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            XOP_REXXB_ENC_BIND
            XOP_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND

        */

        /*
        SEQUENCE XOP_ENC_EMIT
            XOP_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            XOP_REXXB_ENC_EMIT
            XOP_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT

        */

        /*
        SEQUENCE NEWVEX_ENC_BIND
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND
        */

        /*
        SEQUENCE NEWVEX_ENC_EMIT
            VEX_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            VEX_REXXB_ENC_EMIT
            VEX_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT
        */

        /*
        SEQUENCE VMODRM_XMM_BIND
            VMODRM_MOD_ENCODE_BIND()
            VSIB_ENC_BASE_BIND()
            VSIB_ENC_INDEX_XMM_BIND()
            VSIB_ENC_SCALE_BIND()
            VSIB_ENC_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            DISP_NT_BIND()
        */

        /*
        SEQUENCE VMODRM_YMM_BIND
            VMODRM_MOD_ENCODE_BIND()
            VSIB_ENC_BASE_BIND()
            VSIB_ENC_INDEX_YMM_BIND()
            VSIB_ENC_SCALE_BIND()
            VSIB_ENC_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            DISP_NT_BIND()
        */

        /*
        SEQUENCE VMODRM_XMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */

        /*
        SEQUENCE VMODRM_YMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */

        /*
        SEQUENCE EVEX_ENC_BIND
            EVEX_62_REXR_ENC_BIND
            EVEX_REXX_ENC_BIND
            EVEX_REXB_ENC_BIND
            EVEX_REXRR_ENC_BIND
            EVEX_MAP_ENC_BIND
            EVEX_REXW_VVVV_ENC_BIND
            EVEX_UPP_ENC_BIND
            EVEX_LL_ENC_BIND
            AVX512_EVEX_BYTE3_ENC_BIND
        */

        /*
        SEQUENCE EVEX_ENC_EMIT
            EVEX_62_REXR_ENC_EMIT
            EVEX_REXX_ENC_EMIT
            EVEX_REXB_ENC_EMIT
            EVEX_REXRR_ENC_EMIT
            EVEX_MAP_ENC_EMIT
            EVEX_REXW_VVVV_ENC_EMIT
            EVEX_UPP_ENC_EMIT
            EVEX_LL_ENC_EMIT
            AVX512_EVEX_BYTE3_ENC_EMIT
        */

        /*
        SEQUENCE NEWVEX3_ENC_EMIT
            VEX_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            VEX_REXXB_ENC_EMIT
            VEX_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT
        */

        /*
        SEQUENCE UISA_VMODRM_ZMM_BIND
            VMODRM_MOD_ENCODE_BIND()
            VSIB_ENC_BASE_BIND()
            UISA_ENC_INDEX_ZMM_BIND()
            VSIB_ENC_SCALE_BIND()
            VSIB_ENC_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            DISP_NT_BIND()
        */

        /*
        SEQUENCE UISA_VMODRM_YMM_BIND
            VMODRM_MOD_ENCODE_BIND()  # FROM HSW
            VSIB_ENC_BASE_BIND()      # FROM HSW
            UISA_ENC_INDEX_YMM_BIND()
            VSIB_ENC_SCALE_BIND()   # FROM HSW
            VSIB_ENC_BIND()         # FROM HSW
            SEGMENT_DEFAULT_ENCODE_BIND() # FROM BASE ISA
            SEGMENT_ENCODE_BIND()         # FROM BASE ISA
            DISP_NT_BIND()          # FROM BASE ISA

        */

        /*
        SEQUENCE UISA_VMODRM_XMM_BIND
            VMODRM_MOD_ENCODE_BIND()
            VSIB_ENC_BASE_BIND()
            UISA_ENC_INDEX_XMM_BIND()
            VSIB_ENC_SCALE_BIND()
            VSIB_ENC_BIND()
            SEGMENT_DEFAULT_ENCODE_BIND()
            SEGMENT_ENCODE_BIND()
            DISP_NT_BIND()
        */

        /*
            SEQUENCE UISA_VMODRM_ZMM_EMIT
                VSIB_ENC_EMIT()
                DISP_NT_EMIT()
        */

        /*
        SEQUENCE VMODRM_YMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */

        /*
        SEQUENCE UISA_VMODRM_XMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */
    }
}