//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed)]
        public enum DispKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("d/8")]
            d8 = 1,

            [Symbol("d/16")]
            d16 = 2,

            [Symbol("d/32")]
            d32 = 4,

            [Symbol("d/64")]
            d64 = 8,
        }
    }
}