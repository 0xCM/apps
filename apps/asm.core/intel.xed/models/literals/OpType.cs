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
        public enum OpType : byte
        {
            [Symbol("")]
            INVALID,

            [Symbol("error")]
            ERROR,

            [Symbol("imm")]
            IMM,

            [Symbol("kimm")]
            IMM_CONST,

            [Symbol("lu1")]
            NT_LOOKUP_FN,

            [Symbol("lu2")]
            NT_LOOKUP_FN2,

            [Symbol("lu4")]
            NT_LOOKUP_FN4,

            [Symbol("reg")]
            REG,
        }
    }
}