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
        public enum RuleCellKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("neq(x)")]
            FieldNeq,

            [Symbol("eq(x)")]
            FieldEq,

            [Symbol("nt")]
            Nonterminal,

            [Symbol("nt(x)")]
            NontermExpr,

            [Symbol("bfseg(x)")]
            BfSegExpr,

            [Symbol("bfseg")]
            BfSeg,

            [Symbol("bfspec")]
            BfSpec,

            [Symbol("branch")]
            Branch,

            [Symbol("null")]
            Null,

            [Symbol("error")]
            Error,

            [Symbol("keyword")]
            Keyword,

            [Symbol("op")]
            Operator,
        }
   }
}