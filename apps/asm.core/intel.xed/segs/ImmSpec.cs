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
        public enum ImmSpec : byte
        {
            [Symbol("")]
            None,

            [Symbol("i/8")]
            i8 = 1,

            [Symbol("i/16")]
            i16 = 2,

            [Symbol("i/32")]
            i32 = 4,

            [Symbol("i/64")]
            i64 = 8,
        }
    }
}