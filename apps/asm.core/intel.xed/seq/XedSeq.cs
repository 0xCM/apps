//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{

    using static XedSeq.SeqEffect;
    using static XedSeq.SeqKind;
    using static XedSeq.SeqStepKind;

    public unsafe partial class XedSeq
    {
        [MethodImpl(Inline), Op]
        public static SeqType type(SeqKind kind, SeqEffect effect)
            => new(kind,effect);

        [MethodImpl(Inline), Op]
        public static SeqStep step(SeqStepKind kind, byte index, SeqEffect effect)
            => new(kind,index,effect);

        [MethodImpl(Inline), Op]
        public static SeqDef def(SeqType type, params SeqStep[] steps)
            => new SeqDef(type, steps);

        public static SeqDef[] Defs()
            => new SeqDef[]{
                def(type(MODRM,Bind),
                    new SeqStep[]{
                        step(SIB_REQUIRED_ENCODE,0,Bind),
                        step(SIBSCALE_ENCODE,1,Bind),
                        step(SIBINDEX_ENCODE,2,Bind),
                        step(SIBBASE_ENCODE,3,Bind),
                        step(MODRM_RM_ENCODE,4,Bind),
                        step(MODRM_MOD_ENCODE,5,Bind),
                        step(SEGMENT_DEFAULT_ENCODE,6,Bind),
                        step(SEGMENT_ENCODE,7,Bind),
                        step(SIB_NT,8,Bind),
                        step(DISP_NT,9,Bind)
                        }
                    ),

                def(type(MODRM,Emit),new SeqStep[]{
                    step(SIB_NT,0,Emit),
                    step(DISP_NT,1,Emit)

                }),

                def(type(ISA,Bind),new SeqStep[]{

                }),
                def(type(ISA,Emit),new SeqStep[]{

                }),

                def(type(XOP,Bind),new SeqStep[]{

                }),
                def(type(XOP,Emit),new SeqStep[]{

                }),

                def(type(NEWVEX,Bind),new SeqStep[]{

                }),
                def(type(NEWVEX,Emit),new SeqStep[]{

                }),

                def(type(VMODRM_XMM,Bind),new SeqStep[]{

                }),
                def(type(VMODRM_XMM,Emit),new SeqStep[]{

                }),


                def(type(VMODRM_YMM,Bind),new SeqStep[]{

                }),
                def(type(VMODRM_YMM,Emit),new SeqStep[]{

                }),


                def(type(EVEX,Bind),new SeqStep[]{

                }),
                def(type(EVEX,Emit),new SeqStep[]{

                }),

                def(type(NEWVEX3,Bind),new SeqStep[]{

                }),
                def(type(NEWVEX3,Emit),new SeqStep[]{

                }),

                def(type(UISA_VMODRM_XMM,Bind),new SeqStep[]{

                }),
                def(type(UISA_VMODRM_XMM,Emit),new SeqStep[]{

                }),


                def(type(UISA_VMODRM_YMM,Bind),new SeqStep[]{

                }),
                def(type(UISA_VMODRM_YMM,Emit),new SeqStep[]{

                }),


                def(type(UISA_VMODRM_ZMM,Bind),new SeqStep[]{

                }),
                def(type(UISA_VMODRM_ZMM,Emit),new SeqStep[]{

                }),
        };

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
        public static bit xed_encode_nonterminal_MODRM_BIND(ulong* pEncReq)
        {
            bit okay = 0;
            // okay = xed_encode_nonterminal_SIB_REQUIRED_ENCODE_BIND(pEncReq);    => SIB_REQUIRED_ENCODE()
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SIBSCALE_ENCODE_BIND(pEncReq); => SIBSCALE_ENCODE()
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SIBINDEX_ENCODE_BIND(pEncReq); => SIBINDEX_ENCODE()
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SIBBASE_ENCODE_BIND(pEncReq); => SIBBASE_ENCODE()
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_MODRM_RM_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_MODRM_MOD_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SIB_NT_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_BIND(pEncReq);
            // if (!okay) return 0;
            return okay;
        }

        /*
        SEQUENCE MODRM_EMIT
            SIB_NT_EMIT()
            DISP_NT_EMIT()
        */
        public static bit xed_encode_nonterminal_MODRM_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_SIB_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE ISA_ENCODE
            ISA_BINDINGS
            ISA_EMIT
        */
        public static bit xed_encode_nonterminal_ISA_ENCODE(ulong* pEncReq)
        {
            bit okay = 0;
            okay = xed_encode_nonterminal_ISA_BINDINGS(pEncReq);
            if (!okay) return 0;
            okay = xed_encode_nonterminal_ISA_EMIT(pEncReq);
            if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE ISA_BINDINGS
            FIXUP_EOSZ_ENC_BIND()
            FIXUP_EASZ_ENC_BIND()
            ASZ_NONTERM_BIND()
            INSTRUCTIONS_BIND()
            OSZ_NONTERM_ENC_BIND()
            PREFIX_ENC_BIND()
            REX_PREFIX_ENC_BIND()

        */
        public static bit xed_encode_nonterminal_ISA_BINDINGS(ulong* pEncReq)
        {
            bit okay = 0;
            // okay = xed_encode_nonterminal_FIXUP_EOSZ_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_FIXUP_EASZ_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_ASZ_NONTERM_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_INSTRUCTIONS_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_OSZ_NONTERM_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_PREFIX_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEXED_REX_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE ISA_EMIT
            PREFIX_ENC_EMIT()
            REX_PREFIX_ENC_EMIT()
            INSTRUCTIONS_EMIT()
        */
        public static bit xed_encode_nonterminal_ISA_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_PREFIX_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEXED_REX_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_INSTRUCTIONS_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE XOP_ENC_BIND
            XOP_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            XOP_REXXB_ENC_BIND
            XOP_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND

        */
        public static bit xed_encode_nonterminal_XOP_ENC_BIND(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_XOP_TYPE_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXR_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_XOP_REXXB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_XOP_MAP_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REG_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_ESCVL_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE XOP_ENC_EMIT
            XOP_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            XOP_REXXB_ENC_EMIT
            XOP_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT

        */
        public static bit xed_encode_nonterminal_XOP_ENC_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_XOP_TYPE_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXR_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_XOP_REXXB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_XOP_MAP_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REG_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_ESCVL_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE NEWVEX_ENC_BIND
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND
        */
        public static bit xed_encode_nonterminal_NEWVEX_ENC_BIND(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_VEX_TYPE_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXR_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXXB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_MAP_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REG_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_ESCVL_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE NEWVEX_ENC_EMIT
            VEX_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            VEX_REXXB_ENC_EMIT
            VEX_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT
        */
        public static bit xed_encode_nonterminal_NEWVEX_ENC_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_VEX_TYPE_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXR_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXXB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_MAP_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REG_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_ESCVL_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

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
        public static bit xed_encode_nonterminal_VMODRM_XMM_BIND(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_VMODRM_MOD_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BASE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_INDEX_XMM_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_SCALE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

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
        public static bit xed_encode_nonterminal_VMODRM_YMM_BIND(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VMODRM_MOD_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BASE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_INDEX_YMM_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_SCALE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE VMODRM_XMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */
        public static bit xed_encode_nonterminal_VMODRM_XMM_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE VMODRM_YMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */
        public static bit xed_encode_nonterminal_VMODRM_YMM_EMIT(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VSIB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

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
        public static bit xed_encode_nonterminal_EVEX_ENC_BIND(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_EVEX_62_REXR_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXX_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXRR_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_MAP_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXW_VVVV_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_UPP_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_LL_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_AVX512_EVEX_BYTE3_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

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
        public static bit xed_encode_nonterminal_EVEX_ENC_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_EVEX_62_REXR_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXX_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXRR_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_MAP_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_REXW_VVVV_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_UPP_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_EVEX_LL_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_AVX512_EVEX_BYTE3_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE NEWVEX3_ENC_BIND
            VEX_TYPE_ENC_BIND
            VEX_REXR_ENC_BIND
            VEX_REXXB_ENC_BIND
            VEX_MAP_ENC_BIND
            VEX_REG_ENC_BIND
            VEX_ESCVL_ENC_BIND

            enum SeqKind
            {
                Bind=1,
                Emit=2,
            }
            struct NEWVEX3_ENC
            {
                VEX_TYPE_ENC;
                VEX_REXR_ENC;
                VEX_REXXB_ENC;
                VEX_MAP_ENC;
                VEX_REG_ENC;
                VEX_ESCVL_ENC;

            }
        */
        public static bit xed_encode_nonterminal_NEWVEX3_ENC_BIND(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VEX_TYPE_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXR_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXXB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_MAP_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REG_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_ESCVL_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE NEWVEX3_ENC_EMIT
            VEX_TYPE_ENC_EMIT
            VEX_REXR_ENC_EMIT
            VEX_REXXB_ENC_EMIT
            VEX_MAP_ENC_EMIT
            VEX_REG_ENC_EMIT
            VEX_ESCVL_ENC_EMIT
        */
        public static bit xed_encode_nonterminal_NEWVEX3_ENC_EMIT(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_VEX_TYPE_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXR_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REXXB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_MAP_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_REG_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VEX_ESCVL_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

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

        public static bit xed_encode_nonterminal_UISA_VMODRM_ZMM_BIND(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VMODRM_MOD_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BASE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_UISA_ENC_INDEX_ZMM_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_SCALE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        public static bit xed_encode_nonterminal_UISA_VMODRM_YMM_BIND(ulong* pEncReq)
        {
            // bit okay = 0;
            // okay = xed_encode_nonterminal_VMODRM_MOD_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BASE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_UISA_ENC_INDEX_YMM_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_SCALE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

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
        public static bit xed_encode_nonterminal_UISA_VMODRM_XMM_BIND(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VMODRM_MOD_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BASE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_UISA_ENC_INDEX_XMM_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_SCALE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_VSIB_ENC_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_SEGMENT_ENCODE_BIND(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_BIND(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
            SEQUENCE UISA_VMODRM_ZMM_EMIT
                VSIB_ENC_EMIT()
                DISP_NT_EMIT()
        */
        public static bit xed_encode_nonterminal_UISA_VMODRM_ZMM_EMIT(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VSIB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE VMODRM_YMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */
        public static bit xed_encode_nonterminal_UISA_VMODRM_YMM_EMIT(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VSIB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        /*
        SEQUENCE UISA_VMODRM_XMM_EMIT
            VSIB_ENC_EMIT()
            DISP_NT_EMIT()
        */
        public static bit xed_encode_nonterminal_UISA_VMODRM_XMM_EMIT(ulong* pEncReq)
        {
            // bit okay;
            // okay = xed_encode_nonterminal_VSIB_ENC_EMIT(pEncReq);
            // if (!okay) return 0;
            // okay = xed_encode_nonterminal_DISP_NT_EMIT(pEncReq);
            // if (!okay) return 0;
            return 1;
        }

        public static uint xed_encode_nonterminal_SEGMENT_DEFAULT_ENCODE_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            // key = xed_enc_lu_BASE0_EASZ(pEncReq);
            return 0;
        }

        public static uint xed_encode_nonterminal_SEGMENT_ENCODE_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            // key = xed_enc_lu_DEFAULT_SEG_SEG0(pEncReq);
            return 0;
        }

        public static uint xed_encode_nonterminal_SIBBASE_ENCODE_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            ulong res = 1;
            // key = xed_enc_lu_NEED_SIB(pEncReq);
            return 0;
        }

        public static uint xed_encode_nonterminal_SIBBASE_ENCODE_SIB1_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            ulong res = 1;
            // key = xed_enc_lu_BASE0_EASZ(pEncReq);
            return 0;
        }

        public static uint xed_encode_nonterminal_SIBINDEX_ENCODE_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            ulong res = 1;
            // key = xed_enc_lu_NEED_SIB(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_SIBINDEX_ENCODE_SIB1_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            // key = xed_enc_lu_EASZ_INDEX(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_SIBSCALE_ENCODE_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            // key = xed_enc_lu_NEED_SIB_SCALE(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_MODRM_MOD_ENCODE_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            ulong res = 1;
            //key = xed_enc_lu_DISP_WIDTH_EASZ(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_MODRM_MOD_EA16_DISP0_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            //key = xed_enc_lu_BASE0_INDEX(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_MODRM_MOD_EA16_DISP8_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            //key = xed_enc_lu_BASE0_INDEX(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_MODRM_MOD_EA16_DISP16_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            //key = xed_enc_lu_BASE0_INDEX(pEncReq);
            return 1;
        }

        public static uint xed_encode_nonterminal_MODRM_MOD_EA32_DISP0_BIND(ulong* pEncReq)
        {
            ulong key = 0;
            ulong hidx = 0;
            //key = xed_enc_lu_BASE0_MODE(pEncReq);
            return 1;
        }
    }
}
