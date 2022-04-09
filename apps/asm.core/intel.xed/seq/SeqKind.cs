//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedSeq
    {
        public enum SeqKind : byte
        {
            None,

            MODRM,

            ISA,

            XOP,

            NEWVEX,

            VMODRM_XMM,

            VMODRM_YMM,

            EVEX,

            NEWVEX3,

            UISA_VMODRM_XMM,

            UISA_VMODRM_YMM,

            UISA_VMODRM_ZMM,
        }
    }
}