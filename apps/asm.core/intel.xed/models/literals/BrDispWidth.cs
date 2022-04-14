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
        public enum BranchDispWidth : byte
        {
            None = 0,

            [Symbol("w8")]
            W8 = 8,

            [Symbol("w16")]
            W16 = 16,

            [Symbol("w32")]
            W32 = 32,
        }
    }
}