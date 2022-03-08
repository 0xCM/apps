//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum OpVisiblity : byte
        {
            None = 0,

            [Symbol("SUPP")]
            Suppressed,

            [Symbol("IMPL")]
            Implicit,
        }
    }
}