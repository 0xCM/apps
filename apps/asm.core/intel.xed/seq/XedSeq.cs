//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.SeqEffect;
    using static XedRules;

    using NT = XedRules.RuleName;

    public unsafe partial class XedSeq
    {
        [MethodImpl(Inline), Op]
        public static SeqStep bind(RuleName kind)
            => new SeqStep(kind,SeqEffect.BIND);

        [MethodImpl(Inline), Op]
        public static SeqStep emit(RuleName kind)
            => new SeqStep(kind,SeqEffect.EMIT);

        [MethodImpl(Inline), Op]
        public static SeqDef def(SeqStep[] steps)
            => new SeqDef(steps);

/* DISP_NT()::
	DISP_WIDTH=8 DISP[dddddddd]=*  ->	emit dddddddd emit_type=letters nbits=8
	DISP_WIDTH=16 DISP[dddddddddddddddd]=*  ->	emit dddddddddddddddd emit_type=letters nbits=16
	DISP_WIDTH=32 DISP[dddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddd emit_type=letters nbits=32
	DISP_WIDTH=64 DISP[dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd emit_type=letters nbits=64
 */

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
        static SeqDef ISA_BINDINGS => def(new SeqStep[]{
                bind(NT.FIXUP_EOSZ_ENC),
                bind(NT.FIXUP_EASZ_ENC),
                bind(NT.ASZ_NONTERM),
                bind(NT.INSTRUCTIONS),
                bind(NT.OSZ_NONTERM_ENC),
                bind(NT.PREFIX_ENC),
                bind(NT.VEXED_REX),
        }).WithType(NT.ISA, BIND);

        /*
        SEQUENCE ISA_EMIT
            PREFIX_ENC_EMIT()
            REX_PREFIX_ENC_EMIT() | VEXED_REX_EMIT()
            INSTRUCTIONS_EMIT()
        */
        static SeqDef ISA_EMIT => def(new SeqStep[]{
            emit(NT.PREFIX_ENC),
            emit(NT.VEXED_REX),
            emit(NT.INSTRUCTIONS)
        }).WithType(NT.ISA, EMIT);

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
        static SeqDef MODRM_BIND => def(new SeqStep[]{
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
        }).WithType(NT.MODRM,BIND);

        /*
        SEQUENCE MODRM_EMIT
            SIB_NT_EMIT()
            DISP_NT_EMIT()
        */
        static SeqDef MODRM_EMIT => def(new SeqStep[]{
            emit(NT.SIB_NT),
            emit(NT.DISP_NT),
        }).WithType(NT.MODRM, EMIT);

        /*
        SEQUENCE NEWVEX_ENC_BIND
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND
        */

        static SeqDef NEWVEX_ENC_BIND => def(new SeqStep[]{
            bind(NT.VEX_TYPE_ENC),
            bind(NT.VEX_REXR_ENC),
            bind(NT.VEX_REXXB_ENC),
            bind(NT.VEX_MAP_ENC),
            bind(NT.VEX_REG_ENC),
            bind(NT.VEX_ESCVL_ENC),
        }).WithType(NT.NEWVEX_ENC, BIND);

        /*
        SEQUENCE NEWVEX_ENC_EMIT
            VEX_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            VEX_REXXB_ENC_EMIT
            VEX_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT
        */
        static SeqDef NEWVEX_ENC_EMIT => def(new SeqStep[]{
            bind(NT.VEX_TYPE_ENC),
            bind(NT.VEX_REXR_ENC),
            bind(NT.VEX_REXXB_ENC),
            bind(NT.VEX_MAP_ENC),
            bind(NT.VEX_REG_ENC),
            bind(NT.VEX_ESCVL_ENC),
        }).WithType(NT.NEWVEX_ENC, EMIT);

        public static Index<SeqDef> Defs()
            => new SeqDef[]{
                ISA_ENCODE,
                MODRM_BIND,
                MODRM_EMIT,
                NEWVEX_ENC_EMIT,
                NEWVEX_ENC_BIND,
        };

        // xed_uint_t xed_encode_nonterminal_VEXED_REX_EMIT(xed_encoder_request_t* xes)
        // {
        // /* VEXED_REX()::
        // 	VEXVALID=3  ->	nt NT[XOP_ENC]
        // 	VEXVALID=0  ->	nt NT[REX_PREFIX_ENC]
        // 	VEXVALID=1  ->	nt NT[NEWVEX_ENC]
        // 	VEXVALID=2  ->	nt NT[EVEX_ENC]
        //  */
        // xed_uint_t okay=1;
        // unsigned int iform = xed_encoder_request_iforms(xes)->x_VEXED_REX;
        // /* 4 */ if (iform==4) {
        //     xed_encode_nonterminal_XOP_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // /* 1 */ if (iform==1) {
        //     xed_encode_nonterminal_REX_PREFIX_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // /* 2 */ if (iform==2) {
        //     xed_encode_nonterminal_NEWVEX_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // /* 3 */ if (iform==3) {
        //     xed_encode_nonterminal_EVEX_ENC_EMIT(xes);
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // if (1) { /*otherwise*/
        //     if (xed3_operand_get_error(xes) != XED_ERROR_NONE) okay=0;
        //     return okay;
        // }
        // return 0; /*pacify the compiler*/
        // (void) okay;
        // (void) xes;
        // (void) iform;
        /*

        SEQUENCE NEWVEX3_ENC_BIND unused?
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND

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
    }
}