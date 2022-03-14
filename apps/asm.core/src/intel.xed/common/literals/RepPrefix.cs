//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state)]
        public enum RepPrefix : byte
        {
            None = 0,

            [Symbol("F2", "f2_prefix:{REPNZ,REPNE}")]
            REPF2 = 2,

            [Symbol("F3", "f3_prefix:{REPZ,REPE}")]
            REPF3 = 3,

            [Symbol("REP!=3")]
            NOF3 = 4,
        }
    }
}