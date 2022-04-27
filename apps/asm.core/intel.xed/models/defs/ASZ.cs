//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(2,8)]
        public enum ASZ : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("a16")]
            a16 = NativeSizeCode.W16,

            [Symbol("a32")]
            a32 = NativeSizeCode.W32,

            [Symbol("a64")]
            a64 = NativeSizeCode.W64,
        }
    }
}