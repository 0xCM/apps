//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedRules.RuleName;

    public unsafe partial class XedSeq
    {
        [MethodImpl(Inline), Op]
        public static SeqDef bind(RuleName[] rules)
            => new SeqDef(SeqEffect.BIND, rules);

        [MethodImpl(Inline), Op]
        public static SeqDef bind(asci32 name, RuleName[] rules)
            => new SeqDef(SeqEffect.BIND, rules);

        [MethodImpl(Inline), Op]
        public static SeqDef emit(RuleName[] rules)
            => new SeqDef(SeqEffect.EMIT, rules);

        [MethodImpl(Inline), Op]
        public static SeqDef emit(asci32 name, RuleName[] rules)
            => new SeqDef(name, SeqEffect.EMIT, rules);


        /*
        SEQUENCE ISA_ENCODE
            ISA_BINDINGS    | ISA_BINDINGS()
            ISA_EMIT        | ISA_EMIT
        */

        public static SeqDef VMODRM_XMM_EMIT() => emit(nameof(VMODRM_XMM_EMIT), new RuleName[]{
            VSIB_ENC,
            DISP_NT,
            });

        public static SeqDef VMODRM_YMM_EMIT() => emit(nameof(VMODRM_YMM_EMIT), new RuleName[]{
            VSIB_ENC,
            DISP_NT,
            });

        public static SeqDef UISA_VMODRM_XMM_EMIT() => emit(nameof(UISA_VMODRM_XMM_EMIT), new RuleName[]{
            VSIB_ENC,
            DISP_NT,
            });

        public static SeqDef UISA_VMODRM_ZMM_EMIT() => emit(nameof(UISA_VMODRM_ZMM_EMIT), new RuleName[]{
                VSIB_ENC,
                DISP_NT,
            });

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

        public static SeqDef UISA_VMODRM_XMM_BIND() => bind(nameof(UISA_VMODRM_XMM_BIND), new RuleName[]{
            VMODRM_MOD_ENCODE,
            VSIB_ENC_BASE,
            //UISA_ENC_INDEX_XMM,
            VSIB_ENC_SCALE,
            VSIB_ENC,
            SEGMENT_DEFAULT_ENCODE,
            SEGMENT_ENCODE,
            DISP_NT,
            });

        // public static SeqDef VMODRM_YMM_EMIT() => emit(nameof(VMODRM_YMM_EMIT), new RuleName[]{
        //     VSIB_ENC,
        //     DISP_NT,
        //     });


        // public static SeqDef VMODRM_XMM_EMIT() => emit(nameof(VMODRM_XMM_EMIT), new RuleName[]{
        //     VSIB_ENC,
        //     DISP_NT,
        //     });

        // public static SeqDef VMODRM_YMM_EMIT() => emit(nameof(VMODRM_YMM_EMIT), new RuleName[]{
        //     VSIB_ENC,
        //     DISP_NT,
        //     });

        /*




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


/* DISP_NT()::
	DISP_WIDTH=8 DISP[dddddddd]=*  ->	emit dddddddd emit_type=letters nbits=8
	DISP_WIDTH=16 DISP[dddddddddddddddd]=*  ->	emit dddddddddddddddd emit_type=letters nbits=16
	DISP_WIDTH=32 DISP[dddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddd emit_type=letters nbits=32
	DISP_WIDTH=64 DISP[dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd emit_type=letters nbits=64
 */


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
    }
}