//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(1)]
        public enum BCRC : byte
        {
            [Symbol("BCRC0", "BCRC=0")]
            BCRC0 = 0,

            [Symbol("BCRC1", "BCRC=1")]
            BCRC1 = 1
        }
    }
}
