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
        public enum LockIndicator : sbyte
        {
            [Symbol("")]
            None = -1,

            [Symbol("0")]
            Off = 0,

            [Symbol("0")]
            On = 1
        }
    }
}
