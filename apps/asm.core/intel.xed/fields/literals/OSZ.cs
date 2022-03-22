//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedFields
    {
        [SymSource(xed), DataWidth(2)]
        public enum OSZ : byte
        {
            [Symbol("")]
            None,

            [Symbol("1")]
            True,

            [Symbol("0")]
            False,
        }
    }
}