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

            Constraint = 8,

            BfSeg = 16,

            Bits = 32,

            Int = 64,

            Hex = 128,

            Name = 256,
        }
    }
}