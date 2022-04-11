//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum RuleCellKind : byte
        {
            None = 0,

            BinaryLiteral,

            IntLiteral,

            HexLiteral,

            Char,

            String,

            Keyword,

            Nonterm,

            Operator,

            SegField,

            NeqExpr,

            EqExpr,

            NontermExpr,
        }
   }
}