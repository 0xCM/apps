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
            [Symbol("<untyped>")]
            None = 0,

            [Symbol("Lit(0b)")]
            BitLiteral,

            [Symbol("Lit(0i)")]
            IntLiteral,

            [Symbol("Lit(0x)")]
            HexLiteral,

            [Symbol("SegVar")]
            SegVar,

            [Symbol("Keyword")]
            Keyword,

            [Symbol("Nt()")]
            NontermCall,

            [Symbol("Op()")]
            Operator,

            [Symbol("SegField")]
            SegField,

            [Symbol("Neq(x)")]
            NeqExpr,

            [Symbol("Eq(x)")]
            EqExpr,

            [Symbol("Nt(x)")]
            NontermExpr,
        }
   }
}