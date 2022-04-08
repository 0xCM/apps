//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2x32;

    partial class XedRules
    {
        [Flags]
        public enum RuleCellKind : uint
        {
            None = 0,

            Value = P2ᐞ00,

            Literal = P2ᐞ01 | Value,

            BinaryLiteral = P2ᐞ02 | Literal,

            IntLiteral = P2ᐞ03 | Literal,

            HexLiteral = P2ᐞ04 | Literal,

            Char = P2ᐞ05 | Literal,

            String = P2ᐞ06 | Literal,

            Number = P2ᐞ07 | BinaryLiteral | IntLiteral | HexLiteral,

            Text = P2ᐞ08 | Char | String,

            Keyword = P2ᐞ09,

            SegSpec = P2ᐞ10,

            Nonterm = P2ᐞ11,

            Seg = P2ᐞ12,

            Operator = P2ᐞ13,

            Expr = P2ᐞ14,

            NeqExpr = P2ᐞ15 | Expr,

            EqExpr =  P2ᐞ16 | Expr,

            NontermExpr = P2ᐞ18 | Nonterm | EqExpr,

            SegLiteral = P2ᐞ19 | Seg | BinaryLiteral,

            SegVar = P2ᐞ20 | Seg
        }
   }
}