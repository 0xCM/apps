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

            FieldLiteral =1,

            Nonterminal = 2,

            Eq = 8,

            Neq = 16,

            BfSeg = 32,

            BfSpec = 64,

            Bits = 128,

            Int = 256,

            Hex = 512,
        }
    }
}