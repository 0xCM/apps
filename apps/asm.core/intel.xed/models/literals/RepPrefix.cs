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
        public enum RepPrefix : byte
        {
            None = 0,

            [Symbol("F2", "REP=2:{REPNZ,REPNE}")]
            REPF2 = 2,

            [Symbol("F3", "REP=3:{REPZ,REPE}")]
            REPF3 = 3,

            [Symbol("REP!=3", "REP!=3")]
            NOF3 = 4,
        }
    }
}