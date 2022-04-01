//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum CellDataKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("literal")]
            Literal,

            [Symbol("bfseg")]
            BfSeg,

            [Symbol("bfspec")]
            BfSpec,

            [Symbol("nt")]
            Nonterminal,

            [Symbol("fx")]
            FieldExpr,
        }
    }
}