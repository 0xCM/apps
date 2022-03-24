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
        public enum ZEROING : byte
        {
            [Symbol("")]
            Disabled = 0,

            [Symbol("{z}")]
            Enabled = 1,
        }
    }
}
