//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum BfSegKind : byte
        {
            [Symbol("w", "REXW[w]")]
            REXW,

            [Symbol("r", "REXR[r]")]
            REXR,

            [Symbol("x", "REXX[x]")]
            REXX,

            [Symbol("b", "REXB[b]")]
            REXB,

            [Symbol("dddd", "UIMM0[dddd]")]
            UIMM0,

            [Symbol("ssss", "ESRC[ssss]")]
            ESRC,

            [Symbol("ss", "SIBSCALE[ss]")]
            SIBSCALE,

            [Symbol("bbb","SIBBASE[bbb]")]
            SIBBASE,

            [Symbol("iii", "SIBINDEX[iii]")]
            SIBINDEX,

            [Symbol("z", "ZEROING[z]")]
            ZEROING,

            [Symbol("nn", "LLRC[nn]")]
            LLRC,

            [Symbol("b", "BCRC[b]")]
            BCRC,

            [Symbol("aaa", "MASK[aaa]")]
            MASK,

            [Symbol("u", "VEXDEST3[u]")]
            VEXDEST3,

            [Symbol("ddd", "VEXDEST210[ddd]")]
            VEXDEST210,
        }
    }
}