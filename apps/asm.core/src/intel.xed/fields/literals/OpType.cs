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
            INVALID,

            ERROR,

            IMM,

            IMM_CONST,

            NT_LOOKUP_FN,

            NT_LOOKUP_FN2,

            NT_LOOKUP_FN4,

            REG,
        }
    }
}