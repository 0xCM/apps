//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(4,8)]
        public enum RuleCellKind : byte
        {
            None = 0,

            BitLiteral,

            IntLiteral,

            HexLiteral,

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