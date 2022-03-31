//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum RuleCellKind : ushort
        {
            None,

            Literal = 1,

            Nonterminal = 2,

            Assignment = 4,

            CmpEq = 8,

            CmpNeq = 16,

            BfSeg = 32,

            Bits = 64,

            Int = 128,

            Hex = 256,

            FieldValue = 512,
        }
    }
}