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

            Value = P2ᐞ18,

            Literal = P2ᐞ00 | Value,

            BinaryLiteral = P2ᐞ01 | Literal,

            IntLiteral = P2ᐞ02 | Literal,

            HexLiteral = P2ᐞ03 | Literal,

            Char = P2ᐞ04 | Literal,

            String = P2ᐞ05 | Literal,

            Number = P2ᐞ06 | BinaryLiteral | IntLiteral | HexLiteral,

            Text = P2ᐞ07 | Char | String,

            Keyword = P2ᐞ15 | Text,

            SegSpec = P2ᐞ14 | Text,

            Nonterm = P2ᐞ09,

            Seg = P2ᐞ12,

            Operator = P2ᐞ16,

            Expr = P2ᐞ08,

            NeqExpr = P2ᐞ19 | Expr,

            EqExpr =  P2ᐞ20 | Expr,

            SegExpr = P2ᐞ13 | Seg | Expr,

            NontermExpr = P2ᐞ10 | Nonterm | EqExpr,
        }
   }
}