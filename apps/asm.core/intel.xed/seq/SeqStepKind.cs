//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedSeq
    {
        public enum SeqStepKind : byte
        {
            None,

            SIB_REQUIRED_ENCODE,

            SIBSCALE_ENCODE,

            SIBINDEX_ENCODE,

            SIBBASE_ENCODE,

            MODRM_RM_ENCODE,

            MODRM_MOD_ENCODE,

            SEGMENT_DEFAULT_ENCODE,

            SEGMENT_ENCODE,

            SIB_NT,

            DISP_NT,


            FIXUP_EOSZ_ENC,

            FIXUP_EASZ_ENC,

            ASZ_NONTERM,

            INSTRUCTIONS,

            OSZ_NONTERM_ENC,

            PREFIX_ENC,

            REX_PREFIX_ENC,

        }
    }
}