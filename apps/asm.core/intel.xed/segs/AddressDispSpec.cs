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
        public enum AddressDispSpec
        {
            [Symbol("")]
            None,

            [Symbol("a/8")]
            a8 = 1,

            [Symbol("a/16")]
            a16 = 2,

            [Symbol("a/32")]
            a32 = 4,

            [Symbol("a/64")]
            a64 = 8,
        }
    }
}