//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state), DataWidth(1)]
        public enum Mode64WidthDefault : byte
        {
            [Symbol("nrmw", "DF64=0")]
            NRMW = 0,

            [Symbol("df64", "DF64=1")]
            DF64 = 1,
        }
    }
}