//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Flags]
        public enum InstFieldClass : byte
        {
            None,

            Literal = 1,

            Nonterm = 2,

            SegField = 4,

            SegVar = 8,
        }
    }
}