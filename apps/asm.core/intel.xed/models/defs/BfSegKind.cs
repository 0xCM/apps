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
            RexW = AsciCode.w,

            [Symbol("r", "REXR[r]")]
            RexR = AsciCode.r,

            [Symbol("x", "REXX[x]")]
            RexX = AsciCode.x,

            [Symbol("b", "REXB[b]")]
            RexB = AsciCode.b,

            [Symbol("dddd", "UIMM0[dddd]")]
            UIMM0,

            [Symbol("ssss", "ESRC[ssss]")]
            ESRC,

            [Symbol("ss", "SIBSCALE[ss]")]
            SibScale,

            [Symbol("bbb","SIBBASE[bbb]")]
            SibBase,

            [Symbol("iii", "SIBINDEX[iii]")]
            SibIndex
        }
    }
}